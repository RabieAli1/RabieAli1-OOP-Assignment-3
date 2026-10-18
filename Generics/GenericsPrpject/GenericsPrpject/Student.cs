using System.ComponentModel.DataAnnotations;

namespace GenericsPrpject;

public class Student : IHasId
{

public int Id { get; set; }
public string Name { get; set; } = string.Empty;

}

