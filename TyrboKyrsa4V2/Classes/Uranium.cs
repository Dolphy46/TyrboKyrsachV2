using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TyrboKyrsa4V2.Classes
{
    public class Uranium : REsourses
    {
        public int cost { get; }
        public int number { get; set; }

        public Uranium()
        {
            cost = 500;
            number = 0;
        }

        public bool Buying(int money, int uranium)
        {
            bool test;
            if (money >= cost * uranium)
            {
                test = true;
                number = number + uranium;
            }
            else test = false;
            return test;
        }

        public bool Sale(int uranium)
        {
            bool test;
            if (number >= uranium)
            {
                test = true;
                number = number - uranium;
            }
            else test = false;
            return test;
        }
    }
}
