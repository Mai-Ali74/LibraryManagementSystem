using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Services
{
    public class AuthorService
    {
        private readonly ApplicationDbContext _context;
        public AuthorService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddAuthor()
        {
            Console.Write("Author Name: ");
            string name=Console.ReadLine();
            Console.Write("Country: ");
            string country = Console.ReadLine();
            var author = new Author
            {
                Name=name,
                Country=country
            };
            _context.Authors.Add(author);
            _context.SaveChanges();
            Console.WriteLine("Author Added Successfully");

        }
        public void GetAllAuthors() {
            var authors = _context.Authors.ToList();
            foreach (var author in authors) {
                Console.WriteLine($"Id: {author.Id} - Name: {author.Name} - Countery: {author.Country}");
            }
        
        }
    }
}
