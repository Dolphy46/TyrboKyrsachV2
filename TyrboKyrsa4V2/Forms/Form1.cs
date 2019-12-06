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
            mp.Name = "";
            mp.Width = 1280;
            mp.Height = 850;
            mp.Location = new Point(0, 0);
            Controls.Add(mp);
        }

        MapControl mp = new MapControl();

        private void Form1_Load(object sender, EventArgs e)
        {
            Forms.MENU menu = new Forms.MENU();
            menu.ShowDialog();
            mp.Task(menu.task);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
