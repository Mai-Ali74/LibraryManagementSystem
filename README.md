# Library Management System (Console Application)

A console-based Library Management System built with C#, Entity Framework Core, and SQL Server. The project demonstrates Entity Framework Core features, layered architecture using the Service Pattern, and database design best practices.

## 📁 Project Structure & Architecture
The project follows a layered structure that separates data access, domain models, and business logic:
- **`Data/`**: Contains `ApplicationDbContext.cs` for EF Core configuration, including Fluent API relationships and automated Data Seeding.
- **`Models/`**: Contains pure domain entities (`Book`, `Author`, `Category`, `Member`, and `Loan`).
- **`Services/`**: Contains the business logic layer, separating operations into dedicated classes (`BookService`, `MemberService`, `CategoryService`, `AuthorService`, and `LoanService`) to keep `Program.cs` clean and maintainable.

## 🌟 Key Features & Business Logic Implemented

### 1. Loan & Borrowing Operations (`LoanService`)
- **Borrow Book:** Validates book existence, checks if stock quantity is available ($>0$), automatically creates a new loan record, and decreases the available book quantity.
- **Return Book:** Tracks existing loans via Eager Loading (`.Include()`), updates the return timestamp, and automatically increases the available book quantity back into the system.

### 2. Secure Member Management (`MemberService`)
- Handles member registration and directory listings.
- **Data Integrity Protection:** Implements a strict deletion rule—prevents removing any member who currently has active, unreturned books to protect library assets.

### 3. Book, Category, and Author Directories
- Complete CRUD and search functionalities across `BookService`, `CategoryService`, and `AuthorService`.
- Filter and load books dynamically based on their categories.

## 💾 Database Configuration & Advanced EF Core Features
- **Database Migrations:** Used EF Core migrations to create and update the database schema.
- **Fluent API Relationships:** Configured robust one-to-many relationships (e.g., Category-to-Books, Author-to-Books, Member-to-Loans) using Fluent API instead of relying solely on default conventions.
- **Automated Data Seeding:** Embedded default testing data directly into the database migration process for instant testing upon deployment.
- **Eager Loading:** Optimized database queries using `.Include()` to prevent performance bottlenecks (like N+1 query problems) when fetching related entities.

## 🛠️ Technologies Used
- **Language:** C# (.NET 9)
- **ORM:** Entity Framework Core 9
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
