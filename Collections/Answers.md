# Collections — Answers

---

## Task 2.1 — Research: IReadOnlyDictionary & SortedDictionary

### 1. What is each one?

- **`IReadOnlyDictionary<TKey, TValue>`**: An interface that provides a read-only view of a keyed collection of key/value pairs. It exposes read-only members such as `Count`, `Keys`, `Values`, `ContainsKey`, `TryGetValue`, and a read-only indexer (`this[key]`). It contains no mutation methods such as `Add`, `Remove`, or `Clear`.
- **`SortedDictionary<TKey, TValue>`**: A generic collection of key/value pairs sorted automatically by key. It is implemented internally as a self-balancing binary search tree (Red-Black tree).

### 2. How is `IReadOnlyDictionary` different from `Dictionary`, and why would a public method return one?

- **Difference:** `Dictionary<TKey, TValue>` allows both reading and modifying entries (`Add`, `Remove`, updating via indexer). `IReadOnlyDictionary<TKey, TValue>` only permits read operations and hides any state-mutating methods.
- **Why return it from a public method?** To enforce **encapsulation and data integrity**. Returning a concrete `Dictionary` allows callers to accidentally or intentionally modify, clear, or corrupt the internal state of an object. Returning `IReadOnlyDictionary` guarantees that callers can inspect the data without being able to alter it.

### 3. How is `SortedDictionary` different from `Dictionary` in ordering and lookup speed?

- **Ordering:**
  - `Dictionary`: Does not guarantee any specific order of keys. The order depends on insertion sequence, internal bucket distribution, and removals, and can change on resizing.
  - `SortedDictionary`: Always maintains its elements strictly sorted by key according to the default comparer or a custom `IComparer<TKey>`.
- **Lookup Speed:**
  - `Dictionary`: Operates in **$O(1)$** average time complexity for lookups, insertions, and deletions via hash codes.
  - `SortedDictionary`: Operates in **$O(\log N)$** time complexity for lookups, insertions, and deletions because it traverses a balanced binary search tree.

### 4. When would you choose `SortedDictionary`?

Choose `SortedDictionary` when keeping keys continuously sorted in memory is a strict requirement, items are inserted or removed dynamically throughout execution, and iterating over the collection in key order is more critical than maximizing raw $O(1)$ lookup performance.

---

## Task 2.2 — Pick the Collection

- **S1:** Find a student by national ID — thousands of times a day.
  - **Choice:** `Dictionary<string, Student>`
  - **Why:** Lookups by a unique key operate in average $O(1)$ constant time, which is optimal for frequent read operations.

- **S2:** Keep the tags of a course. The same tag must never be stored twice.
  - **Choice:** `HashSet<string>`
  - **Why:** It enforces uniqueness automatically and verifies whether an item exists in $O(1)$ average time without allowing duplicates.

- **S3:** Keep a student's grades in the order they were entered. The same grade can appear more than once.
  - **Choice:** `List<decimal>` (or `List<int>`)
  - **Why:** It preserves insertion order, allows duplicate values, and provides efficient indexed access.

- **S4:** A public method returns the course price list. Callers can read prices but must not add or change any.
  - **Choice:** `IReadOnlyDictionary<string, decimal>`
  - **Why:** It allows callers to query prices by course name while preventing them from adding, removing, or altering values.

- **S5:** A timetable keyed by session start time. Sessions are added at any moment, and it must always print in time order.
  - **Choice:** `SortedDictionary<TimeOnly, Session>` (or `SortedDictionary<DateTime, Session>`)
  - **Why:** It automatically keeps all entries sorted by key upon insertion, ensuring sequential iteration in chronological order.

- **S6:** A method returns results that the caller only loops over once — and may stop early.
  - **Choice:** `IEnumerable<T>`
  - **Why:** It enables deferred execution (lazy evaluation) so items are produced on-demand and iteration can terminate early without buffering the entire sequence in memory.
