using System;
using TyrboKyrsa4V2.Classes;

namespace TurboKyrsa4.Forms
{
    public class Resources
    {
        private int rating = 50; //Рейтинг
        private int money = 10000; //ДЕНЬГИ

        public REsourses[] rEsourses = new REsourses[8];
        public Facilities[] facilities = new Facilities[8];

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

        public void OneHundredRating()
        {
            rating = 100;
        }

        public bool InfoTest()
        {
            return test;
        }

        public int InfoResources(int x)
        {
            int[] info = new int[8];
            info[0] = rEsourses[0].number;
            info[1] = rEsourses[2].number;
            info[2] = rEsourses[1].number;
            info[3] = rEsourses[3].number;
            info[4] = rEsourses[4].number;
            info[5] = men;
            info[6] = tank;
            info[7] = warhead;

            return info[x];
        }

        public int InfoMoney()
        {
            return money;
        }

        public void SetMoney() // каждый ход +1000 монет
        {
            money = money + 1000;

            if (park > 0)
                money = money + 150;
            if (shop > 0)
                money = money + 100 * shop;
            if (temple > 0)
                money = money + 300;
            if (facilities[5].number > 0)
                money = money + 150 * facilities[5].number;
        }

        public void MinusRes(int m, int iron, int coal, int wood )
        {
            money = money - m;
            rEsourses[0].number = rEsourses[0].number - iron;
            if(m == 10000)
                rEsourses[3].number = rEsourses[3].number - coal;
            else
               rEsourses[1].number = rEsourses[1].number - coal;
            rEsourses[2].number = rEsourses[2].number - wood;
        }

        public bool SetNumberResours(int i)
        {
            if(i == 7)
                facilities[i].InfoRes(rEsourses[0].number, rEsourses[1].number, rEsourses[3].number);
            else
            if (i > 2)
                facilities[i].InfoRes(rEsourses[0].number, rEsourses[1].number, rEsourses[2].number);
            if (facilities[i].Build(money))
            {
                MinusRes(facilities[i].cost[0], facilities[i].cost[1], facilities[i].cost[2], facilities[i].cost[3]);
                if(i == 3 || i == 5)
                    rating = rating + 15;
                return true;
            }
            else return false;
        }

        public string GetLabel2()
        {
            string str = "";
            str = "Ресурсы: " + "\nЖелезо: " + rEsourses[0].number + "\nУголь: " + rEsourses[1].number + "\nУран: " + rEsourses[3].number + "\nДерево: " + rEsourses[2].number +
                "\nЕда: " + rEsourses[4].number + "\nТанк: " + tank + "\nСолдаты: " + men + "\nБоеголовка: " + warhead;
            return str;
        }

        
        public string GetLabel3()
        {
            string str = "";
            str = "Количество построек: " + "\nШахты: " + facilities[0].number + "\nЛесопилки: " + facilities[1].number + "\nФермы: " + facilities[2].number + "\nЗаводы: " +
                facilities[4].number + "\nВетряки: " + facilities[5].number + "\nКазармы: " + facilities[6].number + "\nЛаборатории: " + facilities[7].number;
            if (facilities[3].number == 1)
                str = str + "\nПорт: построен";
            return str;
        }
            
        public void MotionTank() //совершает производство такнков
        {
            test = true;
            if (rEsourses[0].number >= 20)
            {
                tank = tank + 5;
                rEsourses[0].number = rEsourses[0].number - 20;
                rating = rating - 5;
            }
            else
                test = false;

        }

        public void MotionMen() //совершает производство солдат
        {
            test = true;
            if (rEsourses[4].number >= 10 && money >=150)
            {
                men = men + 100;
                money = money - 150;
                rEsourses[4].number = rEsourses[4].number - 10;
                rating = rating - 5;
            }
            else
                test = false;

        }

        public void MotionWarhead() //совершает производство боеголовок
        {
            test = true;
            if (rEsourses[3].number >= 10 && rEsourses[0].number >= 20)
            {
                warhead = warhead + 1;
                rEsourses[0].number = rEsourses[0].number - 20;
                rEsourses[3].number = rEsourses[3].number - 10;
                rating = rating - 10;
            }
            else
                test = false;
        }

        public void Buying(int price, int number)  // Покупка и продажа ресурсов в порту
        {
            money = money - (price * number);
        }

        public void Sale(int x, int cost)  // Покупка и продажа ресурсов в порту
        {
            money = money + (x * cost);
        }

        public void Conference(bool f, int x) //изменение рейтинга по средствам диалогов 
        {
            if (f == true)
                rating = rating + x;
            else
                rating = rating - x;
        }

        public void HelpResources(int res, int x1) // помощь ресурсами странам
        {
            test = true;
            if (res == 5)
                if (money >= x1)
                    money = money - x1;
                else
                    test = false;
            else
                if (rEsourses[res].number >= x1)
                   rEsourses[res].number = rEsourses[res].number - x1;
                else
                   test = false;
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
            if (facilities[3].number == 1)
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
