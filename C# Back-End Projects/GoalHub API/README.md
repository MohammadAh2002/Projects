# ⚽ GoalHub – Sports Management Backend API

GoalHub is a complete backend system for managing players, teams, matches, people, statuses, and more.  
It is built with ASP.NET Core Web API, Entity Framework Core, and a clean Onion Architecture that separates concerns across layered components.

The project includes a full REST API, advanced middleware, authentication and authorization using Identity, image handling, configuration binding, data shaping, filtering, sorting, caching, versioning, rate limiting, and a fully modular repository/service architecture.

SQLite is the default database version included in this repository the Project Also Supports SQL Server.

---

## 🎯 Objectives

This project was developed to practice building a complete, scalable backend system using modern architecture and design techniques.  
It aims to:

- 🧱 Build a modular backend using C#, ASP.NET Core, and Entity Framework Core.
- 🔄 Implement complete RESTful operations including POST, PUT, DELETE, GET, PATCH (JsonPatchDocument), HEAD, and OPTIONS.
- 🏛️ Use Onion Architecture with clean separation across Entities, Repositories, Services, and Controllers.
- ⚙️ Demonstrate advanced ASP.NET Core techniques such as middleware, configuration binding, and action filters.
- 🗂️ Support SQL Server and SQLite.
- 🧹 Implement global error handling using middleware and structured API responses.
- 📚 Document all APIs using Swagger/OpenAPI.
- 🔍 Implement filtering, searching, sorting, paging, data shaping, caching, versioning, and rate limiting.
- 🔐 Implement authentication & authorization Incorporate IdentityDbContext for authentication with roles and claims.
- 🖼️ Manage image uploads by saving files to disk and storing their paths in the database.

And More
---

## 🏗️ Architecture Overview

GoalHub is organized using Onion Architecture, divided into the following layers:

### 1. 📦 Entities Layer
- Domain entities such as Country, City, Team, Player, Match, Person, Status.
- Error models.
- Configuration models.
- Contract models.

### 2. 📑 Contract Layer
- Interfaces for services.
- Interfaces for repositories.
- Logging interfaces.
- Data shaping factory interfaces.
- All application-wide abstractions.

### 3. 🗃️ Repository Layer
- EF Core database access logic via `RepositoryBase` and specialized bases:  
  - `ReadRepositoryBase` (read-only)  
  - `DeleteRepositoryBase` (delete-only)  
  - `UpdateRepositoryBase` (update-only)  
  - `CreateRepositoryBase` (create-only)  
- `RepositoryManager` exposes all entity repositories (`Country`, `City`, `Person`, `Team`, `TeamV2`, `Player`, `PlayerStatus`, `Match`) and handles `SaveAsync`.  
- Each entity is restricted to allowed operations according to business rules.

### 4. ⚙️ Service Layer
- Business logic for entities with AutoMapper mappings, image handling, and authentication.  
- Managers for team, player, city, country, person, and match operations.  
- `ServiceManager` exposes all services via lazy initialization (`CountryService`, `CityService`, `PersonService`, `TeamService`, `TeamServiceV2`, `PlayerService`, `MatchService`, `AuthenticationService`).  
- AutoMapper, Logging, RepositoryManager, DataShaperFactory, FileStorageService, UserManager, and Configuration are injected where needed.

### 5. 📡 Controller Layer
- API controllers.
- Routing and nested routing.
- Action filters for validation.
- Versioning and response configuration.

### 6. 🔗 Shared Layer
- DTO classes.
- Mapping profiles.
- Request features for paging, sorting, filtering, searching.
- Shared utilities used across the project.

---

## ⚙️ Configuration

GoalHub uses `appsettings.json` to store configuration such as database settings, file storage paths, JWT configuration, and behavior flags.

The project uses:

- builder.Services for dependency injection.
- Extension methods for middleware and configuration registration.
- Options pattern with strongly typed configuration models.

---

## 🚀 API Features

### 🌐 RESTful Endpoints
Supports all HTTP methods:
- GET
- POST
- PUT
- DELETE
- PATCH (JsonPatchDocument)
- HEAD
- OPTIONS

### 📍 Routing
- Nested routing for hierarchical entities.

### 🧹 Global Error Handling
- Custom middleware that captures and formats all exceptions.

### 🔄 Content Negotiation
- Supports JSON and XML responses based on request headers.

### 🛂 Validation
- Action filters validate incoming input models.

### 🧵 Asynchronous Operations
- All repository and service calls use async/await for scalability.

### 🔍 Filtering, Searching, Sorting, Paging
- Implemented using FromQuery and request feature classes.

### 🧩 Data Shaping
- Clients can request specific fields rather than full DTOs.

### 🏷️ API Versioning
- Allows controllers to support multiple API versions.

### 🧠 Caching
- Reduces overhead and improves performance for frequently used endpoints.

### 🚦 Rate Limiting
- Prevents large volumes of requests and protects the API.

### 🩺 Health Checks
- Simple health check endpoint included (API and database).

### 🔁 AutoMapper
- Used for DTO mapping across services and controllers.

### 🔐 Authentication & Authorization
- Uses IdentityDbContext.
- Custom user entity.
- Roles and claims.
- Login and registration endpoints.
- JWT-based authentication.

### 🖼️ File Uploads
- Player And Team images  saved locally.
- Only the path is stored in the database.

### 🧱 SOLID Principles & Patterns
- Dependency injection everywhere.
- Factory pattern for data shaping.
- Services and repositories cleanly separated.

---

## 📊 Database Tables & Seed Data

| Table Name       | Seeded | Notes                         
|------------------|--------|----------------------------------------------
| Users            | ✅ Yes | Includes default admin user    
| Cities           | ✅ Yes | Preloaded with sample cities   
| Countries        | ✅ Yes | Preloaded with sample countries
| MatchStatus      | ✅ Yes | Preloaded status options For the Match      
| Teams            | ❌ No  | Empty by default              
| Players          | ❌ No  | Empty by default              
| PlayerStatus     | ❌ No  | Empty by default              
| People           | ❌ No  | Empty by default              
| Matches          | ❌ No  | Empty by default              

---

## 🗂️ Database Versions

This project supports multiple databases using Entity Framework migrations.

### 💾 SQLite Version (Default)
- SQLite is included by default for quick and easy setup.

### 🏢 SQL Server Version
- Requires additional configuration:
  1. Ensure SQL Server is installed and running.
  2. Update the connection string in `appsettings.json`.
  3. Apply EF migrations to create the database schema.

## 🏃 How to Run (SQLite Default)

### 1. Install .NET SDK
Download from:  
https://dotnet.microsoft.com/download

### 2. Clone the project
```bash
git clone <your repo>
```

### 3. Navigate to the project folder
```bash
cd GoalHub
```
### 4. Configure Database

- SQLite (default): No extra setup required.

- SQL Server:

1. Ensure SQL Server is installed and running.
2. Update appsettings.json with your SQL Server connection string and Change Database to SqlServer:

```bash
"Database": {
  "Type": "SqlServer"
}

"ConnectionStrings": {
  "SQLDBConnection": "Your Connection Strings to Your Local Sql Server",
}
```
3. Apply migrations:

```bash
dotnet ef database update
```

### 4. Run the application
```bash
dotnet run
```

### 5. API Access & Port Details

- By default, the application runs on port **7128**, but this may change depending on your environment.  
- To check the actual port:  
  1. Look in `Properties/launchSettings.json` under `"applicationUrl"`.  
  2. Or observe the port in the console output when running:
  
  ```bash
  dotnet run
  ```

Access Swagger UI (recommended) using the detected port:

```bash
http://localhost:<PORT>/swagger
```

## Opening the Project in Visual Studio

If you are using **Visual Studio (the purple one)**, the project includes a `.sln` file located inside the **GoalHub.API** folder.  
You can open the entire project by double-clicking the solution file.

## 📁 Postman Collection

Included file:

- **GoalHub APIs.postman** to call APIs

Swagger UI is recommended for testing filtering, sorting, paging, and other features.

---

## 🔐 Authentication

Use these credentials to log in:

- **Username:** ManagerUser  
- **Password:** Password1000  

### ✔ Steps
1. Call the **Login** endpoint.  
2. Copy the generated JWT token.  
3. Add the token to Swagger Authorization or the Postman.  
4. Access protected endpoints.

> 📝 Note: The included Postman collection automates authentication using a pre-configured script, so you don’t need to manually retrieve or add the token.
---

## 🗨️ Feedback
- Found a mistake, bug, or have suggestions? Feel free to open an issue or submit a pull request.
- Got questions about the project? Don’t hesitate to ask!
