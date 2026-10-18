namespace GenericsPrpject;

public class Program
{
    static void Main(string[] args)
    {
        var store = new StudentStore();

        store.Add(new Student { Id = 1, Name = "Ahmed" });
        store.Add(new Student { Id = 2, Name = "Sara" });

        var student = store.GetById(1);
        Console.WriteLine($"Found: {student?.Name}"); // Ahmed

        var notFound = store.GetById(99);
        Console.WriteLine($"Found: {notFound?.Name ?? "null"}"); // null

        store.Remove(1);
        Console.WriteLine($"Total students after remove: {store.GetAll().Count}"); // 1
    }
}

