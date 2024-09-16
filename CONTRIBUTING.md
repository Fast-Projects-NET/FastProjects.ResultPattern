# Contributing to FastProjects

We appreciate your interest in contributing to FastProjects! Below are the guidelines to help you get started.

## Getting Started

Before contributing, please review the following steps.

### Reporting Issues

You can start by creating the following types of issues [here](https://github.com/Fast-Projects-NET/{REPOSITORY_NAME}/issues/new/choose):
1. **Bug Reports**: Report a bug or unexpected behavior.
2. **Feature Requests**: Suggest new features or improvements.
3. **Code Improvements/Documentation Updates**: Propose improvements to the existing code or documentation.

Please ensure you create an issue before working on a PR.

---

## MyFlow Workflow

We use the **MyFlow** workflow for all Pull Requests (PRs). Please follow these steps when submitting your PR:

### Pull Request Naming Convention

Use the following naming convention for your branches linked to PRs:
```
users/{username}/{topic}/{id}_{title}
```
- **username**: Your GitHub username.
- **topic**: Use one of: `feature`, `bugfix`, `documentation`, or `improvement`.
- **id**: The issue number this PR addresses.
- **title**: A brief description of what the PR resolves (e.g., `fix_dependency_injection`).

### Commits and Branches

- **Commits**: All commits in your PR will be **squashed** into one when merged.
- **Branches**: Always create a new branch for your contributions and use the same naming convention as the PR.

---

## Contribution Guidelines

### Best Practices

- Keep your changes simple. Follow the **KISS (Keep It Simple, Stupid)** principle.
- Use [C# coding best practices](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions) as a reference.
- Ensure all tests pass before submitting a PR.

### Running Tests

- Make sure all existing tests pass by running `dotnet test`.
- Add new tests if you're introducing new features or fixing bugs.

---

## Code Standards

Follow [official C# coding standards and best practices](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions) for clean, maintainable code.

---

## Licensing

All contributions are licensed under the MIT License.

---

## Communication

- Use **Issues** for general discussions and feedback.
- Pull Request discussions will focus on specific changes.

---

Thank you for helping improve FastProjects!
