using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TyrboKyrsa4V2.Classes
{
    public class Coal : REsourses
    {
        public int cost { get; }
        public int number { get; set; }

        public Coal()
        {
            cost = 300;
            number = 0;
        }

        public bool Buying(int money, int coal)
        {
            bool test;
            if (money >= cost * coal)
            {
                test = true;
                number = number + (10 * coal);
            }
            else test = false;
            return test;
        }

        public bool Sale(int coal)
        {
            bool test;
            if (number >= 10 * coal)
            {
                test = true;
                number = number - (10 * coal);
            }
            else test = false;
            return test;
        }
    }
}

