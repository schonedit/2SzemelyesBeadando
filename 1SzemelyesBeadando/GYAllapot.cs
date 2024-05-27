using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1SzemelyesBeadando
{
    /// <summary>
    /// Van 13 almánk, 46 körténk és 59 darab barackunk. Egy-egy különböző
    /// gyümölcsért cserébe két darabot kapunk a harmadik fajtéból a csősztől.
    /// Ugyesen csere-berélve érjük el, hogy csak egyetlen fajta gyümölcsünk maradjon.
    /// </summary>
    public class GYAllapot : AbsztraktAllapot
    {
        public int Almák { get; set; }
        public int Körték { get; set; }
        public int Barackok { get; set; }

        public GYAllapot(int almák, int körték, int barackok)
        {
            Almák = almák;
            Körték = körték;
            Barackok = barackok;
        }

        public override bool AllapotE()
        {
            //ha van mindenből
            return Almák >= 0 && Körték >= 0 && Barackok >= 0;
        }

        public override bool CelAllapotE()
        {
            //ha 2 fajtából egyszerre 0 darabom van
            return (Almák == 0 && Körték == 0) || (Körték == 0 && Barackok == 0) || (Almák == 0 && Barackok == 0);
        }

        public override int OperatorokSzama()
        {
            //3 fajta csere van
            return 3;
        }

        public override bool SzuperOperator(int i)
        {
            //cserék
            switch (i)
            {
                //barackot kap, almáért és körtéért
                case 0:
                    if (Almák > 0 && Körték > 0)
                    {
                        Almák--;
                        Körték--;
                        Barackok = Barackok +2;
                        return true;
                    }
                    break;
                    //almát kap, barackért és körtéért
                case 1:
                    if (Körték > 0 && Barackok > 0)
                    {
                        Körték--;
                        Barackok--;
                        Almák = Almák +2;
                        return true;
                    }
                    break;
                case 2:
                    //körtét kap almáért és barackért
                    if (Almák > 0 && Barackok > 0)
                    {
                        Almák--;
                        Barackok--;
                        Körték = Körték +2;
                        return true;
                    }
                    break;
            }
            return false;
        }
        public override object Clone()
        {
            return new GYAllapot(Almák, Körték, Barackok);
        }

        public override bool Equals(object a)
        {
            if (a  != null && a is GYAllapot)
            {
                return this.Almák == ((GYAllapot)a).Almák && this.Körték == ((GYAllapot)a).Körték && this.Barackok == ((GYAllapot)a).Barackok;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return 3 * Almák.GetHashCode() + 7 * Körték.GetHashCode() + 11 * Barackok.GetHashCode();
        }

        public override string ToString()
        {
            return $"Almák: {Almák}, Körték: {Körték}, Barackok: {Barackok}";
        }
    }
}
