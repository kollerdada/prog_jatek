using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jatek.Jatekter;

namespace Jatek.Keret
{
    class Keret
    {
        static Random rnd = new Random();
        const int PALYA_MERET_X = 21;
        const int PALYA_MERET_Y = 11;
        const int KINCSEK_SZAMA = 10;
        private Jatekter.Jatekter ter;
        bool jatekVege = false;

        public Keret()
        {
            ter = new Jatekter.Jatekter(PALYA_MERET_X, PALYA_MERET_Y);
            PalyaGeneralas(PALYA_MERET_X, PALYA_MERET_Y, KINCSEK_SZAMA);
        }

        private void PalyaGeneralas(int PALYA_MERET_X, int PALYA_MERET_Y, int KINCSEK_SZAMA)
        {

            //Jatekter.JatekElem[,] palya = new Jatekter.JatekElem[PALYA_MERET_X, PALYA_MERET_Y];
            for (int i = 0; i <= PALYA_MERET_Y - 1; i++)
            {
                for (int j = 0; j <= PALYA_MERET_X - 1; j++)
                {
                    if (i == 0 || j == PALYA_MERET_X - 1 || j == 0 || i == PALYA_MERET_Y - 1)
                    {
                        //palya[i, j] = new Szabalyok.Fal(i, j, ter);
                        Szabalyok.Fal f1 = new Szabalyok.Fal(i, j, ter)
                        {
                            X = i,
                            Y = j
                        };
                        //Console.WriteLine(f1.X.ToString() + ", " + f1.Y.ToString());
                    }
                    //if ()
                    //{
                    //    //palya[i, j] = new Szabalyok.Fal(i, j, ter);
                    //    Szabalyok.Fal f2 = new Szabalyok.Fal(i, j, ter);
                    //    f2.X = i;
                    //    f2.Y = j;
                    //}
                    //if ()
                    //{
                    //    //palya[i, j] = new Szabalyok.Fal(i, j, ter);
                    //    Szabalyok.Fal f3 = new Szabalyok.Fal(i, j, ter);
                    //    f3.X = i;
                    //    f3.Y = j;
                    //}
                    //if ()
                    //{
                    //    //palya[i, j] = new Szabalyok.Fal(i, j, ter);
                    //    Szabalyok.Fal f4 = new Szabalyok.Fal(i, j, ter);
                    //    f4.X = i;
                    //    f4.Y = j;
                    //}
                    //else { }
                }
            }
            RandomHelyek(KINCSEK_SZAMA);
        }
        private void RandomHelyek(int KINCSEK_SZAMA)
        {
            ;
            int i = 0;
            while (i < KINCSEK_SZAMA)
            {
                int x = rnd.Next(1, 19);
                int y = rnd.Next(1, 9);

                if (x != 1 && y != 1 && ter.MegadottHelyenLevok(x, y).Length <= 10)
                {
                    Szabalyok.Kincs kincs = new Szabalyok.Kincs(x, y, ter);
                    kincs.X = x;
                    kincs.Y = y;
                    i++;
                }

            }
        }
        public void Futtatas()
        {
            Szabalyok.Jatekos jatekos = new Szabalyok.Jatekos("Béla", 1, 1, ter);
            Megjelenites.KonzolosMegjelenito konzolosMegjelenito = new Megjelenites.KonzolosMegjelenito(ter, 0, 0);
            Megjelenites.KonzolosMegjelenito konzolosMegjelenitoBela = new Megjelenites.KonzolosMegjelenito(jatekos, 25, 0);
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    jatekos.Megy(-1, 0);
                    konzolosMegjelenito.Megjelenites();
                    konzolosMegjelenitoBela.Megjelenites();
                }
                if (key.Key == ConsoleKey.RightArrow)
                {
                    jatekos.Megy(1, 0);
                    konzolosMegjelenito.Megjelenites();
                    konzolosMegjelenitoBela.Megjelenites();
                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    jatekos.Megy(0, -1);
                    konzolosMegjelenito.Megjelenites();
                    konzolosMegjelenitoBela.Megjelenites();
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    jatekos.Megy(0, 1);
                    konzolosMegjelenito.Megjelenites();
                    konzolosMegjelenitoBela.Megjelenites();
                }
                if (key.Key == ConsoleKey.Escape)
                {
                    jatekVege = true;
                }
                    //Console.WriteLine(jatekos.Y.ToString() + ", " + jatekos.X.ToString());
                } while (!jatekVege);
        }
    }
}
