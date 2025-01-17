namespace wypozyczalniaSamochodowa
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            groupBox1 = new GroupBox();
            label2 = new Label();
            button4 = new Button();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.Location = new Point(311, 9);
            label1.Name = "label1";
            label1.Size = new Size(337, 32);
            label1.TabIndex = 0;
            label1.Text = "Wypożyczalnia samochodowa";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(50, 79);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(246, 123);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(367, 42);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(251, 173);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(678, 59);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(255, 143);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 3;
            pictureBox3.TabStop = false;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            button1.Location = new Point(92, 13);
            button1.Name = "button1";
            button1.Size = new Size(114, 56);
            button1.TabIndex = 4;
            button1.Text = "Wynajmij";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            button2.Location = new Point(426, 13);
            button2.Name = "button2";
            button2.Size = new Size(114, 56);
            button2.TabIndex = 5;
            button2.Text = "Wynajmij";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Button2;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            button3.Location = new Point(742, 13);
            button3.Name = "button3";
            button3.Size = new Size(114, 56);
            button3.TabIndex = 6;
            button3.Text = "Wynajmij";
            button3.UseVisualStyleBackColor = true;
            button3.Click += Button3;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button2);
            groupBox1.Location = new Point(12, 208);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(986, 78);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label2.Location = new Point(320, 328);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 8;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            button4.Location = new Point(763, 454);
            button4.Name = "button4";
            button4.Size = new Size(114, 56);
            button4.TabIndex = 9;
            button4.Text = "Wyloguj";
            button4.UseVisualStyleBackColor = true;
            button4.Click += LogOut;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label3.Location = new Point(763, 419);
            label3.Name = "label3";
            label3.Size = new Size(0, 20);
            label3.TabIndex = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1010, 613);
            Controls.Add(label3);
            Controls.Add(button4);
            Controls.Add(label2);
            Controls.Add(groupBox1);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Button button1;
        private Button button2;
        private Button button3;
        private GroupBox groupBox1;
        private Label label2;
        private Button button4;
        private Label label3;
    }
}
