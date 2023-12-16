using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2_Threads
{
    internal class Car
    {
        public string Name { get; set; }
        public double Speed { get; set; }
        public double DrivenLength { get; set; }

        public Car(string name) 
        {
            Name = name;
            Speed = 120;
            DrivenLength = 0;
        }
    }
}
