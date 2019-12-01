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

namespace TyrboKyrsa4V2
{
    public partial class MapControl : UserControl
    {
        bool[,] water;
        int[,] map;
        bool[,] playerzone;
        int moves=30;
        private bool fport = false;

        public MapControl()
        {
            InitializeComponent();
            mn.Load();          
            water = mn.GetWater();
            map = mn.GetMap();
            im.LoadDef();
            images = im.GetImage();
            zm.Load();
            playerzone = zm.GetZone();
            GenerateButtons();
            label1.Text = "Рейтинг: " + construction.resources.InfoRating().ToString() + "\nБаланс города: " + construction.resources.InfoMoney().ToString();
            label2.Text = construction.resources.GetLabel2();
            label3.Text = construction.resources.GetLabel3();
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

        void labelupdate()
        {
            label1.Text = "Рейтинг: " + construction.resources.InfoRating().ToString() + "\nБаланс города: " + construction.resources.InfoMoney().ToString();
            label2.Text = construction.resources.GetLabel2();
            label3.Text = construction.resources.GetLabel3();
            label4.Text = "Количество ходов: " + moves;
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
                        buttons[i,i2].MouseEnter += new System.EventHandler(but_Enter);
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
            if (b.build)
            {
                if (b.can)
            {
                    construction.Info(b.map);
                    construction.ShowDialog();
                    if (construction.GetCheck())
                    {
                        construction.GetBilding(b, images);
                        labelupdate();
                    }
                    construction.SetCheck();
                }
                else
                    MessageBox.Show("Это не ваша територия!");
            }
            else
                MessageBox.Show("Здесь уже построено здание!");
            construction.Clean(b.map);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dialogs.InfoResources(construction.resources); //каждый ход передает экзепляр класса Resources в класс Dialogs
            if (moves == 30)
            {
                dialogs.Conference();
                if (dialogs.InfoConference() == true)
                    moves--;
            }

            if (moves != 1)
            {
                construction.resources.SetMoney();
                if (construction.resources.numberMine > 0)
                    construction.resources.PlusMine();
                if (construction.resources.numberSawmill > 0)
                    construction.resources.PlusSwamill();
                if (construction.resources.numberFarm > 0)
                    construction.resources.PlusFarm();
                moves--;

                if (moves % 3 == 0) //каждые три хода - вызов функции для помощи ресурсами
                {
                    dialogs.HelpResources(random.Next(0, 4), random.Next(10, 20));
                }

                if (moves == 16)
                {
                    dialogs.ConferenceEpidemic();
                    if (construction.resources.epidemic)
                    {
                        moves = moves - 2;
                        construction.resources.SetMoney();
                        construction.resources.SetMoney();
                    }
                }

                if (moves == 20 || moves == 7) //20 и 7 ход - вызов функции для помощи монетами
                {
                    dialogs.HelpMoney(random.Next(500, 2500));
                }

                if (moves == 5)
                {
                    if (fport == true && construction.resources.testport == true) //наличия порта после конференции порт
                        if (construction.resources.PortTest())
                        {
                            MessageBox.Show("Порт был пстроен к установленному сроку.\nВы получаете 30 быллов рейтинга.");
                            construction.resources.Conference(true, 30);
                        }
                        else
                        {
                            MessageBox.Show("Порт не был пocтроен к установленному сроку.\nВы теряете 30 быллов рейтинга.");
                            construction.resources.Conference(false, 30);
                        }
                    dialogs.ConferenceSpy();
                }

                if (moves == 10 && construction.resources.port == false)
                {
                    dialogs.ConferencePort();
                    fport = true;
                }

            }
            else
            {
                moves--;
                MessageBox.Show("Конец игры.Дотвиданиня!");
                Application.Exit();
            }
            labelupdate();
        }
    }
}
