using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1SzemelyesBeadando
{
    internal class BackTrack : GráfKereső
    {
        int korlát; // Ha nem nulla, akkor mélységi korlátos kereső.
        bool emlékezetes; // Ha igaz, emlékezetes kereső.
        public BackTrack(Csucs startCsucs, int korlát, bool emlékezetes)
            : base(startCsucs)
        {
            this.korlát = korlát;
            this.emlékezetes = emlékezetes;
        }
        // nincs mélységi korlát, se emlékezet
        public BackTrack(Csucs startCsucs) : this(startCsucs, 0, false) { }
        // mélységi korlátos kereső
        public BackTrack(Csucs startCsucs, int korlát) : this(startCsucs, korlát, false) { }
        // emlékezetes kereső
        public BackTrack(Csucs startCsucs, bool emlékezetes) : this(startCsucs, 0, emlékezetes) { }
        // A keresés a start Csucsból indul.
        // Egy terminális Csucsot ad vissza. A start Csucsból el lehet jutni ebbe a terminális Csucsba.
        // Ha nincs ilyen, akkor null értéket ad vissza.
        public override Csucs Keresés() { return Keresés(GetStartCsucs()); }
        // A kereső algoritmus rekurzív megvalósítása.
        // Mivel rekurzív, ezért a visszalépésnek a "return null" felel meg.
        private Csucs Keresés(Csucs aktCsucs)
        {
            int mélység = aktCsucs.GetMélység();
            // mélységi korlát vizsgálata
            if (korlát > 0 && mélység >= korlát) return null;
            // emlékezet használata kör kiszűréséhez
            Csucs aktSzülő = null;
            if (emlékezetes) aktSzülő = aktCsucs.GetSzulo();
            while (aktSzülő != null)
            {
                // Ellenőrzöm, hogy jártam-e ebben az állapotban. Ha igen, akkor visszalépés.
                if (aktCsucs.Equals(aktSzülő)) return null;
                // Visszafelé haladás a szülői láncon.
                aktSzülő = aktSzülő.GetSzulo();
            }
            if (aktCsucs.TerminalisCsucsE())
            {
                // Megvan a megoldás, vissza kell adni a terminális Csucsot.
                return aktCsucs;
            }
            // Itt hívogatom az alapoperátorokat a szuper operátoron
            // keresztül. Ha valamelyik alkalmazható, akkor új Csucsot
            // készítek, és meghívom önmagamat rekurzívan.
            for (int i = 0; i < aktCsucs.OperatorokSzama(); i++)
            {
                // Elkészítem az új gyermek Csucsot.
                // Ez csak akkor lesz kész, ha alkalmazok rá egy alkalmazható operátort is.
                Csucs újCsucs = new Csucs(aktCsucs);
                // Kipróbálom az i.dik alapoperátort. Alkalmazható?
                if (újCsucs.SzuperOperator(i))
                {
                    // Ha igen, rekurzívan meghívni önmagam az új Csucsra.
                    // Ha nem null értéket ad vissza, akkor megvan a megoldás.
                    // Ha null értéket, akkor ki kell próbálni a következő alapoperátort.
                    Csucs terminális = Keresés(újCsucs);
                    if (terminális != null)
                    {
                        // Visszaadom a megoldást képviselő terminális Csucsot.
                        return terminális;
                    }
                    // Az else ágon kellene visszavonni az operátort.
                    // Erre akkor van szükség, ha az új gyermeket létrehozásában nem lenne klónozást.
                    // Mivel klónoztam, ezért ez a rész üres.
                }
            }
            // Ha kipróbáltam az összes operátort és egyik se vezetett megoldásra, akkor visszalépés.
            // A visszalépés hatására eggyel feljebb a következő alapoperátor kerül sorra.
            return null;
        }
    }
}
