# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Build & Test Commands

```bash
# Build solution
dotnet build

# Run app
dotnet run --project src/App

# Run all tests
dotnet test

# Run single test by name
dotnet test --filter "Test_Add_Returns_Correct_Sum"

# Run tests with verbose output
dotnet test -v n
```

## Architecture

.NET 10 console app with xUnit v3 tests.

```
src/App/          - Main application (App.csproj)
tests/App.Tests/  - xUnit tests referencing App project
```

Test project uses xUnit v3 (0.6.0-pre.7) with `[Fact]` and `[Theory]` attributes.
