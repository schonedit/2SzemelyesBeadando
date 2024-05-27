using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2SzemelyesBeadando
{
    internal class TTTAllapot : AbsztraktAllapot
    {
        public char[,] Tabla { get; set; }
        public char Jatekos { get; private set; }

        public TTTAllapot()
        {
            //kezdő állapot
            this.Jatekos = 'O';
            this.Tabla = new char[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    this.Tabla[i, j] = '.';
        }

        public TTTAllapot(char[,] tabla, char jatekos)
        {
            this.Tabla = tabla;
            this.Jatekos = jatekos;
        }

        public override bool AllapotE()
        {
            //ha a tábla betelt akkor nem állapot
            return Contains(Tabla, '.');
        }

        public override bool CelAllapotE(char Jatekos)
        {
            for (int i = 0; i < 3; i++)
            {
                //sorokat megnézzük
                if (Tabla[i, 0] == Jatekos && Tabla[i, 1] == Jatekos && Tabla[i, 2] == Jatekos)
                {
                    return true;
                }
                //oszlopokoat megnézzük
                if (Tabla[0, i] == Jatekos && Tabla[1, i] == Jatekos && Tabla[2, i] == Jatekos)
                {
                    return true;
                }
            }
            //egyik átló
            if (Tabla[0, 0] == Jatekos && Tabla[1, 1] == Jatekos && Tabla[2, 2] == Jatekos)
            {
                return true;
            }
            //másik átló
            if (Tabla[2, 0] == Jatekos && Tabla[1, 1] == Jatekos && Tabla[0, 2] == Jatekos)
            {
                return true;
            }
            return false;
        }

        public override int OperatorokSzama()
        {
            //attól függ hány üres hely van a táblában
            int count = 0;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (Tabla[i, j] == '.')
                        count++;
            return count;
        }

        public override bool SzuperOperator(int opIndex)
        {
            //lerak metódus ami lerak egy jelet a táblába, így változtatja meg az állapotot
            int oszlop;
            int sor;
            switch (opIndex)
            {
                case 00:
                    sor = 0; oszlop = 0;
                    break;
                case 01:
                    sor = 0; oszlop = 1;
                    break;
                case 02:
                    sor = 0; oszlop = 2;
                    break;
                case 10:
                    sor = 1; oszlop = 0;
                    break;
                case 11:
                    sor = 1; oszlop = 1;
                    break;
                case 12:
                    sor = 1; oszlop = 2;
                    break;
                case 20:
                    sor = 2; oszlop = 0;
                    break;
                case 21:
                    sor = 2; oszlop = 1;
                    break;
                case 22:
                    sor = 2; oszlop = 2;
                    break;
                default:
                    return false;
            }

            if (Tabla[sor, oszlop] == '.')
            {
                Tabla[sor, oszlop] = Jatekos;
                return true;
            }

            return false;
        }

        public static bool Contains(char[,] tomb, char keresettElem)
        {
            for (int i = 0; i < tomb.GetLength(0); i++)
            {
                for (int j = 0; j < tomb.GetLength(1); j++)
                {
                    if (tomb[i, j] == keresettElem)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override bool Equals(object a)
        {
            //összes mezőt
            if (a != null && a is TTTAllapot)
            {
                TTTAllapot masik = a as TTTAllapot;
                return this.Tabla == masik.Tabla
                    && this.Jatekos == masik.Jatekos;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return 3 * Jatekos.GetHashCode() +
                   7 * Tabla.GetHashCode();
        }

        public override object Clone()
        {
            TTTAllapot myClone = new TTTAllapot();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    myClone.Tabla[i,j] = this.Tabla[i, j];
                }
            }
            myClone.Jatekos = Jatekos;
            return myClone;
        }
    }
}
