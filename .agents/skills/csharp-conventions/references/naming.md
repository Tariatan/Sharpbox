# Naming

- Fields: `private readonly camelCase` (no underscore prefix).
- Properties: PascalCase, prefer getter-only `{ get; }` for immutable state.
- Methods and parameters: PascalCase methods, camelCase parameters.
- Constants: PascalCase, never ALL_CAPS. Prefer `public static readonly` over `public const` on publicly-visible declarations — a `const` value is inlined into every consuming assembly, so changing it later means recompiling every consumer. Plain `const` is fine once the containing type/member is `private` or `internal`.
- Enums: PascalCase type and members. Trailing comma after the last member.
- Access modifiers: always explicit — write `private` even when it is the default.
- Keep visibility as narrow as possible; widen a type or member only when something outside its intended scope genuinely needs it. Never make something public just so a test assembly can see it — use `[InternalsVisibleTo]` instead.
- Abstract classes: suffix with `Base`, constructor `protected`.
- Types that wrap an `IObservable<T>`: suffix with `Stream`.
- Static classes holding extension methods: suffix with `Extensions`; extend the most specific type the method actually needs, never `object`.
- Lambda parameters: give them a meaningful name; use `_` only when the parameter is genuinely unused.

## Things to Avoid

- Underscore-prefixed fields (`_field`) — use plain `camelCase`.
- Omitting access modifiers on any member.
