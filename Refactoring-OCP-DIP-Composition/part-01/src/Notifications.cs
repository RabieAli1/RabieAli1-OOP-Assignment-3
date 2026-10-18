namespace RefactoringLab;



// المشكلة هنا ان احنا لو عايزين نضيف حاجة او سلوك جديدة بنعمل كلاس جديد و دي من مشاكل الوراثة و بكدة عدد الكلاسات هتزيد 

// solution i will use the copmosition over inhertaince by separating notification channels from behaviors like Urgent and Scheduled allowing them to be combined without creating a separate class for every combination.




public interface INotificationChannel
{
    void Send(string to, string message);
}


public class EmailNotification : INotificationChannel
{
    public void Send(string to, string message)
    {
        Console.WriteLine($"[email] {to}: {message}");
    }

}

public class SmsNotification : INotificationChannel
{
    public void Send(string to, string message)
    {
        Console.WriteLine($"[sms] {to}: {message}");
    }
}


public class UrgentNotification : INotificationChannel
{
    private readonly INotificationChannel _channel;

    public UrgentNotification(INotificationChannel channel)
    {
        _channel = channel ?? throw new ArgumentNullException(nameof(channel));
    }

    public void Send(string to, string message)
    {
        _channel.Send(to, $"[URGENT] {message}");
    }
}

public class ScheduledNotification : INotificationChannel
{
    private readonly INotificationChannel _channel;
    public DateTime SendAt { get; set; }
    public ScheduledNotification(INotificationChannel channel, DateTime sendAt)
    {
        _channel = channel ?? throw new ArgumentNullException(nameof(channel));
        SendAt = sendAt;
    }
    public void Send(string to, string message)
    {
        _channel.Send(to, $"[email scheduled {SendAt:g}] {to}: [URGENT] {message}");
    }

}

public class WhatsAppNotificationChannel : INotificationChannel
{
    public void Send(string to, string message)
    {
        Console.WriteLine($"[whatsapp] {to}: {message}");
    }
}


// Before refactoring...
// =====================

// public class Notification
// {
//     public virtual void Send(string to, string message) =>
//         Console.WriteLine($"notify {to}: {message}");
// }

// public class EmailNotification : Notification
// {
//     public override void Send(string to, string message) =>
//         Console.WriteLine($"[email] {to}: {message}");
// }

// public class SmsNotification : Notification
// {
//     public override void Send(string to, string message) =>
//         Console.WriteLine($"[sms] {to}: {message}");
// }

// public class UrgentNotification : EmailNotification
// {
//     public override void Send(string to, string message) =>
//         base.Send(to, $"[URGENT] {message}");
// }

// public class UrgentSmsNotification : SmsNotification
// {
//     public override void Send(string to, string message) =>
//         base.Send(to, $"[URGENT] {message}");
// }

// public class UrgentScheduledEmailNotification : UrgentEmailNotification
// {
//     public DateTime SendAt { get; set; }

//     public override void Send(string to, string message) =>
//         Console.WriteLine($"[email scheduled {SendAt:g}] {to}: [URGENT] {message}");
// }

// public class UrgentScheduledSmsNotification : UrgentSmsNotification
// {
//     public DateTime SendAt { get; set; }

//     public override void Send(string to, string message) =>
//         Console.WriteLine($"[sms scheduled {SendAt:g}] {to}: [URGENT] {message}");
// }
