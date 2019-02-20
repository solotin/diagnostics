namespace Diagnostics
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.SaveSetBtn = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SelectBtn = new System.Windows.Forms.Button();
            this.passwordswitch2 = new System.Windows.Forms.PictureBox();
            this.APSex = new System.Windows.Forms.Panel();
            this.sex_W = new System.Windows.Forms.RadioButton();
            this.sex_M = new System.Windows.Forms.RadioButton();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.APTestList = new System.Windows.Forms.ComboBox();
            this.TestConnBtn = new System.Windows.Forms.Button();
            this.passwordswitch1 = new System.Windows.Forms.PictureBox();
            this.passwordTB1 = new System.Windows.Forms.TextBox();
            this.dbnameTB = new System.Windows.Forms.TextBox();
            this.APGroup = new System.Windows.Forms.TextBox();
            this.APStudentName = new System.Windows.Forms.TextBox();
            this.passwordTB2 = new System.Windows.Forms.TextBox();
            this.userTB = new System.Windows.Forms.TextBox();
            this.hostTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PasswordAPbtn = new System.Windows.Forms.Button();
            this.passwordswitch0 = new System.Windows.Forms.PictureBox();
            this.passwordTB0 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passwordswitch2)).BeginInit();
            this.APSex.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passwordswitch1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passwordswitch0)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "eyeBlack.png");
            this.imageList1.Images.SetKeyName(1, "eyeBlue.png");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(243, 342);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 13);
            this.label8.TabIndex = 100;
            // 
            // SaveSetBtn
            // 
            this.SaveSetBtn.BackColor = System.Drawing.Color.LightGray;
            this.SaveSetBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SaveSetBtn.ForeColor = System.Drawing.SystemColors.InfoText;
            this.SaveSetBtn.Location = new System.Drawing.Point(200, 200);
            this.SaveSetBtn.Name = "SaveSetBtn";
            this.SaveSetBtn.Size = new System.Drawing.Size(143, 23);
            this.SaveSetBtn.TabIndex = 114;
            this.SaveSetBtn.Text = "Зберегти налаштування";
            this.SaveSetBtn.UseVisualStyleBackColor = false;
            this.SaveSetBtn.Click += new System.EventHandler(this.SaveSetBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SelectBtn);
            this.panel1.Controls.Add(this.passwordswitch2);
            this.panel1.Controls.Add(this.APSex);
            this.panel1.Controls.Add(this.checkBox3);
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.APTestList);
            this.panel1.Controls.Add(this.TestConnBtn);
            this.panel1.Controls.Add(this.SaveSetBtn);
            this.panel1.Controls.Add(this.passwordswitch1);
            this.panel1.Controls.Add(this.passwordTB1);
            this.panel1.Controls.Add(this.dbnameTB);
            this.panel1.Controls.Add(this.APGroup);
            this.panel1.Controls.Add(this.APStudentName);
            this.panel1.Controls.Add(this.passwordTB2);
            this.panel1.Controls.Add(this.userTB);
            this.panel1.Controls.Add(this.hostTB);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(546, 450);
            this.panel1.TabIndex = 102;
            this.panel1.Visible = false;
            // 
            // SelectBtn
            // 
            this.SelectBtn.BackColor = System.Drawing.Color.LightGray;
            this.SelectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SelectBtn.Location = new System.Drawing.Point(25, 395);
            this.SelectBtn.Name = "SelectBtn";
            this.SelectBtn.Size = new System.Drawing.Size(116, 23);
            this.SelectBtn.TabIndex = 121;
            this.SelectBtn.Text = "Відправити запит";
            this.SelectBtn.UseVisualStyleBackColor = false;
            this.SelectBtn.Click += new System.EventHandler(this.SelectBtn_Click);
            // 
            // passwordswitch2
            // 
            this.passwordswitch2.Location = new System.Drawing.Point(230, 165);
            this.passwordswitch2.Name = "passwordswitch2";
            this.passwordswitch2.Size = new System.Drawing.Size(20, 20);
            this.passwordswitch2.TabIndex = 120;
            this.passwordswitch2.TabStop = false;
            this.passwordswitch2.Click += new System.EventHandler(this.passwordswitch_Click);
            // 
            // APSex
            // 
            this.APSex.Controls.Add(this.sex_W);
            this.APSex.Controls.Add(this.sex_M);
            this.APSex.Enabled = false;
            this.APSex.Location = new System.Drawing.Point(455, 350);
            this.APSex.Name = "APSex";
            this.APSex.Size = new System.Drawing.Size(80, 31);
            this.APSex.TabIndex = 119;
            // 
            // sex_W
            // 
            this.sex_W.AutoSize = true;
            this.sex_W.Location = new System.Drawing.Point(37, 3);
            this.sex_W.Name = "sex_W";
            this.sex_W.Size = new System.Drawing.Size(36, 17);
            this.sex_W.TabIndex = 0;
            this.sex_W.Text = "Ж";
            this.sex_W.UseVisualStyleBackColor = true;
            // 
            // sex_M
            // 
            this.sex_M.AutoSize = true;
            this.sex_M.Checked = true;
            this.sex_M.Location = new System.Drawing.Point(3, 3);
            this.sex_M.Name = "sex_M";
            this.sex_M.Size = new System.Drawing.Size(33, 17);
            this.sex_M.TabIndex = 0;
            this.sex_M.TabStop = true;
            this.sex_M.Text = "Ч";
            this.sex_M.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(461, 332);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(55, 17);
            this.checkBox3.TabIndex = 118;
            this.checkBox3.Text = "Стать";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(243, 332);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(55, 17);
            this.checkBox2.TabIndex = 117;
            this.checkBox2.Text = "Група";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(25, 332);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(44, 17);
            this.checkBox1.TabIndex = 116;
            this.checkBox1.Text = "ПІБ";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // APTestList
            // 
            this.APTestList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.APTestList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.APTestList.ForeColor = System.Drawing.SystemColors.WindowText;
            this.APTestList.FormattingEnabled = true;
            this.APTestList.Items.AddRange(new object[] {
            "1. Професійно важливі та особистісні якості конкурентоспрожного ІТ-фахівця",
            "2. Діагностика реалізації потреби в саморозвитку",
            "3. Методика діагностики особистості на мотивацію до успіху",
            "4. Методика для діагностики учбової мотивації студентів",
            "5. Дослідження ієрархії ціннісних орієнтацій",
            "6. Тест для визначення характеристик мислення",
            "7. Оцінка рівня творчого потенціалу особистості",
            "8. Оцінка рівня розвитку технічного мислення ",
            "9. Тест на визначення ригідності (мобільності)",
            "10. Методика діагностики ступеня готовності до ризику",
            "11. Тест на визначення рівня Вашої комунікабельності ",
            "12. Експрес-діагностика організаторських здібностей",
            "13. Анкета оцінки рівня сформованості особистісних якостей студентів",
            "14. Діагностика рефлексії ",
            "15. Колективізм чи індивідуалізм",
            "16. Діагностика ступеня критичного мислення",
            "17. Загальний рівень конкурентноспроможності"});
            this.APTestList.Location = new System.Drawing.Point(25, 295);
            this.APTestList.Name = "APTestList";
            this.APTestList.Size = new System.Drawing.Size(400, 21);
            this.APTestList.TabIndex = 115;
            // 
            // TestConnBtn
            // 
            this.TestConnBtn.BackColor = System.Drawing.Color.LightGray;
            this.TestConnBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.TestConnBtn.ForeColor = System.Drawing.SystemColors.InfoText;
            this.TestConnBtn.Location = new System.Drawing.Point(25, 200);
            this.TestConnBtn.Name = "TestConnBtn";
            this.TestConnBtn.Size = new System.Drawing.Size(158, 23);
            this.TestConnBtn.TabIndex = 114;
            this.TestConnBtn.Text = "Тестове підключення до БД";
            this.TestConnBtn.UseVisualStyleBackColor = false;
            this.TestConnBtn.Click += new System.EventHandler(this.TestConnBtn_Click);
            // 
            // passwordswitch1
            // 
            this.passwordswitch1.Location = new System.Drawing.Point(505, 115);
            this.passwordswitch1.Name = "passwordswitch1";
            this.passwordswitch1.Size = new System.Drawing.Size(20, 20);
            this.passwordswitch1.TabIndex = 113;
            this.passwordswitch1.TabStop = false;
            this.passwordswitch1.Click += new System.EventHandler(this.passwordswitch_Click);
            // 
            // passwordTB1
            // 
            this.passwordTB1.Location = new System.Drawing.Point(300, 115);
            this.passwordTB1.Name = "passwordTB1";
            this.passwordTB1.PasswordChar = '•';
            this.passwordTB1.Size = new System.Drawing.Size(200, 20);
            this.passwordTB1.TabIndex = 111;
            // 
            // dbnameTB
            // 
            this.dbnameTB.Location = new System.Drawing.Point(300, 65);
            this.dbnameTB.Name = "dbnameTB";
            this.dbnameTB.Size = new System.Drawing.Size(200, 20);
            this.dbnameTB.TabIndex = 112;
            // 
            // APGroup
            // 
            this.APGroup.Enabled = false;
            this.APGroup.Location = new System.Drawing.Point(243, 355);
            this.APGroup.Name = "APGroup";
            this.APGroup.Size = new System.Drawing.Size(200, 20);
            this.APGroup.TabIndex = 110;
            // 
            // APStudentName
            // 
            this.APStudentName.Enabled = false;
            this.APStudentName.Location = new System.Drawing.Point(25, 355);
            this.APStudentName.Name = "APStudentName";
            this.APStudentName.Size = new System.Drawing.Size(200, 20);
            this.APStudentName.TabIndex = 109;
            // 
            // passwordTB2
            // 
            this.passwordTB2.Location = new System.Drawing.Point(25, 165);
            this.passwordTB2.Name = "passwordTB2";
            this.passwordTB2.PasswordChar = '•';
            this.passwordTB2.Size = new System.Drawing.Size(200, 20);
            this.passwordTB2.TabIndex = 108;
            // 
            // userTB
            // 
            this.userTB.Location = new System.Drawing.Point(25, 115);
            this.userTB.Name = "userTB";
            this.userTB.Size = new System.Drawing.Size(200, 20);
            this.userTB.TabIndex = 108;
            // 
            // hostTB
            // 
            this.hostTB.Location = new System.Drawing.Point(25, 65);
            this.hostTB.Name = "hostTB";
            this.hostTB.Size = new System.Drawing.Size(200, 20);
            this.hostTB.TabIndex = 107;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(300, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 16);
            this.label5.TabIndex = 106;
            this.label5.Text = "Пароль БД";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(300, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 16);
            this.label4.TabIndex = 105;
            this.label4.Text = "Ім\'я бази даних";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.Location = new System.Drawing.Point(25, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(139, 16);
            this.label9.TabIndex = 104;
            this.label9.Text = "Пароль адмінпанелі";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(25, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 16);
            this.label1.TabIndex = 104;
            this.label1.Text = "User";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(25, 275);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 16);
            this.label7.TabIndex = 103;
            this.label7.Text = "Назва тесту";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(25, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 16);
            this.label3.TabIndex = 102;
            this.label3.Text = "Host";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(25, 242);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(170, 19);
            this.label6.TabIndex = 101;
            this.label6.Text = "Вибірка результатів";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(25, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(276, 19);
            this.label2.TabIndex = 100;
            this.label2.Text = "Налаштування БД та адмінпанелі";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.PasswordAPbtn);
            this.panel2.Controls.Add(this.passwordswitch0);
            this.panel2.Controls.Add(this.passwordTB0);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(546, 390);
            this.panel2.TabIndex = 104;
            // 
            // PasswordAPbtn
            // 
            this.PasswordAPbtn.BackColor = System.Drawing.Color.Silver;
            this.PasswordAPbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PasswordAPbtn.Location = new System.Drawing.Point(230, 200);
            this.PasswordAPbtn.Name = "PasswordAPbtn";
            this.PasswordAPbtn.Size = new System.Drawing.Size(75, 23);
            this.PasswordAPbtn.TabIndex = 117;
            this.PasswordAPbtn.Text = "OK";
            this.PasswordAPbtn.UseVisualStyleBackColor = false;
            this.PasswordAPbtn.Click += new System.EventHandler(this.PasswordAPbtn_Click);
            // 
            // passwordswitch0
            // 
            this.passwordswitch0.Location = new System.Drawing.Point(376, 165);
            this.passwordswitch0.Name = "passwordswitch0";
            this.passwordswitch0.Size = new System.Drawing.Size(20, 20);
            this.passwordswitch0.TabIndex = 116;
            this.passwordswitch0.TabStop = false;
            this.passwordswitch0.Click += new System.EventHandler(this.passwordswitch_Click);
            // 
            // passwordTB0
            // 
            this.passwordTB0.Location = new System.Drawing.Point(170, 165);
            this.passwordTB0.Name = "passwordTB0";
            this.passwordTB0.PasswordChar = '•';
            this.passwordTB0.Size = new System.Drawing.Size(200, 20);
            this.passwordTB0.TabIndex = 115;
            this.passwordTB0.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwordTB0_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(107, 125);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(347, 20);
            this.label10.TabIndex = 114;
            this.label10.Text = "Введіть пароль для доступу до адмінпанелі";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(603, 392);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Панель адміністратора";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passwordswitch2)).EndInit();
            this.APSex.ResumeLayout(false);
            this.APSex.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passwordswitch1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passwordswitch0)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox passwordswitch2;
        private System.Windows.Forms.Panel APSex;
        private System.Windows.Forms.RadioButton sex_W;
        private System.Windows.Forms.RadioButton sex_M;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox APTestList;
        private System.Windows.Forms.Button SaveSetBtn;
        private System.Windows.Forms.PictureBox passwordswitch1;
        private System.Windows.Forms.TextBox passwordTB1;
        private System.Windows.Forms.TextBox dbnameTB;
        private System.Windows.Forms.TextBox APGroup;
        private System.Windows.Forms.TextBox APStudentName;
        private System.Windows.Forms.TextBox passwordTB2;
        private System.Windows.Forms.TextBox userTB;
        private System.Windows.Forms.TextBox hostTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SelectBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button PasswordAPbtn;
        private System.Windows.Forms.PictureBox passwordswitch0;
        private System.Windows.Forms.TextBox passwordTB0;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button TestConnBtn;
    }
}