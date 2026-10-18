# Generics — Answers

---

## Step 2 — A store for courses

### What is the same between the two stores?

- **The management logic and internal mechanics:** Both classes maintain a private `List<T>`, iterate through items to find a matching `Id`, return `null` when not found, remove elements at a specific index, and return the underlying list in `GetAll()`. The algorithmic structure is 100% identical.

### What is different?

- **The specific data type being managed:** `StudentStore` is tightly coupled to `Student`, while `CourseStore` is tightly coupled to `Course`.
- **The violation introduced:** This duplicates boilerplate code across entities (violating the DRY principle: Don't Repeat Yourself).


## Step 3 — One class for both

### Compiler Error:
```text
error CS1061: 'T' does not contain a definition for 'Id' and no accessible extension method 'Id' accepting a first argument of type 'T' could be found (are you missing a using directive or an assembly reference?)

 Why does the compiler reject it?
C# is a statically-typed language that enforces compile-time type safety. When defining a generic parameter <T> without any constraints, the compiler treats T as System.Object.

Because System.Object contains only members like ToString(), Equals(), and GetHashCode(), the compiler has no guarantee that whichever type replaces T at runtime will possess an Id property. Therefore, accessing item.Id is rejected at compile time.




---

## Step 7 — Prove it in Main

### Why does `new Store<string>()` NOT compile?
Because `Store<T>` has a constraint: `where T : IHasId`. 

The `string` class does not implement `IHasId`. The compiler enforces this rule at compile time and rejects any type that does not follow the contract.

---

## Last Question — Search

### What is the common name for the kind of class built in Steps 4 and 5?
It is called the **Repository Pattern** (specifically a **Generic Repository** or **In-Memory Repository**). 

It acts as an in-memory collection that hides data storage and retrieval details behind standard methods like `Add`, `GetById`, `GetAll`, and `Remove`.