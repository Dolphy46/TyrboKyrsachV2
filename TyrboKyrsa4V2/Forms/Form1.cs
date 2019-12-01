using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TyrboKyrsa4V2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MapControl mp = new MapControl();
            mp.Name = "";
            mp.Width = 1280;
            mp.Height = 850;
            mp.Location = new Point(0, 0);
            Controls.Add(mp);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
