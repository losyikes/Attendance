using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceClient
{
    class Screen : IScreen
    {
        public void PrintLine(string text)
        {
            Console.WriteLine(text);
        }
        public string ReadLine()
        {
            return Console.ReadLine();
        }
        public void Clear()
        {
            Console.Clear();
        }
    }
}
