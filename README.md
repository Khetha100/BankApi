BankApi

BankApi is a RESTful API for managing bank accounts and authentication built using ASP.NET Core.
Features

    Account Management: Create, update, and delete bank accounts.
    Authentication: Secure login with JWT token authentication.
    Withdrawal: Make withdrawals from bank accounts.
    Audit Trail: Track account changes with audit logs.

Technologies Used

    ASP.NET Core 8.0: Framework for building APIs.
    Entity Framework Core: ORM for database operations.
    JWT Authentication: Token-based authentication for API endpoints.
    Swagger: API documentation and testing tool.

Getting Started
Prerequisites

    .NET 8.0 SDK

Installation

    Clone the repository:

    bash

git clone https://github.com/Khetha100/BankApi.git

Navigate to the project directory:

bash

cd BankApi

Restore dependencies:

bash

dotnet restore

Configure the database connection in appsettings.json.

Run the migrations to create the database schema:

bash

dotnet ef database update

Start the application:

bash

    dotnet run

The API will be available at http://localhost:5107.
Usage
Authentication

To authenticate, send a POST request to /auth/login with valid credentials. You will receive a JWT token in the response.
Bank Accounts

    GET /api/bankaccounts/AccountHolder/{accountHolderId}: Get all bank accounts for a specific account holder.
    GET /api/bankaccounts/{accountNumber}: Get details of a bank account by account number.
    POST /api/bankaccounts/withdraw: Make a withdrawal from a bank account.

For more detailed API documentation and testing, access the Swagger UI at http://localhost:5107/swagger.
Contributing

Contributions are welcome! Please fork the repository and submit a pull request with your changes.
License

This project is licensed under the MIT License - see the LICENSE file for details.