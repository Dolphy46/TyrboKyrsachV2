using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TyrboKyrsa4V2.Classes
{
    public class Iron : REsourses
    {
        public int cost { get;}
        public int number { get; set; }

        public Iron()
        {
            cost = 200;
            number = 0;
        }

        public bool Buying(int money, int iron)
        {
            bool test;
            if (money >= cost * iron)
            {
                test = true;
                number = number + ( 10 * iron);
            }
            else test = false;
            return test;
        }

        public bool Sale(int iron)
        {
            bool test;
            if (number >= 10 * iron)
            {
                test = true;
                number = number - (10 * iron);
            }
            else test = false;
            return test;
        }
    }
}
