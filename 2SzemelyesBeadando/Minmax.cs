using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace _2SzemelyesBeadando
{
    internal class Minmax
    {
        char[,] _tabla;

        public Minmax(char[,] tabla)
        {
            this._tabla = tabla;
        }

        public char[,] LerakomAzElsoHelyre(char[,] teszt, char jel, [Optional] LepesPontszammal ertekeles, [Optional] char ittMarJartJel)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (teszt[i, j] == '.' || (jel == 'O' && (teszt[i, j] == '.' || teszt[i, j] == '_')))
                    {
                        if (ittMarJartJel == '_')
                        {
                            teszt[i, j] = ittMarJartJel;
                        }
                        else if (ittMarJartJel == '#')
                        {
                            teszt[i, j] = ittMarJartJel;
                        }
                        else
                        {
                            teszt[i, j] = jel;
                        }
                        if (ertekeles != null)
                        {
                            ertekeles.Sor = i;
                            ertekeles.Oszlop = j;
                        }
                        return teszt;
                    }
                }
            }
            return teszt;
        }
        public char[,] CopyMatrix(char[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            char[,] newMatrix = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    newMatrix[i, j] = matrix[i, j];
                }
            }

            return newMatrix;
        }

        public (int sor, int oszlop) MinMax()
        {
            List<LepesPontszammal> lepesekPontszammal = new List<LepesPontszammal>();
            int helyekSzama = HelyeketSzamol(_tabla);

            if (helyekSzama <= 7)
            {
                char[,] melyseg1 = CopyMatrix(_tabla);

                for (int i = 0; i <= helyekSzama; i++)
                {
                    LepesPontszammal lepesPontszammal = new LepesPontszammal();

                    char[,] ujTablaKovetkezoKorhoz = CopyMatrix(melyseg1);
                    ujTablaKovetkezoKorhoz = LerakomAzElsoHelyre(ujTablaKovetkezoKorhoz, 'X', lepesPontszammal, '_');

                    melyseg1 = LerakomAzElsoHelyre(melyseg1, 'X', lepesPontszammal);
                    lepesPontszammal.Pont = Pontozom(melyseg1, 'X');

                    if (lepesPontszammal.Pont != 10)
                    {
                        char[,] melyseg2 = CopyMatrix(melyseg1);
                        int Opont = 0;
                        for (int j = 0; j <= helyekSzama; j++)
                        {
                            char[,] ujTablaKovetkezoKorhozO = CopyMatrix(melyseg2);
                            ujTablaKovetkezoKorhozO = LerakomAzElsoHelyre(ujTablaKovetkezoKorhozO, 'O', null, '#');

                            melyseg2 = LerakomAzElsoHelyre(melyseg2, 'O');
                            Opont += Pontozom(melyseg2, 'O');
                            melyseg2 = CopyMatrix(ujTablaKovetkezoKorhozO);
                        }
                        lepesPontszammal.Pont = lepesPontszammal.Pont + Opont;
                    }

                    lepesekPontszammal.Add(lepesPontszammal);
                    melyseg1 = CopyMatrix(ujTablaKovetkezoKorhoz);
                }
                LepesPontszammal maxPontosLepes = lepesekPontszammal.OrderByDescending(x => x.Pont).First();
                return (maxPontosLepes.Sor, maxPontosLepes.Oszlop);
            }
            else
            {
                Random rnd = new Random();
                int rndSor = rnd.Next(3);
                int rndOszlop = rnd.Next(3);
                while (_tabla[rndSor, rndOszlop] != '.')
                {
                     rndSor = rnd.Next(3);
                     rndOszlop = rnd.Next(3);
                }
                return (rndSor, rndOszlop);
            }
        }

        public int HelyeketSzamol(char[,] tabla)
        {
            int count = 0;
            for (int i = 0; i < tabla.GetLength(0); i++)
            {
                for (int j = 0; j < tabla.GetLength(1); j++)
                {
                    if (tabla[i, j] == '.')
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public int Pontozom(char[,] tabla, char jel)
        {
            if (CelAllapotE(tabla, jel))
            {
                if (jel == 'X')
                {
                    return 10;
                }
                else
                {
                    return -10;
                }
            }
            return 0;
        }

        public bool CelAllapotE(char[,] Tabla, char Jatekos)
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
    }
}
