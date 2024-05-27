using _1SzemelyesBeadando;
using System;

class Program
{
    static void Main(string[] args)
    {
        GYAllapot kezdoAllapot = new GYAllapot(13, 46, 59);
        Csucs kezdoCsucs = new Csucs(kezdoAllapot);

        BackTrack kereső = new BackTrack(kezdoCsucs);

        Csucs megoldásCsucs = kereső.Keresés();
        kereső.megoldásKiírása(megoldásCsucs);

        Console.ReadLine();
    }
}