namespace GenericsPrpject;

public class Program
{
    static void Main(string[] args)
    {

        var studentStore = new Store<Student>();
        studentStore.Add(new Student { Id = 1, Name = "Ahmed" });
        studentStore.Add(new Student { Id = 2, Name = "Sara" });
        studentStore.Add(new Student { Id = 3, Name = "Mona" });
        studentStore.Add(new Student { Id = 4, Name = "Omar" });
        studentStore.Add(new Student { Id = 5, Name = "Ziad" });

        var courseStore = new Store<Course>();
        courseStore.Add(new Course { Id = 101, Title = "C# Basics", Price = 300 });
        courseStore.Add(new Course { Id = 102, Title = "OOP & Collections", Price = 450 });
        courseStore.Add(new Course { Id = 103, Title = "Design Patterns", Price = 600 });

        var student = studentStore.GetById(3);
        Console.WriteLine($"Found Student: {student?.Name} (Id: {student?.Id})");

        var course = courseStore.GetById(102);
        Console.WriteLine($"Found Course: {course?.Title} (Price: {course?.Price})");

        Console.WriteLine();

        try
        {
            studentStore.Add(new Student { Id = 1, Name = "Duplicate Student" });
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Expected Exception Caught: {ex.Message}");
        }

        Console.WriteLine();

        Console.WriteLine("Students - Page 2 (Size 2):");
        var page2 = studentStore.GetAll().Page(2, 2);
        foreach (var s in page2)
        {
            Console.WriteLine($"  Id: {s.Id}, Name: {s.Name}");
        }

        Console.WriteLine();

        var studentList = new List<Student>
{
    new Student { Id = 10, Name = "Kareem" },
    new Student { Id = 20, Name = "Nour" }
};

        var foundFromList = studentList.FindById(20);
        Console.WriteLine($"Found in plain List: {foundFromList?.Name} (Id: {foundFromList?.Id})");

        // var invalidStore = new Store<int>(); // must NOT compile
    }
}

