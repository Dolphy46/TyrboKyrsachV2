using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using TurboKyrsa4.Forms;
using TurboKyrsa4.MainClasses;

namespace TyrboKyrsa4V2.Classes
{
    class Ai
    {
        Resources resam = new Resources();
        Construction construction = new Construction();
        Image[] images;
        int sawmill = 0;
        int mine = 0;
        int farm = 0;
        int counter = 0;
        bool trigger = true;


        public SButton[,] am(SButton[,] buttons,int moves,Image[] im, bool[,] water)
        {       
            images = im;
            int count;
            if (moves <= 5)
                count = 6;
            else
            {
                if (moves <= 10)
                    count = 5;
                else
                {
                    if (moves <= 15)
                        count = 4;
                    else
                    {
                        if (moves <= 20)
                            count = 3;
                        else
                        {
                            if (moves <= 25)
                                count = 2;
                            else
                                count = 1;
                        }
                    }
                }
            }
            switch (count)
            {
                case 1:
                    firstmove(buttons,water);
                    break;
                case 2:
                    secoundmove(buttons, water);
                    break;
                case 3:
                    threedmove(buttons, water);
                    break;
                case 4:
                    fourmove(buttons, water);
                    break;
                case 5:
                    break;
                case 6:
                    break;
            }
            return buttons;
        }

        public SButton[,] firstmove(SButton[,] buttons, bool[,] water)
        {
            int[] index = GetIndex(buttons, water);
            if (index[1] != 0)
            {
                construction.GetResources(resam);
                int map = new Random().Next(0, 3);
                switch (map)
                {
                    case 0:
                        mine++;
                        break;
                    case 1:
                        sawmill++;
                        break;
                    case 2:
                        farm++;
                        break;
                }
                resam.SetNumberResours(map);
                buttons[index[0], index[1]].map = map + 25;
                buttons[index[0], index[1]].ambuild = false;
                buttons[index[0], index[1]].Image = images[map + 25];
            }
            return buttons;
        }

        public SButton[,] secoundmove(SButton[,] buttons, bool[,] water)
        {
            int[] index = GetIndex(buttons, water);
            if (index[1] != 0)
            {
                construction.GetResources(resam);
                int map;
                if (mine < 3)
                {
                    mine++;
                    map = 0;
                }
                else
                {
                    if (sawmill < 2)
                    {
                        map = 1;
                        sawmill++;
                    }
                    else
                    {
                        if (farm < 2)
                        {
                            map = 2;
                            farm++;
                        }
                        else return buttons;
                    }
                }
                resam.SetNumberResours(map);
                buttons[index[0], index[1]].map = map + 25;
                buttons[index[0], index[1]].ambuild = false;
                buttons[index[0], index[1]].Image = images[map + 25];
            }
            return buttons;
        }

        public SButton[,] threedmove(SButton[,] buttons, bool[,] water)
        {
            int[] index = GetIndex(buttons, water);
            construction.GetResources(resam);
            int map = 0;     
            if (counter == 0)
            {
                resam.SetNumberResours(31);
                buttons[index[0], index[1]].map = 31;
                buttons[index[0], index[1]].ambuild = false;
                buttons[index[0], index[1]].Image = images[31];
            }
            else
            {
                if (counter == 1)
                {
                    resam.SetNumberResours(29);
                    buttons[index[0], index[1]].map = 29;
                    buttons[index[0], index[1]].ambuild = false;
                    buttons[index[0], index[1]].Image = images[29];
                    resam.MotionMen();
                }
                else
                {
                    resam.MotionMen();
                    resam.MotionTank();
                }
            }
            counter++;
            return buttons;
        }

        public SButton[,] fourmove(SButton[,] buttons, bool[,] water)
        {
            int[] index = GetIndex(buttons, water);
            construction.GetResources(resam);
            if (trigger)
            {
                resam.SetNumberResours(32);
                buttons[index[0], index[1]].map = 32;
                buttons[index[0], index[1]].ambuild = false;
                buttons[index[0], index[1]].Image = images[32];
                trigger = false;
            }
            resam.MotionMen();
            resam.MotionTank();
            return buttons;
        }

        public SButton[,] fivemove(SButton[,] buttons, bool[,] water)
        {
            resam.MotionMen();
            resam.MotionTank();
            resam.MotionWarhead();
            return buttons;
        }

        public SButton[,] sixmove(SButton[,] buttons, bool[,] water)
        {
            resam.MotionMen();
            resam.MotionTank();
            resam.MotionWarhead();
            return buttons;
        }

        public int[] GetIndex(SButton[,] button, bool[,] water)
        {
            List<int[]> list = new List<int[]>();
            for (int i = 0; i < 15; i++)
            {
                for (int i2 = 0; i2 < 7; i2++)
                {                   
                    if(water[i,i2])
                        if (button[i, i2].ambuild)
                            if (button[i, i2].am)
                                {
                                    int[] numbers = new int[2];
                                    numbers[0] = i;
                                    numbers[1] = i2;
                                    list.Add(numbers);
                                }
                }
            }
            int[] index = new int[2];
            if (list.Count > 0)
            {
                index = list[new Random().Next(list.Count)];
                return index;
            }
            else
            {
                index[1] = 0;
                return index;
            }
        }
    }
}
