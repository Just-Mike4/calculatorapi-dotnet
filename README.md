# Calculator API

## Project Title
ASP.NET Core Calculator API

## Short Description
This project implements a simple RESTful API built with ASP.NET Core that provides basic arithmetic operations. It allows clients to perform addition, subtraction, and multiplication by sending a request with two operands and a specified operation. The API is designed with a clear separation of concerns, utilizing services for business logic and models for data transfer.

## Installation Instructions

To set up and run this project locally, follow these steps:

1.  **Prerequisites:**
    *   Ensure you have the .NET SDK (version compatible with ASP.NET Core) installed on your machine. You can download it from the official .NET website.

2.  **Clone the Repository:**
    *   (Assuming this project is hosted in a Git repository) Clone the repository to your local machine using your preferred Git client.
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

The Calculator API exposes a single endpoint for performing calculations.

### `POST /api/Calculator`

This endpoint accepts a JSON payload containing two numbers and an operation string, then returns the calculated result.

**Request Body Example:**

```json
{
  "operand1": 10.5,
  "operand2": 5.2,
  "operation": "add"
}
```

**Supported Operations:**
*   `"add"`: Performs addition.
*   `"subtract"`: Performs subtraction.
*   `"multiply"`: Performs multiplication.

**Example using `curl`:**

**Addition:**
```bash
curl -X POST -H "Content-Type: application/json" -d '{"operand1": 10.5, "operand2": 5.2, "operation": "add"}' http://localhost:5130/api/Calculator
```
**Expected Successful Response (JSON):**
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
curl -X POST -H "Content-Type: application/json" -d '{"operand1": 7, "operand2": 3, "operation": "multiply"}' http://localhost:5130/api/Calculator
```
**Expected Successful Response (JSON):**
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
curl -X POST -H "Content-Type: application/json" -d '{"operand1": 10, "operand2": 2, "operation": "divide"}' http://localhost:5130/api/Calculator
```
**Expected Error Response (JSON - HTTP 400 Bad Request):**
```json
{
  "error": "Unsupported operation. Use 'add', 'subtract', or 'multiply'."
}
```

## Features Overview

*   **Core Arithmetic Operations:** Supports addition, subtraction, and multiplication.
*   **RESTful API Design:** Implements a clean, single-endpoint POST API for calculations.
*   **Dependency Injection:** Utilizes ASP.NET Core's built-in dependency injection for managing services, specifically `ICalculatorService` and `CalculatorService`.
*   **Clear Separation of Concerns:** Logic is organized into Controllers (API endpoints), Models (data structures), and Services (business logic).
*   **Swagger/OpenAPI Documentation:** Automatically generates and serves interactive API documentation using Swashbuckle, accessible in the development environment (typically at `/swagger`).
*   **Robust Error Handling:** Catches unsupported operations and returns appropriate error messages.
*   **Configurable Logging:** Basic logging configured via `appsettings.json` and `appsettings.Development.json`.

## File Structure Summary

The project follows a standard ASP.NET Core API project structure:

```
.
├── Controllers/
│   └── CalculatorController.cs       # Defines the API endpoint for calculations.
├── Models/
│   ├── CalculatorRequest.cs          # Data model for incoming calculation requests.
│   └── CalculatorResult.cs           # Data model for outgoing calculation results.
├── Services/
│   ├── CalculatorService.cs          # Implements the core calculation logic.
│   └── ICalculatorService.cs         # Interface defining the contract for the calculator service.
├── appsettings.json                  # Main application configuration.
├── appsettings.Development.json      # Configuration specific to the development environment.
├── Program.cs                        # Application entry point, handles service registration and middleware setup.
├── Properties/
│   └── launchSettings.json           # Defines local launch profiles for development.
├── .gitignore                        # Specifies files and directories to be ignored by Git.
└── README.md                         # This comprehensive README file.
```

## Important Notes

*   **Development Environment:** Swagger UI is only enabled when the application is running in the `Development` environment (controlled by `ASPNETCORE_ENVIRONMENT` variable).
*   **Supported Operations:** Currently, the API only supports "add", "subtract", and "multiply" operations. Requests with other operations will result in a Bad Request (HTTP 400) response.
*   **Logging:** Basic logging is configured to output `Information` level messages for default categories and `Warning` for `Microsoft.AspNetCore` messages. This can be adjusted in the `appsettings.json` files.
*   **HTTPS Redirection:** The application is configured to redirect HTTP requests to HTTPS by default, which is a security best practice. Development profiles include both HTTP and HTTPS URLs.