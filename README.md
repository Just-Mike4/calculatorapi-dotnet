# ASP.NET Core Calculator API

This project implements a simple RESTful API built with ASP.NET Core that provides basic arithmetic operations. It allows clients to perform addition, subtraction, and multiplication by sending a GET request with two operands and a specified operation as query parameters. The API is designed with a clear separation of concerns, utilizing services for business logic and models for data transfer, and employs the Strategy design pattern for operation handling.

## Installation Instructions

To set up and run this project locally, follow these steps:

1.  **Prerequisites:**
    *   Ensure you have the .NET SDK (compatible with ASP.NET Core) installed on your machine. You can download it from the official .NET website.

2.  **Clone the Repository:**
    *   (Assuming this project is hosted in a Git repository) Clone the repository to your local machine:
        ```bash
        git clone <repository-url>
        cd <project-directory>
        ```

3.  **Restore Dependencies:**
    *   Navigate to the project's root directory in your terminal or command prompt and restore the necessary NuGet packages:
        ```bash
        dotnet restore
        ```

4.  **Build the Project:**
    *   Build the application to ensure all dependencies are resolved and the code compiles without errors:
        ```bash
        dotnet build
        ```

5.  **Run the Application:**
    *   You can run the application using the .NET CLI:
        ```bash
        dotnet run
        ```
    *   Alternatively, you can open the project in Visual Studio or JetBrains Rider and run it directly from the IDE.
    *   Once running, the API will typically be accessible at `http://localhost:5130` (HTTP) or `https://localhost:7002` (HTTPS) in a development environment, as configured in `launchSettings.json`.

## Usage Examples

The Calculator API exposes a single `GET` endpoint for performing calculations.

### `GET /api/Calculator`

This endpoint accepts two numbers and an operation string as query parameters, then returns the calculated result.

**Query Parameters:**
*   `operand1` (double): The first number for the calculation.
*   `operand2` (double): The second number for the calculation.
*   `operation` (string): The arithmetic operation to perform.

**Supported Operations:**
*   `"add"`: Performs addition.
*   `"subtract"`: Performs subtraction.
*   `"multiply"`: Performs multiplication.

**Example using `curl`:**

**Addition:**
```bash
curl "http://localhost:5130/api/Calculator?operand1=10.5&operand2=5.2&operation=add"
```
**Expected Successful Response (JSON - HTTP 200 OK):**
```json
{
  "operand1": 10.5,
  "operand2": 5.2,
  "operation": "add",
  "result": 15.7
}
```

**Multiplication:**
```bash
curl "http://localhost:5130/api/Calculator?operand1=7&operand2=3&operation=multiply"
```
**Expected Successful Response (JSON - HTTP 200 OK):**
```json
{
  "operand1": 7,
  "operand2": 3,
  "operation": "multiply",
  "result": 21
}
```

**Unsupported Operation Example:**
```bash
curl "http://localhost:5130/api/Calculator?operand1=10&operand2=2&operation=divide"
```
**Expected Error Response (JSON - HTTP 400 Bad Request):**
```json
{
  "error": "Unsupported operation. Use add, subtract, or multiply."
}
```

## Features Overview

*   **Core Arithmetic Operations:** Supports addition, subtraction, and multiplication.
*   **RESTful API Design:** Implements a clean, single-endpoint GET API for calculations.
*   **Strategy Pattern Implementation:** Uses the Strategy design pattern (`IOperationStrategy`) to encapsulate different arithmetic operations, making the service easily extensible for new operations.
*   **Dependency Injection:** Utilizes ASP.NET Core's built-in dependency injection for managing services, including the `ICalculatorService` and various `IOperationStrategy` implementations.
*   **Clear Separation of Concerns:** Logic is organized into Controllers (API endpoints), Models (data structures), and Services (business logic, operation strategies).
*   **Swagger/OpenAPI Documentation:** Automatically generates and serves interactive API documentation using Swashbuckle, accessible in the development environment (typically at `/swagger`).
*   **Robust Error Handling:** Catches unsupported operations and returns appropriate `HTTP 400 Bad Request` error messages.
*   **Configurable Logging:** Basic logging configured via `appsettings.json` and `appsettings.Development.json`.

## File Structure Summary

The project follows a standard ASP.NET Core API project structure:

```
.
├── Controllers/
│   └── CalculatorController.cs       # Defines the API endpoint for calculations, handling HTTP requests.
├── Models/
│   └── CalculatorResult.cs           # Data model representing the output of a calculation.
├── Services/
│   ├── CalculatorService.cs          # Implements the core business logic for calculations using strategies.
│   ├── ICalculatorService.cs         # Interface defining the contract for the calculator service.
│   └── OperationStrategies.cs        # Contains implementations of IOperationStrategy for add, subtract, multiply.
├── appsettings.json                  # Main application configuration settings.
├── appsettings.Development.json      # Configuration settings specific to the development environment.
├── Program.cs                        # Application entry point, handles service registration, middleware setup, and application startup.
├── Properties/
│   └── launchSettings.json           # Defines local launch profiles for debugging and development.
├── .gitignore                        # Specifies files and directories to be ignored by Git version control.
└── README.md                         # This comprehensive README file.
```

## Important Notes

*   **Development Environment:** Swagger UI, providing interactive API documentation, is only enabled when the application is running in the `Development` environment (controlled by the `ASPNETCORE_ENVIRONMENT` variable).
*   **Supported Operations:** Currently, the API explicitly supports "add", "subtract", and "multiply" operations. Requests with any other operation string will result in a `HTTP 400 Bad Request` response.
*   **Logging:** Basic logging is configured to output `Information` level messages for default categories and `Warning` for `Microsoft.AspNetCore` messages. This configuration can be easily adjusted within the `appsettings.json` and `appsettings.Development.json` files.
*   **HTTPS Redirection:** The application is configured to redirect HTTP requests to HTTPS by default, which is a standard security best practice in web development. Development launch profiles include both HTTP and HTTPS URLs for flexibility.