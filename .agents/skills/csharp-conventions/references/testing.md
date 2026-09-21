# Testing

- Use `new Mock<T>()` + `mock.Object` rather than `Mock.Of<T>()` / `Mock.Get()`.
- Name mock fields `<mockedThing>Mock` (e.g. `assayConfigurationProviderMock`).
- Structure every test as Arrange / Act / Assert, marked with `// Arrange`, `// Act`, `// Assert` comments so the sections are easy to scan.
- Test method naming: `MethodUnderTest_Precondition_ExpectedOutcome`.
- Prefer `[TestInitialize]` over constructor logic for non-trivial setup shared across tests. Skip it when setup is just constructing a couple of mocks needed to build the class under test.

```csharp
[TestMethod]
public void Calculate_WithSomeInput_CalculatesSomeResult()
{
    // Arrange
    var testee = new ClassUnderTest();
    testee.Initialize(1234);

    // Act
    var result = testee.Calculate();

    // Assert
    result.Should().Be(2345);
}
```
