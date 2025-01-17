using Microsoft.VisualBasic.Logging;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using wypozyczalniaSamochodowa.Models;
namespace wypozyczalniaSamochodowa

{
    public partial class Form1 : Form
    {
        Button[] Buttons = new Button[3];
        DbConnection Database;
        User? CurrentlyLoggedUser;

        Control[] LogInStuff = new Control[3];

        Control[] LogOutStuff = new Control[2];

        public Form1()
        {
            InitializeComponent();
            Database = new DbConnection();
            for (int i = 0; i < 3; i++)
            {
                string s = "button" + (i + 1);
                Buttons[i] = this.Controls.Find(s, true).FirstOrDefault() as Button;
            }
            LogInStuff[0] = label2;
            LogOutStuff[0] = label3;
            LogOutStuff[1] = button4;
            GenLogInOptions();
            Refresh();

        }

        void LogOut(object sender, EventArgs e)
        {
            CurrentlyLoggedUser = null;
            Refresh();
        }
        void ShowLogInOptions()
        {
            foreach (var c in LogInStuff)
            {
                c.Visible = true;
                c.Enabled = true;
            }
            foreach(var c in LogOutStuff)
            {
                c.Visible = false;
                c.Enabled = false;
            }
        }

        void HideLogInOptions()
        {
            foreach (var c in LogInStuff)
            {
                c.Visible = false;
                c.Enabled = false;
            }
            foreach (var c in LogOutStuff)
            {
                c.Visible = true;
                c.Enabled = true;
            }
        }

        void Refresh()
        {

            if (CurrentlyLoggedUser != null)
            {
                HideLogInOptions();
                label3.Text = $"Zalogowano jako : {CurrentlyLoggedUser.login}";
                var cars = Database.GetAllCars();
                for (int i = 0; i < 3; i++)
                {
                    if (cars[i].isAvaliable)
                    {
                        Buttons[i].Enabled = true;
                        Buttons[i].Text = "Wynajmij";
                    }
                    else
                    {
                        if (cars[i].rentedBy == CurrentlyLoggedUser.login)
                        {
                            Buttons[i].Enabled = true;
                            Buttons[i].Text = "Oddaj";
                        }
                        else
                        {
                            Buttons[i].Text = "Niedostepny";
                            Buttons[i].Enabled = false;
                        }
                    }
                }

            }
            else
            {
                ShowLogInOptions();
                foreach (var item in Buttons)
                {
                    item.Enabled = false;
                    item.Text = "Wynajmij";
                }
            }
        }

        public void Button1(object sender, EventArgs e)
        {
            Rezerwuj(0);
        }
        public void Button2(object sender, EventArgs e)
        {
            Rezerwuj(1);
        }
        public void Button3(object sender, EventArgs e)
        {
            Rezerwuj(2);
        }

        public void Rezerwuj(int index)
        {
            if (CurrentlyLoggedUser == null)
            {
                Refresh();
                return;
            }
            var cars = Database.GetAllCars();
            if (CurrentlyLoggedUser.login == cars[index].rentedBy)
            {
                 Database.UpdateCar(new Car
                {
                    id = index,
                    isAvaliable = true,
                });
               
            }
            else
            {
                bool wasSuccess = Database.UpdateCar(new Car
                {
                    id = index,
                    rentedBy = CurrentlyLoggedUser.login,
                    isAvaliable = false,
                });
                if (wasSuccess)
                    ShowRentCompleteMonit();
            }
            Refresh();
        }


        public void GenLogInOptions()
        {
            label2.Text = "Zaloguj siê lub zarejestruj aby kontynuowaæ";
            Button newButton = new Button
            {
                Text = "Zaloguj siê",
                Size = new Size(114, 56),
                Location = new Point(355, 428)
            };
            newButton.Click += NewButton_Click_LogReje;
            LogInStuff[1] = newButton;
            this.Controls.Add(newButton);

            Button newButton2 = new Button
            {
                Text = "Zarejestruj siê",
                Size = new Size(114, 56),
                Location = new Point(479, 428)
            };
            newButton2.Click += ShowRegisterMonit;
            LogInStuff[2] = newButton2;

            this.Controls.Add(newButton2);
        }


        private void NewButton_Click_LogReje(object sender, EventArgs e)
        {
            //Panel logowania
            Form loginForm = new Form
            {
                Text = "Logowanie",
                Size = new Size(310, 300),
                BackColor = Color.White
            };

            TextBox logwanie_uz_log = new TextBox
            {
                PlaceholderText = "Podaj login",
                Location = new Point(100, 50),
                AutoSize = true
            };

            TextBox logwanie_uz_has = new TextBox
            {
                PlaceholderText = "Podaj has³o",
                Location = new Point(100, 100),
                AutoSize = true
            };

            Button wyslijDoBazyLog = new Button
            {
                Text = "Zaloguj siê",
                Size = new Size(100, 56),
                Location = new Point(100, 150)
            };

            wyslijDoBazyLog.Click += (s, args) =>
            {
                User? userFound = Database.GetUser(logwanie_uz_log.Text);
                if (userFound != null)
                {
                    if (userFound.password == logwanie_uz_has.Text)
                    {
                        CurrentlyLoggedUser = userFound;
                        MessageBox.Show("Zalogowano pomyœlnie!");

                    }
                    else
                    {
                        MessageBox.Show("Nieprawid³owe has³o");

                    }

                }
                else
                {
                    MessageBox.Show("Nieprawid³owy login");

                }
                Refresh();

            };
            loginForm.Controls.Add(logwanie_uz_log);
            loginForm.Controls.Add(logwanie_uz_has);
            loginForm.Controls.Add(wyslijDoBazyLog);
            loginForm.Show();
        }

        void ShowRentCompleteMonit()
        {

            Form newForm = new Form();
            {
                Text = "Nowe Okno";
                Size = new Size(1000, 600);
                BackColor = Color.White;
            };

            Label congratulationLabel = new Label
            {
                Location = new Point(20, 20),
                AutoSize = false,
                Width = 300,
                Height = 100,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 12, FontStyle.Bold),
                BackColor = Color.LightGray,
                BorderStyle = BorderStyle.FixedSingle
            };

            congratulationLabel.AutoSize = true;
            congratulationLabel.MaximumSize = new Size(280, 0);
            congratulationLabel.Text = "Gratulacja wypo¿yczy³eœ auto! Odbierz auto jutro od 8:00 na naszym parkingu ul.Zimna12A Warszawa tel:123432213."; // Mo¿na u¿yæ d³ugiego tekstu.



            newForm.Controls.Add(congratulationLabel);

            newForm.ClientSize = new Size(congratulationLabel.Width + 40, congratulationLabel.Height + 40);

            newForm.Show();
        }
        private void ShowRegisterMonit(object sender, EventArgs e)
        {
            //Panel rejestracji
            Form registerForm = new Form
            {
                Text = "Rejestracja",
                Size = new Size(310, 300),
                BackColor = Color.White
            };

            TextBox regi_uz_log = new TextBox
            {
                PlaceholderText = "Podaj nowy login",
                Location = new Point(100, 50),
                AutoSize = true
            };
            TextBox regi_uz_has = new TextBox
            {
                PlaceholderText = "Podaj nowe has³o",
                Location = new Point(100, 100),
                AutoSize = true
            };

            Button wyslijDoBazyRej = new Button
            {
                Text = "Zarejestruj siê",
                Size = new Size(100, 56),
                Location = new Point(100, 150)
            };

            wyslijDoBazyRej.Click += (s, args) =>
            {
                bool status = Database.AddUser(new User
                {
                    login = regi_uz_log.Text,
                    password = regi_uz_has.Text,
                });

                if (status)
                {
                    MessageBox.Show("Zarejestrowano");
                    registerForm.Close();
                    registerForm.Dispose();

                }
                else
                {
                    MessageBox.Show("Rejestracja nie powiod³a siê");

                }
                Refresh();

            };

            registerForm.Controls.Add(regi_uz_log);
            registerForm.Controls.Add(regi_uz_has);
            registerForm.Controls.Add(wyslijDoBazyRej);
            registerForm.Show();

        }
      
    }
}
