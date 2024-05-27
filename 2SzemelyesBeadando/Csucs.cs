using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2SzemelyesBeadando
{
    internal class Csucs
    {
        char aktJel;
        TTTAllapot allapot;
        Csucs szulo;

        public Csucs(TTTAllapot kezdoAllapot)
        {
            this.allapot = kezdoAllapot;
            this.szulo = null;
        }

        public Csucs(Csucs szulo, char jel)
        {
            this.aktJel =jel;
            this.allapot = (TTTAllapot)szulo.allapot.Clone();
            this.szulo = szulo;
        }

        public char GetAktJel()
        {
            return aktJel;
        }

        public Csucs GetSzulo()
        {
            return this.szulo;
        }

        public TTTAllapot GetAllapot()
        {
            return this.allapot;
        }

        public bool TerminalisCsucsE() { return allapot.CelAllapotE(aktJel); }

        public int OperatorokSzama() { return allapot.OperatorokSzama(); }

        public bool SzuperOperator(int i) { return allapot.SzuperOperator(i); }

        public override bool Equals(Object obj)
        {
            Csucs cs = (Csucs)obj;
            return allapot.Equals(cs.allapot);
        }

        public override int GetHashCode() { return allapot.GetHashCode(); }

        public override String ToString() { return allapot.ToString(); }
    }
}
