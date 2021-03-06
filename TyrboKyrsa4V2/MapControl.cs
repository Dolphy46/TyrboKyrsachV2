﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TurboKyrsa4.MainClasses;
using TyrboKyrsa4V2.Classes;
using TyrboKyrsa4V2.Forms;
using TurboKyrsa4.Forms;

namespace TyrboKyrsa4V2
{
    public partial class MapControl : UserControl
    {
        bool[,] water;
        int[,] map;
        bool[,] playerzone;
        bool[,] am;
        bool[,] du;
        int moves=30;
        int task;
        bool z = true, l = true;
        public MapControl()
        {
            InitializeComponent();
            mn.Load();          
            water = mn.GetWater();
            map = mn.GetMap();
            im.LoadDef();
            images = im.GetImage();
            zm.Load();
            zm.LoadAm();
            zm.LoadDu();
            am = zm.GetAmZone();
            du = zm.GetDuZone();
            playerzone = zm.GetZone();
            GenerateButtons();

            resources.rEsourses[0]= new Iron();
            resources.rEsourses[1] = new Coal();
            resources.rEsourses[2] = new Wood();
            resources.rEsourses[3] = new Uranium();
            resources.rEsourses[4] = new Eat();
            resources.facilities[0] = new Mine(2000);
            resources.facilities[1] = new Swamill(2000);
            resources.facilities[2] = new Farm(2000);
            resources.facilities[3] = new POrt(5000, 30, 25, 40);
            resources.facilities[4] = new Plant(3000, 20, 15, 30);
            resources.facilities[5] = new Windturbine(3000, 20, 0, 10);
            resources.facilities[6] = new Casern(3000, 50, 20, 60);
            resources.facilities[7] = new Laboratory(10000, 10, 10, 15);

            label1.Text = "Рейтинг: " + resources.InfoRating().ToString() + "\nБаланс города: " + resources.InfoMoney().ToString();
            label2.Text = resources.GetLabel2();
            label3.Text = resources.GetLabel3();
            label4.Text = "Количество ходов: " + moves;
        }
        
        Manager mn = new Manager();
        SButton[,] buttons = new SButton[15, 8];
        ZoneManager zm = new ZoneManager();
        Image[] images;
        Dialogs dialogs = new Dialogs();
        ImageManager im = new ImageManager();
        Random random = new Random();
        Construction construction = new Construction();
        Port port = new Port();
        City city = new City();
        Production production = new Production();
        Resources resources = new Resources();
        DialogResult dr = new DialogResult();

        void labelupdate()
        {
            label1.Text = "Рейтинг: " + resources.InfoRating().ToString() + "\nБаланс города: " + resources.InfoMoney().ToString();
            label2.Text = resources.GetLabel2();
            label3.Text = resources.GetLabel3();
            label4.Text = "Количество ходов: " + moves;
        }

        public void Task(int x)
        {
            task = x;
        }

        public void GenerateButtons()
        {       
            int x = 138, y = 75;
            bool count = true;
            Point[] P = new Point[6];
            P[0] = new Point(27, 5);
            P[1] = new Point(82, 5);
            P[2] = new Point(110, 50);
            P[3] = new Point(81, 97);
            P[4] = new Point(28, 97);
            P[5] = new Point(-1, 50);
            for (int i = 0; i < 15; i++)
            {
                for (int i2 = 0; i2 < 7; i2++)
                {
                    if (water[i, i2] == true)
                    {
                        buttons[i,i2] = new SButton();
                        buttons[i, i2].Name = "";
                        buttons[i, i2].Width = 110;
                        buttons[i, i2].Height = 100;
                        buttons[i, i2].Location = new Point(x,y);
                        buttons[i, i2].FlatAppearance.BorderSize = 0;
                        buttons[i, i2].FlatStyle = FlatStyle.Flat;
                        buttons[i, i2].MouseEnter += new System.EventHandler(but_Enter);
                        buttons[i, i2].MouseLeave += new System.EventHandler(but_Leave);
                        buttons[i, i2].Click += new System.EventHandler(but_click);
                        buttons[i, i2].BackColor = Color.Green;
                        Controls.Add(buttons[i, i2]);
                        System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                        path.AddPolygon(P);
                        Region RG = new Region(path);
                        buttons[i, i2].Region = RG;
                        buttons[i, i2].Image = images[map[i,i2]];
                        buttons[i, i2].i = i;
                        buttons[i, i2].i2 = i2;
                        buttons[i, i2].can = playerzone[i, i2];
                        buttons[i, i2].map = map[i, i2];
                        buttons[i, i2].build = true;
                        buttons[i, i2].am = am[i,i2];
                        buttons[i, i2].ambuild = true;
                        buttons[i, i2].du = du[i,i2];
                    }
                    x += 162;
                }
                if (count == true)
                {
                    x = 57;
                    y += 47;
                    count = false;
                }
                else
                {
                    x = 138;
                    y += 45;
                    count = true;
                }
            }
        }

        private void but_Enter(object sender, EventArgs e)
        {
            SButton b = (SButton)sender;
            if (b.can)
                b.BackColor = Color.Orange;
            else
                b.BackColor = Color.Red;
        }

        private void but_Leave(object sender, EventArgs e)
        {
            SButton b = (SButton)sender;
            b.BackColor = Color.Green;
        }

        private void but_click(object sender, EventArgs e)
        {
            SButton b = (SButton)sender;
            if (b.build || b.map==28 || b.map == 29 || b.map == 31 || b.map == 32)
            {
                if (b.map == 28)
                {
                    port.GetResoures(resources);
                    port.Info();
                    port.ShowDialog();
                }
                else
                if(b.map == 1)
                {
                    city.GetResources(resources);
                    city.ShowDialog();
                }
                else
                    if(b.map == 31 || b.map == 32 || b.map == 29)
                {
                    production.GetResources(resources);
                    production.InfoCoords(b.map);
                    production.ShowDialog();
                }
                else
                {
                    if (b.can)
                    {
                        construction.GetResources(resources);
                        construction.ShowDialog();
                        if (construction.GetCheck())
                        {
                            construction.GetBilding(b, images);
                        }
                        construction.SetCheck();
                    }
                    else
                        MessageBox.Show("Это не ваша территория!");
                }
            }
            else
                MessageBox.Show("Здесь уже построено здание!");
            labelupdate();
        }

        private bool TaskExecution()
        {
            switch (task)
            {
                case 90:
                    if (resources.InfoRating() >= task)
                        return true;
                    else
                        return false;
                case 10:
                    if (resources.InfoRating() <= task)
                        return true;
                    else
                        return false;
                case 50000:
                    if (resources.InfoMoney() >= task)
                        return true;
                    else
                        return false;
                case 3055:
                    if (resources.InfoResources(5) >= 3000 && resources.InfoResources(6) >= 50 && resources.InfoResources(7) >= 5)
                        return true;
                    else
                        return false;
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
                dialogs.InfoResources(resources); //каждый ход передает экзепляр класса Resources в класс Dialogs
                if (moves == 30)
                {
                    dialogs.Conference();
                    if (dialogs.InfoConference() == true)
                        moves--;
                }

                if (moves != 1)
                {
                    resources.SetMoney();

                    if (resources.facilities[0].number > 0)
                    {
                        int[] a = new int[3];
                        Mine mine = (Mine)resources.facilities[0];
                        a = mine.Plus(resources.rEsourses[0].number, resources.rEsourses[1].number, resources.rEsourses[3].number);
                        resources.rEsourses[0].number = a[0];
                        resources.rEsourses[1].number = a[1];
                        resources.rEsourses[3].number = a[2];
                    }

                    if (resources.facilities[1].number > 0)
                    {
                        Swamill swamill = (Swamill)resources.facilities[1];
                        int a = swamill.Plus(resources.rEsourses[2].number);
                        resources.rEsourses[2].number = a;
                    }

                    if (resources.facilities[2].number > 0)
                    {
                        Farm farm = (Farm)resources.facilities[2];
                        int a = farm.Plus(resources.rEsourses[4].number);
                        resources.rEsourses[4].number = a;
                    }

                    if (resources.InfoRating() >= 100)
                        resources.OneHundredRating();
                    labelupdate();
                    moves--;
                    dialogs.TestDualog(moves);
                if (resources.facilities[4].number > 2 && z == true)
                {
                    dialogs.Heat();
                    z = false;
                }
                if (resources.facilities[1].number > 2 && l == true)
                {
                    dialogs.LittleO2();
                    l = false;
                }
                if (resources.epidemic == true)
                {
                    moves--;
                    resources.epidemic = false;
                }
                    if (resources.InfoRating() >= 100)
                        resources.OneHundredRating();
                    labelupdate();
                    if (resources.InfoRating() <= 0)
                    {
                        MessageBox.Show("Ваш рейтинг достиг нуля. Вы проиграли.");
                        Application.Exit();
                    }
                }
                else
                {
                    moves--;
                    labelupdate();
                    if (TaskExecution())
                        MessageBox.Show("Поздравляем!!!\nВы достигли цели игры.\n Спасибо большое за игру. Дотвиданиня!");
                    else
                        MessageBox.Show("Не расстраивайтесь!!!\nВы не достигли цели игры.\nОбызательно попробуйте пройти её ещё раз");
                    Application.Exit();
                }
        }
    }
}
