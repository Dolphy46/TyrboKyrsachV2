using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TyrboKyrsa4V2.Classes
{
    public class Plant : Facilities
    {
        public int[] cost { get; }
        public int number { get; set; }
        int[] res = new int[3];

        public void InfoRes(int res0, int res1, int res2)
        {
            this.res[0] = res0;
            this.res[1] = res1;
            this.res[2] = res2;
        }

        public Plant(int res1, int res2, int res3, int res4)
        {
            cost = new int[4];
            cost[0] = res1;
            cost[1] = res2;
            cost[2] = res3;
            cost[3] = res4;
            number = 0;
        }

        public bool Build(int money)
        {
            if (money >= cost[0] && cost[1] < res[0] && cost[2] < res[1] & cost[3] < res[2])
            {
                number++;
                return true;
            }
            else return false;
        }
    }
}
