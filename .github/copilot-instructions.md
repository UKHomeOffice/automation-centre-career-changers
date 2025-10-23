# Copilot Instructions for homeoffice-careerchange

## Project Overview

This repository contains a series of C# kata exercises, each in its own solution subfolder under `solutions/`. Each kata is a self-contained application, these should be kept as simple as possible when creating the solutions.

## Architecture & Structure

- **Kata Organization:**
  - Each kata (e.g., `kata-3-fizz-buzz`, `kata-4-string-sanitiser`, `kata-5-temperature-converter`) is in its own subfolder under `solutions/`.
  - Each contains its own build artifacts (`bin/`, `obj/`), source files, and project file.
- **No shared libraries:** Each kata is independent; there are no cross-kata dependencies or shared code.
- **Documentation:** Each kata has a corresponding markdown file at the root (e.g., `kata-3-fizzbuzz-plus.md`) describing requirements and context.

## Developer Workflows

- **Build:**
  - Build a single kata: `dotnet build solutions/<kata-folder>/<project>.csproj`
- **Run:**
  - Run a kata: `dotnet run --project solutions/<kata-folder>/<project>.csproj`
- **Debug:**
  - Use VS Code's C# debugging for step-through in `Program.cs`.
- **Test:**
  - No test projects detected; if adding tests, place them in a `tests/` folder or as `<kata-folder>.Tests` projects.

## Conventions & Patterns

- **C# Console Apps:** All katas use the C# console application template.
- **Single-file main:** Most logic is in `Program.cs` per kata.
- **.NET Version:** Projects target .NET 9.0 (`net9.0`).
- Minimal dependencies: NUnit is the unit testing framework of choice, if required, ask for confirmation before adding any dependencies.
- **Naming:**
  - Kata folders and markdown files use a consistent `kata-<number>-<name>` pattern.
  - Project files match their folder name (e.g., `FizzBuzzPlus.csproj` in `kata-3-fizz-buzz`).

## Integration Points

- **No external APIs or services:** All code is self-contained.

## Examples

- To build and run the FizzBuzz kata:
  ```sh
  dotnet build solutions/kata-3-fizz-buzz/FizzBuzzPlus.csproj
  dotnet run --project solutions/kata-3-fizz-buzz/FizzBuzzPlus.csproj
  ```
- To add a new kata:
  1. Create a new folder under `solutions/`.
  2. Add a new C# console project: `dotnet new console -o solutions/kata-<number>-<name>`
  3. Add a markdown spec at the root.
  4. Add the project to the solution: `dotnet sln add solutions/kata-<number>-<name>/<project>.csproj`

## Key Files & Directories

- `homeoffice-careerchange.sln` — Solution file
- `solutions/` — All kata projects
- `kata-*-*.md` — Kata specifications

---

**If any conventions or workflows are unclear or missing, please provide feedback so this guide can be improved.**
