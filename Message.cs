using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diagnostics
{
    static class Message
    {
        public static void ShowHelpText(String text)
        {
            MessageBox.Show(text, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void ShowErrorText(String text)
        {
            MessageBox.Show(text, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void Savelog(Exception ex)
        {
            using (StreamWriter sw = new StreamWriter(@"logfile.txt", true, System.Text.Encoding.Default))
            {
                sw.WriteLine("{0}{1}{0}", new string('-', 20), System.DateTime.Now.ToString());
                sw.WriteLine(ex.Message);
            }
        }
    }
}
