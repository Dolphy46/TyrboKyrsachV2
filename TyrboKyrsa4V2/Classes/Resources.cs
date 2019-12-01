using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurboKyrsa4.Forms
{
    public class Resources
    {
        private int rating = 50; //Рейтинг
        private int money = 10000; //ДЕНЬГИ

        public int numberMine = 0; //количество шахт
        public int numberSawmill = 0; //количество лесопилок
        public int numberFarm = 0; // количество ферм
        public bool port = false; // наличие порта
        public int numberPlant = 0; // количество заводов
        public int numberWindturbine = 0; // количество ветряков
        public int numberCasern = 0; // количество казарм
        public int numberLaboratory = 0; // количество лабораторий

        private int iron = 0; // количество железа
        private int coal = 0; //количество угля
        private int wood = 0; // количество древесины
        private int uranium = 0; // количество урана
        private int eat = 0; // количество еды
        private int tank = 0; // количество танков
        private int men = 0; // количество солдат
        private int warhead = 0; // колчество боеголовок


        public int park = 0;
        public int shop = 0;
        public int temple = 0;

        bool test = true; //Для проверки достаточно ли денег или ресурсов на счету у игрока
        public bool testport = false;
        public bool epidemic = false;

        public int InfoRating()
        {
            return rating;
        }

        public int InfoResources(int x)
        {
            int[] info = new int[5];
            info[0] = iron;
            info[1] = wood;
            info[2] = coal;
            info[3] = uranium;
            info[4] = eat;

            return info[x];
        }

        public int InfoMoney()
        {
            return money;
        }

        public bool InfoTest()
        {
            return test;
        }

        public void SetMoney() // каждый ход +500 монет
        {
            money = money + 500;

            if (park > 0)
                money = money + 10;
            if (shop > 0)
                money = money + 30 * shop;
            if (temple > 0)
                money = money + 300;
            if (numberWindturbine > 0)
                money = money + 150 * numberWindturbine;
        }

        public void SetNumberResours(int i)
        {
            test = true;
            switch (i)
            {
                case 0:
                    if (money >= 2000)
                    {
                        numberMine++;
                        money = money - 2000;
                    }
                    else
                        test = false;
                    break;
                case 1:
                    if (money >= 2000)
                    {
                        numberSawmill++;
                        money = money - 2000;
                    }
                    else
                        test = false;
                    break;
                case 2:
                    if (money >= 2000)
                    {
                        numberFarm++;
                        money = money - 2000;
                    }
                    else
                        test = false;
                    break;
                case 3:
                    if (money >= 5000 && iron >= 30 && coal >= 25 && wood >= 40)
                    {
                        iron = iron - 30;
                        coal = coal - 25;
                        wood = wood - 40;
                        port = true;
                        money = money - 5000;
                        rating = rating + 15;
                    }
                    else
                        test = false;
                    break;
                case 4:
                    if (money >= 3000 && iron >= 15 && coal >= 20 && wood >= 30)
                    {
                        iron = iron - 15;
                        coal = coal - 20;
                        wood = wood - 30;
                        numberPlant++;
                        money = money - 3000;
                    }
                    else
                        test = false;
                    break;
                case 5:
                    if (money >= 3000 && iron >= 20 && wood >= 10)
                    {
                        iron = iron - 20;
                        wood = wood - 10;
                        numberWindturbine++;
                        money = money - 3000;
                        rating = rating + 5;
                    }                   
                    else
                        test = false;

                    break;
                case 6:
                    if (money >= 3000 && iron >= 50 && coal >= 20 && wood >= 60)
                    {
                        iron = iron - 50;
                        coal = coal - 20;
                        wood = wood - 60;
                        numberCasern++;
                        money = money - 3000;
                    }
                    else
                        test = false;
                        break;
                case 7:
                    if (money >= 10000 && iron >= 30 && uranium >= 10 && wood >= 15)
                    {
                        iron = iron - 30;
                        wood = wood - 15;
                        uranium = uranium - 10;
                        numberLaboratory++;
                        money = money - 10000;
                    }    
                    else
                        test = false;
                    break;
                case 8:
                    if (money >=300)
                    {
                        park++;
                        money = money - 300;
                    }
                    else
                        test = false;
                    break;
                case 9:
                    if (money >= 1500)
                    {
                        shop++;
                        money = money - 1500;
                    }
                    else
                        test = false;
                    break;
                case 10:
                    if (money >= 2000)
                    {
                        temple++;
                        money = money - 2000;
                    }
                    else
                        test = false;
                    break;
            }
        }

        public string GetLabel2()
        {
            string str = "";
            str = "Ресурсы: " + "\nЖелезо: " + iron + "\nУголь: " + coal + "\nУран: " + uranium + "\nДерево: " + wood +
                "\nЕда: " + eat + "\nТанк: " + tank + "\nСолдаты: " + men + "\nБоеголовка: " + warhead;
            return str;
        }

        
        public string GetLabel3()
        {
            string str = "";
            str = "Количество построек: " + "\nШахты: " + numberMine + "\nЛесопилки: " + numberSawmill + "\nФермы: " + numberFarm + "\nЗаводы: " +
                numberPlant + "\nВетряки: " + numberWindturbine + "\nКазармы: " + numberCasern + "\nЛаборатории: " + numberLaboratory;
            if (port == true)
                str = str + "\nПорт: построен";
            return str;
        }
            

        Random random = new Random();

        public void PlusMine() // определяет сколько в шахте добывается ресурсов за ход
        {
            for (int i = 0; i < numberMine; i++)
            {
                iron = iron + random.Next(5, 30);
                coal = coal + random.Next(5, 15);
                uranium = uranium + random.Next(0, 4);
            }
        }

        public void PlusSwamill() //определяет сколько в лесопилки добывается ресурсов за ход
        {
            for(int i = 0; i < numberSawmill; i++)
            wood = wood + random.Next(5, 15);
        }

        public void PlusFarm() //определяет сколько на ферме добывается ресурсов за ход
        {
            for(int i = 0; i < numberFarm; i++)
            eat = eat + random.Next(5, 10);
        }

        public void MotionTank() //совершает производство такнков
        {
            test = true;
            if (iron >= 20)
            {
                tank = tank + 1;
                iron = iron - 20;
                rating = rating - 1;
            }
            else
                test = false;

        }

        public void MotionMen() //совершает производство солдат
        {
            test = true;
            if (eat >= 10 && money >=150)
            {
                men = men + 100;
                money = money - 150;
                eat = eat - 10;
                rating = rating - 5;
            }
            else
                test = false;

        }


        public void MotionWarhead() //совершает производство боеголовок
        {
            test = true;
            if (uranium >= 10 && iron >= 20)
            {
                warhead = warhead + 1;
                iron = iron - 20;
                uranium = uranium - 10;
                rating = rating - 25;
            }
            else
                test = false;
        }

        public void Buying(int x)  // Покупка и продажа ресурсов в порту
        {
            switch(x)
            {
                case 0:
                    money = money - 200;
                    iron = iron + 10;
                    break;
                case 1:
                    money = money - 100;
                    wood = wood + 10;
                    break;
                case 2:
                    money = money - 300;
                    coal = coal + 10;
                    break;
                case 3:
                    money = money - 500;
                    uranium = uranium + 1;
                    break;
                case 4:
                    money = money - 300;
                    eat = eat + 10;
                    break;
                case 5:
                    money = money + 200;
                    iron = iron - 10;
                    break;
                case 6:
                    money = money + 100;
                    wood = wood - 10;
                    break;
                case 7:
                    money = money + 300;
                    coal = coal - 10;
                    break;
                case 8:
                    money = money + 500;
                    uranium = uranium - 1;
                    break;
                case 9:
                    money = money + 300;
                    eat = eat - 10;
                    break;
            }

        }

        public void Conference(bool f, int x) //изменение рейтинга по средствам диалогов 
        {
            if (f == true)
                rating = rating + x;
            else
                rating = rating - x;
        }

        public void HelpResources(int x, int x1) // помощь ресурсами странам
        {
            test = true;
            switch (x)
            {
                case 0:
                    if (iron >= x1)
                        iron = iron - x1;
                    else
                        test = false;
                    break;

                case 1:
                    if (wood >= x1)
                        wood = wood - x1;
                    else
                        test = false;
                    break;

                case 2:
                    if (coal >= x1)
                        coal = coal - x1;
                    else
                        test = false;
                    break;

                case 3:
                    if (uranium >= x1)
                        uranium = uranium - x1;
                    else
                        test = false;
                    break;

                case 4:
                    if (eat >= x1)
                        eat = eat - x1;
                    else
                        test = false;
                    break;
                case 5:
                    if (money >= x1)
                        money = money - x1;
                    else
                        test = false;
                    break;
            }
        }

        public void HelpNature(int x)
        {
            test = true;
            if (money >= x)
                money = money - x;
            else
                test = false;
        }

        public void Spy() //Конференция: шпион (охрд солдта)
        {
            test = true;
            if (men >= 500)
                men = men - 500;
            else
            {
                test = false;
                men = 0;
            }
        }

        public bool PortTest() //Конференция: порт 
        {
            bool porttest;
            if (port == true)
            {
                porttest = true;
            }
            else
            {
                porttest = false;
            }
            return porttest;
        }

        
    }
}
