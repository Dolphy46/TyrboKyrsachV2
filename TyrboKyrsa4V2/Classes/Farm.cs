using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TyrboKyrsa4V2.Classes
{
    public class Farm : Facilities
    {
        public int[] cost { get; }
        public int number { get; set; }
        public void InfoRes(int res0, int res1, int res2) { }

        public Farm(int res1)
        {
            cost = new int[4];
            cost[0] = res1;
            cost[1] = 0;
            cost[2] = 0;
            cost[3] = 0;
            number = 0;
        }

        public bool Build(int money)
        {
            if (money >= cost[0])
            {
                number++;
                return true;
            }
            else return false;
        }

        public int Plus(int eat)
        {
            Random random = new Random();
            for (int i = 0; i < number; i++)
                eat = eat + random.Next(5, 10);
            return eat;
        }
    }
}
