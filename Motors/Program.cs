namespace Motors
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Statisztika stat1 = new Statisztika();
			stat1.ReadFromFile("motors.txt");
            Console.WriteLine("Ennyibne kerülne az összes kocsi összesen: " + stat1.sumPrices());
            Console.WriteLine();
			Console.WriteLine("Van-e ilyen motor a gyűjteményben: Guerrilla 450 : " + stat1.Contains("Guerrilla 450"));
            Console.WriteLine();
            Console.WriteLine("A legidősebb kocsi: " + stat1.Oldest().Brand  +" , "+ stat1.Oldest().Name);           
            Console.WriteLine();
            Console.WriteLine("Ennyi az összes Harley Davidson ára: " + stat1.SumBasedOnBrand("Harley-Davidson", "motors.txt"));
            Console.WriteLine();
            stat1.Sort();
        }
	}
}
