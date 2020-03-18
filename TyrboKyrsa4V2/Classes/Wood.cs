using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TyrboKyrsa4V2.Classes
{
    public class Wood : REsourses
    {
        public int cost { get; }
        public int number { get; set; }

        public Wood()
        {
            cost = 100;
            number = 0;
        }

        public bool Buying(int money, int wood)
        {
            bool test;
            if (money >= cost * wood)
            {
                test = true;
                number = number + (10 * wood);
            }
            else test = false;
            return test;
        }

        public bool Sale(int wood)
        {
            bool test;
            if (number >=  10 * wood)
            {
                test = true;
                number = number - (10* wood);
            }
            else test = false;
            return test;
        }
    }
}
