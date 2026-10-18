namespace RefactoringLab.Part02.Enrollment;

// problem => Tight Coupling , vaiolated SRP , Code Duplication
// solution =>  Desigen Pattern (Facade)


public class EnrollmentFacade
{
    private readonly PaymentGateway _payment = new();
    private readonly SeatInventory _seats = new();
    private readonly InvoiceGenerator _invoices = new();
    private readonly EmailService _email = new();
    public void Enroll(string studentId, string courseId, decimal amount)
    {
        _payment.Charge( studentId,  amount);
        _seats.Reserve(courseId, studentId);
        var invoiceId =_invoices.Create(studentId,amount);
        _email.Send(studentId, "Enrollment confirmed", $"Invoice {invoiceId} for {courseId}");
    }
}




public class PaymentGateway
{
    public void Charge(string studentId, decimal amount) =>
        Console.WriteLine($"charge {studentId}: {amount}");
}

public class SeatInventory
{
    public void Reserve(string courseId, string studentId) =>
        Console.WriteLine($"reserve seat {courseId} for {studentId}");
}

public class InvoiceGenerator
{
    public string Create(string studentId, decimal amount)
    {
        var invoiceId = $"INV-{studentId}-{amount}";
        Console.WriteLine($"invoice {invoiceId}");
        return invoiceId;
    }
}

public class EmailService
{
    public void Send(string studentId, string subject, string body) =>
        Console.WriteLine($"email {studentId}: {subject} / {body}");
}
