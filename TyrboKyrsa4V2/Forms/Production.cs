using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TurboKyrsa4.Forms;

namespace TyrboKyrsa4V2.Forms
{
    public partial class Production : Form
    {
        public Production()
        {
            InitializeComponent();
        }

        int infcoords;
        Resources resources;

        public void GetResources(Resources r)
        {
            resources = r;
        }

        public void InfoCoords(int info)
        {
            infcoords = info;
            if (infcoords == 31)
                label25.Text = "Количество произведённого ресурса: 100 солдат\nКоличество потраченных ресурсов:" +
                    " 10 еды, 150 монет\nКаждые 100 солдат принесут - 5 к рейтингу";
            if (infcoords == 32)
                label25.Text = "Количество произведённого ресурса: 1 боеголовка\nКоличество потраченных ресурсов:" +
                    " 20 железа, 10 урана\nКаждая боеголовка принесёт - 25 к рейтингу";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (infcoords == 31)
                resources.MotionMen();
            else
               if (infcoords == 32)
                resources.MotionWarhead();
            else
                resources.MotionTank();
            if (resources.InfoTest() == false)
                MessageBox.Show("У вас недостаточно ресурсов для производства.");
            this.Close();
        }
    }
}
