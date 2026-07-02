# 📚 Library Management System

A **C# console application** for managing a library's books, authors, categories, members, and loans — built with **Entity Framework Core** and **SQL Server** using a Code-First approach.

## ✨ Features

**Books**
- Add, update, delete, and list all books
- Search books by title
- List available books (quantity > 0)
- Filter books by category

**Authors**
- Add a new author
- List all authors

**Categories**
- Add a new category
- List all categories

**Members**
- Add a new member
- List all members
- Delete a member (blocked automatically if the member has unreturned books)

**Loans**
- Borrow a book (decreases available quantity, fails if the book is unavailable)
- Return a book (increases available quantity, prevents double-return)
- List all loans (with return status)
- List currently active (not yet returned) loans

## 🛠️ Built With

- **C#**
- **.NET**
- **Entity Framework Core** (Code-First + Migrations)
- **SQL Server**

## 🗂️ Data Model

| Entity | Description | Relationships |
|---|---|---|
| `Book` | Title, publish year, quantity | Belongs to one `Author` and one `Category`; has many `Loan`s |
| `Author` | Name, country | Has many `Book`s |
| `Category` | Name | Has many `Book`s |
| `Member` | Full name, phone | Has many `Loan`s |
| `Loan` | Loan date, return date | Belongs to one `Book` and one `Member` |

The database is seeded on migration with sample authors, categories, books, and members for quick testing.

## 📂 Project Structure
LibraryManagementSystem/
├── LibraryManagementSystem.sln
├── Program.cs                  # Console menu & entry point
├── Data/
│   └── ApplicationDbContext.cs # EF Core DbContext, relationships, seed data
├── Models/
│   ├── Author.cs
│   ├── Book.cs
│   ├── Category.cs
│   ├── Loan.cs
│   └── Member.cs
└── Services/
├── BookService.cs
├── AuthorService.cs
├── CategoryService.cs
├── MemberService.cs
└── LoanService.cs

## 🚀 Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- SQL Server (LocalDB, Express, or full instance)
- Visual Studio (recommended) or the `dotnet-ef` CLI tool

### Setup

1. Clone the repository
```bash
   git clone https://github.com/Mai-Ali74/LibraryManagementSystem.git
```

2. Update the connection string in `Data/ApplicationDbContext.cs` to match your own SQL Server instance:
```csharp
   options.UseSqlServer("Server=YOUR_SERVER; Database=LibraryDb; Trusted_Connection=True; TrustServerCertificate=True;");
```

3. Apply migrations to create the database (from the Package Manager Console or CLI):
```bash
   dotnet ef database update
```

4. Run the project:
```bash
   dotnet run
```

## 📖 Usage

Once running, the app shows a menu in the console:
============== Library System ==============
1 -> Books
2 -> Authors
3 -> Categories
4 -> Members
5 -> Loans
0 -> Exit

Pick a number to enter a section, then choose the operation you want (add / update / delete / list / search, depending on the section) and follow the prompts.

## 👤 Author

**Mai Ali**
- GitHub: [@Mai-Ali74](https://github.com/Mai-Ali74)
