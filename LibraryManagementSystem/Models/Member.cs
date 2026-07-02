using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        [Phone]
        public string? Phone {  get; set; }
        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}
