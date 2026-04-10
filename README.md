# SauceDemo-PlaywrightCSharpBDD

A robust C# test automation framework using Playwright and Reqnroll (BDD) for end-to-end testing of the Sauce Demo application. This project demonstrates modern testing practices with behavior-driven development, dependency injection, and the Page Object Model pattern.

## 🚀 Features

- **Behavior-Driven Development (BDD)** - Write tests in natural language using Gherkin syntax
- **Playwright Integration** - Cross-browser automation with Chromium, Firefox, and WebKit
- **Dependency Injection** - Clean architecture using Microsoft.Extensions.DependencyInjection
- **Page Object Model** - Maintainable test code with clear separation of concerns
- **.NET 8** - Built on the latest .NET framework with C# 12 features
- **Configurable** - Easy configuration via `appsettings.json`

## 🛠️ Technologies

| Technology | Version | Purpose |
|------------|---------|---------|
| .NET | 8.0 | Runtime framework |
| C# | 12.0 | Programming language |
| Playwright | 1.58.0 | Browser automation |
| Reqnroll | 3.3.3 | BDD framework (SpecFlow successor) |
| NUnit | 4.5.0 | Test runner |
| Microsoft.Extensions.DependencyInjection | 10.0.3 | Dependency injection |

## 📁 Project Structure

## 📋 Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- [Visual Studio 2022](https://visualstudio.microsoft.com/) (17.8+) or [Visual Studio Code](https://code.visualstudio.com/)
- [PowerShell](https://docs.microsoft.com/powershell/) (for Playwright browser installation)

## ⚙️ Setup

### 1. Clone the Repository

### 2. Install Dependencies

### 3. Install Playwright Browsers

### 4. Configure Test Settings

Edit `Configurations/appsettings.json`:

```json
{
  "BaseUrl": "https://www.saucedemo.com/",
  "Browser": "chromium",
  "Headless": true,
  "SlowMo": 50
}
```

**Configuration Options:**
- `BaseUrl` - Application URL to test
- `Browser` - Browser to use: `chromium`, `firefox`, or `webkit`
- `Headless` - Run browser in headless mode: `true` or `false`
- `SlowMo` - Slow down operations by specified milliseconds (useful for debugging)

### 5. Build the Project

## 🧪 Running Tests

### Visual Studio

1. Open __Test Explorer__ (Test → Test Explorer)
2. Click __Run All__ or right-click specific tests

### Command Line
```bash
dotnet test
```

## 🏗️ Architecture

### Dependency Injection Flow

### Configuration File Not Found

Ensure `appsettings.json` has __Build Action__ set to __Content__ and __Copy to Output Directory__ set to __Copy always__.

### Coding Standards

- Follow C# naming conventions
- Use async/await for asynchronous operations
- Implement Page Object Model for UI interactions
- Write descriptive Gherkin scenarios

## 📝 Best Practices

1. **Keep Scenarios Independent** - Each scenario should be able to run in isolation
2. **Use Page Objects** - Encapsulate page interactions in reusable classes
3. **Descriptive Step Names** - Make steps readable and maintainable
4. **Wait for Elements** - Use Playwright's auto-waiting features
5. **Clean Test Data** - Use hooks to ensure clean state between tests
6. **Configuration** - Externalize environment-specific settings

## 📚 Resources

- [Playwright for .NET Documentation](https://playwright.dev/dotnet/)
- [Reqnroll Documentation](https://docs.reqnroll.net/)
- [NUnit Documentation](https://docs.nunit.org/)
- [BDD Best Practices](https://cucumber.io/docs/bdd/)

## 👥 Authors

- **Vijay Yalla** - [@yallav](https://github.com/yallav)

---

**Happy Testing! 🎭**
