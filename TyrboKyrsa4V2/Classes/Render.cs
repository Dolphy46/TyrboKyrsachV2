using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TyrboKyrsa4V2;

namespace TurboKyrsa4
{
    public class Render
    {
        Bitmap map = new Bitmap(1280, 960);
        Graphics graph;
        ImageManager mn = new ImageManager();
        Image[] images;

        public void LoadIm()
        {
            mn.LoadSpec();
            images = mn.GetImage();
        }
 
        public Bitmap Construction(int x)
        {
            Bitmap construction = new Bitmap(100, 100);
            graph = Graphics.FromImage(construction);
            graph.DrawImage(images[x], 0, 0);
            return construction;
        }

        public Bitmap AccentuationConstruction(int x)
        {
            Bitmap construction1 = Construction(x);
            graph = Graphics.FromImage(construction1);
            graph.DrawLine(new Pen(Color.Green, 5), 24, 8, 74, 8);
            graph.DrawLine(new Pen(Color.Green, 5), 73, 7, 100, 50);
            graph.DrawLine(new Pen(Color.Green, 5), 99, 50, 74, 91);
            graph.DrawLine(new Pen(Color.Green, 5), 75, 91, 24, 91);
            graph.DrawLine(new Pen(Color.Green, 5), 24, 90, 1, 50);
            graph.DrawLine(new Pen(Color.Green, 5), 0, 50, 24, 8);
            return construction1;
        }
    }
}
