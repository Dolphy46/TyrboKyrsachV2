using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace TyrboKyrsa4V2
{
    class ImageManager
    {
        Image[] images;
        public void LoadDef()
        {
            string filename = "data/Cells.txt";
            StreamReader sr = new StreamReader(filename);
            string[] s = sr.ReadLine().Split(' ');
            string[] ss;
            images = new Image[Convert.ToInt32(s[1])];
            if (s[0] != "Cells")
                throw new Exception("Неверный файл map.txt");
            for (int i = 0; i < Convert.ToInt32(s[1]); i++)
            {
                ss = sr.ReadLine().Split();
                images[Convert.ToInt32(ss[0])] = Image.FromFile(ss[1]);
            }
            sr.Close();
        }

        public void LoadSpec()
        {
            string filename = "data/buildings.txt";
            StreamReader sr = new StreamReader(filename);
            string[] s = sr.ReadLine().Split(' ');
            string[] ss;
            images = new Image[Convert.ToInt32(s[1])];
            if (s[0] != "Buldings")
                throw new Exception("Неверный файл map.txt");
            for (int i = 0; i < Convert.ToInt32(s[1]); i++)
            {
                ss = sr.ReadLine().Split();
                images[Convert.ToInt32(ss[0])] = Image.FromFile(ss[1]);
            }
            sr.Close();
        }

        public Image[] GetImage()
        {
            return images;
        }
    }
}
