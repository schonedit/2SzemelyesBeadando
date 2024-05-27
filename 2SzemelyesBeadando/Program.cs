using _2SzemelyesBeadando;
using System;

class Program
{
    static void Main()
    {
        TTTAllapot aktAllapot = new TTTAllapot();
        Csucs aktCsucs = new Csucs(aktAllapot);

        PrintBoard(aktCsucs.GetAllapot());
        while (aktCsucs.GetAllapot().AllapotE())
        {
            if (!aktCsucs.TerminalisCsucsE())
            {
                PlayerMove(aktCsucs.GetAllapot());
                PrintBoard(aktCsucs.GetAllapot());

                aktCsucs = new Csucs(aktCsucs, 'O');
            }
            else
            {
                Console.WriteLine(aktCsucs.GetAktJel() + " győzött.");
                break;

            }
            if (!aktCsucs.TerminalisCsucsE())
            {
                PcMove(aktCsucs.GetAllapot());
                PrintBoard(aktCsucs.GetAllapot());

                aktCsucs = new Csucs(aktCsucs, 'X');
            }
            else
            {
                Console.WriteLine(aktCsucs.GetAktJel() + " győzött.");
                break;
            }
        }
        Console.WriteLine("Játék vége.");
    }

    static void PcMove(TTTAllapot allapot)
    {
        Minmax minmax = new Minmax(allapot.Tabla);
        char[,] tablaUjLepessel = allapot.Tabla;
        (int sor, int oszlop) kovetkezoLepes = minmax.MinMax();
        tablaUjLepessel[kovetkezoLepes.sor, kovetkezoLepes.oszlop] = 'X';
        Console.WriteLine("Számítógép lépése: ");
        allapot.Tabla = tablaUjLepessel;
    }

    static void PlayerMove(TTTAllapot allapot)
    {
        int move;
        while (true)
        {
            Console.WriteLine("Játékos lépése: ");
            move = int.Parse(Console.ReadLine());
            if (allapot.SzuperOperator(move))
            {
                break;
            }
            else
            {
                Console.WriteLine("Helytelen lépés. Próbáld újra!");
            }
        }
    }

    static void PrintBoard(TTTAllapot allapot)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(allapot.Tabla[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
