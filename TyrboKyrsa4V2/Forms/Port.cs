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
    public partial class Port : Form
    {
        public Port()
        {
            InitializeComponent();           
        }

        Resources resources;

        public void Info()
        {
            if (resources.InfoMoney() >= 200)
                button1.Enabled = true;
            else
                button1.Enabled = false;

            if (resources.InfoMoney() >= 100)
                button2.Enabled = true;
            else
                button2.Enabled = false;

            if (resources.InfoMoney() >= 300)
            {
                button3.Enabled = true;
                button6.Enabled = true;
            }
            else
            {
                button3.Enabled = false;
                button6.Enabled = false;
            }

            if (resources.InfoMoney() >= 500)
                button5.Enabled = true;
            else
                button5.Enabled = false;

            if (resources.InfoResources(0) >= 10)
                button7.Enabled = true;
            else
                button7.Enabled = false;

            if (resources.InfoResources(1) >= 10)
                button8.Enabled = true;
            else
                button8.Enabled = false;

            if (resources.InfoResources(2) >= 10)
                button9.Enabled = true;
            else
                button9.Enabled = false;

            if (resources.InfoResources(3) >= 1)
                button10.Enabled = true;
            else
                button10.Enabled = false;

            if (resources.InfoResources(4) >= 10)
                button11.Enabled = true;
            else
                button11.Enabled = false;
        }

        public void GetResoures(Resources r)
        {
            resources = r;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (resources.InfoMoney() >= 200 * trackBar2.Value)
            {
                resources.Buying(0, trackBar2.Value);
                this.Close();
            }
            else
            {
                MessageBox.Show("У вас недостаточно монет для покупки.\nТребуется " + (200 * trackBar2.Value) + " монет.");
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (resources.InfoMoney() >= 100 * trackBar3.Value)
            { 
                resources.Buying(1, trackBar3.Value);
                this.Close();
            }
            else
            {
                MessageBox.Show("У вас недостаточно монет для покупки.\nТребуется " + (100 * trackBar3.Value) + " монет.");
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (resources.InfoMoney() >= 300 * trackBar4.Value)
            { 
                resources.Buying(2, trackBar4.Value);
                this.Close();
            }
            else
            {
                MessageBox.Show("У вас недостаточно монет для покупки.\nТребуется " + (300 * trackBar4.Value) + " монет.");
                this.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (resources.InfoMoney() >= 500 * trackBar5.Value)
            { 
                resources.Buying(3, trackBar5.Value);
                this.Close();
            }
            else
            {
                MessageBox.Show("У вас недостаточно монет для покупки.\nТребуется " + (500 * trackBar5.Value) + " монет.");
                this.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (resources.InfoMoney() >= 300 * trackBar6.Value)
            { 
                resources.Buying(4, trackBar6.Value);
                this.Close();
            }
            else
            {
                MessageBox.Show("У вас недостаточно монет для покупки.\nТребуется " + (300 * trackBar6.Value) + " монет.");
                this.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (resources.InfoResources(0) >= 10 * trackBar1.Value)
            { 
                resources.Buying(5, trackBar1.Value);
                this.Close();
            }
            else
            {
                MessageBox.Show("У вас недостаточно железа для продажи.\nТребуется " + (10 * trackBar1.Value) + " железа.");
                this.Close();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (resources.InfoResources(1) >= 10 * trackBar7.Value)
            { 
                resources.Buying(6, trackBar7.Value);
                this.Close();
            }
            else
            {
                MessageBox.Show("У вас недостаточно древесины для продажи.\nТребуется " + (10 * trackBar7.Value) + " дерева.");
                this.Close();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (resources.InfoResources(2) >= 10 * trackBar8.Value)
            { 
                resources.Buying(7, trackBar8.Value);
                this.Close();
            }
            else
            {
                MessageBox.Show("У вас недостаточно угля для продажи.\nТребуется " + (10 * trackBar8.Value) + " угля.");
                this.Close();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (resources.InfoResources(3) >= 1 * trackBar9.Value)
            { 
                resources.Buying(8, trackBar9.Value);
                this.Close();
            }
            else
            {
                MessageBox.Show("У вас недостаточно урана для продажи.\nТребуется " + (1 * trackBar9.Value) + " урана.");
                this.Close();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (resources.InfoResources(4) >= 10 * trackBar10.Value)
            { 
                resources.Buying(9, trackBar10.Value);
                this.Close();
            }
            else
            {
                MessageBox.Show("У вас недостаточно еды для продажи.\nТребуется " + (10 * trackBar10.Value) + " еды.");
                this.Close();
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            button7.Text = (200 * trackBar1.Value) + " монет = " + (10 * trackBar1.Value) + " железа";
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            button1.Text = (10 * trackBar2.Value) + " железа = " + (200 * trackBar2.Value) + " монет";
        }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            button2.Text = (10 * trackBar3.Value) + " дерева = " + (100 * trackBar3.Value) + " монет";
        }

        private void trackBar4_ValueChanged(object sender, EventArgs e)
        {
            button3.Text = (10 * trackBar4.Value) + " угля = " + (300 * trackBar4.Value) + " монет";
        }

        private void trackBar5_ValueChanged(object sender, EventArgs e)
        {
            button5.Text = (1 * trackBar5.Value) + " уран = " + (500 * trackBar5.Value) + " монет";
        }

        private void trackBar6_ValueChanged(object sender, EventArgs e)
        {
            button6.Text = (10 * trackBar5.Value) + " еды = " + (300 * trackBar5.Value) + " монет";
        }

        private void trackBar7_ValueChanged(object sender, EventArgs e)
        {
            button8.Text = (100 * trackBar7.Value) + " монет = " + (10 * trackBar7.Value) + " дерева";
        }

        private void trackBar8_ValueChanged(object sender, EventArgs e)
        {
            button9.Text = (300 * trackBar8.Value) + " монет = " + (10 * trackBar8.Value) + " угля";
        }

        private void trackBar9_ValueChanged(object sender, EventArgs e)
        {
            button10.Text = (500 * trackBar9.Value) + " монет = " + (1 * trackBar9.Value) + " уран";
        }

        private void trackBar10_ValueChanged(object sender, EventArgs e)
        {
            button11.Text = (300 * trackBar10.Value) + " монет = " + (10 * trackBar10.Value) + " еды";
        }
    }
}
