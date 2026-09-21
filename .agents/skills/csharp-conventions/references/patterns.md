# Patterns & Idioms

- Prefer `var` when the type is obvious from the right-hand side.
- Prefer expression-bodied members (`=>`) for single-expression methods and properties.
- Use primary constructors where the class mainly captures constructor parameters as properties.
- Use collection expressions (`[a, b, c]`) for array/list literals; use target-typed `new()` for field init.
- Use dictionary indexer initializer syntax: `[key] = value` (not `{ key, value }` / `Add`).
- Trailing commas in multi-line initializers and enum definitions.
- `string.Empty` over `""` when the intent is "no content" rather than a literal empty string.
- String interpolation (`$"..."`) over concatenation. `string.Join` for collections.
- `StringBuilder` for heavy concatenation in loops.
- Pass `CultureInfo.InvariantCulture` explicitly for culture-sensitive operations.
- Switch expressions over switch statements when returning a value or assigning.
- Use property patterns (`{ Prop: value }`), relational patterns, and `when` guards freely.
- Allman brace style. Always use braces for `if`/`for`/`foreach` bodies, even single-statement.
- Prefer `foreach` over index-based `for` loops. Use deconstruction (`foreach (var (k, v) in dict)`) when iterating key-value pairs.
- One attribute per line — don't combine multiple attributes into a single `[...]` declaration.
- Use `record` for value-object types — gets structural equality (`IEquatable`) and immutable properties for free instead of hand-writing both on a class.
- `IReadOnlyCollection<T>` for a collection you expose (e.g. a property); `IEnumerable<T>` for a collection you merely consume (e.g. a method parameter).

## Modern Framework Features

- Prefer the latest .NET / C# APIs over legacy equivalents. Examples:
  - `Enum.GetValues<T>().Index()` over manually tracking an index variable.
  - Collection expressions `[a, b]` over `new[] { a, b }`.
  - `string.Contains(value, StringComparison.Ordinal)` over `IndexOf(...) >= 0`.
  - `Random.Shared` over `new Random()`.
  - `TimeProvider` over `DateTime.UtcNow` in testable code.
- When reviewing, flag opportunities to replace older patterns with modern equivalents.

## Null Handling

- Nullable reference types always enabled (`<Nullable>enable</Nullable>`).
- Prefer `??` (null-coalescing) over `if (x == null) ...` assignments.
- Prefer `??=` (null-coalescing assignment) over conditional set.
- Prefer `?.` (null-conditional) over explicit null-check before member access.
- Use `!` (null-forgiving) sparingly and only when the compiler cannot prove non-null but you can.

## Async / Concurrency

- Async methods must accept `CancellationToken` and forward it to all async calls.
- Always pass `TaskScheduler.Default` to `ContinueWith` — never rely on the ambient scheduler.
- Prefer `lock` + `ConcurrentQueue<T>` for serialized event dispatch over manual synchronization.
- Use `TaskCompletionSource<T>` with `WaitAsync(TimeSpan)` for timed async coordination.

## Disposal

- Implement the full `IDisposable` pattern (finalizer, `Dispose(bool)`, `GC.SuppressFinalize`) when holding unmanaged resources.
- Use `using` declarations (`using var x = ...;`) over `using` statement blocks.

## Things to Avoid

- `new[]` syntax — prefer collection expressions `[...]` on modern target frameworks.
