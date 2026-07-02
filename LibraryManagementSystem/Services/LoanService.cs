using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Services
{
    public class LoanService
    {
        private readonly ApplicationDbContext _context;
        public LoanService (ApplicationDbContext context)
        {
            _context = context;
        }

        public void BorrowBook()
        {
            Console.Write("Member Id: ");
            int memberId=Convert.ToInt32(Console.ReadLine());

            Console.Write("Book Id: ");
            int bookId = Convert.ToInt32(Console.ReadLine());

            var book =_context.Books.Find(bookId);

            if (book == null)
            {
                Console.WriteLine("Book Not Found");
                return;
            }

                if (book.Quantity <= 0) {
                Console.WriteLine("Book Not Available");
                return;
            }

            var loan = new Loan
            {
                MemberId = memberId,
                BookId = bookId,
                LoanDate = DateTime.Now

            };

            book.Quantity--;
            _context.Loans.Add(loan);
            _context.SaveChanges();
            Console.WriteLine("Book Borrowed Successfully");
        }

        public void ReturnBook()
        {
            Console.Write("Loan Id: ");
            int loanId=Convert.ToInt32(Console.ReadLine());

            var loan=_context.Loans
                .Include(l=>l.Book)
                .FirstOrDefault(l=>l.Id == loanId);

            if(loan == null) {
                Console.WriteLine("Loan Not Found");
                return;
            }
            if (loan.ReturnDate != null)
            {
                Console.WriteLine("Loan already returned");
                return;
            }
            loan.ReturnDate = DateTime.Now;
            loan.Book.Quantity++;
            _context.SaveChanges();
            Console.WriteLine("Book returned successfully.");
        }

        public void GetAllLoans()
        {
            var loans=_context.Loans
                .Include(l=>l.Book)
                .Include(l=>l.Member)
                .ToList();

            foreach(var loan in loans)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine($"Loan Id: {loan.Id}");
                Console.WriteLine($"Book Title: {loan.Book.Title}");
                Console.WriteLine($"Member Name: {loan.Member.FullName}");
                Console.WriteLine($"Loan Id: {loan.Id}");
                Console.WriteLine($"Loan Date: {loan.LoanDate}");
                Console.WriteLine($"Return Date: {(loan.ReturnDate == null ? "Not returned" :loan.ReturnDate.ToString())}");
                
            }
        }
        public void GetActiveLoans()
        {
            var loans= _context.Loans
                .Where(l=>l.ReturnDate==null)
                .Include(l=>l.Book)
                .Include(l=>l.Member)
                .ToList();

            foreach (var loan in loans)
                Console.WriteLine($"{loan.Book.Title} borrowed by {loan.Member.FullName}");
        }
    }
}
