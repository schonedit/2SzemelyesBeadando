using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1SzemelyesBeadando
{
    internal class Csucs
    {
        GYAllapot allapot;
        Csucs szulo;
        int mélység;

        public Csucs(GYAllapot kezdoAllapot)
        {
            this.allapot = kezdoAllapot;
            this.szulo = null;
            mélység = 0;
        }

        public Csucs(Csucs szulo)
        {
            this.allapot = (GYAllapot)szulo.allapot.Clone();
            this.szulo = szulo;
            this.mélység = szulo.mélység + 1;
        }

        public int GetMélység() { return mélység; }


        public Csucs GetSzulo()
        {
            return this.szulo;
        }

        public GYAllapot GetAllapot()
        {
            return this.allapot;
        }

        public bool TerminalisCsucsE() { return allapot.CelAllapotE(); }

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
