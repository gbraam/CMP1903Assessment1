﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Program
    {
        static void Main(string[] args)
        {
            Pack pack = Pack.Instance;
            Console.WriteLine(Pack.shuffleCardPack(1));
            Console.ReadLine();
        }
    }
}
