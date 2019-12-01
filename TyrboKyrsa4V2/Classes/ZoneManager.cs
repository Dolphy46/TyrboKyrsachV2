using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TyrboKyrsa4V2.Classes
{
    class ZoneManager
    {
        static bool[,] playerzone;
        static string filename = "data/playerzone.txt";
        static int width;
        static int height;
        public void Load()
        {
            StreamReader sr = new StreamReader(filename);
            string[] s = sr.ReadLine().Split(' ');
            if (s[0] != "PlayerZone")
                throw new Exception("Неверный файл map.txt");
            height = Convert.ToInt32(s[1]);
            width = Convert.ToInt32(s[2]);
            playerzone = new bool[height, width];
            for (int i = 0; i < height; i++)
            {
                string[] ss = sr.ReadLine().Split(' ');
                for (int j = 0; j < width; j++)
                    playerzone[i, j] = Convert.ToBoolean(ss[j]);
            }
            sr.Close();
        }

        public bool[,] GetZone()
        {
            return playerzone;
        }
    }
}
