namespace Challenge;

class Program
{
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("CSHARP CHALLENGE!!");
        Console.WriteLine("MENU:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("1. CollectionMapper");
        Console.WriteLine("2. Linq and Events");

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Select an option:");
            
            int selection = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine();

            switch (selection)
            {
                case 1:                   
                    Converter.ConverterElements();
                    break;
                case 2:                   
                    ProcessFile.Read();
                    break;
                default:
                    break;
            }
        }
    }
}


