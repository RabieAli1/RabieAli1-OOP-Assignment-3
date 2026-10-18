# Generics — Answers

---

## Step 2 — A store for courses

### What is the same between the two stores?

- **The management logic and internal mechanics:** Both classes maintain a private `List<T>`, iterate through items to find a matching `Id`, return `null` when not found, remove elements at a specific index, and return the underlying list in `GetAll()`. The algorithmic structure is 100% identical.

### What is different?

- **The specific data type being managed:** `StudentStore` is tightly coupled to `Student`, while `CourseStore` is tightly coupled to `Course`.
- **The violation introduced:** This duplicates boilerplate code across entities (violating the DRY principle: Don't Repeat Yourself).
