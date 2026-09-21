# Sharpbox

A personal C# playground for trying out language features, idioms, and small patterns in isolation.

Each file is a self-contained example rather than part of a larger application:

- `BestPractices.cs` — before/after pairs contrasting verbose code with more idiomatic C# (null-coalescing operators, dictionary vs. array iteration, `Enum.GetValues` with `Index()`, etc.)
- `DisposePattern.cs` — the standard `IDisposable`/finalizer dispose pattern
- `EventProcessor.cs`, `ThreadSafeEventHandling.cs`, `WaitAllEvents.cs` — thread-safe event queueing with a chained `Task.ContinueWith`, and awaiting a set of events via `TaskCompletionSource`
- `Extensions.cs` — small extension method examples (tuple-to-`KeyValuePair`, string formatting helpers)
- `Scan.cs` — building a formatted table from a flat array of values
- `Png.cs` — writing a minimal valid PNG file by hand
- `Planets.cs`, `Moons.cs`, `Mnemonic.cs`, `MnemonicPair.cs`, `Systems.cs` — a small toy domain model (enums and records) used as sample data across the other examples
- `Program.cs` — a scratchpad exercising pattern matching, switch expressions, LINQ, generics, string formatting, and reflection

## Requirements

- .NET 10 SDK

## Running

```bash
dotnet run --project Sharpbox
```
