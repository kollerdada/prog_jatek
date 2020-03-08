using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jatek.Megjelenites
{
    class KonzolosMegjelenito
    {
        IMegjelenitheto forras;
        int pozX;
        int pozY;

        public KonzolosMegjelenito(IMegjelenitheto forras, int pozX, int pozY)
        {
            this.forras = forras;
            this.pozX = pozX;
            this.pozY = pozY;
        }

        public void Megjelenites()
        {
            ;
            IKirajzolhato[] elemek = forras.MegjelenitendoElemek();
            //elemek = ;
            int[] meret = forras.MegjelenitendoMeret;
            ;
            int szamlalo = 0;
            for (int i = 0; i < meret[1] - 1; i++)
            {
                for (int j = 0; j < meret[0] - 1; j++)
                {
                    if (!(elemek[szamlalo].X == i && elemek[szamlalo].Y == j))
                    {
                        //SzalbiztosKonzol.KiirasXY(i /*+= pozX*/, j /*+= pozY*/, elemek[szamlalo].Alak);
                        SzalbiztosKonzol.KiirasXY(i/* += pozX*/, j/* += pozY*/, ' ');
                        //szamlalo++;
                    }
                    else
                    {
                        SzalbiztosKonzol.KiirasXY(i/* += pozX*/, j/* += pozY*/, elemek[szamlalo].Alak);
                        //SzalbiztosKonzol.KiirasXY(i/* += pozX*/, j /*+= pozY*/, ' ');
                        szamlalo++;
                    }
                }
            }
            for (int i = 0; i < elemek.Length; i++)
            {
                //elemek[i].X += pozX;
                //elemek[i].Y += pozY;

            }
        }
    }
}
