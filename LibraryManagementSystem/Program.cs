using LibraryManagementSystem.Data;
using LibraryManagementSystem.Services;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
namespace LibraryManagementSystem { 
    public class Program
    {

        static void Main(string[] args)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            BookService bookService = new BookService(context);

            AuthorService authorService = new AuthorService(context);

            CategoryService categoryService = new CategoryService(context);

            MemberService memberService = new MemberService(context);

            LoanService loanService=new LoanService(context);
            

            while (true)
            {
                Console.Clear();
                Console.WriteLine("============== Library System ============== ");

                Console.WriteLine("1 -> Books");
                Console.WriteLine("2 -> Authors");
                Console.WriteLine("3 -> Categories");
                Console.WriteLine("4 -> Members");
                Console.WriteLine("5 -> Loans");
                Console.WriteLine("0 -> Exit");
                
                Console.WriteLine("Choose:  ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("1- Add Book");
                        Console.WriteLine("2- Update Book");
                        Console.WriteLine("3- Delete Book");
                        Console.WriteLine("4- Show Books");
                        Console.WriteLine("5- Search");
                        int b = Convert.ToInt32(Console.ReadLine());
                        if (b == 1)
                            bookService.AddBook();
                        else if (b == 2)
                            bookService.UpdateBook();
                        else if (b == 3)
                            bookService.DeleteBook();
                         else if (b == 4)
                            bookService.GetAllBooks();
                        else if (b == 5)
                            bookService.SearchBook();
                        break;

                    case 2:
                        Console.WriteLine("1- Add Author");
                        Console.WriteLine("2- Show Authors");
                        int a = Convert.ToInt32(Console.ReadLine());
                        if (a == 1)
                            authorService.AddAuthor();
                        else if (a == 2)
                            authorService.GetAllAuthors();
                        break;

                    case 3:
                        Console.WriteLine("1- Add Category");
                        Console.WriteLine("2- Show Categories");
                        int c = Convert.ToInt32(Console.ReadLine());
                        if (c == 1)
                            categoryService.AddCategory();
                        else if (c == 2)
                            categoryService.GetAllCategories();
                        break;

                    case 4:
                        Console.WriteLine("1- Add Member");
                        Console.WriteLine("2- Show Members");
                        Console.WriteLine("3- Delete Member");
                        int m = Convert.ToInt32(Console.ReadLine());
                        if (m == 1)
                            memberService.AddMember();
                        else if (m == 2)
                            memberService.GetAllMembers();
                        else if (m == 3)
                            memberService.DeleteMember();
                        break;

                    case 5:
                        Console.WriteLine("1- Borrow Book");
                        Console.WriteLine("2- Return Book");
                        Console.WriteLine("3- Show Loans");
                        int l = Convert.ToInt32(Console.ReadLine());
                        if (l == 1)
                            loanService.BorrowBook();
                        else if (l == 2)
                            loanService.ReturnBook();
                        else if (l == 3)
                            loanService.GetAllLoans();
                        break;
                    case 0:
                        return;
                }

                Console.WriteLine();
                Console.WriteLine("Press Any Key....");
                Console.ReadKey();




            }
        }
    }


}





