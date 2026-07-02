# Library Management System (Console Application)

A structured .NET 9 backend application showcasing clean architecture principles using Entity Framework Core, LINQ, and SQL Server.

## 🌟 Key Features & Business Logic
- **Book Management:** Add, Update, Delete, Search, and filter books by Category.
- **Member Tracking:** Register new members and safely handle member deletion (checks for unreturned books first).
- **Loan Operations:** Borrow books (automatically reduces stock quantity) and handle book returns (restores stock quantity).
- **Database Architecture:** Structured relationships configured via Fluent API with initial data seeding for testing.

## 🛠️ Technologies
- **Language:** C# (.NET 9)
- **ORM:** Entity Framework Core 9 (Eager Loading with `.Include()`)
- **Database:** SQL Server
- **Data Querying:** LINQ

## ⚙️ How to Run Locally
1. Clone the project:
   ```bash
   git clone [https://github.com/Mai-Ali74/LibraryManagementSystem.git](https://github.com/Mai-Ali74/LibraryManagementSystem.git)
Update the connection string in ApplicationDbContext.cs to match your local SQL Server instance.

Run the migration command in Package Manager Console:

Bash
Update-Database
Run the application!
