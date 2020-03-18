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
            if (resources.InfoMoney() >= 300)
            {
                resources.park++;
                resources.Buying(300, 1);
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
            if (resources.InfoMoney() >= 1500)
            {
                resources.shop++;
                resources.Buying(1500, 1);
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
            if(resources.InfoMoney() >= 2000)
            {
                resources.temple++;
                resources.Buying(2000, 1);
                button3.Enabled = false;
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
    }
}
