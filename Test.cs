using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnostics
{
    class Test
    {
        public string testname { get; private set; }
        public bool testcompletestatus { get; set; }
        public bool testsavingstatus { get; set; }
        public int resultvalue { get; set; }
        public int resultlvl { get; set; }
        public Test(string testname)
        {
            this.testname = testname;
            testcompletestatus = false;
            testsavingstatus = false;
            resultvalue = 0;
        }
    }
    class SpecialTest:Test
    {
        public new int[] resultvalue { get; set; }
        public SpecialTest(string testname, int[] resultvalue):base(testname)
        {
            this.resultvalue = resultvalue;
        }
    }
}
