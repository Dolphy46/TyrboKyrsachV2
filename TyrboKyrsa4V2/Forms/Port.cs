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
            if (resources.InfoMoney() >= 200)
                resources.Buying(0);
            else
            {
                MessageBox.Show("У вас недостаточно монет для покупки");
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (resources.InfoMoney() >= 100)
                resources.Buying(1);
            else
            {
                MessageBox.Show("У вас недостаточно монет для покупки");
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (resources.InfoMoney() >= 300)
                resources.Buying(2);
            else
            {
                MessageBox.Show("У вас недостаточно монет для покупки");
                this.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (resources.InfoMoney() >= 500)
                resources.Buying(3);
            else
            {
                MessageBox.Show("У вас недостаточно монет для покупки");
                this.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (resources.InfoMoney() >= 300)
                resources.Buying(4);
            else
            {
                MessageBox.Show("У вас недостаточно монет для покупки");
                this.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (resources.InfoResources(0) >= 10)
                resources.Buying(5);
            else
            {
                MessageBox.Show("У вас недостаточно железа для продажи");
                this.Close();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (resources.InfoResources(1) >= 10)
                resources.Buying(6);
            else
            {
                MessageBox.Show("У вас недостаточно древесины для продажи");
                this.Close();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (resources.InfoResources(2) >= 10)
                resources.Buying(7);
            else
            {
                MessageBox.Show("У вас недостаточно угля для продажи");
                this.Close();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (resources.InfoResources(3) >= 1)
                resources.Buying(8);
            else
            {
                MessageBox.Show("У вас недостаточно урана для продажи");
                this.Close();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (resources.InfoResources(4) >= 10)
                resources.Buying(9);
            else
            {
                MessageBox.Show("У вас недостаточно еды для продажи");
                this.Close();
            }
        }
    }
}
