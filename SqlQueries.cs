using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Diagnostics
{
    class SqlQueries
    {
        private MySqlConnection conn;
        private string FIO, group;
        private bool sex;
        private int id = 0;
        public SqlQueries(String FIO, String group, bool sex)
        {
            this.FIO = FIO;
            this.group = group;
            this.sex = sex;
            string connstr = String.Format("server={0};user={1};database={2};port=3306;password={3}", Properties.Settings.Default.host, Properties.Settings.Default.user, Properties.Settings.Default.DBname, Properties.Settings.Default.password);
            conn = new MySqlConnection(connstr);
        }
        public SqlQueries()
        {
            string connstr = String.Format("server={0};user={1};database={2};port=3306;password={3}", Properties.Settings.Default.host, Properties.Settings.Default.user, Properties.Settings.Default.DBname, Properties.Settings.Default.password);
            conn = new MySqlConnection(connstr);
        }
        public SqlQueries(string host, string user, string DBname, string password)
        {
            string connstr = String.Format("server={0};user={1};database={2};port=3306;password={3}", host, user, DBname, password);
            conn = new MySqlConnection(connstr);
        }
        public void ConnectionClose()
        {
            conn.Close();
        }
        private bool GetId()
        {
            try
            {
                MySqlException error = null;

                MySqlCommand command = new MySqlCommand("SELECT `id` FROM `student_name` WHERE `Name`=@name AND `GroupName`=@group", conn);
                command.Parameters.Add(new MySqlParameter("@name", FIO));
                command.Parameters.Add(new MySqlParameter("@group", group));
                object obj = command.ExecuteScalar();

                if (obj != null) id = (int)obj;
                else if (!SaveStudent()) throw error;

                return true;
            }
            catch (MySqlException ex)
            {
                Message.Savelog(ex);
                return false;
            }
        }
        private bool SaveStudent()
        {
            try
            {
                MySqlCommand command = new MySqlCommand("INSERT INTO `student_name`(`Name`, `GroupName`, `sex`) VALUES (@name,@group,@sex)", conn);
                command.Parameters.Add(new MySqlParameter("@name", FIO));
                command.Parameters.Add(new MySqlParameter("@group", group));
                command.Parameters.Add(new MySqlParameter("@sex", sex));
                command.ExecuteNonQuery();
                command = new MySqlCommand("SELECT MAX(`id`) FROM student_name", conn);
                id = (int)(command.ExecuteScalar());

                return true;
            }
            catch (MySqlException ex)
            {
                Message.Savelog(ex);
                return false;
            }
        }
        private bool DeleteLine(string testName)
        {
            try
            {
                MySqlCommand command;
                command = new MySqlCommand(String.Format("SELECT `id` FROM `{0}` WHERE `id`={1}", testName, id), conn);
                object obj = command.ExecuteScalar();
                if (obj != null)
                {
                    command = new MySqlCommand(String.Format("DELETE FROM `{0}` WHERE `id`={1}", testName, id), conn);
                    command.ExecuteNonQuery();
                }

                return true;
            }
            catch (MySqlException ex)
            {
                Message.Savelog(ex);
                return false;
            }
        }
        public bool SaveResult(Test t)
        {
            try
            {
                Exception error = new Exception();

                conn.Open();
                if (id == 0) if (!GetId()) throw error;
                if (!DeleteLine(t.testname)) throw error;

                MySqlCommand command;
                command = new MySqlCommand(String.Format("INSERT INTO `{0}`(`id`, `value`, `lvl`) VALUES ({1},{2},{3})", t.testname, id, t.resultvalue, t.resultlvl), conn);
                command.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                Message.Savelog(ex);
                Message.ShowErrorText("Ошибка подключения к Базе Данных. Проверьте сетевое подключение или обратитесь к администратору");
                return false;
            }
            finally
            {
                ConnectionClose();
            }
        }
        public bool SaveResult(SpecialTest st)
        {
            try
            {
                MySqlException error = null;

                conn.Open();
                if (id == 0) if (!GetId()) throw error;
                if (!DeleteLine(st.testname)) throw error;

                StringBuilder sb = new StringBuilder("INSERT INTO ");
                switch (st.testname)
                {
                    case "test0":
                        {
                            sb.AppendFormat("`{0}`(`id` , `par1_1` , `par1_2` , `par1_3` , `par1_4` , `par1_5` , `par1_6` , `par1_7` , `par1_8` , `par1_9` , `par1_10` , `par1_11` , `par1_12` , `par1_13` , `par1_14` , `par1_15` , `par2_1` , `par2_2` , `par2_3` , `par2_4` , `par2_5` , `par2_6` , `par2_7` , `par2_8` , `par2_9` , `par2_10` ) VALUES ({1}", st.testname, id);
                            for (int i = 0; i < 25; i++)
                                sb.AppendFormat(",{0}", st.resultvalue[i]);
                            break;
                        }

                    case "test3":
                        {
                            sb.AppendFormat("`{0}`(`id`, `scale1`, `scale2`, `scale3`, `scale4`, `scale5`, `scale6`, `scale7`) VALUES ({1}", st.testname, id);
                            for (int i = 0; i < 7; i++)
                                sb.AppendFormat(",{0}", st.resultvalue[i]);
                            break;
                        }
                    case "test4":
                        {
                            sb.AppendFormat("`{0}`(`id`, `par1`, `par2`, `par3`, `par4`, `par5`, `par6`, `par7`, `par8`, `par9`, `par10`, `par11`, `par12`, `par13`, `par14`, `par15`, `par16`, `par17`, `par18`) VALUES ({1}", st.testname, id);
                            for (int i = 0; i < 18; i++)
                                sb.AppendFormat(",{0}", st.resultvalue[i]);
                            break;
                        }
                }
                sb.Append(")");

                MySqlCommand command;
                command = new MySqlCommand(sb.ToString(), conn);
                command.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                Message.ShowErrorText("Ошибка подключения к Базе Данных. Проверьте сетевое подключение или обратитесь к администратору");
                Message.Savelog(ex);
                return false;
            }
            finally
            {
                ConnectionClose();
            }
        }
        public MySqlDataReader SelectResult(string testName, string StudentName, string GroupName, string sex)
        {
            try
            {
                Task t = Task.Run(() =>
                {
                    try
                    {
                        conn.Open();
                    }
                    catch
                    {
                    }
                }
                    );

                bool paramsused = false;

                StringBuilder sb = new StringBuilder();
                switch (testName)
                {
                    case "test0":
                        {
                            sb.Append("SELECT s.Name, s.GroupName, s.sex, t.par1_1, t.par1_2, t.par1_3, t.par1_4, t.par1_5, t.par1_6, t.par1_7, t.par1_8, t.par1_9, t.par1_10, t.par1_11, t.par1_12, t.par1_13, t.par1_14, t.par1_15, t.par2_1, t.par2_2, t.par2_3, t.par2_4, t.par2_5, t.par2_6, t.par2_7, t.par2_8, t.par2_9, t.par2_10 FROM student_name s,");
                            break;
                        }
                    case "test3":
                        {
                            sb.Append("SELECT s.Name, s.GroupName, s.sex, t.scale1, t.scale2, t.scale3, t.scale4, t.scale5, t.scale6, t.scale7 FROM student_name s,");
                            break;
                        }
                    case "test4":
                        {
                            sb.Append("SELECT s.Name, s.GroupName, s.sex, t.par1, t.par2, t.par3, t.par4, t.par5, t.par6, t.par7, t.par8, t.par9, t.par10, t.par11, t.par12, t.par13, t.par14, t.par15, t.par16, t.par17, t.par18 FROM student_name s,");
                            break;
                        }
                    case "all":
                        {
                            sb.Append("SELECT * FROM student_name s");
                            break;
                        }
                    default:
                        {
                            sb.Append("SELECT s.Name, s.GroupName, s.sex, t.value, t.lvl FROM student_name s,");
                            break;
                        }
                }
                if (testName != "all") sb.AppendFormat(" {0} t WHERE ", testName);
                else if (StudentName != "" || GroupName != "" || sex != "") sb.Append(" WHERE ");
                if (StudentName != "")
                {
                    sb.AppendFormat("LOWER(s.Name) LIKE '%{0}%'", StudentName.Trim().ToLower());
                    paramsused = true;
                }
                if (GroupName != "")
                {
                    if (paramsused) sb.Append(" AND ");
                    sb.AppendFormat("s.GroupName='{0}'", GroupName);
                    paramsused = true;
                }
                if (sex != "")
                {
                    if (paramsused) sb.Append(" AND ");
                    sb.AppendFormat("s.sex={0}", sex);
                }
                if (paramsused && testName != "all") sb.Append(" AND ");
                if (testName != "all") sb.Append("t.id = s.id");

                MySqlCommand command = new MySqlCommand(sb.ToString(), conn);
                t.Wait();
                return command.ExecuteReader();


            }
            catch (Exception ex)
            {
                Message.Savelog(ex);
                Message.ShowErrorText("Ошибка подключения к Базе Данных. Проверьте сетевое подключение или обратитесь к администратору");
                return null;

            }
        }
        public void TestConnection()
        {
            try
            {
                conn.Open();


                MySqlCommand command;
                string commandstr;
                for (int i = 0; i < 16; i++)
                {
                    string testname = String.Format("test{0}", i);
                    switch (testname)
                    {
                        case "test0": { commandstr = "CREATE TABLE IF NOT EXISTS `test0` (  `id` int(11) NOT NULL,  `par1_1` tinyint(3) unsigned NOT NULL,  `par1_2` tinyint(3) unsigned NOT NULL,  `par1_3` tinyint(3) unsigned NOT NULL,  `par1_4` tinyint(3) unsigned NOT NULL,  `par1_5` tinyint(3) unsigned NOT NULL,  `par1_6` tinyint(3) unsigned NOT NULL,  `par1_7` tinyint(3) unsigned NOT NULL,  `par1_8` tinyint(3) unsigned NOT NULL,  `par1_9` tinyint(3) unsigned NOT NULL,  `par1_10` tinyint(3) unsigned NOT NULL,  `par1_11` tinyint(3) unsigned NOT NULL,  `par1_12` tinyint(3) unsigned NOT NULL,  `par1_13` tinyint(3) unsigned NOT NULL,  `par1_14` tinyint(3) unsigned NOT NULL,  `par1_15` tinyint(3) unsigned NOT NULL,  `par2_1` tinyint(3) unsigned NOT NULL,  `par2_2` tinyint(3) unsigned NOT NULL,  `par2_3` tinyint(3) unsigned NOT NULL,  `par2_4` tinyint(3) unsigned NOT NULL,  `par2_5` tinyint(3) unsigned NOT NULL,  `par2_6` tinyint(3) unsigned NOT NULL,  `par2_7` tinyint(3) unsigned NOT NULL,  `par2_8` tinyint(3) unsigned NOT NULL,  `par2_9` tinyint(3) unsigned NOT NULL,  `par2_10` tinyint(3) unsigned NOT NULL,  PRIMARY KEY (`id`) ) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;"; break; }
                        case "test3": { commandstr = "CREATE TABLE IF NOT EXISTS `test3` (`id` int(11) NOT NULL,`scale1` smallint(3) unsigned NOT NULL,`scale2` smallint(3) unsigned NOT NULL,`scale3` smallint(3) unsigned NOT NULL,`scale4` smallint(3) unsigned NOT NULL,`scale5` smallint(3) unsigned NOT NULL,`scale6` smallint(3) unsigned NOT NULL,`scale7` smallint(3) unsigned NOT NULL,PRIMARY KEY(`id`)) ENGINE = InnoDB DEFAULT CHARSET = utf8 COLLATE = utf8_unicode_ci; "; break; }
                        case "test4": { commandstr = "CREATE TABLE IF NOT EXISTS `test4` (`id` int(11) NOT NULL,`par1` tinyint(3) unsigned NOT NULL,`par2` tinyint(3) unsigned NOT NULL,`par3` tinyint(3) unsigned NOT NULL,`par4` tinyint(3) unsigned NOT NULL,`par5` tinyint(3) unsigned NOT NULL,`par6` tinyint(3) unsigned NOT NULL,`par7` tinyint(3) unsigned NOT NULL,`par8` tinyint(3) unsigned NOT NULL,`par9` tinyint(3) unsigned NOT NULL,`par10` tinyint(3) unsigned NOT NULL,`par11` tinyint(3) unsigned NOT NULL,`par12` tinyint(3) unsigned NOT NULL,`par13` tinyint(3) unsigned NOT NULL,`par14` tinyint(3) unsigned NOT NULL,`par15` tinyint(3) unsigned NOT NULL,`par16` tinyint(3) unsigned NOT NULL,`par17` tinyint(3) unsigned NOT NULL,`par18` tinyint(3) unsigned NOT NULL,PRIMARY KEY (`id`)) ENGINE = InnoDB DEFAULT CHARSET = utf8 COLLATE = utf8_unicode_ci; "; break; }
                        default: { commandstr = String.Format("CREATE TABLE IF NOT EXISTS `{0}` (`id` int(11) NOT NULL,`value` tinyint(3) unsigned NOT NULL,`lvl` tinyint(1) unsigned NOT NULL, PRIMARY KEY(`id`)) ENGINE = InnoDB  DEFAULT CHARSET = utf8 COLLATE = utf8_unicode_ci AUTO_INCREMENT = 3 ;", testname); break; }
                    }
                    command = new MySqlCommand(commandstr, conn);
                    command.ExecuteNonQuery();
                }
                commandstr = "CREATE TABLE IF NOT EXISTS `student_name` (`id` int(11) NOT NULL AUTO_INCREMENT,`Name` varchar(60) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,`GroupName` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,`sex` tinyint(1) NOT NULL,PRIMARY KEY(`id`)) ENGINE = InnoDB  DEFAULT CHARSET = utf8 COLLATE = utf8_unicode_ci;";
                command = new MySqlCommand(commandstr, conn);
                command.ExecuteNonQuery();

                ConnectionClose();
                Message.ShowHelpText("Подключение прошло успешно!");
            }
            catch (Exception ex)
            {
                Message.Savelog(ex);
                Message.ShowErrorText("Ошибка подключения к Базе Данных. Проверьте сетевое подключение или обратитесь к администратору");
            }
            finally
            {
                ConnectionClose();
            }
        }
    }
}
