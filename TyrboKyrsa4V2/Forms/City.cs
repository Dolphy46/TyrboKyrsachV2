using System;
using System.Windows.Forms;
using TurboKyrsa4.Forms;

namespace TyrboKyrsa4V2.Forms
{
    public partial class City : Form
    {
        public City()
        {
            InitializeComponent();
        }

        int number;
        Resources resources;

        public void GetResources(Resources r)
        {
            resources = r;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            number = 8;
            resources.SetNumberResours(number);
            if (resources.InfoTest())
            {
                button1.Enabled = false;
                label1.Text = "Количество построек: \nПарк: " + resources.park + "\nТорговый центр: " + resources.shop +
                    "\nЦерковь: " + resources.temple;
                label24.Text = "К постройке больше недоступен";
            }
            else
            {
                MessageBox.Show("У вас недостаточно монет!");
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            number = 9;
            resources.SetNumberResours(number);
            if (resources.InfoTest())
            {
                if (resources.shop == 3)
                {
                    button2.Enabled = false;
                    label22.Text = "К постройке больше недоступен";
                }
                label1.Text = "Количество построек: \nПарк: " + resources.park + "\nТорговый центр: " + resources.shop +
                   "\nЦерковь: " + resources.temple;
            }
            else
            {
                MessageBox.Show("У вас недостаточно монет!");
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            number = 10;
            resources.SetNumberResours(number);
            if (resources.InfoTest())
            {
                button3.Enabled = false;
                label1.Text = "Количество построек: \nПарк: " + resources.park + "\nТорговый центр: " + resources.shop +
                    "\nЦерковь: " + resources.temple;
                label20.Text = "К постройке больше недоступен";
            }
            else
            {
                MessageBox.Show("У вас недостаточно монет!");
                this.Close();
            }
        }
    }
}
