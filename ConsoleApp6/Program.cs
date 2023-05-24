using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Muvelet> muveletek = new List<Muvelet>();
            //1. feladat
            using (StreamReader fajl = new StreamReader("kifejezesek.txt"))
            {
                while (!fajl.EndOfStream)
                {
                    muveletek.Add(new Muvelet(fajl.ReadLine()));
                }
            }
            //2. feladat
            Console.WriteLine($"2. feladat: Kifejezések száma: {muveletek.Count}");

            //3. feladat
            Console.WriteLine($"3. feladat: Kifejezések maradékos osztásssal: {muveletek.Count(x => x.Operat == "mod")}");

            //4. feladat
            int index = 0;
            bool talalt = false;
            do
            {
                talalt = muveletek[index].OperandA % 10 == 0 && muveletek[index].OperandB % 10 == 0;
                index++;
            } while (!talalt);
            Console.WriteLine($"4. feladat: {(talalt ? "Van" : "Nincs")} ilyen kifejezés!");

            //5. feladat
            Console.WriteLine("5. feladat: Statisztika");
            muveletek.Where(x => x.Operat == "+" || x.Operat == "-" || x.Operat == "*" || x.Operat == "/" || x.Operat == "div" || x.Operat == "mod").GroupBy(x => x.Operat).ToList().ForEach(y => Console.WriteLine($"\t\t{y.Key}\t->\t{y.Count()} db"));

        }
    }
}