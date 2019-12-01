using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TyrboKyrsa4V2
{
    class Manager
    {
        static string filename = "data/map.txt";
        static int[,] map;
        static bool[,] water;
        static int width;
        static int height;

        public void Load()
        {
            StreamReader sr = new StreamReader(filename);
            string[] s = sr.ReadLine().Split(' ');
            if (s[0] != "Map")
                throw new Exception("Неверный файл map.txt");
            height = Convert.ToInt32(s[1]);
            width = Convert.ToInt32(s[2]);
            map = new int[height, width];
            water = new bool[height, width];
            for (int i = 0; i < height; i++)
            {
                string[] ss = sr.ReadLine().Split(' ');
                for (int j = 0; j < width; j++)
                    map[i, j] = Convert.ToInt32(ss[j]);
            }
            sr.ReadLine();
            for (int i = 0; i < height; i++)
            {
                string[] ss = sr.ReadLine().Split(' ');
                for (int j = 0; j < width; j++)
                    water[i, j] = Convert.ToBoolean(ss[j]);
            }
            sr.Close();
        }

        public bool[,] GetWater()
        {
            return water;
        }

        public int[,] GetMap()
        {
            return map;
        }
    }
}
