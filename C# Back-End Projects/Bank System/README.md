# 🏦 Bank System Back-End Project

## Overview
A comprehensive C# Web API solution for managing all banking operations, designed as a robust and scalable backend system. It offers a wide array of RESTful API endpoints to support essential banking services, including user management (for individuals, employees, and customers), detailed account management, secure transaction processing, seamless money transfers, and precise currency conversion.

## 🎯 Objectives
This project was developed as a comprehensive learning exercise to solidify skills in backend development. It aims to:

- Master backend technologies by gaining hands-on experience with C#, ASP.NET Core Web API, and SQL databases.
- Design and implement a fully functional RESTful API for banking systems, covering a wide range of banking operations.
- Apply and understand the 3-tier architecture pattern by separating concerns into Presentation, Business Logic, and Data Access layers to build a scalable system.
- Work with relational databases, including T-SQL for SQL Server, and understand the key differences when using SQLite.
- Integrate custom middleware for logging incoming requests to enhance system observability and traceability.
- Utilize Swagger UI as a presentation layer for comprehensive API documentation and interactive testing.
- Practice working with and supporting both SQL Server and SQLite backends.

## Architecture
The system is built upon a **3-tier architecture**, effectively separating concerns into distinct layers:

- **Presentation Layer:**  
  This layer handles incoming HTTP requests and responses. It exposes the API endpoints, processes client input, and returns the results. In this project, Swagger UI is integrated here to provide an intuitive and interactive interface for exploring and testing the API.

- **Business Logic Layer:**  
  The core of the application, this layer contains all the business rules and logic. It processes data from the Presentation Layer, applies validations and workflows, and communicates with the Data Access Layer to perform CRUD operations.

- **Data Access Layer:**  
  Responsible for interacting directly with the database. This layer uses SQL and T-SQL queries to retrieve, insert, update, and delete data, ensuring efficient database communication.

- **Helper Layers:**  
  These include several supporting components:  
  - **Validation Helpers** and **Custom Attributes** used for method and class-level validation to enforce business rules and ensure data integrity.  
  - **DTO (Data Transfer Object) Layer** used to move data cleanly and efficiently between the different layers, promoting loose coupling and separation of concerns.

This layered architecture enhances **scalability** and **maintainability** by organizing code logically and minimizing interdependencies.

## Technologies Used
- **C#**, **.NET** and **ASP.NET Core** for building a powerful, modular Web API backend.  
- **SQL Server** and **SQLite** for relational database management, with T-SQL supporting advanced database operations in SQL Server.  
- **Swagger UI** integrated as both a presentation and testing interface, providing full documentation and easy interaction with over 100 API endpoints.  
- **Middlewares** for logging every incoming request, ensuring traceability and observability throughout the system.
- **Controllers with Attributes:**  
  The API endpoints are implemented using ASP.NET Core Controllers decorated with attributes for routing, validation, response types, Documentation and more.  

## 📌 Key Features
- ✅ 100+ endpoints to handle all banking operations.
- 👤 Role-based support for users, employees, customers, employees, and admins.
- 💸 accounts, Money transfers, transactions, and currency conversion.
- 📂 SQLite and SQL Server database support.
- 🔍 Middleware included to log every incoming request.
- 🧪 Swagger used for API testing and documentation.
- 🔐 Secure hashing of sensitive data such as passwords and PIN codes in the database.

## 📋 Request Logging
The project includes middleware that logs every API call with details such as:

- Timestamp of the request.  
- Log level ([INF]).  
- HTTP method (GET, POST, etc.). 
- Endpoint URL.  
- Response status code.

Logs are saved in the `logs` folder inside the Bank System folder in the project directory.

## 🔧 Custom Attributes
The project includes custom attributes that can be applied to classes, methods, or properties to enforce validation and other business rules. These attributes help keep the code clean and maintainable by centralizing common logic in reusable decorators.

## 📊 Database Tables and Seed Data
The project database contains a variety of tables used to support banking operations. These include:

- **People**
- **Users**
- **Customers**
- **Employees**
- **Accounts**
- **LogIns**
- **Transactions**
- **Transfers**
- **Currencies**
- **AccountStatuses**
- **TransferReasons**
- **TransactionTypes**
- **Countries**
- **Departments**
- **FeeSettings**

### 🧪 Seeded vs Empty Tables
Some tables come preloaded with sample (seed) data to support development and testing and enable using the project right away:

- ✅ `People`, `Users`, `Employees`, `Customers`,`Accounts`, `TransactionTypes`, `TransferReasons`, `AccountStatuses`, `Departments`, `FeeSettings`, `Countries`, and `Currencies` include initial data.
- 🚫 `Transactions`, `Transfers`, and `LogIns`, start empty by default.

## 📝 Important Note on Versions
This project comes in two primary database versions:

- **SQL Server Version:**  
  This is the main version, leveraging the full power of SQL Server, including the extensive use of Stored Procedures for complex database operations.

- **SQLite Version:**  
  This version offers a lightweight, file-based database alternative. It has a few key differences from the SQL Server version, notably:
  - **No Stored Procedures:** SQLite does not support stored procedures, so equivalent logic is handled within the C# application code.
  - **No Triggers:** To maintain simplicity and ensure portability, triggers were intentionally avoided in the SQLite version. All required behaviors are implemented through business logic in the codebase.
  - **Data Type Handling:** In the C# code, primarily `long` is used for numeric types, with `byte` or `int` being used less frequently due to SQLite's more flexible type affinity.

The version included in this repository is the **SQLite version**, chosen because it runs more easily without requiring additional downloads or complex configuration. This makes the project fully self-contained and easier to get up and running quickly.

While the SQLite version differs slightly from the SQL Server version (e.g., no stored procedures and some differences in data type handling), the core functionality and business logic remain consistent across both versions.

## 🚀 How to Run
Follow these steps to get the Bank System Web API running on your local machine:

1. **Prerequisites:**  
   Ensure the .NET SDK is installed on your computer.  
   Download it from the official Microsoft [.NET website](https://dotnet.microsoft.com/download) if you don’t have it yet.

2. **Clone or Download:**  
   Clone this repository to your local machine or download the ZIP archive and extract it.

3. **Navigate to Project Directory:**  
   Open your terminal (VS Code integrated terminal, PowerShell, or Command Prompt) and change directory to the Bank System folder of the project.

4. **Run the Application:**  
   Execute the following command to start the Web API:  
   ```bash 
    dotnet run

5. **Access the API:**  
   Once the app is running, open your browser and navigate to the URL shown in the terminal (e.g., `http://localhost:5136`).
   > **Note:** The port number may vary each time you run the app, but the default port is **5136**.

   To access the Swagger UI, append `/swagger` to the base URL:
   `http://localhost:<PORT>/swagger`

   Replace `<PORT>` with the actual port number displayed in your terminal.

## 🔑 Accessing the System
To interact with the system's endpoints via Swagger UI, authentication is required.

1. Locate the **Login** API endpoint (usually the last one listed in the Swagger documentation).
2. Use the following credentials to log in:
   - **Username:** MainUser  
   - **Password:** MainUser
3. Now you Can Use the API.

## 🗨️ Feedback
- Found a mistake, bug, or have suggestions? Feel free to open an issue or submit a pull request.
- Got questions about the project? Don’t hesitate to ask!
