# Library Management System (LMS)

A robust console-based **Library Management System** built using **C#**, **.NET**, and **Entity Framework Core (EF Core)** with **SQL Server**. The project follows a clean service-oriented architecture to handle data operations cleanly and safely through an interactive CLI menu.

---

## 🚀 Features

### 📚 Book Management
* **Add Book:** Add new titles with specific release years and starting stock quantities.
* **Update / Delete Book:** Full CRUD capabilities for updating or removing book listings.
* **Search Book:** Quick search functions to find titles instantly.

### 👤 Author Management
* **Add Author:** Prompt inputs for Author Name and Country.
* **List Authors:** View all registered authors with their system IDs and countries.

### 📁 Category Management
* **Add Category:** Organize books by custom categories (e.g., Novel, Science).
* **List Categories:** Display all available genres/categories.

### 👥 Member Management
* **Register Member:** Track library members using their full names and phone numbers.
* **Safe Delete:** Members **cannot** be deleted if they currently hold active, unreturned book loans, preventing data discrepancy.

### 💳 Loan & Borrowing System
* **Borrow Book:** Allows members to borrow books. Automatically checks if the book exists and if it is currently in stock (`Quantity > 0`). Decreases stock by 1 upon success.
* **Return Book:** Updates loan status with the return timestamp and replenishes book stock by 1. Prevents double-returning.
* **View All Loans:** Displays comprehensive historical records of all loans (Book, Member, Borrow Date, and Return status).

---

## 💻 Console Interface Guide

When you run the application, you will be greeted with an interactive console menu:

```text
============== Library System ============== 
1 -> Books
2 -> Authors
3 -> Categories
4 -> Members
5 -> Loans
0 -> Exit
Choose: 
🛠️ Tech Stack & Prerequisites
Language: C# (.NET Core)

ORM: Entity Framework Core (EF Core)

Database: Microsoft SQL Server

Dependencies:

Microsoft.EntityFrameworkCore

Microsoft.EntityFrameworkCore.SqlServer

Microsoft.EntityFrameworkCore.Design

🔧 Database Setup & Migration
Update Connection String: Open Data/ApplicationDbContext.cs and ensure the connection string matches your local SQL Server instance:

C#
options.UseSqlServer("Server=MAI; Database=LibraryDb; Trusted_Connection=True; TrustServerCertificate=True;");
Apply Migrations:
Open the Package Manager Console in Visual Studio and run the following commands to initialize the database and seed records:

Bash
Add-Migration InitialCreate
Update-Database
📁 Project Structure
Plaintext
LibraryManagementSystem/
│
├── Data/
│   └── ApplicationDbContext.cs    # EF Core DB Context & Data Seeding
│
├── Models/                        # Entity Models (Database Tables)
│   ├── Author.cs
│   ├── Book.cs
│   ├── Category.cs
│   ├── Loan.cs
│   └── Member.cs
│
├── Services/                      # Business Logic & Console Handlers
│   ├── AuthorService.cs
│   ├── BookService.cs
│   ├── CategoryService.cs
│   ├── LoanService.cs
│   └── MemberService.cs
│
└── Program.cs                     # Application Entry Point & Core UI Switch
