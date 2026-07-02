# Library Management System (Console Application)

A console-based Library Management System built with C#, Entity Framework Core, and SQL Server. The project demonstrates Entity Framework Core features, layered architecture using the Service Pattern, and database design best practices.

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

1. **Clone the project:**
   ```bash
   git clone [https://github.com/Mai-Ali74/LibraryManagementSystem.git](https://github.com/Mai-Ali74/LibraryManagementSystem.git)
Update Connection String:
Update the connection string in ApplicationDbContext.cs to match your local SQL Server instance.

Apply Database Migrations:
Run the following command in the Package Manager Console inside Visual Studio:

PowerShell
Update-Database
Run the application! 🚀
