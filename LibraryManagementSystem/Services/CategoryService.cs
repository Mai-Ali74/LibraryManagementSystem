using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Services
{
    public class CategoryService
    {
        private readonly ApplicationDbContext _context;
        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddCategory()
        {
            Console.Write("Category Name : ");
            string name = Console.ReadLine();
            var category = new Category
            {
                Name = name
            };
            _context.Categories.Add(category);
            _context.SaveChanges();
            Console.WriteLine("Category Added");
        }
        public void GetAllCategories() { 
         var categories = _context.Categories.ToList();
            foreach (var category in categories) {
                Console.WriteLine($"Id: {category.Id} - Category Name: {category.Name}");
            }
        
        }
    }
}
