﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TurboKyrsa4.Forms;

namespace TurboKyrsa4.MainClasses
{
    class Dialogs
    {
        Resources resources;
        Random random = new Random();
        DialogResult res = new DialogResult();
        bool conference = false;
        private bool fport = false;

        public bool InfoConference()
        {
            return conference;
        }

        public void InfoResources(Resources re)
        {
            resources = re;
        }

        public void TestDualog(int x)
        {
            if (x % 3 == 0) //каждые три хода - вызов функции для помощи ресурсами
            {
                HelpResources(random.Next(0, 4), random.Next(10, 20));
            }

            if (x == 16)
            {
                ConferenceEpidemic();
                if (resources.epidemic)
                {
                    x = x - 2;
                    resources.SetMoney();
                    resources.SetMoney();
                }
            }

            if (x == 20 || x == 7) //20 и 7 ход - вызов функции для помощи монетами
            {
                HelpMoney(random.Next(500, 2500));
            }

            if (x == 5)
            {
                if (fport == true && resources.testport == true) //наличия порта после конференции порт
                    if (resources.PortTest())
                    {
                        MessageBox.Show("Порт был пстроен к установленному сроку.\nВы получаете 30 быллов рейтинга.");
                        resources.Conference(true, 30);
                    }
                    else
                    {
                        MessageBox.Show("Порт не был пocтроен к установленному сроку.\nВы теряете 30 быллов рейтинга.");
                        resources.Conference(false, 30);
                    }
                ConferenceSpy();
            }

            if (x == 10 && resources.port == false)
            {
                ConferencePort();
                fport = true;
            }
        }

        public void Conference() //первый ход - конференция
        {
            DialogResult res = MessageBox.Show("Добро пожаловать в игру!\nВ первый ход игры вам предлагается посетить приветственную " +
                "конференцию на которой произойдет знакомство всех стран.\nЕсли вы согласитесь её посетить, то вам пибавить 20 баллов" +
                " рейтинга, так как это будет расцениваться как положительный знак.\nЕсли вы решите не присутсвовать на конференции, " +
                "то вы потеряете 15 баллов рейтинга.\nПосещение конференции отнимет у вас один игровой ход, в течении которого вы не " +
                "сможите ничего сделать на карте.\n\nВы готовы посетить конференцию?", "Преветственная конференция", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                resources.Conference(true, 20);
                MessageBox.Show("Члены конференции были рады видеть вас на собрании\nВы потратили один ход и получили + 20 рейтинга");
                conference = true;
            }
            else
            {
                resources.Conference(false, 15);
                MessageBox.Show("Члены конференции надеялись увидеть вас на собрании.\nВы получили - 15 рейтинга");
            }
        }

        public void HelpResources(int x, int x1) // помощь стране ресурсами
        {
            string s = "";
            if (x == 0)
                s = "железа";
            else
                 if (x == 1)
                s = "дерева";
            else
                 if (x == 2)
                s = "угля";
            else
               if (x == 3)
                s = "урана";
            else
                s = "еды";

            res = MessageBox.Show("Одна из стран просит помочь ей ресурсами.\nЕсли вы согласны, то это принесёт 5 баллов " +
               "рейтинга.\nЕсли вы не согласны это отнимет 5 баллово рейтинга.\n\nГотовы ли вы перечислить стране " + x1 + " " + s + "?",
               "Помощь", MessageBoxButtons.YesNo);

            ResNew(5, x, x1);
        }

        public void HelpMoney(int x)// помощь стране деньгами
        {
            res = MessageBox.Show("Одна из стран просит помочь ей монетами.\nЕсли вы согласны, то это принесёт 10 баллов " +
               "рейтинга.\nЕсли вы не согласны это отнимет 10 баллово рейтинга.\n\nГотовы ли вы перечислить стране " + x + " монет?",
               "Помощь", MessageBoxButtons.YesNo);
            ResNew(10, 5, x);
        }

        public void ResNew(int r, int x, int x1) //изменение данных по количеству ресурсов при диалоге с другмими странами
        {
            if (res == DialogResult.Yes)
            {
                resources.HelpResources(x, x1);
                if (resources.InfoTest())
                {
                    resources.Conference(true, r);
                    MessageBox.Show("Страна благодарна вам за помощь\nВы получили + " + r + " рейтигна.");
                }
                else
                {
                    MessageBox.Show("У вас недостаточно ресурсов для помощи\nВы получаете - " + r + " рейтинга, потому что не можите помочь");
                    resources.Conference(false, r);
                }
            }
            else
            {
                resources.Conference(false, r);
                MessageBox.Show("Страна очень разочарована вашем отказом\nВы получили  - " + r + " рейтинга.");
            }
        }

        public void Heat()  //глобальное потеплеение из-за заводов (каждый раз при постройки более чем 2 заводов)
        {
            res = MessageBox.Show("Вы построили больше двух заводов на своей территории.\nЭто пагубно отразиться на экологии: " +
                "выбрасы влияют на чистоту воздуха.\nМировое сообщество просит вас поставить на заводы специальные фильтры как возмещение выбрасов от заводов." +
                "\nФильтры будут стоить 1500 монет.\nЕсли вы согласны, то это принесёт вам 20 баллов рейтинга." +
                "\nЕсли вы откажитесь, это отнимет 15 баллов рейтинга.\n\nВы готовы возместить ущерб за постройку завода?",
               "Нехватка кислорода", MessageBoxButtons.YesNo);
            HelpNature(15, 1500);
        }

        public void LittleO2() //нехватка кислорода из-за лесорубок (каждый раз при постройки более чем 2 лесорубок)
        {
            res = MessageBox.Show("Вы построили больше двух лесопилок на своей территории.\nЭто пагубно отразиться на экологии: " +
                "уменьшается количества кислорода.\nМировое сообщество просит вас посадить деревье для возмещения вреда от лесопилок." +
                "\nВысодка деревьев будет стоить 1000 монет.\nЕсли вы согласны, то это принесёт вам 20 баллов рейтинга." +
                "\nЕсли вы откажитесь, это отнимет 15 баллов рейтинга.\n\nВы готовы возместить ущерб за постройку лесопилки?",
               "Загрязнение воздуха", MessageBoxButtons.YesNo);
            HelpNature(15, 1000);
        }

        public void HelpNature(int r, int x) //изменение монет и рейтинга при диалоге с другмими странами в ситуация глоабльного потепления и нехватки кислорода
        {
            if (res == DialogResult.Yes)
            {
                resources.HelpNature(x);
                if (resources.InfoTest())
                {
                    resources.Conference(true, r + 5);
                    MessageBox.Show("Вы выполнили просьбу мирового сообщества.\nВы получили + " + (r + 5) + " рейтигна.");
                }
                else
                {
                    MessageBox.Show("У вас недостаточно монет.\nВы получаете - " + r + " рейтинга, потому что ваши действия вредят окружающей среде.");
                    resources.Conference(false, r);
                }
            }
            else
            {
                resources.Conference(false, r);
                MessageBox.Show("Мировое сообщество разочаровано, что вы отрицательно влияете на экологию в мире.\nВы получили  - " + r + " рейтинга.");
            }
        }

        public void ConferenceSpy() //Конференция: шпион
        {
            DialogResult res = MessageBox.Show("Был обнаружен шпион из вашей страны.\nПредставители всех стран собрались на конференцию " +
                "решать этот вопрос.\nЕсли вы готовы сдаВть человека, которого обвиняют в шпионаже пострадавшей стране, то вам " +
                "прибавиться 30 баллов рейтинга, но при этом от вас отвернуться 500 солдат из армии.\nЕсли вы окажите помощь " +
                "подозреваемрму человеку и оставите его у себя в стране вы потеряете 30 баллов рейтинга.\n\nВы готовы отдать шпиона?", 
                "Конференция: шпион", MessageBoxButtons.YesNo);

            if(res == DialogResult.Yes)
            {
                resources.Spy();
                if(resources.InfoTest())
                {
                    resources.Conference(true, 30);
                    MessageBox.Show("Вы согласились принять условия мирового сообщества.\nЭто принесло вам 30 баллов рейтинга, но от вас отвернулось 500 солдат.");
                }
                else
                {
                    resources.Conference(true, 30);
                    MessageBox.Show("Вы согласились принять условия мирового сообщества.\nЭто принесло вам 30 баллов рейтинга, но от вас отвернулись все солдаты.");
                }
            }
            else
            {
                resources.Conference(false, 30);
                MessageBox.Show("Вы отказались принять условия мирового сообщества\nВы получили - 30 рейтинга, но в тоже время с вами остались все ваши солдаты.");
            }
        }

        public void ConferencePort() //Конференция: порт
        {
            DialogResult res = MessageBox.Show("\nПредставители всех стран собрались на конференцию для улучшение торговой ситуации." +
                "\nК данному моменту игры, важно чтобы у всех стран был построен порт.\nЕсли у вас ещё не построен порт, то вам обязательно " +
                "надо его построить к 5 ходу.\nЭто принесёт вам 30 баллов рейтинга.\nЕсли вы не готовы его строить, то это отнимет у вас 30 баллов рейтинга." +
                "\n\nВы готовы постоить порт к 5 ходу?","Конференция: порт", MessageBoxButtons.YesNo);

            if(res == DialogResult.Yes)
            {
                resources.testport = true;
                MessageBox.Show("К 5 ходу у вас обязан в стране стоять порт.");
            }
            else
            {
                resources.Conference(false, 30);
                MessageBox.Show("Вы отказались принимать условия мирового сообщества.\nВы получаете - 30 баллов рейтинга.");
            }
        }

        public void ConferenceEpidemic() // Конференция: эпидемия
        {
            DialogResult res = MessageBox.Show("\nПредставители всех стран собрались на конференцию так как у вас в старне началась эпидемия." +
                "\nЭто очень серьезно, так как она может перейти и к другим странам. \nЕсли вы готовы закрыть свою страну на 2 хода (вам придут только деньги что приносит город" +
                "), то вы получите 30 баллов рейтинга.\nЕсли вы не хотите закрывать город, то это отнимет у вас 30 баллов рейтинга." +
                "\n\nВы готовы закрыть город?", "Конференция: эпидемия", MessageBoxButtons.YesNo);

            if (res == DialogResult.Yes)
            {
                resources.epidemic = true;
                resources.Conference(true, 30);
                MessageBox.Show("Вы приняли условия мирового сообщества.\nВы получаете - 30 баллов рейтинга и лишаетесь двух игровых ходов.");
            }
            else
            {
                resources.Conference(false, 30);
                MessageBox.Show("Вы отказались принимать условия мирового сообщества.\nВы получаете - 30 баллов рейтинга.");
            }
        }
    }
}