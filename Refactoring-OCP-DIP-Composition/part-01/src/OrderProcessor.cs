namespace RefactoringLab;


//في مشكلة هنا في مبدئ DIP
// Tight Coupling
// high level class creat object from low level class
// وكمان بيخالف مبدئ  OCP
// ===========================================================
// soulution is i will make interface (IOrderRepository , IEmailSender)
// passing Dependencies to class (OrderProcessor) by Constructor

//1.Abstractions (Interface)
public interface IOrderRepository
{
    public void Save(int orderID, DateTime processedAt);
}


public interface IEmailSender
{
    void Send(string to, string body);
}

//2.Implementaion

public class SqlOrderRepository : IOrderRepository
{
    public void Save(int orderID, DateTime processedAt)
    {
        Console.WriteLine($"[SQL] save order {orderID} @ {processedAt:O}");
    }
}

public class SmtpEmailSender : IEmailSender
{
    public void Send(string to, string body)
    {
        Console.WriteLine($"[SMTP] to={to} body={body}");
    }
}



public class OrderProcessor
{

    private readonly IOrderRepository _repository;
    private readonly IEmailSender _emailSender;

    public OrderProcessor(IOrderRepository repository, IEmailSender emailSender)
    {

        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _emailSender = emailSender ?? throw new ArgumentNullException(nameof(emailSender));

    }

    public void Process(int orderId, string customerEmail)
    {
        _repository.Save(orderId, DateTime.Now);
        _emailSender.Send(customerEmail, $"Order {orderId} confirmed at {DateTime.Now}");
    }
    


}


//Befor Refactoring
//==================
//  public void Process(int orderId, string customerEmail)

//     {
//         var repo = new SqlOrderRepository();
//         var email = new SmtpEmailSender();
//         repo.Save(orderId, DateTime.Now);
//         email.Send(customerEmail, $"Order {orderId} confirmed at {DateTime.Now}")
//     }

// public class SqlOrderRepository
// {
//     public void Save(int orderId, DateTime processedAt) =>
//         Console.WriteLine($"[SQL] save order {orderId} @ {processedAt:O}");
// }

// public class SmtpEmailSender
// {
//     public void Send(string to, string body) =>
//         Console.WriteLine($"[SMTP] to={to} body={body}");
// }
