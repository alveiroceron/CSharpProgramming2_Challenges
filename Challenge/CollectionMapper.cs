using Challenge.Models;

namespace Challenge
{
    public class ProcessFile
    {
        public static void Read()
        {
           var reader = new JsonFileReader<StudentJson>();

            reader.OnFileRead += (students) => { Console.WriteLine($"1. Executing Filter Elements count. ==> Size {students.Count()}");};
            reader.OnFileRead += FileReader_FilterClass;
            reader.OnFileRead += FileReader_FilterSocialSit;
            reader.OnFileRead += FileReader_FilterAverage;

            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent?.Parent?.FullName + $"//Students.json";

            reader.ReadJsonFile(path);
        }

        public static void FileReader_FilterClass(List<StudentJson> students)
        {
            var studentsClass12 =  students.Where(x => x.Class == "12").Select(y => new { y.Name,  y.Eyes }).ToList();

            WriteSeparator();
            Console.WriteLine("2. Executing Filter Class 12. ==> ");

            foreach (var student in studentsClass12)
            {
                Console.WriteLine($"name: {student.Name}, eyes: {student.Eyes}");
            }
        }

        public static void FileReader_FilterSocialSit(List<StudentJson> students)
        {
            WriteSeparator();
            Console.WriteLine("3. Executing Filter SocialSit. ==> ");

            var result = from s in students
                         where s.ScheduleAction.Contains("SocialSit")
                         orderby s.Class, s.Name
                         select s;

            foreach (var item in result)
            {
                Console.WriteLine($"class: {item.Class}, name: {item.Name}, scheduleAction: {item.ScheduleAction}  ");
            }
        }

        public static void FileReader_FilterAverage(List<StudentJson> students)
        {
            WriteSeparator();
            Console.WriteLine("4. Executing Filter LockerSize AVG. ==> ");

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
}
