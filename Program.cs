using Budapest.DataSource;

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


        }
    }
}
