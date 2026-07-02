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
    public class MemberService
    {
        private readonly ApplicationDbContext _context;
        public MemberService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddMember()
        {
            Console.Write("Full Name : ");
            string name = Console.ReadLine();
            Console.Write("Phone : ");
            string phone = Console.ReadLine();

            var member = new Member
            {
                FullName = name,
                Phone = phone,
            };
            _context.Members.Add(member);
            _context.SaveChanges();
            Console.WriteLine("Member Added");

        }

        public void GetAllMembers() { 
        var members= _context.Members.ToList();
            foreach (var member in members) {
                Console.WriteLine($"Id: {member.Id} - FullName : {member.FullName} - Phone : {member.Phone}");
            }
        
        }
        public void DeleteMember()
        {
            Console.Write("Member Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var member = _context.Members
                .Include(m => m.Loans)
                .FirstOrDefault(m => m.Id == id);

            if (member == null)
            {
                Console.WriteLine("Member Not Found");
                return;
            }

            bool hasActiveLoans = member.Loans.Any(l => l.ReturnDate == null);
            if (hasActiveLoans)
            {
                Console.WriteLine("Cannot delete member! This member currently has borrowed books that are not returned yet.");
                return;
            }

            _context.Members.Remove(member);
            _context.SaveChanges();
            Console.WriteLine("Member Deleted Successfully");
        }
    }
}
