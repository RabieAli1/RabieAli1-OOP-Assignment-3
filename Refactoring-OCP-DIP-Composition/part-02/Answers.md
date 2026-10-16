# Part 02 — answers

---

## Reports

- What was the problem?
  The report exporters (`CsvReportExporter`, `JsonReportExporter`, and `TextReportExporter`) duplicated the high-level export algorithm flow. Each exporter repeated the exact same steps for loading data, validating rows, and saving the generated output to disk, violating the DRY (Don't Repeat Yourself) principle.

- What did you change?
  Refactored the exporters using the Template Method pattern by introducing an abstract base class `ReportExporter`. Defined the template method `Export(string path)` to encapsulate the fixed steps (`Load()`, `Validate()`, `Format()`, and `Save()`). Marked `Format()` as an `abstract` method so derived classes only implement their unique formatting logic (CSV, JSON, or Text), while reusing the shared data loading, validation, and File I/O implementations.

- Why did you choose that approach?
  An abstract class is superior to an interface here because it allows sharing concrete method implementations (`Load`, `Validate`, and `Save`) and enforcing a fixed algorithm execution sequence inside `Export()`. An interface can only mandate method signatures, which would force each exporter to reimplement the common workflow and file-writing logic.

---

## Enrollment

- What was the problem?
  `Program.cs` was tightly coupled to four separate subsystem services (`PaymentGateway`, `SeatInventory`, `InvoiceGenerator`, and `EmailService`). To enroll a single student, the caller had to instantiate each service manually and orchestrate the execution sequence step by step. This violated the Single Responsibility Principle (SRP) by exposing internal subsystem workflows to the client and introduced code duplication if enrollment were needed elsewhere.

- What did you change?
  Refactored the enrollment workflow using the Facade pattern by creating an `EnrollmentFacade` class. The facade encapsulates the instantiation and orchestration of the four services behind a single high-level `Enroll(studentId, courseId, amount)` method, leaving the original classes in `Services.cs` untouched. Replaced the multi-step instantiation and calls in `Program.cs` with a single call to the facade.

- Why did you choose that approach?
  The Facade pattern provides a simple, unified interface to a complex subsystem. It shields the client from knowing subsystem implementation details, dependencies, and execution order (R4). It reduces coupling, centralizes workflow orchestration in one place, and ensures the enrollment process can be reused without leaking subsystem complexity to client code.
