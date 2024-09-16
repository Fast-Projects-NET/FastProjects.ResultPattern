# 🚀 **FastProjects.ResultPattern**

![Build Status](https://github.com/Fast-Projects-NET/FastProjects.ResultPattern/actions/workflows/test.yml/badge.svg)
![NuGet](https://img.shields.io/nuget/v/FastProjects.ResultPattern.svg)
![NuGet Downloads](https://img.shields.io/nuget/dt/FastProjects.ResultPattern.svg)
![License](https://img.shields.io/github/license/Fast-Projects-NET/FastProjects.ResultPattern.svg)
![Last Commit](https://img.shields.io/github/last-commit/Fast-Projects-NET/FastProjects.ResultPattern.svg)
![GitHub Stars](https://img.shields.io/github/stars/Fast-Projects-NET/FastProjects.ResultPattern.svg)
![GitHub Forks](https://img.shields.io/github/forks/Fast-Projects-NET/FastProjects.ResultPattern.svg)

> 🚨 ALERT: Project Under Development
> This project is not yet production-ready and is still under active development. Currently, it's being used primarily for personal development needs. However, contributions are more than welcome! If you'd like to collaborate, feel free to submit issues or pull requests. Your input can help shape the future of FastProjects!

---

## 📚 **Overview**

Result pattern implementation with IActionResult mapping for ASP.NET Core.

---

## 🛠 **Roadmap**

- ✅ [Result](src/FastProjects.ResultPattern/Result.cs) - Result pattern implementation
- ✅ [ResultPatternToActionResultExtensions](src/FastProjects.ResultPattern/ResultPatternToActionResultExtensions.cs) - Extensions for mapping Result to IActionResult
- ✅ [ResultExtensions](src/FastProjects.ResultPattern/ResultExtensions.cs) - Extensions for Result that checks status codes

---

## 🚀 **Installation**

You can download the NuGet package using the following command to install:
```bash
dotnet add package FastProjects.ResultPattern
```

---

## 📖 **Usage**

Basic usage example:
```csharp
public async Task<Result<User>> GetByIdAsync(Guid id)
{
    var user = await _userRepository.GetAsync(id);
    if (user is null)
    {
        return Result.NotFound($"User with {id} not found.");
    }

    return Result.Success(user);
}
```

Translation of the result to IActionResult (example with [FastEndpoints](https://fast-endpoints.com/) usage):
```csharp
public override async Task HandleAsync(
    GetUserByIdRequest request,
    CancellationToken ct)
{
    var command = new GetUserByIdQuery(request.UserId);

    var result = await mediator.Send(command, ct);
    
    if (result.IsSuccess)
    {
        Response = new GetUserByIdResponse(
            Id: result.Value.Id,
            Name: result.Value.Name);
    }
    else
    {
        await SendResultAsync(result.ToWebResult());
    }
}
```

## 🤝 **Contributing**

This project is still under development, but contributions are welcome! Whether you’re opening issues, submitting pull requests, or suggesting new features, we appreciate your involvement. For more details, please check the [contribution guide](CONTRIBUTING.md). Let’s build something amazing together! 🎉

---

## 📄 **License**

FastProjects is licensed under the **MIT License**. See the [LICENSE](LICENSE) file for full details.
