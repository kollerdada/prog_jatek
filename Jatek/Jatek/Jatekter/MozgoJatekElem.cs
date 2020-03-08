using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jatek.Jatekter
{
    class MozgoJatekElem : JatekElem
    {
        bool aktiv;

        public bool Aktiv { get { return aktiv; } set {aktiv = value; } }

        public override double Meret => throw new NotImplementedException();

        public MozgoJatekElem(int x, int y, Jatekter ter) : base(x, y, ter)
        {

        }
        
        public void Athelyez(int ujx, int ujy)
        {
            JatekElem[] adottHelyenLevok = ter.MegadottHelyenLevok(ujx, ujy);

            for (int i = 0; i < adottHelyenLevok.Length; i++)
            {
                adottHelyenLevok[i].Utkozes(this);
                this.Utkozes(adottHelyenLevok[i]);
                if (this.Aktiv == false)
                {
                    break;
                }
            }
            //adottHelyenLevok = ter.MegadottHelyenLevok(ujx, ujy);
            double meglevoMeret = 0;
            for (int i = 0; i < adottHelyenLevok.Length; i++)
            {
                meglevoMeret += adottHelyenLevok[i].Meret;
            }
            if (LephetE(meglevoMeret, this.Meret))
            {
                this.X = ujx;
                this.Y = ujy;
            }

        }
        private bool LephetE(double meglevok, double mozgo)
        {
            bool lephetE = false;
            if (meglevok + mozgo <= 1)
            {
                lephetE = true;
            }
            return lephetE;
        }
        public override void Utkozes(JatekElem elem)
        {
            throw new NotImplementedException();
        }
    }
}
