# C# Web Application

This project is a C# web application built with .NET 8.0 and uses various technologies for authentication, configuration, and data access. It utilizes PostgreSQL with Entity Framework Core, and Swagger for API documentation.

## Technologies

- **.NET 8.0 SDK**: The application is built using the latest version of .NET, providing performance improvements, enhanced security, and simplified code syntax.
- **Entity Framework Core**: ORM for database interaction, with PostgreSQL as the database provider.
- **JWT Authentication**: Secure API endpoints with JSON Web Tokens (JWT).
- **Swashbuckle/Swagger**: Generate and document APIs for testing and easy access.
- **Npgsql**: PostgreSQL provider for Entity Framework Core.

## Getting Started

### Prerequisites

To run this project locally, ensure you have the following tools installed:

- .NET 8.0 SDK or later: [Download .NET SDK](https://dotnet.microsoft.com/download/dotnet)
- PostgreSQL: [Download PostgreSQL](https://www.postgresql.org/download/)
- Visual Studio or Visual Studio Code for code editing (optional, but recommended).

### Cloning the Repository

1. Open a terminal or command prompt.
2. Clone the repository by running the following command:
   ```bash
   git clone https://github.com/zainabimran94/StoryBook-c-
3. Navigate into the project directory:
   cd StoryBook

### DataBase Setup
This project uses PostgreSQL with Entity Framework Core. To set up the database:
 1. Create a PostgreSQL database locally or on your server.
 2. Update the connection string in the appsettings.json file.
 3. Run the following command to apply database migrations:
    ```bash
    dotnet ef database update
    
### Installing Dependencies
Run the following command to restore all necessary NuGet packages:
  ```bash
 dotnet restore


    
