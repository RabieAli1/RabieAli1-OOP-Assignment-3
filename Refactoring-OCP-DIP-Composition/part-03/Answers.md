# Part 03 — answers

---

## BlockedUsers

- Time complexity before: $O(N \times M)$ where $N$ is the number of blocked IDs and $M$ is the number of request IDs. Calling `.Contains()` on a `List<int>` performs a linear search for each request.
- Time (ms) before: 33 ms
- What did you change: Converted the `blockedIds` collection into a `HashSet<int>`. Lookups using `HashSet.Contains()` operate in $O(1)$ constant average time instead of scanning through the list sequentially.
- Time complexity after: $O(N + M)$ — $O(N)$ to construct the set from the initial list, plus $O(M)$ for constant-time lookups across all requests.
- Time (ms) after: 2 ms

---

## Students

- What was the problem: `StudentCatalog.GetAllStudents()` used eager execution. It created a `List<Student>` and allocated 1,000,000 objects in memory upfront, even though the caller only needed the first 3 students. This caused massive unnecessary memory allocations and wasted CPU cycles.
- What did you change: Changed the return type from `List<Student>` to `IEnumerable<Student>` and used `yield return` to implement lazy (deferred) execution. Students are now instantiated on-demand, terminating immediately after the third item is read without creating the remaining 999,997 students.
