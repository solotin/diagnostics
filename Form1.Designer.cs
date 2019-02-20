namespace Diagnostics
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.FName = new System.Windows.Forms.TextBox();
            this.SName = new System.Windows.Forms.TextBox();
            this.Group = new System.Windows.Forms.TextBox();
            this.Patron = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Sex = new System.Windows.Forms.Panel();
            this.sex_W = new System.Windows.Forms.RadioButton();
            this.sex_M = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Sex.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.YellowGreen;
            this.label1.Location = new System.Drawing.Point(0, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(569, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Реєстрація";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FName
            // 
            this.FName.Location = new System.Drawing.Point(100, 113);
            this.FName.Name = "FName";
            this.FName.Size = new System.Drawing.Size(191, 20);
            this.FName.TabIndex = 93;
            this.FName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FIO_KeyPress);
            // 
            // SName
            // 
            this.SName.Location = new System.Drawing.Point(100, 80);
            this.SName.Name = "SName";
            this.SName.Size = new System.Drawing.Size(191, 20);
            this.SName.TabIndex = 92;
            this.SName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FIO_KeyPress);
            // 
            // Group
            // 
            this.Group.Location = new System.Drawing.Point(100, 179);
            this.Group.Name = "Group";
            this.Group.Size = new System.Drawing.Size(80, 20);
            this.Group.TabIndex = 91;
            this.Group.TextChanged += new System.EventHandler(this.Group_TextChanged);
            // 
            // Patron
            // 
            this.Patron.Location = new System.Drawing.Point(100, 146);
            this.Patron.Name = "Patron";
            this.Patron.Size = new System.Drawing.Size(191, 20);
            this.Patron.TabIndex = 94;
            this.Patron.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FIO_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label5.Location = new System.Drawing.Point(49, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 20);
            this.label5.TabIndex = 90;
            this.label5.Text = "Група";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label4.Location = new System.Drawing.Point(13, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 20);
            this.label4.TabIndex = 89;
            this.label4.Text = "По батькові";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label3.Location = new System.Drawing.Point(26, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 88;
            this.label3.Text = "Прізвище";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label2.Location = new System.Drawing.Point(63, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 20);
            this.label2.TabIndex = 87;
            this.label2.Text = "Ім\'я";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.button1.Location = new System.Drawing.Point(202, 293);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 34);
            this.button1.TabIndex = 96;
            this.button1.Text = "Розпочати тестування";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label7.Image = ((System.Drawing.Image)(resources.GetObject("label7.Image")));
            this.label7.Location = new System.Drawing.Point(538, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 26);
            this.label7.TabIndex = 97;
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label8.Location = new System.Drawing.Point(60, 221);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 20);
            this.label8.TabIndex = 90;
            this.label8.Text = "Стать";
            // 
            // Sex
            // 
            this.Sex.Controls.Add(this.sex_W);
            this.Sex.Controls.Add(this.sex_M);
            this.Sex.Location = new System.Drawing.Point(108, 221);
            this.Sex.Name = "Sex";
            this.Sex.Size = new System.Drawing.Size(80, 31);
            this.Sex.TabIndex = 98;
            // 
            // sex_W
            // 
            this.sex_W.AutoSize = true;
            this.sex_W.Location = new System.Drawing.Point(44, 3);
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(100, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 15);
            this.label6.TabIndex = 99;
            this.label6.Text = "Приклад: 4РП-01";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(516, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.TabIndex = 100;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(569, 392);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Sex);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.FName);
            this.Controls.Add(this.SName);
            this.Controls.Add(this.Group);
            this.Controls.Add(this.Patron);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Комп\'ютерне діагностування особистості";
            this.Sex.ResumeLayout(false);
            this.Sex.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FName;
        private System.Windows.Forms.TextBox SName;
        private System.Windows.Forms.TextBox Group;
        private System.Windows.Forms.TextBox Patron;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel Sex;
        private System.Windows.Forms.RadioButton sex_W;
        private System.Windows.Forms.RadioButton sex_M;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

