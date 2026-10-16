using RefactoringLab;

var shipping = new ShippingCostCalculator();
Console.WriteLine($"Aramex 2kg → {shipping.Calculate(new AramexCarrier(), 2)}");
Console.WriteLine($"FedEx 2kg  → {shipping.Calculate(new FedExCarrier(), 2)}");
Console.WriteLine();


IOrderRepository rep = new SqlOrderRepository();
IEmailSender emailSender = new SmtpEmailSender();

var processor = new OrderProcessor(rep, emailSender);
processor.Process(1001, "customer@example.com");
Console.WriteLine();

INotificationChannel emailChannel = new EmailNotification();
INotificationChannel urgentEmail = new UrgentNotification(emailChannel);
INotificationChannel urgentScheduledEmail = new ScheduledNotification(urgentEmail, DateTime.Today.AddHours(18));
urgentScheduledEmail.Send("customer@example.com", "Your order ships tomorrow");

INotificationChannel smsChannel = new SmsNotification();
INotificationChannel urgentSms = new UrgentNotification(smsChannel);

urgentSms.Send("+201000000000", "OTP 4821");



