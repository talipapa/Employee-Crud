
# Employee-Crud using Dapper, C#, MSSQL Server, and ASP.NET Core 8.0 API

This repository contains an API for managing employee information. It is built with C#, ASP.NET Core 8.0, EntityFramework SqlServer for database operations, and Microsoft SQL Server data storage.



## Table of Contents
- [Introduction / Features](#features)
- [Technologies Used](#technologies-used)
- [Getting Started / Installation](#installation)
- [Endpoints](#endpoints)

## Features
This API provides CRUD operation for managing Employee information. It allows user to:
 - Get all employees (has optional search query)
 - Get employee by ID
 - Add new employee
 - Update existing employee
 - Partially update existing employee
 - Delete employee

## Technologies Used
- .NET 8.0: The application is built on the .NET 8.0 framework.
- Entity Framework Core (EF Core) 9.0.8: The core ORM for data access.
  - Microsoft.EntityFrameworkCore.SqlServer
  - Microsoft.EntityFrameworkCore.Tools
  - Microsoft EntityFrameworkCore.Design
- Swashbuckle.AspNetCore 6.6.2

## Installation
To run this project locally, follow these steps:

1. Clone this repository to your local machine.
    ```
    git clone <repository-url>
    cd <project-directory>
    ```
3. Database Setup
    1. Ensure your SQL Server instance is running
    2. Open the appsettings.json file in the project root
    3. Make sure to match the connection string with your SQL Server configuration:
       
         ```
         {
           "ConnectionStrings": {
             "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=employeedb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true"
           }
         }
         ```
4. Database Migration
    1. Open the solution in Visual Studio 2022
    2. Open the Package Manager Console (Tools → NuGet Package Manager → Package Manager Console)
    3. Run the following command to apply database migrations:
    
       ```
        Update-Database
        ```
  
4.  Build and Run
##  Endpoints
- **GET** `/api/Employee` - Retrieve all employees.
- **GET** `/api/Employee?searchString=''` - Filter employees using query.
- **GET** `/api/Employee/{id}` - Retrieve a employees by ID.
- **POST** `/api/Employee` - Add a new employees.
- **PUT** `/api/Employee/{id}` - Update an existing employees.
- **DELETE** `/api/Employee/{id}` - Delete a employees by ID.
