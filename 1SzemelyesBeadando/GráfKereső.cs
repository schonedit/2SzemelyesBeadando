using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1SzemelyesBeadando
{
    internal abstract class GráfKereső
    {
        private Csucs startCsucs; // A start Csucs Csucs.
        // Minden gráfkereső a start Csucsból kezd el keresni.
        public GráfKereső(Csucs startCsucs)
        {
            this.startCsucs = startCsucs;
        }
        // Jobb, ha a start Csucs privát, de a gyermek osztályok lekérhetik.
        protected Csucs GetStartCsucs() { return startCsucs; }
        /// Ha van megoldás, azaz van olyan út az állapottér gráfban,
        /// ami a start Csucsból egy terminális Csucsba vezet,
        /// akkor visszaad egy megoldást, egyébként null.
        /// A megoldást egy terminális Csucsként adja vissza.
        /// Ezen Csucs szülő referenciáin felfelé haladva adódik a megoldás fordított sorrendben.
        public abstract Csucs Keresés();
        /// <summary>
        /// Kiíratja a megoldást egy terminális Csucs alapján.
        /// Feltételezi, hogy a terminális Csucs szülő referenciáján felfelé haladva eljutunk a start Csucshoz.
        /// A Csucsok sorrendjét megfordítja, hogy helyesen tudja kiírni a megoldást.
        /// Ha a Csucs null, akkor kiírja, hogy nincs megoldás.
        /// </summary>
        /// <param name="egyTerminálisCsucs">
        /// A megoldást képviselő terminális Csucs vagy null.
        /// </param>
        public void megoldásKiírása(Csucs egyTerminálisCsucs)
        {
            if (egyTerminálisCsucs == null)
            {
                Console.WriteLine("Nincs megoldás");
                return;
            }
            // Meg kell fordítani a Csucsok sorrendjét.
            Stack<Csucs> megoldás = new Stack<Csucs>();
            Csucs aktCsucs = egyTerminálisCsucs;
            while (aktCsucs != null)
            {
                megoldás.Push(aktCsucs);
                aktCsucs = aktCsucs.GetSzulo();
            }
            // Megfordítottuk, lehet kiírni.
            foreach (Csucs akt in megoldás) Console.WriteLine(akt);
        }
    }
}
