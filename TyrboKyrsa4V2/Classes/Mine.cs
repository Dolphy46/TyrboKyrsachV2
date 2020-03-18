using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TyrboKyrsa4V2.Classes
{
    public class Mine : Facilities
    {
        public int[] cost { get; }
        public int number { get; set; }
        public void InfoRes(int res0, int res1, int res2) { }
        
        public Mine(int res1)
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


        public int[] Plus(int iron, int coal, int uran)
        {
            Random random = new Random();
            for (int i = 0; i < number; i++)
            {
                iron = iron + random.Next(5, 30);
                coal = coal + random.Next(5, 15);
                uran = uran + random.Next(0, 4);
            }
            int[] a = new int[3] { iron, coal, uran };
            return a;
        }
    }
}
