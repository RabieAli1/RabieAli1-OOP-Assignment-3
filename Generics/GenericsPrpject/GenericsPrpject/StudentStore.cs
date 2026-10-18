namespace GenericsPrpject;

public class StudentStore
{
    private readonly List<Student> _student = new();

    // 1. Add(Student)
    public void Add(Student student)
    {
        _student.Add(student);
    }

    // 2. GetById( id) 

    public Student? GetById(int id)
    {
        foreach (var student in _student)
        {
            if (student.Id == id)
                return student;
        }
        return null;
    }

    // 3.  GetAll()

    public List<Student> GetAll()
    {
        return _student;
    }

    // 4. Remove(int id)

    public bool Remove(int id)
    {
        for (int i = 0; i <= _student.Count; i++)
        {
            if (_student[i].Id == id)
            {
                _student.RemoveAt(i);
                return true;
            }

        }
        return false;
    }

}
