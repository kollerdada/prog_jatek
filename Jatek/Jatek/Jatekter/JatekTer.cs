using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jatek.Jatekter
{
    class Jatekter : Megjelenites.IMegjelenitheto
    {
        const int MAX_ELEMSZAM = 1000;
        int elemN;
        JatekElem[] elemek = new JatekElem[MAX_ELEMSZAM];
        int meretX;
        int meretY;

        public int MeretX { get { return meretX; } }
        public int MeretY { get { return meretY; } }

        public int[] MegjelenitendoMeret
        {
            get
            {
                int[] meret = new int[2];
                meret[0] = meretX;
                meret[1] = meretY;
                return meret;
            }
        }

        public Jatekter(int meretX, int meretY)
        {
            this.meretX = meretX;
            this.meretY = meretY;
        }

        public Megjelenites.IKirajzolhato[] MegjelenitendoElemek()
        {
            int szamlalo = 0;
            for (int i = 0; i < elemek.Length; i++)
            {
                if (elemek[i] is Megjelenites.IKirajzolhato)
                {
                    szamlalo++;
                }
            }
            int idx = 0;
            Megjelenites.IKirajzolhato[] vissza = new Megjelenites.IKirajzolhato[szamlalo];
            for (int i = 0; i < elemek.Length; i++)
            {
                if (elemek[i] is Megjelenites.IKirajzolhato)
                {
                    vissza[idx] = (elemek[i] as Megjelenites.IKirajzolhato);
                    idx++;
                    //vissza[idx].Y = elemek[i].Y;
                }
            }
            return vissza;
        }

        public void Felvetel(JatekElem ujElem)
        {
            int i = 0;
            while (i < elemek.Length - 1 && !(elemek[i] == null))
            {
                i++;
            }

            elemek[i] = ujElem;
            elemN++;
        }
        public void Torles(JatekElem regiElem)
        {
            int i = 0;
            while (i < elemek.Length && !(elemek[i] == regiElem))
            {
                i++;
            }
            elemek[i] = null;
            for (int k = i; k < elemek.Length; k++)
            {
                JatekElem tmp = elemek[i];
                elemek[i] = elemek[i + 1];
                elemek[i + 1] = tmp;
            }
            regiElem = null;
            elemN--;
        }

        public JatekElem[] MegadottHelyenLevok(int x, int y, double tavolsag)
        {
            int ennyiJatekElem = 0;
            JatekElem[] talaltElemek;
            for (int i = 0; i < elemek.Length; i++)
            {
                if (elemek[i] != null)
                {
                    if (Math.Abs(x - elemek[i].X) <= tavolsag && Math.Abs(y - elemek[i].Y) <= tavolsag)
                    {
                        ennyiJatekElem++;
                    }
                }
            }
            ;
            talaltElemek = new JatekElem[ennyiJatekElem];
            int k = 0;
            for (int i = 0; i < elemek.Length; i++)
            {
                if (elemek[i] != null)
                {
                    if (Math.Abs(x - elemek[i].X) <= tavolsag && Math.Abs(y - elemek[i].Y) <= tavolsag)
                    {
                        talaltElemek[k] = elemek[i];
                        k++;
                    }
                }
            }
            ;
            return talaltElemek;
        }
        public JatekElem[] MegadottHelyenLevok(int x, int y)
        {
            ;
            double tavolsag = 0;
            int ennyiJatekElem = 0;
            JatekElem[] talaltElemek;
            for (int i = 0; i < elemek.Length; i++)
            {
                if (elemek[i] != null)
                {
                    if (Math.Abs(x - elemek[i].X) == tavolsag && Math.Abs(y - elemek[i].Y) == tavolsag)
                    {
                        ennyiJatekElem++;
                    }
                }
            }
            talaltElemek = new JatekElem[ennyiJatekElem];
            int k = 0;
            ;
            for (int i = 0; i < elemek.Length; i++)
            {
                if (elemek[i] != null)
                {
                    if (Math.Abs(x - elemek[i].X) == tavolsag && Math.Abs(y - elemek[i].Y) == tavolsag)
                    {
                        talaltElemek[k] = elemek[i];
                        k++;
                    }
                }
            }
            return talaltElemek;
            ;
        }

    }
}
