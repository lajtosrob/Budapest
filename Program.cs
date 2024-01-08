using Budapest.DataSource;
using System.LINQ;

namespace Budapest
{
    internal class Program
    {
        static List<Kozterulet> kozteruletek = new List<Kozterulet> ();
        static void Main(string[] args)
        {
            // 1. feladat

            StreamReader sr = new StreamReader(".\\DataSource\\bp.csv");

            sr.ReadLine(); // fejléc sor olvasása

            while (!sr.EndOfStream)
            {
                string[] line = sr.ReadLine().Split(";");

                Kozterulet adatsor = new Kozterulet(
                    int.Parse(line[0]),
                    line[1],
                    line[2],
                    line[3]
                    );

                kozteruletek.Add(adatsor);

            }

            // 2. feladat 

            Console.WriteLine($"2. feladat: Közterületek száma: {kozteruletek.Count()}");


            // 3. feladat

            var kozteruletNyolcKer =  kozteruletek.GroupBy(x => x.ker).Count(x => x.ker == "VIII");

            Console.WriteLine(kozteruletNyolcKer);

            // 4. feladat

            Console.Write("Adjon meg egy irányítószámot: ");
            int iranyitoszam = Console.ReadLine();

            bool helyesIrSzam = kozteruletek.Any(x => x.irsz == iranyitoszam) ? true : false;

            Console.WriteLine("4. feladat: Az irányítószám létezik");

            // 5. feladat

            Console.WriteLine("Kérem egy közterület nevének kezdetét!");
            string kozterNeve = Console.ReadLine();

            foreach (var item in kozteruletek)
            {
                if (item.nev == kozterNeve)
                {
                    Console.WriteLine($"{item.nev} - {item.ker}");
                }
            }

            // 6. feladat

            kozteruletek = kozteruletek.GroupBy(x => x.ker).Count(x => x.utotag == "tér");

            Dictionary<string, int> statisztika = kozteruletek.Where(x => x.utotag != "tér").GroupBy(x => x.ker).ToDictionary(x => x.Key, x => x.Count());

            Console.WriteLine("6. feladat");

            foreach (var item in kozteruletek)
            {
                Console.WriteLine($"{item.Key} kerületben {item.Value} közterület van.");
            }

        }
    }
}
