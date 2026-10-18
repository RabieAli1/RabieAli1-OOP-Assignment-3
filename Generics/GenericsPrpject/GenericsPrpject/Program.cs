namespace GenericsPrpject;

public class Program
{
    static void Main(string[] args)
    {
        var studentStore = new Store<Student>();
        studentStore.Add(new Student { Id = 1, Name = "Ali" });
        Console.WriteLine(studentStore.GetById(1)?.Name);

        var courseStore = new Store<Course>();
        courseStore.Add(new Course { Id = 101, Title = "C# Advanced", Price = 500 });
        Console.WriteLine(courseStore.GetById(101)?.Title);
    }
}

