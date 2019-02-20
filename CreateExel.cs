using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using MySql.Data.MySqlClient;
using System.IO;
using OfficeOpenXml.Drawing.Chart;

namespace Diagnostics
{
    static class CreateExel
    {

        private static FileInfo getReportFileName()
        {
            System.Windows.Forms.SaveFileDialog sd = new System.Windows.Forms.SaveFileDialog();
            sd.Filter = "Excel(*.xlsx)|*.xlsx|All files(*.*)|*.*";
            sd.DefaultExt = "xlsx";
            sd.AddExtension = true;
            sd.Title = "Сохранить отчёт";

            if (sd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo fi = new FileInfo(sd.FileName);
                if (fi.Exists)
                {
                    try
                    {
                        fi.Delete();
                        fi = new FileInfo(sd.FileName);
                    }
                    catch (Exception)
                    {
                        Message.ShowErrorText("Невозможно перезаписать файл, возможно он используется другим процессом!");
                        return null;
                    }
                }
                return fi;
            }
            else return null;
        }
        public static void GetReport(string testName, string StudentName, string GroupName, string sex)
        {
            SqlQueries sql = new SqlQueries();
            MySqlDataReader reader = sql.SelectResult(testName, StudentName, GroupName, sex);
            if (reader.HasRows)
            {
                if (testName == "test0") CreateSpecialReportT0(reader);
                else if (testName == "test3" || testName == "test4") CreateSpecialReport(reader, testName);
                else if (testName == "all") CreateFullReport(reader);
                else CreateReport(reader);
            }
            else Message.ShowErrorText("Результаты по заданным параметрам не найдены!");

            reader.Close();
            sql.ConnectionClose();

        }
        private static void CreateReport(MySqlDataReader reader)
        {
            FileInfo fi = getReportFileName();
            if (fi == null) return;
            
            int lvl, testres;

            using (ExcelPackage book = new ExcelPackage(fi))
            {
                ExcelWorksheet ws = book.Workbook.Worksheets.Add("Report");
                ws.Cells[1, 1].Value = "ПІБ";
                ws.Cells[1, 2].Value = "Група";
                ws.Cells[1, 3].Value = "Стать";
                ws.Cells[1, 4].Value = "Результат тестування";
                ws.Cells[1, 5].Value = "Рівень";

                int currentrow = 1;
                while(reader.Read())
                {
                    currentrow++;
                    ws.Cells[currentrow, 1].Value = reader.GetValue(0);
                    ws.Cells[currentrow, 2].Value = reader.GetValue(1);
                    ws.Cells[currentrow, 3].Value = ((bool)reader.GetValue(2))?"М":"Ж";
                    testres= Convert.ToInt32(reader.GetValue(3));
                    lvl = Convert.ToInt16(reader.GetValue(4));
                    ws.Cells[currentrow, 4].Value = testres;

                    if (lvl == 2) ws.Cells[currentrow, 5].Value = "В";
                    else if(lvl == 1) ws.Cells[currentrow, 5].Value = "С";
                    else ws.Cells[currentrow, 5].Value = "Н";
                }
                currentrow += 2;
                ws.Cells[currentrow, 1].Value = "Всього:";
                ws.Cells[currentrow+1, 1].Value = "Рівень:";
                ws.Cells[currentrow + 2, 1].Value = "Високий";
                ws.Cells[currentrow + 3, 1].Value = "Середній";
                ws.Cells[currentrow + 4, 1].Value = "Низький";
                ws.Cells[currentrow+1, 2].Value = "М";
                ws.Cells[currentrow+1, 3].Value = "Ж";
                ws.Cells[currentrow + 2, 2].Formula = String.Format("COUNTIFS({0},\"В\",{1},\"М\")",ExcelRange.GetAddress(2,5,currentrow-2,5), ExcelRange.GetAddress(2, 3, currentrow - 2, 3));
                ws.Cells[currentrow + 3, 2].Formula = String.Format("COUNTIFS({0},\"С\",{1},\"М\")", ExcelRange.GetAddress(2, 5, currentrow - 2, 5), ExcelRange.GetAddress(2, 3, currentrow - 2, 3));
                ws.Cells[currentrow + 4, 2].Formula = String.Format("COUNTIFS({0},\"Н\",{1},\"М\")", ExcelRange.GetAddress(2, 5, currentrow - 2, 5), ExcelRange.GetAddress(2, 3, currentrow - 2, 3));
                ws.Cells[currentrow + 2, 3].Formula = String.Format("COUNTIFS({0},\"В\",{1},\"Ж\")", ExcelRange.GetAddress(2, 5, currentrow - 2, 5), ExcelRange.GetAddress(2, 3, currentrow - 2, 3));
                ws.Cells[currentrow + 3, 3].Formula = String.Format("COUNTIFS({0},\"С\",{1},\"Ж\")", ExcelRange.GetAddress(2, 5, currentrow - 2, 5), ExcelRange.GetAddress(2, 3, currentrow - 2, 3));
                ws.Cells[currentrow + 4, 3].Formula = String.Format("COUNTIFS({0},\"Н\",{1},\"Ж\")", ExcelRange.GetAddress(2, 5, currentrow - 2, 5), ExcelRange.GetAddress(2, 3, currentrow - 2, 3));
               
                var tb = ws.Tables.Add(ws.Cells[1, 1, currentrow-2, 5],null);
                tb.TableStyle = OfficeOpenXml.Table.TableStyles.Medium13;

                tb= ws.Tables.Add(ws.Cells[currentrow+1, 1, currentrow + 4, 3], null);
                tb.TableStyle = OfficeOpenXml.Table.TableStyles.Medium14;

                 ExcelBarChart barchart = ws.Drawings.AddChart("График", OfficeOpenXml.Drawing.Chart.eChartType.ColumnStacked3D) as ExcelBarChart;
                barchart.SetPosition(0, 0, 7, 0);
                 barchart.SetSize(600, 400);
                
                var ser = (ExcelBarChartSerie)(barchart.Series.Add(ExcelRange.GetAddress(currentrow + 2, 2, currentrow + 4, 2), ExcelRange.GetAddress(currentrow + 2, 1, currentrow + 4, 1)));
                var headeradr = ws.Cells[currentrow + 1, 2];
                ser.HeaderAddress = headeradr;
                ser = (ExcelBarChartSerie)(barchart.Series.Add(ExcelRange.GetAddress(currentrow + 2, 3, currentrow + 4, 3), ExcelRange.GetAddress(currentrow + 2, 1, currentrow + 4, 1)));
                headeradr = ws.Cells[currentrow + 1, 3];
                ser.HeaderAddress = headeradr;

                ws.Calculate();
                ws.Cells.AutoFitColumns();

                book.Save();
            }
        }
        private static void CreateSpecialReport(MySqlDataReader reader, string testName)
        {
            FileInfo fi = getReportFileName();
            if (fi == null) return;

            string[] scaleName=null;
            int count = 0;
            if (testName == "test3")
            {
                scaleName = new string[] { "Комунікативні мотиви", "Мотиви уникнення", "Мотиви престижу", "Професійні мотиви", "Мотиви творчої самореалізації", "Навчально-пізнавальні мотиви", "Соціальні мотиви" };
                count = 7;
            }
            else
            {
                scaleName = new string[] { "активне діяльне життя", "життєва мудрість", "здоров'я", "цікава робота", "краса природи і мистецтва", "любов", "матеріально забезпечене життя", "наявність гарних і вірних друзів", "суспільне визнання", "пізнання", "продуктивне життя", "розвиток", "розваги", "воля", "щасливе сімейне життя", "щастя інших", "творчість", "впевненість у собі" };
                count = 18;
            }

            using (ExcelPackage book = new ExcelPackage(fi))
            {
                ExcelWorksheet ws = book.Workbook.Worksheets.Add("Report");

                int currentrow = 1;
                ws.Cells[1, 1].Value = "ПІБ";
                ws.Cells[1, 2].Value = "Група";
                ws.Cells[1, 3].Value = "Стать";
                for (int i = 0; i < count; i++)
                {
                    ws.Cells[1, 4 + i].Value = scaleName[i];
                }
                while (reader.Read())
                {
                    currentrow++;
                    ws.Cells[currentrow, 1].Value = reader.GetValue(0);
                    ws.Cells[currentrow, 2].Value = reader.GetValue(1);
                    ws.Cells[currentrow, 3].Value = ((bool)reader.GetValue(2)) ? "М" : "Ж";
                    for (int i = 0; i < count; i++)
                        ws.Cells[currentrow, i+4].Value = reader.GetValue(i+3);
                }

                ws.Cells[currentrow+2, 1].Value = "Середнє значення:";
                ws.Cells[currentrow + 4, 1].Value = "Шкала:";
                ws.Cells[currentrow + 4, 2].Value = "М";
                ws.Cells[currentrow + 4, 3].Value = "Ж";
                ws.Cells[currentrow + 4, 4].Value = "Загальнє";
                if (testName == "test0") { ws.Cells[currentrow + 3, 1].Value = "Перша частина"; ws.Cells[currentrow + 20, 1].Value = "Друга частина"; count = 15; }
                for (int i = 0; i < count; i++)
                {
                    ws.Cells[currentrow + 5 + i, 1].Value = scaleName[i];
                    ws.Cells[currentrow + 5 + i, 2].FormulaR1C1 = String.Format("IF(COUNTIFS(R{4}C{5}:R{6}C{7},\"=М\")>0,AVERAGEIFS(R{0}C{1}:R{2}C{3}, R{4}C{5}:R{6}C{7}, \"=М\"),0)", 2, 4 + i, currentrow, 4 + i, 2, 3, currentrow, 3);
                    ws.Cells[currentrow + 5 + i, 3].FormulaR1C1 = String.Format("IF(COUNTIFS(R{4}C{5}:R{6}C{7},\"=Ж\")>0,AVERAGEIFS(R{0}C{1}:R{2}C{3}, R{4}C{5}:R{6}C{7}, \"=Ж\"),0)", 2, 4 + i, currentrow, 4 + i, 2, 3, currentrow, 3);
                    ws.Cells[currentrow + 5 + i, 4].FormulaR1C1 = String.Format("AVERAGE(R{0}C{1}:R{2}C{3})", 2, 4 + i, currentrow, 4 + i);
                }

                var tb = ws.Tables.Add(ws.Cells[currentrow + 4, 1, currentrow + 4 + count, 4], null);
                tb.TableStyle = OfficeOpenXml.Table.TableStyles.Medium14;

                ExcelBarChart barchart = ws.Drawings.AddChart("График", OfficeOpenXml.Drawing.Chart.eChartType.ColumnClustered) as ExcelBarChart;
                barchart.SetPosition(currentrow + 1, 0, 6, 0);
                barchart.SetSize(500, 400);

                var ser = (ExcelBarChartSerie)(barchart.Series.Add(ExcelRange.GetAddress(currentrow + 5, 2, currentrow + count +5, 2), ExcelRange.GetAddress(currentrow + 5, 1, currentrow + count +5, 1)));
                var headeradr = ws.Cells[currentrow + 4, 2];
                ser.HeaderAddress = headeradr;
                ser = (ExcelBarChartSerie)(barchart.Series.Add(ExcelRange.GetAddress(currentrow + 5, 3, currentrow + count + 5, 3), ExcelRange.GetAddress(currentrow + 5, 1, currentrow + count + 5, 1)));
                headeradr = ws.Cells[currentrow + 4, 3];
                ser.HeaderAddress = headeradr;
                ser = (ExcelBarChartSerie)(barchart.Series.Add(ExcelRange.GetAddress(currentrow + 5, 4, currentrow + count + 5, 4), ExcelRange.GetAddress(currentrow + 5, 1, currentrow + count + 5, 1)));
                headeradr = ws.Cells[currentrow + 4, 4];
                ser.HeaderAddress = headeradr;

                ws.Cells[currentrow + 3, 1, currentrow + count + 3, 4].Style.Numberformat.Format = "0.00";

                tb = ws.Tables.Add(ws.Cells[1, 1, currentrow, count + 3], null);
                tb.TableStyle = OfficeOpenXml.Table.TableStyles.Medium13;

                ws.Calculate();
                ws.Cells.AutoFitColumns();
                book.Save();
            }
           
        }
        private static void CreateSpecialReportT0(MySqlDataReader reader)
        {
            FileInfo fi = getReportFileName();
            if (fi == null) return;

            string[] scaleName = new string[] { "Технічне мислення", "Креативність", "Мобільність ", "Здатність до роботи в команді", "Адекватна оцінка власної діяльності", "Логічне мислення", "Організаторські здібності", "Готовність до ризику", "Критичне мислення", "Лідерські здібності", "Комунікабельність", "Вміння планувати власну діяльність", "Бажання досягати успіху", "Прагнення до самовдосконалення", "Наявність професійних знань", "Стресостійкість", "Відповідальність", "Ініціативність", "Cамостійність у прийнятті рішень", "Амбіційність", "Наполегливість", "Цілеспрямованість", "Старанність", "Уважність", "Терплячість" };

            using (ExcelPackage book = new ExcelPackage(fi))
            {
                ExcelWorksheet ws = book.Workbook.Worksheets.Add("Report");

                int currentrow = 1;
                ws.Cells[1, 1].Value = "ПІБ";
                ws.Cells[1, 2].Value = "Група";
                ws.Cells[1, 3].Value = "Стать";
                for (int i = 0; i < 25; i++)
                {
                    ws.Cells[1, 4 + i].Value = scaleName[i];
                }
                while (reader.Read())
                {
                    currentrow++;
                    ws.Cells[currentrow, 1].Value = reader.GetValue(0);
                    ws.Cells[currentrow, 2].Value = reader.GetValue(1);
                    ws.Cells[currentrow, 3].Value = ((bool)reader.GetValue(2)) ? "М" : "Ж";
                    for (int i = 0; i < 25; i++)
                        ws.Cells[currentrow, i + 4].Value = reader.GetValue(i + 3);
                }

                ws.Cells[currentrow + 2, 1].Value = "Середнє значення:";
                ws.Cells[currentrow + 4, 1].Value = "Шкала:";
                ws.Cells[currentrow + 4, 2].Value = "М";
                ws.Cells[currentrow + 4, 3].Value = "Ж";
                ws.Cells[currentrow + 4, 4].Value = "Загальнє";
                for (int i = 0; i < 15; i++)
                {
                    ws.Cells[currentrow + 5 + i, 1].Value = scaleName[i];
                    ws.Cells[currentrow + 5 + i, 2].FormulaR1C1 = String.Format("IF(COUNTIFS(R{4}C{5}:R{6}C{7},\"=М\")>0,AVERAGEIFS(R{0}C{1}:R{2}C{3}, R{4}C{5}:R{6}C{7}, \"=М\"),0)", 2, 4 + i, currentrow, 4 + i, 2, 3, currentrow, 3);
                    ws.Cells[currentrow + 5 + i, 3].FormulaR1C1 = String.Format("IF(COUNTIFS(R{4}C{5}:R{6}C{7},\"=Ж\")>0,AVERAGEIFS(R{0}C{1}:R{2}C{3}, R{4}C{5}:R{6}C{7}, \"=Ж\"),0)", 2, 4 + i, currentrow, 4 + i, 2, 3, currentrow, 3);
                    ws.Cells[currentrow + 5 + i, 4].FormulaR1C1 = String.Format("AVERAGE(R{0}C{1}:R{2}C{3})", 2, 4 + i, currentrow, 4 + i);
                }
                ws.Cells[currentrow + 20, 1].Value = "Шкала:";
                ws.Cells[currentrow + 20, 2].Value = "М";
                ws.Cells[currentrow + 20, 3].Value = "Ж";
                ws.Cells[currentrow + 20, 4].Value = "Загальнє";
                for (int i = 0; i < 10; i++)
                {
                    ws.Cells[currentrow + 21 + i, 1].Value = scaleName[i+15];
                    ws.Cells[currentrow + 21 + i, 2].FormulaR1C1 = String.Format("IF(COUNTIFS(R{4}C{5}:R{6}C{7},\"=М\")>0,AVERAGEIFS(R{0}C{1}:R{2}C{3}, R{4}C{5}:R{6}C{7}, \"=М\"),0)", 2, 19 + i, currentrow, 19 + i, 2, 3, currentrow, 3);
                    ws.Cells[currentrow + 21 + i, 3].FormulaR1C1 = String.Format("IF(COUNTIFS(R{4}C{5}:R{6}C{7},\"=Ж\")>0,AVERAGEIFS(R{0}C{1}:R{2}C{3}, R{4}C{5}:R{6}C{7}, \"=Ж\"),0)", 2, 19 + i, currentrow, 19 + i, 2, 3, currentrow, 3);
                    ws.Cells[currentrow + 21 + i, 4].FormulaR1C1 = String.Format("AVERAGE(R{0}C{1}:R{2}C{3})", 2, 19 + i, currentrow, 19 + i);
                }

                var tb = ws.Tables.Add(ws.Cells[1, 1, currentrow, 28], null);
                tb.TableStyle = OfficeOpenXml.Table.TableStyles.Medium13;

                tb = ws.Tables.Add(ws.Cells[currentrow + 4, 1, currentrow + 19, 4], null);
                tb.TableStyle = OfficeOpenXml.Table.TableStyles.Medium14;

                tb = ws.Tables.Add(ws.Cells[currentrow + 20, 1, currentrow + 30, 4], null);
                tb.TableStyle = OfficeOpenXml.Table.TableStyles.Medium12;

                ExcelBarChart barchart = ws.Drawings.AddChart("График ч1", OfficeOpenXml.Drawing.Chart.eChartType.ColumnClustered) as ExcelBarChart;
                barchart.SetPosition(currentrow + 2, 0, 5, 0);
                barchart.SetSize(500, 400);

                var ser = (ExcelBarChartSerie)(barchart.Series.Add(ExcelRange.GetAddress(currentrow + 5, 2, currentrow + 19, 2), ExcelRange.GetAddress(currentrow + 5, 1, currentrow + 19, 1)));
                var headeradr = ws.Cells[currentrow + 4, 2];
                ser.HeaderAddress = headeradr;
                ser = (ExcelBarChartSerie)(barchart.Series.Add(ExcelRange.GetAddress(currentrow + 5, 3, currentrow + 19, 3), ExcelRange.GetAddress(currentrow + 5, 1, currentrow + 19, 1)));
                headeradr = ws.Cells[currentrow + 4, 3];
                ser.HeaderAddress = headeradr;
                ser = (ExcelBarChartSerie)(barchart.Series.Add(ExcelRange.GetAddress(currentrow + 5, 4, currentrow + 19, 4), ExcelRange.GetAddress(currentrow + 5, 1, currentrow + 19, 1)));
                headeradr = ws.Cells[currentrow + 4, 4];
                ser.HeaderAddress = headeradr;

                ExcelBarChart barchart2 = ws.Drawings.AddChart("График ч2", OfficeOpenXml.Drawing.Chart.eChartType.ColumnClustered) as ExcelBarChart;
                barchart2.SetPosition(currentrow + 20, 0, 5, 0);
                barchart2.SetSize(500, 400);

                var ser2 = (ExcelBarChartSerie)(barchart2.Series.Add(ExcelRange.GetAddress(currentrow + 21, 2, currentrow + 30, 2), ExcelRange.GetAddress(currentrow + 21, 1, currentrow + 30, 1)));
                var headeradr2 = ws.Cells[currentrow + 20, 2];
                ser2.HeaderAddress = headeradr2;
                ser2 = (ExcelBarChartSerie)(barchart2.Series.Add(ExcelRange.GetAddress(currentrow + 21, 3, currentrow + 30, 3), ExcelRange.GetAddress(currentrow + 21, 1, currentrow + 30, 1)));
                headeradr2 = ws.Cells[currentrow + 20, 3];
                ser2.HeaderAddress = headeradr2;
                ser2 = (ExcelBarChartSerie)(barchart2.Series.Add(ExcelRange.GetAddress(currentrow + 21, 4, currentrow + 30, 4), ExcelRange.GetAddress(currentrow + 21, 1, currentrow + 30, 1)));
                headeradr2 = ws.Cells[currentrow + 20, 4];
                ser2.HeaderAddress = headeradr2;

                ws.Cells[currentrow + 3, 1, currentrow + 19, 4].Style.Numberformat.Format = "0.00";
                ws.Cells[currentrow + 21, 1, currentrow + 30, 4].Style.Numberformat.Format = "0.00";
                ws.Calculate();
                ws.Cells.AutoFitColumns();
                book.Save();
            }
            }
        private static void CreateFullReport(MySqlDataReader student)
        {
            FileInfo fi = getReportFileName();
            if (fi == null) return;

            string[] testnamearr = new string[] { "test1", "test2", "test5", "test6", "test7", "test8", "test9", "test10", "test11", "test12", "test13", "test14", "test15" };
            SqlQueries sql = new SqlQueries();
            MySqlDataReader reader;

            if (student.HasRows)
            {
                using (ExcelPackage book = new ExcelPackage(fi))
                {
                    ExcelWorksheet ws = book.Workbook.Worksheets.Add("Report");
                    ws.Cells[1, 1].Value = "ПІБ";
                    ws.Cells[1, 2].Value = "Група";
                    ws.Cells[1, 3].Value = "Стать";
                    ws.Cells[1, 4].Value = "Тест 2";
                    ws.Cells[1, 5].Value = "Тест 3";
                    ws.Cells[1, 6].Value = "Тест 6";
                    ws.Cells[1, 7].Value = "Тест 7";
                    ws.Cells[1, 8].Value = "Тест 8";
                    ws.Cells[1, 9].Value = "Тест 9";
                    ws.Cells[1, 10].Value = "Тест 10";
                    ws.Cells[1, 11].Value = "Тест 11";
                    ws.Cells[1, 12].Value = "Тест 12";
                    ws.Cells[1, 13].Value = "Тест 13";
                    ws.Cells[1, 14].Value = "Тест 14";
                    ws.Cells[1, 15].Value = "Тест 15";
                    ws.Cells[1, 16].Value = "Тест 16";
                    ws.Cells[1, 17].Value = "Загальний рівень конкурентноспроможності";

                    int currentrow = 1,sum,curr_lvl,compl_test_num;
                    string studentName, groupName;
                    while (student.Read())
                    {
                        sum = 0;compl_test_num = 0;
                        currentrow++;
                        studentName = student.GetString(1);
                        groupName = student.GetString(2);
                        ws.Cells[currentrow, 1].Value = studentName;
                        ws.Cells[currentrow, 2].Value = groupName;
                        ws.Cells[currentrow, 3].Value = student.GetBoolean(3) ? "М" : "Ж";
                        for (int i = 0; i < 13; i++)
                        {
                            reader = sql.SelectResult(testnamearr[i], studentName, groupName, "");
                            if (reader.HasRows)
                            {
                                reader.Read();
                                curr_lvl= reader.GetInt16(4);
                                if (curr_lvl == 2) ws.Cells[currentrow, i + 4].Value = "В";
                                else if (curr_lvl == 1) ws.Cells[currentrow, i + 4].Value = "С";
                                else ws.Cells[currentrow, i + 4].Value = "Н";
                                sum += curr_lvl;
                                compl_test_num++;
                            }
                            reader.Close();
                        }
                        curr_lvl = (int)Math.Round((double)sum / compl_test_num, 0, MidpointRounding.AwayFromZero);
                        if (curr_lvl == 2) ws.Cells[currentrow, 17].Value = "В";
                        else if (curr_lvl == 1) ws.Cells[currentrow, 17].Value = "С";
                        else ws.Cells[currentrow, 17].Value = "Н";
                    }
                    currentrow += 2;

                    ws.Cells[currentrow, 1].Value = "Всього:";
                    ws.Cells[currentrow + 1, 1].Value = "Рівень:";
                    ws.Cells[currentrow + 2, 1].Value = "Високий";
                    ws.Cells[currentrow + 3, 1].Value = "Середній";
                    ws.Cells[currentrow + 4, 1].Value = "Низький";
                    ws.Cells[currentrow + 1, 2].Value = "М";
                    ws.Cells[currentrow + 1, 3].Value = "Ж";
                    ws.Cells[currentrow + 2, 2].Formula = String.Format("COUNTIFS({0},\"В\",{1},\"М\")", ExcelRange.GetAddress(2, 17, currentrow - 2, 17), ExcelRange.GetAddress(2, 3, currentrow - 2, 3));
                    ws.Cells[currentrow + 3, 2].Formula = String.Format("COUNTIFS({0},\"С\",{1},\"М\")", ExcelRange.GetAddress(2, 17, currentrow - 2, 17), ExcelRange.GetAddress(2, 3, currentrow - 2, 3));
                    ws.Cells[currentrow + 4, 2].Formula = String.Format("COUNTIFS({0},\"Н\",{1},\"М\")", ExcelRange.GetAddress(2, 17, currentrow - 2, 17), ExcelRange.GetAddress(2, 3, currentrow - 2, 3));
                    ws.Cells[currentrow + 2, 3].Formula = String.Format("COUNTIFS({0},\"В\",{1},\"Ж\")", ExcelRange.GetAddress(2, 17, currentrow - 2, 17), ExcelRange.GetAddress(2, 3, currentrow - 2, 3));
                    ws.Cells[currentrow + 3, 3].Formula = String.Format("COUNTIFS({0},\"С\",{1},\"Ж\")", ExcelRange.GetAddress(2, 17, currentrow - 2, 17), ExcelRange.GetAddress(2, 3, currentrow - 2, 3));
                    ws.Cells[currentrow + 4, 3].Formula = String.Format("COUNTIFS({0},\"Н\",{1},\"Ж\")", ExcelRange.GetAddress(2, 17, currentrow - 2, 17), ExcelRange.GetAddress(2, 3, currentrow - 2, 3));

                    var tb = ws.Tables.Add(ws.Cells[1, 1, currentrow-2, 17], null);
                    tb.TableStyle = OfficeOpenXml.Table.TableStyles.Medium13;
                    tb = ws.Tables.Add(ws.Cells[currentrow + 1, 1, currentrow + 4, 3], null);
                    tb.TableStyle = OfficeOpenXml.Table.TableStyles.Medium14;

                    ExcelBarChart barchart = ws.Drawings.AddChart("График", OfficeOpenXml.Drawing.Chart.eChartType.ColumnStacked3D) as ExcelBarChart;
                    barchart.SetPosition(currentrow, 0, 4, 0);
                    barchart.SetSize(600, 400);

                    var ser = (ExcelBarChartSerie)(barchart.Series.Add(ExcelRange.GetAddress(currentrow + 2, 2, currentrow + 4, 2), ExcelRange.GetAddress(currentrow + 2, 1, currentrow + 4, 1)));
                    var headeradr = ws.Cells[currentrow + 1, 2];
                    ser.HeaderAddress = headeradr;
                    ser = (ExcelBarChartSerie)(barchart.Series.Add(ExcelRange.GetAddress(currentrow + 2, 3, currentrow + 4, 3), ExcelRange.GetAddress(currentrow + 2, 1, currentrow + 4, 1)));
                    headeradr = ws.Cells[currentrow + 1, 3];
                    ser.HeaderAddress = headeradr;

                    ws.Calculate();

                    ws.Cells.AutoFitColumns();
                    book.Save();
                }
            }
        }
    }
}
