# Coding Guidelines

## File & Type Organization

- File-scoped namespaces: `namespace Foo;` (no block braces).
- One type per file. Closely related helper types (e.g. a small DTO used only by its sibling) may share a file.
- `using` directives go outside (above) the namespace declaration.
- Implicit usings enabled — do not re-import namespaces the SDK already provides.

## Correctness

- Edge cases: empty/null/absent input, boundary values, first/last element.
- Error propagation and error handling: does a failure surface where it can be acted on, or get swallowed?
- Cancellation, retries, and idempotency: repeating or interrupting the operation doesn't corrupt state or duplicate effects.
- Concurrency and async correctness: race conditions, ordering guarantees, thread safety, lifecycle issues (something used after it's disposed/shut down).
- Resource cleanup and disposal: everything acquired is released on every exit path, including error paths — see `references/patterns.md` for the C# `IDisposable`/`using` mechanics.
- State transitions: every reachable state is accounted for, not just the ones the happy path exercises.
- Whether an error condition could be **defined out of existence** — a different API shape, a sentinel default, restructuring so the case can't occur — instead of being defended against everywhere it might arise.

## Architecture

- Responsibilities are well separated between types/modules.
- Abstractions are appropriate for what they hide — not too thin (leaks the detail anyway) or too thick (hides something a caller actually needs).
- Dependencies point in the correct direction; no cyclic dependencies.
- The implementation matches the intended concept, not a nearby-but-different one.
- The resulting API is usable from a caller's perspective, not just correct from the implementer's.

## Design Complexity

Complexity compounds over the life of a system — a change is a chance to catch it early instead of letting it in.

- **Change amplification** — does a simple-sounding change touch many unrelated files or classes? That usually means a missing abstraction, not an unlucky diff.
- **Cognitive load** — to understand or extend this change, how much context does a reader have to hold at once? Prefer designs where a caller only needs the interface, not the implementation.
- **Unknown unknowns** — is it obvious, from the code alone, what else would need to change if this area is touched again? If not, that's a design smell even when the code is otherwise correct.
- **Deep modules** — a simple interface hiding real functionality is worth more than a simple implementation with a complicated interface. Watch for classes/functions whose interface is large or leaky relative to what they actually do.
- **Information hiding** — who needs to know this detail, and when? Watch for places where an implementation detail leaks across a boundary that should hide it.
- **Sensible defaults** — prefer designs where the common case works automatically over ones that require every caller to remember an extra step.
- **Pass-through method** (red flag): a method whose body does little more than forward its arguments to another method with the same shape. Usually signals responsibilities aren't cleanly divided between the two — worth addressing rather than treating as harmless boilerplate.

## Things to Avoid

- `Console.WriteLine` in production code — use structured logging (`ILogger`).
- `catch` without re-throw or handling — never swallow exceptions silently.

## Reporting

When reviewing, correctness issues that risk incorrect behavior, data loss, or a race/deadlock are usually **Critical**; architecture and design-complexity issues are usually **Major**, unless small enough to be a **Minor** readability/naming-level nit. Naming and pattern/idiom deviations (see `references/naming.md`, `references/patterns.md`) are usually **Minor**.
