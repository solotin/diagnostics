using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Diagnostics
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            passwordswitch0.Image = imageList1.Images[0];
            passwordswitch1.Image = imageList1.Images[0];
            passwordswitch2.Image = imageList1.Images[0];
            hostTB.Text = Properties.Settings.Default.host;
            dbnameTB.Text = Properties.Settings.Default.DBname;
            passwordTB1.Text = Properties.Settings.Default.password;
            passwordTB2.Text = Properties.Settings.Default.APpassword;
            userTB.Text = Properties.Settings.Default.user;
        }
        private void passwordswitch_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            TextBox tx;
            if (pb.Name == "passwordswitch1") tx = passwordTB1;
            else if (pb.Name == "passwordswitch2") tx = passwordTB2;
            else tx = passwordTB0;

            if (tx.PasswordChar == '•')
            { pb.Image = imageList1.Images[1]; tx.PasswordChar = '\0'; }
            else { pb.Image = imageList1.Images[0]; tx.PasswordChar = '•'; }
        }

        private void SaveSetBtn_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.host = hostTB.Text;
            Properties.Settings.Default.DBname = dbnameTB.Text;
            Properties.Settings.Default.password = passwordTB1.Text;
            Properties.Settings.Default.user = userTB.Text;
            Properties.Settings.Default.APpassword = passwordTB2.Text;
            Properties.Settings.Default.Save();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            APStudentName.Enabled = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            APGroup.Enabled = checkBox2.Checked;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            APSex.Enabled = checkBox3.Checked;
        }

        private void SelectBtn_Click(object sender, EventArgs e)
        {
            int testNum = APTestList.SelectedIndex;
            string sex = checkBox3.Checked ? Convert.ToString(sex_M.Checked) : "";
            string StudentName = checkBox1.Checked ? APStudentName.Text : "";
            string GroupName = checkBox2.Checked ? APGroup.Text : "";
            if (testNum == -1) MessageBox.Show("Виберіть тест", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                if (testNum != 16) CreateExel.GetReport(String.Format("test{0}", testNum), StudentName, GroupName, sex);
                else CreateExel.GetReport("all", StudentName, GroupName, sex);
        }

        private void PasswordAPbtn_Click(object sender, EventArgs e)
        {
            if (passwordTB0.Text == Properties.Settings.Default.APpassword)
            {
                panel1.Visible = true;
                panel2.Visible = false;
            }
            else
            {
                passwordTB0.Text = "";
            }
        }

        private void TestConnBtn_Click(object sender, EventArgs e)
        {
            (new SqlQueries(hostTB.Text, userTB.Text, dbnameTB.Text, passwordTB1.Text)).TestConnection();
        }

        private void passwordTB0_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) PasswordAPbtn_Click(PasswordAPbtn, null);
        }
    }
}
