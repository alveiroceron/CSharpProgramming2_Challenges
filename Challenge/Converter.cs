using Challenge.Models;

namespace Challenge;
public class Converter
{
    public delegate List<T2> MyDelegateConverter<T1, T2>(List<T1> input);
    public static void ConverterElements()
    {
        Console.Write("Number of students to convert:");
        int total = Convert.ToInt16(Console.ReadLine());

        var students = FillStudentCollection(total);

        Console.WriteLine($"Total students: {students.Count}");

        students.ForEach(x => Console.WriteLine($"Student Name: {x.Name}, Email:{x.Email}, Id:{x.Id}"));

        MyDelegateConverter<Student, Person> delegateConverter = (List<Student> input) =>
        {
            var output = new List<Person>();

            foreach (var item in input)
            {
                output.Add(new Person { Name = item.Name, Email = item.Email, Id = item.Id });
            }
            return output;
        };

        var person = students.MapCollection(delegateConverter);

        Console.WriteLine($"Total person: {person.Count}");

        person.ForEach(x => Console.WriteLine($"Person Name: {x.Name}, Email:{x.Email}, Id:{x.Id}"));

    }

    public static List<Student> FillStudentCollection(int total)
    {
        List<Student> students = new();

        for (int i = 0; i < total; i++)
        {
            var student = new Student
            {
                Id = Guid.NewGuid(),
                Name = $"participant {i}",
                Email = $"participant{i}@mydemo.net"
            };

            students.Add(student);
        }

        return students;

    }

}

