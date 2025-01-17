using System.Data.SQLite;
namespace wypozyczalniaSamochodowa.Models
{
    class DbConnection
    {
        string connectionString = "Data Source=MyDatabase.sqlite;Version=3";
       public  DbConnection()
        {
            connection = new SQLiteConnection(connectionString);
            if(!DoesTableExist("samochody"))
                   InitializeDatabase();
        }

        private void InitializeDatabase()
        {

            if (!System.IO.File.Exists("MyDatabase.sqlite"))
            {
                SQLiteConnection.CreateFile("MyDatabase.sqlite");
            }

              connection.Open();

              ExecuteNonQuery(connection, createSamochodyTableQuery);
              ExecuteNonQuery(connection, createUzytkownicyTableQuery);
              ExecuteNonQuery(connection, createWypozyczenieTableQuery);

              ExecuteNonQuery(connection, insertSamochodyDataQuery);
              ExecuteNonQuery(connection, insertUzytkownicyDataQuery);
              connection.Close();

        }
        private void ExecuteNonQuery(SQLiteConnection connection, string query)
        {
            using (var command = new SQLiteCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }
        public User GetUser(string Login )
        {
            User returnUser = null;
         string query = "SELECT * FROM uzytkownicy WHERE login = @login";
            try
            {
               connection.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@login", Login);
                    SQLiteDataReader reader = cmd.ExecuteReader();

                  
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                             returnUser = new User
                             {
                                 id = Convert.ToInt32(reader["id"]),
                                 login = reader["login"].ToString(),
                                 password = reader["haslo"].ToString()
                             };
                    }
                   reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return returnUser;

        }
        public bool DoesTableExist(string tableName)
        {
            bool tableExists = false;
            string query = "SELECT name FROM sqlite_master WHERE type='table' AND name=@tableName;";
            try
            {
                connection.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@tableName", tableName);

                    object result = cmd.ExecuteScalar();
                    tableExists = (result != null); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error verifying table existence: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }

            return tableExists;
        }

        public List<Car> GetAllCars()
        {
            List<Car> cars = new List<Car>();
            string query = "SELECT * FROM samochody ORDER BY Id";
            try
            {
                connection.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    SQLiteDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            cars.Add(new Car
                            {
                                id = Convert.ToInt32(reader["id"].ToString()),
                                isAvaliable = Convert.ToInt32(reader["is_available"].ToString()) > 0,
                                marka = reader["marka"].ToString(),
                                model = reader["model"].ToString(),
                                rentedBy = reader["RentedBy"].ToString(),
                            }) ;
                        }
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();

            }
            return cars;

        }
        public bool UpdateCar(Car car)
        {
            bool returnStatus = false;
            string query = "UPDATE samochody SET RentedBy = @rentedBy, is_available = @isAvailable WHERE id = @id";

            try
            {
                connection.Open();

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", car.id);
                    if (string.IsNullOrEmpty(car.rentedBy))
                    {
                        cmd.Parameters.AddWithValue("@rentedBy", DBNull.Value); 
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@rentedBy", car.rentedBy); 
                    }
                    cmd.Parameters.AddWithValue("@isAvailable", car.isAvaliable);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        returnStatus = true;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return returnStatus;
        }

        public bool AddUser(User user)
        {
            bool returnStatus = false;
            string query = "INSERT INTO uzytkownicy (login, haslo) VALUES (@login, @haslo)";
            try
            {
                connection.Open();

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    // Dodawanie parametrów do zapytania
                    cmd.Parameters.AddWithValue("@login", user.login);
                    cmd.Parameters.AddWithValue("@haslo", user.password);

                    // Wykonanie zapytania
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        returnStatus = true;
                    }
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return returnStatus;
        }
      // public string ConnectionString = "server=127.0.0.1; user=root; database=wyp; password=";
        public SQLiteConnection connection;

        string createSamochodyTableQuery = @"
CREATE TABLE IF NOT EXISTS samochody (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    marka TEXT NOT NULL,
    model TEXT NOT NULL,
    is_available INTEGER NOT NULL DEFAULT 1,
    RentedBy TEXT NULL DEFAULT NULL
);";

        string insertSamochodyDataQuery = @"
INSERT INTO samochody (id, marka, model, is_available, RentedBy) VALUES
(0, 'Tesla', 'S', 1, NULL),
(1, 'Mercedes', 'S class', 1, NULL),
(2, 'Skoda', 'Octavia', 1, NULL);";

        string createUzytkownicyTableQuery = @"
CREATE TABLE IF NOT EXISTS uzytkownicy (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    login TEXT NOT NULL,
    haslo TEXT NOT NULL
);";

        string insertUzytkownicyDataQuery = @"
INSERT INTO uzytkownicy (id, login, haslo) VALUES
(4, 'jan', 'urban'),
(6, 'stefciopizza12', 'stefek78'),
(7, 'łokietek778', 'janko'),
(8, 'jumper', 'jumper1234'),
(9, 'cukrowaAnka12', 'anusia');";

        string createWypozyczenieTableQuery = @"
CREATE TABLE IF NOT EXISTS wypozyczenie (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    uzytkownik_id INTEGER NOT NULL,
    samochody_id INTEGER NOT NULL,
    FOREIGN KEY (uzytkownik_id) REFERENCES uzytkownicy (id) ON DELETE CASCADE,
    FOREIGN KEY (samochody_id) REFERENCES samochody (id) ON DELETE CASCADE
);";

    }
}
