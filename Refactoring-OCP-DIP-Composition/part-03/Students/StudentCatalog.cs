namespace RefactoringLab.Part03.Students;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
}

public static class StudentCatalog
{
    // Lazy Execution مش بيصنع الطالب إلا لما الـ Caller يطلبه
    public static IEnumerable<Student> GetAllStudents()
    {
        for (var i = 1; i <= 1_000_000; i++)
        {
            yield return new Student { Id = i, Name = $"Student {i}" };
        }
    }
}