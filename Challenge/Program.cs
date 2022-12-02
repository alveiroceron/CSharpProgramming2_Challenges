using Challenge;

Console.WriteLine("1. CollectionMapper");
Console.WriteLine("2. Linq and Events");
Console.WriteLine();

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
