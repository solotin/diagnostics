using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diagnostics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Group_TextChanged(object sender, EventArgs e)
        {
            //string str = Group.Text;
            //int u;
            //for (int i = 0; i < Group.TextLength; i++)
            //{
            //    u = Convert.ToInt16(Group.Text[i]);

            //    if (i == 0 || i == 4 || i == 5)
            //        if (u < 48 || u > 57) { str = str.Substring(0, i); break; }
            //    if (i == 1 || i == 2)
            //        if (u < 1040 || u > 1103) { str = str.Substring(0, i); break; }
            //        else str = str.Substring(0, i) + Char.ToUpper(str[i]) + str.Substring(i + 1, str.Length - i - 1);
            //    if (i == 3)
            //        if (Group.Text[i] != '-') { str = str.Substring(0, i); break; }
            //    if (i > 5) { str = str.Substring(0, 6); break; }
            //}
            //Group.Text = str;
            //Group.SelectionStart = Group.TextLength;
        }

        private void FIO_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ch = (int)e.KeyChar;
            TextBox tx = (TextBox)sender;
            if ((ch < 1040 || ch > 1103) && ch != 1111 && ch != 1110 && ch != 1031 && ch != 1030 && ch != 1108 && ch != 1028 && ch != 8 && ch != 45)
                e.Handled = true;
            else
                if (tx.Text.Length == 0)
                if (ch != 45 && ch != 8)
                {
                    tx.Text = tx.Text + Char.ToUpper(e.KeyChar);
                    tx.SelectionStart = tx.TextLength;
                    e.Handled = true;
                }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (SName.Text != "" && FName.Text != "" && Patron.Text != "" && Group.Text != "")
            {
                bool sex;
                if (sex_M.Checked) sex = true;
                else sex = false;

                Form2 f2 = new Form2(String.Format("{0} {1} {2}",SName.Text.Trim(),FName.Text.Trim(), Patron.Text.Trim()),Group.Text.ToUpper(),sex);
                Hide();
                f2.Show();
            }
            else { MessageBox.Show("Заповніть усі поля!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            (new Info()).Show();
        }
    }
}
