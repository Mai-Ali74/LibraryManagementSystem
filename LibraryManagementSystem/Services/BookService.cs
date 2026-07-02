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
    public class BookService
    {
        public readonly ApplicationDbContext _Context;
        public BookService (ApplicationDbContext context)
        {
            _Context = context;
        }



        //Add Function
        public void AddBook()
        {
            Book book = new Book();
            Console.Write("Title : ");
            book.Title = Console.ReadLine();
            Console.Write("Publish Year : ");
            book.PublishYear = Convert.ToInt32(Console.ReadLine());
            Console.Write("Quantity : ");
            book.Quantity = Convert.ToInt32(Console.ReadLine());
            Console.Write("Author Id : ");
            book.AuthorId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Category Id : ");
            book.CategoryId = Convert.ToInt32(Console.ReadLine());
            _Context.Books.Add(book);
            _Context.SaveChanges();
            Console.WriteLine("Book Added Successfully");
        }

       
        public void GetAllBooks()
        {
            var books =_Context.Books
                .Include(b=>b.Author)
                .Include(b=>b.Category)
                .ToList();

            foreach(var book in books)
            {
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine($"Id : { book.Id}");
                Console.WriteLine($"Title : { book.Title}");
                Console.WriteLine($"Author : { book.Author.Name}");
                Console.WriteLine($"Category : { book.Category.Name}");
                Console.WriteLine($"Year : { book.PublishYear}");
                Console.WriteLine($"Quantity : { book.Quantity}");
            }

        }


      

        public void DeleteBook()
        {
            Console.Write("Book Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var book = _Context.Books.Find(id);
            if (book == null)
            {
                Console.WriteLine("Book Not Found");
                return;
            }
            _Context.Books.Remove(book);
            _Context.SaveChanges();
            Console.WriteLine("Book Deleted Successfully");
        }


        

        public void UpdateBook()
        {
            Console.WriteLine("Book Id : ");
            int id = Convert.ToInt32(Console.ReadLine());
            var book = _Context.Books.Find(id);
            if (book == null)
            {
                Console.WriteLine("Book Not found");
                return;
            }
            Console.Write("New Title : ");
            book.Title = Console.ReadLine();
            Console.Write("New Quantity : ");
            book.Quantity = Convert.ToInt32(Console.ReadLine());
            _Context.SaveChanges();
            Console.WriteLine("Book Updated Successfully");
        }


       

        public void SearchBook()
        {

            Console.Write("Book Name : ");
            string title =Console.ReadLine();
            var books = _Context.Books
                .Where(b=>b.Title.Contains(title))
                .Include(b => b.Author)
                .Include(b => b.Category)
                .ToList();
            foreach(var book in books)
            {
                Console.WriteLine($"Book Title : {book.Title}  - Author :  {book.Author.Name}   -  Category :  {book.Category.Name}");
            }

        }
        public void GetAvailableBooks()
        {
            var books = _Context.Books
                .Where(b => b.Quantity > 0)
                .Include(b => b.Author)
                .Include(b => b.Category)
                .ToList();

            foreach (var book in books)
            {
                Console.WriteLine($"Id : {book.Id} - Title : {book.Title} - Author  : {book.Author.Name} - Qty : {book.Quantity}");
            }
        }


        public void GetBooksByCategory()
        {
            Console.Write("Category Id : ");
            int categoryId=Convert.ToInt32(Console.ReadLine()) ;
            var books = _Context.Books
                .Where(b => b.CategoryId == categoryId)
                .Include(b => b.Author)
                .Include(b => b.Category)
                .ToList();

            foreach( var book in books)
            {
                Console.WriteLine($"Category Name : {book.Category.Name} - Book Title : {book.Title}");
            }
        }
        
        

        }
    }
