using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TyrboKyrsa4V2.Forms
{
    public partial class MENU : Form
    {
        public MENU()
        {
            InitializeComponent();
        }

        public int task;
        int n = 0;

        public void Rule()
        {
            if (n < 1)
            {
                Rules rule = new Rules();
                rule.ShowDialog();
            }
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            task = 90;
            MessageBox.Show("Для того чтобы достичь выбранной цели, вам надо к концу игры иметь рейтинг не ниже 90 процентов.");
            Rule();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            task = 10;
            MessageBox.Show("Для того чтобы достичь выбранной цели, вам надо к концу игры иметь рейтинг не выше 10 процентов.");
            Rule();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            task = 50000;
            MessageBox.Show("Для того чтобы достичь выбранной цели, вам надо к концу игры иметь в запасе стране не меньше 50 000 монет.");
            Rule();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            task = 3055;
            MessageBox.Show("Для того чтобы достичь выбранной цели, вам надо к концу игры иметь в запасе страны не меньше 3000 солдат, 50 танков и 5 боеголовок.");
            Rule();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            n = 1;
            Rules rule = new Rules();
            rule.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
