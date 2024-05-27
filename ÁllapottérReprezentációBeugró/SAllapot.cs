using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÁllapottérReprezentációBeugró
{

    /// <summary>
    /// Adott egy 3 × 3-as sakktabla, a felso sorban 3 vilagos, az also sorban 3 sotet
    /// huszarral.Csereljuk meg a 6 figurat ugy, hogy a sotet es vilagos figurakkal
    /// felvaltva lehet lepni!
    /// </summary>
    internal class SAllapot : AbsztraktAllapot
    {
        int aktHuszar;
        private int[,] tabla;

        public SAllapot(int[,] tabla, int aktHuszar)
        {
            this.tabla = tabla;
            aktHuszar = aktHuszar;
        }

        public override bool AllapotE()
        {
            return true;
        }

        public override bool CelAllapotE()
        {
            //1 = világos huszár
            //-1 = sötét huszár
            //1-1-1
            return AllapotE() && (tabla[0, 0] == 1 && tabla[0, 1] == 1 && tabla[0, 2] == 1) &&
                (tabla[2, 0] == -1 && tabla[2, 1] == -1 && tabla[2, 2] == -1);
        }

        public override int OperatorokSzama()
        {
            //9 helyre léphet
            return 9;
        }

        public override bool SzuperOperator(int i)
        {
            // Huszár lépés
            switch (i)
            {
                case 0: return Lepes(0, 0);
                case 1: return Lepes(0, 1);
                case 2: return Lepes(0, 2);
                case 3: return Lepes(1, 0);
                case 4: return Lepes(1, 1);
                case 5: return Lepes(1, 2);
                case 6: return Lepes(2, 0);
                case 7: return Lepes(2, 1);
                case 8: return Lepes(2, 2);
                default: return false;
            }
        }

        private bool Lepes(int sor1, int oszlop1)
        {
            // Huszárok cseréje az adott pozíciókon
            if (tabla[sor1, oszlop1] != 0) return false; // Ha mindkét pozíció foglalt

            tabla[sor1, oszlop1] = aktHuszar;
            return AllapotE(); 
        }

        public override object Clone()
        {
            int[,] masolt = (int[,])tabla.Clone();
            return new SAllapot(masolt, this.aktHuszar);
        }

        public override bool Equals(object obj)
        {
            if (obj != null && obj is SAllapot)
            {
                for (int i = 0; i < tabla.GetLength(0); i++)
                {
                    for (int j = 0; j < tabla.GetLength(1); j++)
                    {
                        if (this.tabla[i, j] != ((SAllapot)obj).tabla[i, j])
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hash = 3;
            for (int i = 0; i < tabla.GetLength(0); i++)
            {
                for (int j = 0; j < tabla.GetLength(1); j++)
                {
                    hash = hash * 11 + tabla[i, j];
                }
            }
            return hash;
        }
    }
}
