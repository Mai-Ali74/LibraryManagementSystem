using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Member> Members { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server =MAI; Database = LibraryDb; Trusted_Connection = True; TrustServerCertificate = True; ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);


           
            modelBuilder.Entity<Book>()
                .HasOne(b=>b.Category)
                .WithMany(c=>c.Books)
                .HasForeignKey(b=>b.CategoryId);

            
            modelBuilder.Entity<Loan>()
                .HasOne(l=>l.Member)
                .WithMany(m=>m.Loans)
                .HasForeignKey(l=>l.MemberId);

            
            modelBuilder.Entity<Loan>()
                .HasOne(l=>l.Book)
                .WithMany(b=>b.Loans)
                .HasForeignKey(l=>l.BookId);

            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id = 1,
                    Name = "Ahmed Khaled Tawfik",
                    Country = "Egypt"
                },
                 new Author
                 {
                     Id=2,
                     Name = "Naguib Mahfouz",
                     Country = "Egypt"
                 }


                );


            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id=1,
                    Name = "Novel"
                },

                 new Category
                 {
                     Id=2,
                     Name = "Science"
                 }


                );

            modelBuilder.Entity<Book>().HasData(

                new Book
                {
                    Id = 1,
                    Title = "Utopia",
                    PublishYear = 1999,
                    Quantity = 10,
                    AuthorId = 1,
                    CategoryId = 1

                },
                 new Book
                 {
                     Id = 2,
                     Title = "Utopia",
                     PublishYear = 2000,
                     Quantity = 20,
                     AuthorId = 2,
                     CategoryId = 1

                 }
                );

            modelBuilder.Entity<Member>().HasData(

                new Member
                {
                    Id= 1,
                    FullName = "Mohammed Ali",
                    Phone = "01234567810"
                },

                 new Member
                 {   
                     Id = 2,
                     FullName = "Sara Ahmed",
                     Phone = "01056478931"
                 }
                 );




        }

    }
}
