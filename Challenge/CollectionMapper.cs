using Challenge.Models;

namespace Challenge;
public class ProcessFile
{
    public static void Read()
    {
        var reader = new JsonFileReader<StudentJson>();

        reader.FileRead += (object sender, FileReadEventArgs<StudentJson> e) => { Console.WriteLine($"1. Executing Filter Elements count. ==> Size {e.Students.Count()}"); };
        reader.FileRead += FileReader_FilterClass;
        reader.FileRead += FileReader_FilterSocialSit;
        reader.FileRead += FileReader_FilterAverage;

        string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent?.Parent?.FullName + $"//Students.json";

        reader.ReadJsonFile(path);
    }

    public static void FileReader_FilterClass(object sender, FileReadEventArgs<StudentJson> e)
    {
        var studentsClass12 = e.Students.Where(x => x.Class == "12").Select(y => new { y.Name, y.Eyes }).ToList();

        WriteSeparator();
        Console.WriteLine("2. Executing Filter Class 12. ==> ");

        foreach (var student in studentsClass12)
        {
            Console.WriteLine($"name: {student.Name}, eyes: {student.Eyes}");
        }
    }

    public static void FileReader_FilterSocialSit(object sender, FileReadEventArgs<StudentJson> e)
    {
        WriteSeparator();
        Console.WriteLine("3. Executing Filter SocialSit. ==> ");

        var result = from s in e.Students
                     where s.ScheduleAction.Contains("SocialSit")
                     orderby s.Class, s.Name
                     select s;

        foreach (var item in result)
        {
            Console.WriteLine($"class: {item.Class}, name: {item.Name}, scheduleAction: {item.ScheduleAction}  ");
        }
    }

    public static void FileReader_FilterAverage(object sender, FileReadEventArgs<StudentJson> e)
    {
        WriteSeparator();
        Console.WriteLine("4. Executing Filter LockerSize AVG. ==> ");

        var students = e.Students;
        var average = students.Average(x => Convert.ToDouble(x.LockerSize));
        Console.WriteLine($"average: {average}");

        var result = students.Where(x => Convert.ToDouble(x.LockerSize) > average).OrderByDescending(y => y.LockerSize).Take(5);
        foreach (var item in result)
        {
            Console.WriteLine($"name: {item.Name}, lockerSize: {item.LockerSize}");
        }
    }

    private static void WriteSeparator()
    {
        Console.WriteLine("***************************************************");
    }

}

