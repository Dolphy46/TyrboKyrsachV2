using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TyrboKyrsa4V2.Classes
{
    public class Eat : REsourses
    {
        public int cost { get; }
        public int number { get; set; }

        public Eat()
        {
            cost = 300;
            number = 0;
        }

        public bool Buying(int money, int eat)
        {
            bool test;
            if (money >= cost * eat)
            {
                test = true;
                number = number + (10 * eat);
            }
            else test = false;
            return test;
        }

        public bool Sale(int eat)
        {
            bool test;
            if (number >= 10 * eat)
            {
                test = true;
                number = number - (10 * eat);
            }
            else test = false;
            return test;
        }
    }
}
