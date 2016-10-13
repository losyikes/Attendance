﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceClient
{
    interface IScreen
    {
        void PrintLine(string text);
        string ReadLine();
        void Clear();
    }
}
