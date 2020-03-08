using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jatek.Jatekter
{
    abstract class JatekElem
    {
        int x;
        int y;
        protected Jatekter ter;
        
        public JatekElem(int x, int y, Jatekter ter)
        {
            this.x = x;
            this.y = y;
            this.ter = ter;
            ter.Felvetel(this);
        }
        
        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }
        abstract public double Meret { get; }

        public abstract void Utkozes(JatekElem elem);
    }
}
