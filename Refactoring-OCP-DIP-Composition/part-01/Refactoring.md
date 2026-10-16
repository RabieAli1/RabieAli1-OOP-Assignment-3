# Part 01 — answers

---

## ShippingCostCalculator

- What was the problem?
  The `ShippingCostCalculator` class violated the Open/Closed Principle (OCP). It used a `switch` statement based on hardcoded carrier strings to calculate shipping costs. Adding a new shipping carrier required directly modifying the existing `ShippingCostCalculator` class.

- What did you change?
  Refactored the design to rely on abstraction. Created the `IShippingCarrier` interface with a `CalculateCost(decimal weightKg)` method, and implemented individual concrete carrier classes (`AramexCarrier`, `FedExCarrier`, `DHLCarrier`). Modified `ShippingCostCalculator.Calculate` to accept `IShippingCarrier` instead of a string, eliminating conditional logic and allowing new carriers to be added via extension.

---

## OrderProcessor

- What was the problem?
  The `OrderProcessor` class violated the Dependency Inversion Principle (DIP). It was tightly coupled to concrete low-level implementations (`SqlOrderRepository` and `SmtpEmailSender`) by directly instantiating them using `new` inside its `Process` method. This also made the class hard to unit test and modify.

- What did you change?
  Introduced abstractions `IOrderRepository` and `IEmailSender`. Implemented these interfaces in `SqlOrderRepository` and `SmtpEmailSender`. Refactored `OrderProcessor` to use Constructor Injection for its dependencies (`IOrderRepository` and `IEmailSender`), decoupling high-level business logic from concrete low-level implementations.

---

## Notifications

- What was the problem?
  The notification system suffered from class explosion due to relying on inheritance rather than composition (`UrgentScheduledEmailNotification`, `UrgentSmsNotification`, etc.). Adding new behavior or a new channel required creating a new class for every possible combination of features.

- What did you change?
  Refactored the system using Composition over Inheritance . Defined an `INotificationChannel` interface for core channels (`EmailNotificationChannel`, `SmsNotificationChannel`). Created wrapper classes (`UrgentNotification` and `ScheduledNotification`) that accept an `INotificationChannel` instance via constructor injection, allowing notification behaviors to be dynamically wrapped and composed without multiplying classes.

---

## Proof

- New carrier file(s): `BostaCarrier`
- New notification channel file(s): `WhatsAppNotificationChannel`
- Existing classes left unchanged? (yes/no): yes
