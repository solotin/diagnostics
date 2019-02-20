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
    public partial class Form2 : Form
    {

        bool sex;
        SqlQueries BD;
        Exception NotAllAnswers = new Exception("Заповніть усі відповіді!");
        Test[] tests = new Test[16];
        bool[] t4anscase = new bool[18];

        public Form2(String FIO, String group, bool sex)
        {
            InitializeComponent();
            this.sex = sex;
            BD = new SqlQueries(FIO, group, sex);
            tests[0] = new SpecialTest("test0", new int[25]);
            tests[3] = new SpecialTest("test3", new int[7]);
            tests[4] = new SpecialTest("test4", new int[18]);
            for (int i = 0; i < 16; i++) { if (i != 0 && i != 3 && i != 4) tests[i] = new Test(String.Format("test{0}", i)); }

        }

        private int getLvl(int hight, int medium, int num, Panel t_res_lvl)
        {
            int resultlvl = 0;
            if (num >= hight)
            {
                t_res_lvl.Size = new Size(15, 30);
                t_res_lvl.Location = new Point(t_res_lvl.Location.X, t_res_lvl.Location.Y - 20);
                t_res_lvl.BackColor = Color.GreenYellow;
                resultlvl = 2;

            }
            else if (num >= medium)
            {
                t_res_lvl.Size = new Size(15, 20);
                t_res_lvl.Location = new Point(t_res_lvl.Location.X, t_res_lvl.Location.Y - 10);
                t_res_lvl.BackColor = Color.Yellow;
                resultlvl = 1;
            }
            return resultlvl;
        }
        private async void SaveResult()
        {
            await Task.Run(() =>
            {
                foreach (Test t in tests)
                    if (t.testcompletestatus == true && t.testsavingstatus == false)
                        if (t.testname == "test0" || t.testname == "test3" || t.testname == "test4") t.testsavingstatus = BD.SaveResult((SpecialTest)t);
                        else t.testsavingstatus = BD.SaveResult(t);
            });
        }
        private void t15Next_Click(object sender, EventArgs e)
        {
            try
            {
                #region answerlist
                int sum = 0;
                if (t15a1.SelectedIndex == -1) throw NotAllAnswers;
                else if (t15a1.SelectedIndex == 0 || t15a1.SelectedIndex == 2) sum++;
                if (t15a2.SelectedIndex == -1) throw NotAllAnswers;
                else if (t15a2.SelectedIndex == 1) sum++;
                if (t15a3.SelectedIndex == -1) throw NotAllAnswers;
                else if (t15a3.SelectedIndex == 3) sum++;
                if (t15a4.SelectedIndex == -1) throw NotAllAnswers;
                else if (t15a4.SelectedIndex == 0) sum++;
                if (t15a5.SelectedIndex == -1) throw NotAllAnswers;
                else if (t15a5.SelectedIndex == 0 || t15a5.SelectedIndex == 1 || t15a5.SelectedIndex == 3) sum++;
                if (t15a6.SelectedIndex == -1) throw NotAllAnswers;
                else if (t15a6.SelectedIndex == 1) sum++;
                if (t15a7.SelectedIndex == -1) throw NotAllAnswers;
                else if (t15a7.SelectedIndex == 0) sum++;
                if (t15a8.SelectedIndex == -1) throw NotAllAnswers;
                else if (t15a8.SelectedIndex == 1) sum++;
                if (t15a9.SelectedIndex == -1) throw NotAllAnswers;
                else if (t15a9.SelectedIndex == 0 || t15a9.SelectedIndex == 3) sum++;
                if (t15a10.SelectedIndex == -1) throw NotAllAnswers;
                else if (t15a10.SelectedIndex == 1) sum++;
                if (t15a11.SelectedIndex == -1) throw NotAllAnswers;
                else if (t15a11.SelectedIndex == 3) sum++;
                if (t15a12.SelectedIndex == -1) throw NotAllAnswers;
                else if (t15a12.SelectedIndex == 2) sum++;
                if (t15a13.SelectedIndex == -1) throw NotAllAnswers;
                else if (t15a13.SelectedIndex == 2) sum++;
                if (t15a14.SelectedIndex == -1) throw NotAllAnswers;
                else if (t15a14.SelectedIndex == 3) sum++;
                if (t15a15.SelectedIndex == -1) throw NotAllAnswers;
                else if (t15a15.SelectedIndex == 0 || t15a15.SelectedIndex == 2) sum++;
                if (t15a16.SelectedIndex == -1) throw NotAllAnswers;
                else if (t15a16.SelectedIndex == 0) sum++;
                if (t15a17.SelectedIndex == -1) throw NotAllAnswers;
                else if (t15a17.SelectedIndex == 1) sum++;
                if (t15a18.SelectedIndex == -1) throw NotAllAnswers;
                else if (t15a18.SelectedIndex == 2) sum++;
                if (t15a19.SelectedIndex == -1) throw NotAllAnswers;
                else if (t15a19.SelectedIndex == 2) sum++;
                if (t15a20.SelectedIndex == -1) throw NotAllAnswers;
                else if (t15a20.SelectedIndex == 0) sum++;
                if (t15a21.SelectedIndex == -1) throw NotAllAnswers;
                else if (t15a21.SelectedIndex == 2) sum++;
                #endregion

                tests[15].resultvalue = sum;
                t15_res_num.Text = sum.ToString() + "/21";
                tests[15].resultlvl = getLvl(15, 8, sum, t15_res_lvl);

                test15.Visible = false;
                tests[15].testcompletestatus = true;
                t15status.Image = imageList1.Images[0];
                SelectTest.Visible = true;
                progressBar1.Value += 10;
                SaveResult();
            }
            catch (Exception ex)
            {
                Message.ShowErrorText(ex.Message);
            }
        }
        private void t14_Next_Click(object sender, EventArgs e)
        {
            try
            {
                #region answerlist
                ComboBox[] answerlist = new ComboBox[10];
                answerlist[0] = t14a1;
                answerlist[1] = t14a2;
                answerlist[2] = t14a3;
                answerlist[3] = t14a4;
                answerlist[4] = t14a5;
                answerlist[5] = t14a6;
                answerlist[6] = t14a7;
                answerlist[7] = t14a8;
                answerlist[8] = t14a9;
                answerlist[9] = t14a10;
                #endregion

                int a = 0, b = 0, c = 0, sum;
                for (int i = 0; i < 10; i++)
                    if (answerlist[i].SelectedIndex == -1) throw NotAllAnswers;
                    else
                    {
                        switch (answerlist[i].SelectedIndex)
                        {
                            case 0: { a++; break; }
                            case 1: { b++; break; }
                            case 2: { c++; break; }
                        }
                    }

                if (a >= b)
                {
                    if (a >= c) sum = 3;
                    else sum = 1;
                }
                else
                {
                    if (b >= c) sum = 2;
                    else sum = 1;
                }
                tests[14].resultvalue = sum;
                t14_res_num.Text = sum.ToString() + "/3";
                tests[14].resultlvl = getLvl(3, 2, sum, t14_res_lvl);

                test14.Visible = false;
                tests[14].testcompletestatus = true;
                t14status.Image = imageList1.Images[0];
                SelectTest.Visible = true;
                progressBar1.Value += 10;
                SaveResult();
            }
            catch (Exception ex)
            {
                Message.ShowErrorText(ex.Message);
            }
        }
        private void t13Next_Click(object sender, EventArgs e)
        {
            try
            {
                #region answerlist
                ComboBox[] answerlist = new ComboBox[27];
                answerlist[0] = t13a1;
                answerlist[1] = t13a3;
                answerlist[2] = t13a4;
                answerlist[3] = t13a5;
                answerlist[4] = t13a9;
                answerlist[5] = t13a10;
                answerlist[6] = t13a11;
                answerlist[7] = t13a14;
                answerlist[8] = t13a15;
                answerlist[9] = t13a18;
                answerlist[10] = t13a19;
                answerlist[11] = t13a20;
                answerlist[12] = t13a22;
                answerlist[13] = t13a24;
                answerlist[14] = t13a25;
                answerlist[15] = t13a2;
                answerlist[16] = t13a6;
                answerlist[17] = t13a7;
                answerlist[18] = t13a8;
                answerlist[19] = t13a12;
                answerlist[20] = t13a13;
                answerlist[21] = t13a16;
                answerlist[22] = t13a17;
                answerlist[23] = t13a21;
                answerlist[24] = t13a23;
                answerlist[25] = t13a26;
                answerlist[26] = t13a27;
                #endregion

                int sum = 0;
                for (int i = 0; i < 14; i++)
                    if (answerlist[i].SelectedIndex == -1) throw NotAllAnswers;
                    else sum += answerlist[i].SelectedIndex + 1;
                for (int i = 11; i < 26; i++)
                    if (answerlist[i].SelectedIndex == -1) throw NotAllAnswers;
                    else sum += Math.Abs(answerlist[i].SelectedIndex - 7);

                tests[13].resultvalue = sum;
                t13_res_num.Text = tests[13].resultvalue.ToString() + "/189";
                tests[13].resultlvl = getLvl(161, 121, tests[13].resultvalue, t13_res_lvl);

                test13.Visible = false;
                tests[13].testcompletestatus = true;
                t13status.Image = imageList1.Images[0];
                SelectTest.Visible = true;
                progressBar1.Value += 10;
                SaveResult();
            }
            catch (Exception ex)
            {
                Message.ShowErrorText(ex.Message);
            }
        }
        private void t12Next_Click(object sender, EventArgs e)
        {
            try
            {
                #region answerlist
                ComboBox[] answerlist = new ComboBox[10];
                answerlist[0] = t12a1;
                answerlist[1] = t12a2;
                answerlist[2] = t12a3;
                answerlist[3] = t12a4;
                answerlist[4] = t12a5;
                answerlist[5] = t12a6;
                answerlist[6] = t12a7;
                answerlist[7] = t12a8;
                answerlist[8] = t12a9;
                answerlist[9] = t12a10;
                #endregion

                int sum = 0;
                foreach (ComboBox ans in answerlist)
                {
                    if (ans.SelectedIndex == -1) throw NotAllAnswers;
                    sum += Convert.ToInt16(ans.SelectedItem.ToString());
                }

                tests[12].resultvalue = sum;
                t12_res_num.Text = tests[12].resultvalue.ToString() + "/30";
                tests[12].resultlvl = getLvl(22, 11, tests[12].resultvalue, t12_res_lvl);

                test12.Visible = false;
                tests[12].testcompletestatus = true;
                t12status.Image = imageList1.Images[0];
                SelectTest.Visible = true;
                progressBar1.Value += 10;
                SaveResult();

            }
            catch (Exception ex)
            {
                Message.ShowErrorText(ex.Message);
            }
        }

        private void t11Next_Click(object sender, EventArgs e)
        {
            try
            {
                #region answerlist
                ComboBox[] answerlist = new ComboBox[20];
                answerlist[0] = t11a1;
                answerlist[1] = t11a3;
                answerlist[2] = t11a5;
                answerlist[3] = t11a7;
                answerlist[4] = t11a9;
                answerlist[5] = t11a11;
                answerlist[6] = t11a13;
                answerlist[7] = t11a17;
                answerlist[8] = t11a18;
                answerlist[9] = t11a19;
                answerlist[10] = t11a20;
                answerlist[11] = t11a2;
                answerlist[12] = t11a4;
                answerlist[13] = t11a6;
                answerlist[14] = t11a8;
                answerlist[15] = t11a10;
                answerlist[16] = t11a12;
                answerlist[17] = t11a14;
                answerlist[18] = t11a15;
                answerlist[19] = t11a16;
                #endregion

                int sum = 0;
                for (int i = 0; i < 11; i++)
                {
                    if (answerlist[i].SelectedIndex == 0) sum++;
                    else { if (answerlist[i].SelectedIndex == -1) throw NotAllAnswers; }
                }
                for (int i = 11; i < 20; i++)
                {
                    if (answerlist[i].SelectedIndex == 1) sum++;
                    else { if (answerlist[i].SelectedIndex == -1) throw NotAllAnswers; }
                }
                sum *= 5;
                tests[11].resultvalue = sum;
                t11_res_num.Text = tests[11].resultvalue.ToString() + "/100%";
                tests[11].resultlvl = getLvl(70, 40, tests[11].resultvalue, t11_res_lvl);

                test11.Visible = false;
                tests[11].testcompletestatus = true;
                t11status.Image = imageList1.Images[0];
                SelectTest.Visible = true; ;
                progressBar1.Value += 10;
                SaveResult();
            }
            catch (Exception ex)
            {
                Message.ShowErrorText(ex.Message);
            }
        }

        private void t10Next_Click(object sender, EventArgs e)
        {
            try
            {
                #region answerlist
                ComboBox[] answerlist = new ComboBox[16];
                answerlist[0] = t10a1;
                answerlist[1] = t10a2;
                answerlist[2] = t10a3;
                answerlist[3] = t10a4;
                answerlist[4] = t10a5;
                answerlist[5] = t10a6;
                answerlist[6] = t10a7;
                answerlist[7] = t10a8;
                answerlist[8] = t10a9;
                answerlist[9] = t10a10;
                answerlist[10] = t10a11;
                answerlist[11] = t10a12;
                answerlist[12] = t10a13;
                answerlist[13] = t10a14;
                answerlist[14] = t10a15;
                answerlist[15] = t10a16;
                #endregion

                int sum = 0;
                foreach (ComboBox ans in answerlist)
                {
                    if (ans.SelectedIndex == -1) throw NotAllAnswers;
                    else
                    {
                        if (ans.SelectedIndex == 0) sum += 2;
                        else { if (ans.SelectedIndex == 2) sum++; }
                    }
                }

                tests[10].resultvalue = 32 - sum;
                t10_res_num.Text = (32 - tests[10].resultvalue).ToString() + "/32";
                tests[10].resultlvl = getLvl(19, 8, 32 - tests[10].resultvalue, t10_res_lvl);

                test10.Visible = false;
                tests[10].testcompletestatus = true;
                t10status.Image = imageList1.Images[0];
                SelectTest.Visible = true;
                progressBar1.Value += 10;
                SaveResult();
            }
            catch (Exception ex)
            {
                Message.ShowErrorText(ex.Message);
            }
        }

        private void t9Next_Click(object sender, EventArgs e)
        {
            try
            {
                #region answerlist
                ComboBox[] answerlist = new ComboBox[25];
                answerlist[0] = t9a1;
                answerlist[1] = t9a2;
                answerlist[2] = t9a3;
                answerlist[3] = t9a4;
                answerlist[4] = t9a5;
                answerlist[5] = t9a6;
                answerlist[6] = t9a7;
                answerlist[7] = t9a8;
                answerlist[8] = t9a9;
                answerlist[9] = t9a10;
                answerlist[10] = t9a11;
                answerlist[11] = t9a12;
                answerlist[12] = t9a13;
                answerlist[13] = t9a14;
                answerlist[14] = t9a15;
                answerlist[15] = t9a16;
                answerlist[16] = t9a17;
                answerlist[17] = t9a18;
                answerlist[18] = t9a19;
                answerlist[19] = t9a20;
                answerlist[20] = t9a21;
                answerlist[21] = t9a22;
                answerlist[22] = t9a23;
                answerlist[23] = t9a24;
                answerlist[24] = t9a25;
                #endregion

                int sum = 0;
                foreach (ComboBox ans in answerlist)
                {
                    if (ans.SelectedIndex == -1) throw NotAllAnswers;
                    sum += Convert.ToInt16(ans.SelectedItem.ToString());
                }
                tests[9].resultvalue = sum;
                t9_res_num.Text = tests[9].resultvalue.ToString() + "/50";
                tests[9].resultlvl = getLvl(15, -15, tests[9].resultvalue, t9_res_lvl);

                test9.Visible = false;
                tests[9].testcompletestatus = true;
                t9status.Image = imageList1.Images[0];
                SelectTest.Visible = true;
                progressBar1.Value += 10;
                SaveResult();
            }
            catch (Exception ex)
            {
                Message.ShowErrorText(ex.Message);
            }
        }

        private void t8Next_Click(object sender, EventArgs e)
        {
            try
            {
                #region answerlist
                ComboBox[] answerlist = new ComboBox[49];
                answerlist[0] = t8a1;
                answerlist[1] = t8a4;
                answerlist[2] = t8a6;
                answerlist[3] = t8a8;
                answerlist[4] = t8a9;
                answerlist[5] = t8a11;
                answerlist[6] = t8a13;
                answerlist[7] = t8a14;
                answerlist[8] = t8a18;
                answerlist[9] = t8a20;
                answerlist[10] = t8a23;
                answerlist[11] = t8a26;
                answerlist[12] = t8a27;
                answerlist[13] = t8a30;
                answerlist[14] = t8a31;
                answerlist[15] = t8a33;
                answerlist[16] = t8a34;
                answerlist[17] = t8a38;
                answerlist[18] = t8a39;
                answerlist[19] = t8a40;
                answerlist[20] = t8a43;
                answerlist[21] = t8a44;
                answerlist[22] = t8a46;
                answerlist[23] = t8a48;
                answerlist[24] = t8a50;
                answerlist[25] = t8a2;
                answerlist[26] = t8a3;
                answerlist[27] = t8a5;
                answerlist[28] = t8a7;
                answerlist[29] = t8a10;
                answerlist[30] = t8a12;
                answerlist[31] = t8a15;
                answerlist[32] = t8a16;
                answerlist[33] = t8a17;
                answerlist[34] = t8a19;
                answerlist[35] = t8a21;
                answerlist[36] = t8a22;
                answerlist[37] = t8a24;
                answerlist[38] = t8a25;
                answerlist[39] = t8a28;
                answerlist[40] = t8a29;
                answerlist[41] = t8a32;
                answerlist[42] = t8a35;
                answerlist[43] = t8a37;
                answerlist[44] = t8a41;
                answerlist[45] = t8a42;
                answerlist[46] = t8a45;
                answerlist[47] = t8a47;
                answerlist[48] = t8a49;
                #endregion

                int sum = 0;
                for (int i = 0; i < 25; i++)
                {
                    if (answerlist[i].SelectedIndex == 1) sum++;
                    else { if (answerlist[i].SelectedIndex == -1) throw NotAllAnswers; }
                }
                for (int i = 25; i < 49; i++)
                {
                    if (answerlist[i].SelectedIndex == 0) sum++;
                    else { if (answerlist[i].SelectedIndex == -1) throw NotAllAnswers; }
                }

                tests[8].resultvalue = sum;
                t8_res_num.Text = tests[8].resultvalue.ToString() + "/50";
                tests[8].resultlvl = getLvl(35, 18, tests[8].resultvalue, t8_res_lvl);

                test8.Visible = false;
                tests[8].testcompletestatus = true;
                t8status.Image = imageList1.Images[0];
                SelectTest.Visible = true;
                progressBar1.Value += 10;
                SaveResult();
            }
            catch (Exception ex)
            {
                Message.ShowErrorText(ex.Message);
            }
        }

        private void t7Next_Click(object sender, EventArgs e)
        {
            try
            {
                #region answerlist
                ComboBox[] answerlist = new ComboBox[70];
                answerlist[0] = t7a1;
                answerlist[1] = t7a2;
                answerlist[2] = t7a3;
                answerlist[3] = t7a4;
                answerlist[4] = t7a5;
                answerlist[5] = t7a6;
                answerlist[6] = t7a7;
                answerlist[7] = t7a8;
                answerlist[8] = t7a9;
                answerlist[9] = t7a10;
                answerlist[10] = t7a11;
                answerlist[11] = t7a12;
                answerlist[12] = t7a13;
                answerlist[13] = t7a14;
                answerlist[14] = t7a15;
                answerlist[15] = t7a16;
                answerlist[16] = t7a17;
                answerlist[17] = t7a18;
                answerlist[18] = t7a19;
                answerlist[19] = t7a20;
                answerlist[20] = t7a21;
                answerlist[21] = t7a22;
                answerlist[22] = t7a23;
                answerlist[23] = t7a24;
                answerlist[24] = t7a25;
                answerlist[25] = t7a26;
                answerlist[26] = t7a27;
                answerlist[27] = t7a28;
                answerlist[28] = t7a29;
                answerlist[29] = t7a30;
                answerlist[30] = t7a31;
                answerlist[31] = t7a32;
                answerlist[32] = t7a33;
                answerlist[33] = t7a34;
                answerlist[34] = t7a35;
                answerlist[35] = t7a36;
                answerlist[36] = t7a37;
                answerlist[37] = t7a38;
                answerlist[38] = t7a39;
                answerlist[39] = t7a40;
                answerlist[40] = t7a41;
                answerlist[41] = t7a42;
                answerlist[42] = t7a43;
                answerlist[43] = t7a44;
                answerlist[44] = t7a45;
                answerlist[45] = t7a46;
                answerlist[46] = t7a47;
                answerlist[47] = t7a48;
                answerlist[48] = t7a49;
                answerlist[49] = t7a50;
                answerlist[50] = t7a51;
                answerlist[51] = t7a52;
                answerlist[52] = t7a53;
                answerlist[53] = t7a54;
                answerlist[54] = t7a55;
                answerlist[55] = t7a56;
                answerlist[56] = t7a57;
                answerlist[57] = t7a58;
                answerlist[58] = t7a59;
                answerlist[59] = t7a60;
                answerlist[60] = t7a61;
                answerlist[61] = t7a62;
                answerlist[62] = t7a63;
                answerlist[63] = t7a64;
                answerlist[64] = t7a65;
                answerlist[65] = t7a66;
                answerlist[66] = t7a67;
                answerlist[67] = t7a68;
                answerlist[68] = t7a69;
                answerlist[69] = t7a70;
                #endregion

                #region checkanswers
                foreach (ComboBox ans in answerlist)
                    if (ans.SelectedIndex == -1) throw NotAllAnswers;

                int sum = 0;
                if (answerlist[0].SelectedIndex == 1) sum++;
                if (answerlist[1].SelectedIndex == 1) sum++;
                if (answerlist[2].SelectedIndex == 0) sum++;
                if (answerlist[3].SelectedIndex == 2) sum++;
                if (answerlist[4].SelectedIndex == 1) sum++;
                if (answerlist[5].SelectedIndex == 1) sum++;
                if (answerlist[6].SelectedIndex == 2) sum++;
                if (answerlist[7].SelectedIndex == 2) sum++;
                if (answerlist[8].SelectedIndex == 1) sum++;
                if (answerlist[9].SelectedIndex == 2) sum++;
                if (answerlist[10].SelectedIndex == 1) sum++;
                if (answerlist[11].SelectedIndex == 1) sum++;
                if (answerlist[12].SelectedIndex == 1) sum++;
                if (answerlist[13].SelectedIndex == 2) sum++;
                if (answerlist[14].SelectedIndex == 1) sum++;
                if (answerlist[15].SelectedIndex == 1) sum++;
                if (answerlist[16].SelectedIndex == 1) sum++;
                if (answerlist[17].SelectedIndex == 2) sum++;
                if (answerlist[18].SelectedIndex == 1) sum++;
                if (answerlist[19].SelectedIndex == 2) sum++;
                if (answerlist[20].SelectedIndex == 1) sum++;
                if (answerlist[21].SelectedIndex == 0) sum++;
                if (answerlist[22].SelectedIndex == 2) sum++;
                if (answerlist[23].SelectedIndex == 2) sum++;
                if (answerlist[24].SelectedIndex == 1) sum++;
                if (answerlist[25].SelectedIndex == 1) sum++;
                if (answerlist[26].SelectedIndex == 0) sum++;
                if (answerlist[27].SelectedIndex == 2) sum++;
                if (answerlist[28].SelectedIndex == 1) sum++;
                if (answerlist[29].SelectedIndex == 0) sum++;
                if (answerlist[30].SelectedIndex == 2) sum++;
                if (answerlist[31].SelectedIndex == 1) sum++;
                if (answerlist[32].SelectedIndex == 0) sum++;
                if (answerlist[33].SelectedIndex == 2) sum++;
                if (answerlist[34].SelectedIndex == 0) sum++;
                if (answerlist[35].SelectedIndex == 2) sum++;
                if (answerlist[36].SelectedIndex == 1) sum++;
                if (answerlist[37].SelectedIndex == 2) sum++;
                if (answerlist[38].SelectedIndex == 0) sum++;
                if (answerlist[39].SelectedIndex == 1) sum++;
                if (answerlist[40].SelectedIndex == 0) sum++;
                if (answerlist[41].SelectedIndex == 1) sum++;
                if (answerlist[42].SelectedIndex == 1) sum++;
                if (answerlist[43].SelectedIndex == 0) sum++;
                if (answerlist[44].SelectedIndex == 2) sum++;
                if (answerlist[45].SelectedIndex == 0) sum++;
                if (answerlist[46].SelectedIndex == 0) sum++;
                if (answerlist[47].SelectedIndex == 0) sum++;
                if (answerlist[48].SelectedIndex == 1) sum++;
                if (answerlist[49].SelectedIndex == 2) sum++;
                if (answerlist[50].SelectedIndex == 1) sum++;
                if (answerlist[51].SelectedIndex == 0) sum++;
                if (answerlist[52].SelectedIndex == 1) sum++;
                if (answerlist[53].SelectedIndex == 0) sum++;
                if (answerlist[54].SelectedIndex == 0) sum++;
                if (answerlist[55].SelectedIndex == 1) sum++;
                if (answerlist[56].SelectedIndex == 0) sum++;
                if (answerlist[57].SelectedIndex == 0) sum++;
                if (answerlist[58].SelectedIndex == 1) sum++;
                if (answerlist[59].SelectedIndex == 0) sum++;
                if (answerlist[60].SelectedIndex == 1) sum++;
                if (answerlist[61].SelectedIndex == 0) sum++;
                if (answerlist[62].SelectedIndex == 2) sum++;
                if (answerlist[63].SelectedIndex == 1) sum++;
                if (answerlist[64].SelectedIndex == 0) sum++;
                if (answerlist[65].SelectedIndex == 1) sum++;
                if (answerlist[66].SelectedIndex == 2) sum++;
                if (answerlist[67].SelectedIndex == 0) sum++;
                if (answerlist[68].SelectedIndex == 1) sum++;
                if (answerlist[69].SelectedIndex == 0) sum++;
                #endregion

                tests[7].resultvalue = sum;
                t7_res_num.Text = tests[7].resultvalue.ToString() + "/70";
                if (sex) tests[7].resultlvl = getLvl(43, 31, tests[7].resultvalue, t7_res_lvl);
                else tests[7].resultlvl = getLvl(31, 21, tests[7].resultvalue, t7_res_lvl);

                test7.Visible = false;
                tests[7].testcompletestatus = true;
                t7status.Image = imageList1.Images[0];
                SelectTest.Visible = true;
                progressBar1.Value += 10;
                SaveResult();
            }
            catch (Exception ex)
            {
                Message.ShowErrorText(ex.Message);
            }
        }

        private void t6Next_Click(object sender, EventArgs e)
        {
            try
            {
                #region answerlist
                ComboBox[] answerlist = new ComboBox[18];
                answerlist[0] = t6a1;
                answerlist[1] = t6a2;
                answerlist[2] = t6a3;
                answerlist[3] = t6a4;
                answerlist[4] = t6a5;
                answerlist[5] = t6a6;
                answerlist[6] = t6a7;
                answerlist[7] = t6a8;
                answerlist[8] = t6a9;
                answerlist[9] = t6a10;
                answerlist[10] = t6a11;
                answerlist[11] = t6a12;
                answerlist[12] = t6a13;
                answerlist[13] = t6a14;
                answerlist[14] = t6a15;
                answerlist[15] = t6a16;
                answerlist[16] = t6a17;
                answerlist[17] = t6a18;
                #endregion
                int sum = 0;
                foreach (ComboBox ans in answerlist)
                {
                    if (ans.SelectedIndex == -1) throw NotAllAnswers;
                    sum += Convert.ToInt16(ans.SelectedItem.ToString());
                }

                tests[6].resultvalue = sum;
                t6_res_num.Text = tests[6].resultvalue.ToString() + "/162";
                tests[6].resultlvl = getLvl(130, 70, tests[6].resultvalue, t6_res_lvl);

                test6.Visible = false;
                tests[6].testcompletestatus = true;
                t6status.Image = imageList1.Images[0];
                SelectTest.Visible = true;
                progressBar1.Value += 10;
                SaveResult();
            }
            catch (Exception ex)
            {
                Message.ShowErrorText(ex.Message);
            }
        }

        private void t5Next_Click(object sender, EventArgs e)
        {
            try
            {
                #region checkanswers
                int sum = 0;
                if (t5a1.SelectedIndex == 1) sum++;
                if (t5a2.SelectedIndex == 1) sum++;
                if (t5a3.SelectedIndex == 1) sum++;
                if (t5a4.SelectedIndex == 2) sum++;
                if (t5a5.SelectedIndex == 1) sum++;
                if (t5a6.SelectedIndex == 2) sum++;
                if (t5a7.SelectedIndex == 1) sum++;
                if (t5a8.SelectedIndex == 2) sum++;
                if (t5a9.SelectedIndex == 1) sum++;
                if (t5a10.SelectedIndex == 0) sum++;
                if (t5a11.SelectedIndex == 2) sum++;
                if (t5a12.SelectedIndex == 0) sum++;
                if (t5a13.SelectedIndex == 0) sum++;
                if (t5a1.SelectedIndex == -1 || t5a2.SelectedIndex == -1 || t5a3.SelectedIndex == -1 || t5a4.SelectedIndex == -1 ||
                    t5a5.SelectedIndex == -1 || t5a6.SelectedIndex == -1 || t5a7.SelectedIndex == -1 || t5a8.SelectedIndex == -1 || t5a9.SelectedIndex == -1 ||
                    t5a10.SelectedIndex == -1 || t5a11.SelectedIndex == -1 || t5a12.SelectedIndex == -1 || t5a13.SelectedIndex == -1) throw NotAllAnswers;
                #endregion

                tests[5].resultvalue = sum;
                t5_res_num.Text = tests[5].resultvalue.ToString() + "/13";
                tests[5].resultlvl = getLvl(9, 4, tests[5].resultvalue, t5_res_lvl);

                test5.Visible = false;
                tests[5].testcompletestatus = true;
                t5status.Image = imageList1.Images[0];
                SelectTest.Visible = true;
                progressBar1.Value += 10;
                SaveResult();
            }
            catch (Exception ex)
            {
                Message.ShowErrorText(ex.Message);
            }
        }
        private void t4a1_DropDown(object sender, EventArgs e)
        {
            ComboBox answerlist = (ComboBox)sender;
            answerlist.Items.Clear();

            if (Convert.ToInt32(answerlist.Tag) != -1) t4anscase[Convert.ToInt32(answerlist.Tag) - 1] = false;
            int max_i;
            if (test0_1.Visible) max_i = 15;
            else if (test0_2.Visible) max_i = 10;
            else max_i = 18;

            for (int i = 0; i < max_i; i++)
                if (!t4anscase[i]) answerlist.Items.Add(i + 1);
        }

        private void t4a1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox answerlist = (ComboBox)sender;
            if (Convert.ToInt32(answerlist.Tag) != -1)
                t4anscase[Convert.ToInt32(answerlist.Tag) - 1] = false;
            if (answerlist.SelectedIndex != -1)
                t4anscase[Convert.ToInt32(answerlist.Items[answerlist.SelectedIndex]) - 1] = true;

            answerlist.Tag = answerlist.Items[answerlist.SelectedIndex];
        }
        private void t4Next_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < 18; i++)
                    if (!t4anscase[i]) throw NotAllAnswers;

                SpecialTest test = (SpecialTest)tests[4];
                test.resultvalue[0] = Convert.ToInt32(t4a1.Items[t4a1.SelectedIndex]);
                test.resultvalue[1] = Convert.ToInt32(t4a2.Items[t4a2.SelectedIndex]);
                test.resultvalue[2] = Convert.ToInt32(t4a3.Items[t4a3.SelectedIndex]);
                test.resultvalue[3] = Convert.ToInt32(t4a4.Items[t4a4.SelectedIndex]);
                test.resultvalue[4] = Convert.ToInt32(t4a5.Items[t4a5.SelectedIndex]);
                test.resultvalue[5] = Convert.ToInt32(t4a6.Items[t4a6.SelectedIndex]);
                test.resultvalue[6] = Convert.ToInt32(t4a7.Items[t4a7.SelectedIndex]);
                test.resultvalue[7] = Convert.ToInt32(t4a8.Items[t4a8.SelectedIndex]);
                test.resultvalue[8] = Convert.ToInt32(t4a9.Items[t4a9.SelectedIndex]);
                test.resultvalue[9] = Convert.ToInt32(t4a10.Items[t4a10.SelectedIndex]);
                test.resultvalue[10] = Convert.ToInt32(t4a11.Items[t4a11.SelectedIndex]);
                test.resultvalue[11] = Convert.ToInt32(t4a12.Items[t4a12.SelectedIndex]);
                test.resultvalue[12] = Convert.ToInt32(t4a13.Items[t4a13.SelectedIndex]);
                test.resultvalue[13] = Convert.ToInt32(t4a14.Items[t4a14.SelectedIndex]);
                test.resultvalue[14] = Convert.ToInt32(t4a15.Items[t4a15.SelectedIndex]);
                test.resultvalue[15] = Convert.ToInt32(t4a16.Items[t4a16.SelectedIndex]);
                test.resultvalue[16] = Convert.ToInt32(t4a17.Items[t4a17.SelectedIndex]);
                test.resultvalue[17] = Convert.ToInt32(t4a18.Items[t4a18.SelectedIndex]);

                for (int i = 0; i < 18; i++) t4anscase[i] = false;
                test4.Visible = false;
                test.testcompletestatus = true;
                t4status.Image = imageList1.Images[0];
                SelectTest.Visible = true;
                progressBar1.Value += 10;
                SaveResult();
            }
            catch (Exception ex)
            {
                Message.ShowErrorText(ex.Message);
            }
        }

        private void t3Next_Click(object sender, EventArgs e)
        {
            try
            {
                float sum1 = 0, sum2 = 0, sum3 = 0, sum4 = 0, sum5 = 0, sum6 = 0, sum7 = 0;
                #region answerlist
                if (t3a7.SelectedIndex == -1) throw NotAllAnswers; else sum1 += Convert.ToInt16(t3a7.Items[t3a7.SelectedIndex]);
                if (t3a10.SelectedIndex == -1) throw NotAllAnswers; else sum1 += Convert.ToInt16(t3a10.Items[t3a10.SelectedIndex]);
                if (t3a14.SelectedIndex == -1) throw NotAllAnswers; else sum1 += Convert.ToInt16(t3a14.Items[t3a14.SelectedIndex]);
                if (t3a32.SelectedIndex == -1) throw NotAllAnswers; else sum1 += Convert.ToInt16(t3a32.Items[t3a32.SelectedIndex]);

                if (t3a6.SelectedIndex == -1) throw NotAllAnswers; else sum2 += Convert.ToInt16(t3a6.Items[t3a6.SelectedIndex]);
                if (t3a12.SelectedIndex == -1) throw NotAllAnswers; else sum2 += Convert.ToInt16(t3a12.Items[t3a12.SelectedIndex]);
                if (t3a13.SelectedIndex == -1) throw NotAllAnswers; else sum2 += Convert.ToInt16(t3a13.Items[t3a13.SelectedIndex]);
                if (t3a15.SelectedIndex == -1) throw NotAllAnswers; else sum2 += Convert.ToInt16(t3a15.Items[t3a15.SelectedIndex]);
                if (t3a19.SelectedIndex == -1) throw NotAllAnswers; else sum2 += Convert.ToInt16(t3a19.Items[t3a19.SelectedIndex]);

                if (t3a8.SelectedIndex == -1) throw NotAllAnswers; else sum3 += Convert.ToInt16(t3a8.Items[t3a8.SelectedIndex]);
                if (t3a9.SelectedIndex == -1) throw NotAllAnswers; else sum3 += Convert.ToInt16(t3a9.Items[t3a9.SelectedIndex]);
                if (t3a29.SelectedIndex == -1) throw NotAllAnswers; else sum3 += Convert.ToInt16(t3a29.Items[t3a29.SelectedIndex]);
                if (t3a30.SelectedIndex == -1) throw NotAllAnswers; else sum3 += Convert.ToInt16(t3a30.Items[t3a30.SelectedIndex]);
                if (t3a34.SelectedIndex == -1) throw NotAllAnswers; else sum3 += Convert.ToInt16(t3a34.Items[t3a34.SelectedIndex]);

                if (t3a1.SelectedIndex == -1) throw NotAllAnswers; else sum4 += Convert.ToInt16(t3a1.Items[t3a1.SelectedIndex]);
                if (t3a2.SelectedIndex == -1) throw NotAllAnswers; else sum4 += Convert.ToInt16(t3a2.Items[t3a2.SelectedIndex]);
                if (t3a3.SelectedIndex == -1) throw NotAllAnswers; else sum4 += Convert.ToInt16(t3a3.Items[t3a3.SelectedIndex]);
                if (t3a4.SelectedIndex == -1) throw NotAllAnswers; else sum4 += Convert.ToInt16(t3a4.Items[t3a4.SelectedIndex]);
                if (t3a5.SelectedIndex == -1) throw NotAllAnswers; else sum4 += Convert.ToInt16(t3a5.Items[t3a5.SelectedIndex]);
                if (t3a26.SelectedIndex == -1) throw NotAllAnswers; else sum4 += Convert.ToInt16(t3a26.Items[t3a26.SelectedIndex]);

                if (t3a27.SelectedIndex == -1) throw NotAllAnswers; else sum5 += Convert.ToInt16(t3a27.Items[t3a27.SelectedIndex]);
                if (t3a28.SelectedIndex == -1) throw NotAllAnswers; else sum5 += Convert.ToInt16(t3a28.Items[t3a28.SelectedIndex]);

                if (t3a17.SelectedIndex == -1) throw NotAllAnswers; else sum6 += Convert.ToInt16(t3a17.Items[t3a17.SelectedIndex]);
                if (t3a18.SelectedIndex == -1) throw NotAllAnswers; else sum6 += Convert.ToInt16(t3a18.Items[t3a18.SelectedIndex]);
                if (t3a20.SelectedIndex == -1) throw NotAllAnswers; else sum6 += Convert.ToInt16(t3a20.Items[t3a20.SelectedIndex]);
                if (t3a21.SelectedIndex == -1) throw NotAllAnswers; else sum6 += Convert.ToInt16(t3a21.Items[t3a21.SelectedIndex]);
                if (t3a22.SelectedIndex == -1) throw NotAllAnswers; else sum6 += Convert.ToInt16(t3a22.Items[t3a22.SelectedIndex]);
                if (t3a23.SelectedIndex == -1) throw NotAllAnswers; else sum6 += Convert.ToInt16(t3a23.Items[t3a23.SelectedIndex]);
                if (t3a24.SelectedIndex == -1) throw NotAllAnswers; else sum6 += Convert.ToInt16(t3a24.Items[t3a24.SelectedIndex]);

                if (t3a11.SelectedIndex == -1) throw NotAllAnswers; else sum7 += Convert.ToInt16(t3a11.Items[t3a11.SelectedIndex]);
                if (t3a16.SelectedIndex == -1) throw NotAllAnswers; else sum7 += Convert.ToInt16(t3a16.Items[t3a16.SelectedIndex]);
                if (t3a25.SelectedIndex == -1) throw NotAllAnswers; else sum7 += Convert.ToInt16(t3a25.Items[t3a25.SelectedIndex]);
                if (t3a31.SelectedIndex == -1) throw NotAllAnswers; else sum7 += Convert.ToInt16(t3a31.Items[t3a31.SelectedIndex]);
                if (t3a33.SelectedIndex == -1) throw NotAllAnswers; else sum7 += Convert.ToInt16(t3a33.Items[t3a33.SelectedIndex]);
                #endregion

                sum1 /= 4;
                sum2 /= 5;
                sum3 /= 5;
                sum4 /= 6;
                sum5 /= 2;
                sum6 /= 7;
                sum7 /= 5;
                SpecialTest test = (SpecialTest)tests[3];
                test.resultvalue[0] = (int)(sum1 * 100);
                test.resultvalue[1] = (int)(sum2 * 100);
                test.resultvalue[2] = (int)(sum3 * 100);
                test.resultvalue[3] = (int)(sum4 * 100);
                test.resultvalue[4] = (int)(sum5 * 100);
                test.resultvalue[5] = (int)(sum6 * 100);
                test.resultvalue[6] = (int)(sum7 * 100);

                t3_res_num1.Text = sum1.ToString("F1") + "/5";
                t3_res_num2.Text = sum2.ToString("F1") + "/5";
                t3_res_num3.Text = sum3.ToString("F1") + "/5";
                t3_res_num4.Text = sum4.ToString("F1") + "/5";
                t3_res_num5.Text = sum5.ToString("F1") + "/5";
                t3_res_num6.Text = sum6.ToString("F1") + "/5";
                t3_res_num7.Text = sum7.ToString("F1") + "/5";

                getLvl(400, 200, test.resultvalue[0], t3_res_lvl1);
                getLvl(400, 200, test.resultvalue[1], t3_res_lvl2);
                getLvl(400, 200, test.resultvalue[2], t3_res_lvl3);
                getLvl(400, 200, test.resultvalue[3], t3_res_lvl4);
                getLvl(400, 200, test.resultvalue[4], t3_res_lvl5);
                getLvl(400, 200, test.resultvalue[5], t3_res_lvl6);
                getLvl(400, 200, test.resultvalue[6], t3_res_lvl7);

                test3.Visible = false;
                test.testcompletestatus = true;
                t3status.Image = imageList1.Images[0];
                SelectTest.Visible = true;
                progressBar1.Value += 10;
                SaveResult();
            }
            catch (Exception ex)
            {
                Message.ShowErrorText(ex.Message);
            }

        }

        private void t2Next_Click(object sender, EventArgs e)
        {
            try
            {
                #region answerlist
                ComboBox[] answerlist = new ComboBox[32];
                answerlist[0] = t2a2;
                answerlist[1] = t2a3;
                answerlist[2] = t2a4;
                answerlist[3] = t2a5;
                answerlist[4] = t2a7;
                answerlist[5] = t2a8;
                answerlist[6] = t2a9;
                answerlist[7] = t2a10;
                answerlist[8] = t2a14;
                answerlist[9] = t2a15;
                answerlist[10] = t2a16;
                answerlist[11] = t2a17;
                answerlist[12] = t2a21;
                answerlist[13] = t2a22;
                answerlist[14] = t2a25;
                answerlist[15] = t2a26;
                answerlist[16] = t2a27;
                answerlist[17] = t2a28;
                answerlist[18] = t2a29;
                answerlist[19] = t2a30;
                answerlist[20] = t2a32;
                answerlist[21] = t2a37;
                answerlist[22] = t2a41;
                answerlist[23] = t2a6;
                answerlist[24] = t2a18;
                answerlist[25] = t2a19;
                answerlist[26] = t2a20;
                answerlist[27] = t2a24;
                answerlist[28] = t2a31;
                answerlist[29] = t2a36;
                answerlist[30] = t2a38;
                answerlist[31] = t2a39;
                #endregion
                int sum = 0;
                for (int i = 0; i < 32; i++)
                {
                    if (i < 23) { if (answerlist[i].SelectedItem.ToString() == "Так") sum++; }
                    else if ((answerlist[i].SelectedItem.ToString() != "Так")) sum++;
                }

                tests[2].resultvalue = sum;
                t2_res_num.Text = tests[2].resultvalue.ToString() + "/32";
                tests[2].resultlvl = getLvl(20, 11, tests[2].resultvalue, t2_res_lvl);

                test2.Visible = false;
                t2status.Image = imageList1.Images[0];
                tests[2].testcompletestatus = true;
                SelectTest.Visible = true;
                progressBar1.Value += 10;
                SaveResult();

            }
            catch (Exception ex)
            {
                Message.ShowErrorText(ex.Message);
            }
        }
        private void t1Next_Click(object sender, EventArgs e)
        {
            try
            {
                #region answerlist
                ComboBox[] answerlist = new ComboBox[15];
                answerlist[0] = t1a1;
                answerlist[1] = t1a2;
                answerlist[2] = t1a3;
                answerlist[3] = t1a4;
                answerlist[4] = t1a5;
                answerlist[5] = t1a6;
                answerlist[6] = t1a7;
                answerlist[7] = t1a8;
                answerlist[8] = t1a9;
                answerlist[9] = t1a10;
                answerlist[10] = t1a11;
                answerlist[11] = t1a12;
                answerlist[12] = t1a13;
                answerlist[13] = t1a14;
                answerlist[14] = t1a15;
                #endregion
                int sum = 0;
                foreach (ComboBox ans in answerlist)
                {
                    if (ans.SelectedIndex == -1) throw NotAllAnswers;
                    sum += Convert.ToInt16(ans.SelectedItem.ToString());
                }

                tests[1].resultvalue = sum;
                t1_res_num.Text = tests[1].resultvalue.ToString() + "/75";
                tests[1].resultlvl = getLvl(55, 36, tests[1].resultvalue, t1_res_lvl);

                test1.Visible = false;
                t1status.Image = imageList1.Images[0];
                tests[1].testcompletestatus = true;
                SelectTest.Visible = true;
                progressBar1.Value += 10;
                SaveResult();
            }
            catch (Exception ex)
            {
                Message.ShowErrorText(ex.Message);
            }
        }
        private void t0_1Next_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < 15; i++)
                    if (!t4anscase[i]) throw NotAllAnswers;

                for (int i = 0; i < 15; i++) t4anscase[i] = false;
                test0_1.Visible = false;
                test0_2.Visible = true;
            }
            catch (Exception ex)
            {
                Message.ShowErrorText(ex.Message);
            }
        }

        private void t0_2Next_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < 10; i++)
                    if (!t4anscase[i]) throw NotAllAnswers;

                SpecialTest test = (SpecialTest)tests[0];
                test.resultvalue[0] = Convert.ToInt32(t0_1a1.Items[t0_1a1.SelectedIndex]);
                test.resultvalue[1] = Convert.ToInt32(t0_1a2.Items[t0_1a2.SelectedIndex]);
                test.resultvalue[2] = Convert.ToInt32(t0_1a3.Items[t0_1a3.SelectedIndex]);
                test.resultvalue[3] = Convert.ToInt32(t0_1a4.Items[t0_1a4.SelectedIndex]);
                test.resultvalue[4] = Convert.ToInt32(t0_1a5.Items[t0_1a5.SelectedIndex]);
                test.resultvalue[5] = Convert.ToInt32(t0_1a6.Items[t0_1a6.SelectedIndex]);
                test.resultvalue[6] = Convert.ToInt32(t0_1a7.Items[t0_1a7.SelectedIndex]);
                test.resultvalue[7] = Convert.ToInt32(t0_1a8.Items[t0_1a8.SelectedIndex]);
                test.resultvalue[8] = Convert.ToInt32(t0_1a9.Items[t0_1a9.SelectedIndex]);
                test.resultvalue[9] = Convert.ToInt32(t0_1a10.Items[t0_1a10.SelectedIndex]);
                test.resultvalue[10] = Convert.ToInt32(t0_1a11.Items[t0_1a11.SelectedIndex]);
                test.resultvalue[11] = Convert.ToInt32(t0_1a12.Items[t0_1a12.SelectedIndex]);
                test.resultvalue[12] = Convert.ToInt32(t0_1a13.Items[t0_1a13.SelectedIndex]);
                test.resultvalue[13] = Convert.ToInt32(t0_1a14.Items[t0_1a14.SelectedIndex]);
                test.resultvalue[14] = Convert.ToInt32(t0_1a15.Items[t0_1a15.SelectedIndex]);
                test.resultvalue[15] = Convert.ToInt32(t0_2a1.Items[t0_2a1.SelectedIndex]);
                test.resultvalue[16] = Convert.ToInt32(t0_2a2.Items[t0_2a2.SelectedIndex]);
                test.resultvalue[17] = Convert.ToInt32(t0_2a3.Items[t0_2a3.SelectedIndex]);
                test.resultvalue[18] = Convert.ToInt32(t0_2a4.Items[t0_2a4.SelectedIndex]);
                test.resultvalue[19] = Convert.ToInt32(t0_2a5.Items[t0_2a5.SelectedIndex]);
                test.resultvalue[20] = Convert.ToInt32(t0_2a6.Items[t0_2a6.SelectedIndex]);
                test.resultvalue[21] = Convert.ToInt32(t0_2a7.Items[t0_2a7.SelectedIndex]);
                test.resultvalue[22] = Convert.ToInt32(t0_2a8.Items[t0_2a8.SelectedIndex]);
                test.resultvalue[23] = Convert.ToInt32(t0_2a9.Items[t0_2a9.SelectedIndex]);
                test.resultvalue[24] = Convert.ToInt32(t0_2a10.Items[t0_2a10.SelectedIndex]);

                for (int i = 0; i < 15; i++) t4anscase[i] = false;
                test0_2.Visible = false;
                t0status.Image = imageList1.Images[0];
                test.testcompletestatus = true;
                SelectTest.Visible = true;
                progressBar1.Value += 10;
                SaveResult();
            }
            catch (Exception ex)
            {
                Message.ShowErrorText(ex.Message);
            }
        }

        private void test_MouseEnter(object sender, EventArgs e)
        {
            ((Panel)sender).Focus();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool flag = false;
            foreach (Test t in tests)
                if (t.testcompletestatus == true && t.testsavingstatus == false) flag = true;
            if (flag)
                if (MessageBox.Show("Не все результаты сохранены, вы уверены что хотите закрыть приложение?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    e.Cancel = true;
                    SaveResult();
                }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.PaleGreen;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.LightBlue;
        }
        private void gotot0_Click(object sender, EventArgs e)
        {
            SelectTest.Visible = false;
            if (!tests[0].testcompletestatus)
            {
                test0_1.Visible = true;
                Message.ShowHelpText("Проранжуйте професійно важливі та особистісні якості конкурентоспроможного фахівця з інформаційних технологій за ступенем їх важливості (найважливіша – 1 ранг) ");
                test0_1.AutoScrollPosition = new Point(0, 0);
            }
            else t_res.Visible = true;

        }

        private void gotot1_Click(object sender, EventArgs e)
        {
            SelectTest.Visible = false;
            if (!tests[1].testcompletestatus)
            {
                test1.Visible = true;
                Message.ShowHelpText("Відповідаючи на запитання анкети, поставте, будь ласка, бали, відповідні вашу думку:  5 - якщо дане твердження повністю відповідає дійсності; ");
                test1.AutoScrollPosition = new Point(0, 0);
            }
            else t_res.Visible = true;
        }

        private void gotot2_Click(object sender, EventArgs e)
        {
            SelectTest.Visible = false;
            if (!tests[2].testcompletestatus)
            {
                test2.Visible = true;
                Message.ShowHelpText("Тестовий матеріал являє собою 41 твердження, на які вам необхідно дати один з двох варіантів відповідей «так» або «ні». ");
                test2.AutoScrollPosition = new Point(0, 0);
            }
            else t_res.Visible = true;
        }

        private void gotot3_Click(object sender, EventArgs e)
        {
            SelectTest.Visible = false;
            if (!tests[3].testcompletestatus)
            {
                test3.Visible = true;
                Message.ShowHelpText("Оцініть за 5-бальною системою приведені мотиви учбової діяльності по значущості для Вас: 1 бал  відповідає мінімальній значущості мотиву, 5 балів – максимальний.");
                test3.AutoScrollPosition = new Point(0, 0);
            }
            else t_res.Visible = true;
        }

        private void gotot4_Click(object sender, EventArgs e)
        {
            SelectTest.Visible = false;
            if (!tests[4].testcompletestatus)
            {
                test4.Visible = true;
                Message.ShowHelpText("Проранжуйте список із 18 тверджень-цінностей по значимості для вас, як принципів, якими Ви керуєтеся у житті. Уважно вивчіть твердження, найбільш значиме – на перше місце. Найменш важлива залишиться останньої й займе 18 місце.");
                test4.AutoScrollPosition = new Point(0, 0);
            }
            else t_res.Visible = true;
        }

        private void gotot5_Click(object sender, EventArgs e)
        {
            SelectTest.Visible = false;
            if (!tests[5].testcompletestatus)
            {
                test5.Visible = true;
                Message.ShowHelpText("У кожному питанні відзначте один варіант відповіді, який ви вважаєте правильним.");
                test5.AutoScrollPosition = new Point(0, 0);
            }
            else t_res.Visible = true;
        }

        private void gotot6_Click(object sender, EventArgs e)
        {
            SelectTest.Visible = false;
            if (!tests[6].testcompletestatus)
            {
                test6.Visible = true;
                Message.ShowHelpText("За 9-бальною шкалою оцініть кожне з 18 тверджень");
                test6.AutoScrollPosition = new Point(0, 0);
            }
            else t_res.Visible = true;
        }

        private void gotot7_Click(object sender, EventArgs e)
        {
            SelectTest.Visible = false;
            if (!tests[7].testcompletestatus)
            {
                test7.Visible = true;
                Message.ShowHelpText("Під номерами від 1 до 70 дано відповідні завдання у вигляді малюнків та пов'язаних з ними питань. Під кожним із запитань, у свою чергу, дані три варіанти можливих відповідей на нього, причому тільки один з них є правильним. ");
                test7.AutoScrollPosition = new Point(0, 0);
            }
            else t_res.Visible = true;
        }

        private void gotot8_Click(object sender, EventArgs e)
        {
            SelectTest.Visible = false;
            if (!tests[8].testcompletestatus)
            {
                test8.Visible = true;
                Message.ShowHelpText("Тест включає кілька тверджень, що вимагають однозначної відповіді («так» або «ні»).");
                test8.AutoScrollPosition = new Point(0, 0);
            }
            else t_res.Visible = true;
        }

        private void gotot9_Click(object sender, EventArgs e)
        {
            SelectTest.Visible = false;
            if (!tests[9].testcompletestatus)
            {
                test9.Visible = true;
                Message.ShowHelpText("Оцініть ступінь своєї готовності здійснити зазначені дії. Відповідаючи на кожне з 25 запитань, поставте відповідний бал за такою схемою:\n 2 бали — цілком згоден, «так»;\n 1 бал — швидше «так», ніж «ні»;\n 0 балів — ні «так», ні «ні», щось середнє;\n -1 бал — швидше «ні», ніж «так»;\n -2 бали — абсолютно не згоден «ні».");
                test9.AutoScrollPosition = new Point(0, 0);
            }
            else t_res.Visible = true;
        }

        private void gotot10_Click(object sender, EventArgs e)
        {
            SelectTest.Visible = false;
            if (!tests[10].testcompletestatus)
            {
                test10.Visible = true;
                Message.ShowHelpText("Для визначення Вашого рівня комунікативності слід відповісти на запропоновані нижче запитання. Варіанти відповідей: «так», «ні», «іноді».");
                test10.AutoScrollPosition = new Point(0, 0);
            }
            else t_res.Visible = true;
        }

        private void gotot11_Click(object sender, EventArgs e)
        {
            SelectTest.Visible = false;
            if (!tests[11].testcompletestatus)
            {
                test11.Visible = true;
                Message.ShowHelpText("Перед вами 20 питань, які потребують однозначної відповіді «так» або «ні».");
                test11.AutoScrollPosition = new Point(0, 0);
            }
            else t_res.Visible = true;
        }

        private void gotot12_Click(object sender, EventArgs e)
        {
            SelectTest.Visible = false;
            if (!tests[12].testcompletestatus)
            {
                test12.Visible = true;
                Message.ShowHelpText("Визначте, будь ласка, ступінь прояву у Вас наведених нижче особистісних якостей в балах. Оцінюйте найближчий рік життя. Вибирайте одну відповідь з трьох можливих, за шкалою 1-2-3.  Шкала можливих відповідей: 1  – слабка вираженість якості; 2 – середня вираженість якості; 3 – висока вираженість якості. ");
                test12.AutoScrollPosition = new Point(0, 0);
            }
            else t_res.Visible = true;
        }

        private void gotot13_Click(object sender, EventArgs e)
        {
            SelectTest.Visible = false;
            if (!tests[13].testcompletestatus)
            {
                test13.Visible = true;
                Message.ShowHelpText("У бланку  відповідей напроти номера питання проставте, будь ласка, цифру, відповідну Вашого варіанту відповіді: 1 – абсолютно невірно;\n 2 – невірно;\n 3 – швидше невірно;\n 4 – не знаю;\n 5 – швидше вірно;\n 6 – вірно;\n 7 – абсолютно вірно.\n");
                test13.AutoScrollPosition = new Point(0, 0);
            }
            else t_res.Visible = true;
        }
        private void gotot14_Click(object sender, EventArgs e)
        {
            SelectTest.Visible = false;
            if (!tests[14].testcompletestatus)
            {
                test14.Visible = true;
                Message.ShowHelpText("Для визначення Вашого рівня колективізму слід визначити прийнятний для Вас варіант відповіді: а, б чи c.");
                test14.AutoScrollPosition = new Point(0, 0);
            }
            else t_res.Visible = true;
        }
        private void gotot15_Click(object sender, EventArgs e)
        {
            SelectTest.Visible = false;
            if (!tests[15].testcompletestatus)
            {
                test15.Visible = true;
                Message.ShowHelpText("Дайте відповіді на питання.");
                test15.AutoScrollPosition = new Point(0, 0);
            }
            else t_res.Visible = true;
        }
        private void teststatus_Click(object sender, EventArgs e)
        {
            t_res.Visible = true;
            SelectTest.Visible = false;
        }

        private void t_res_Back_Click(object sender, EventArgs e)
        {
            t_res.Visible = false;
            SelectTest.Visible = true;
        }

        
    }
}
