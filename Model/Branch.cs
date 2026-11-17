using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace NationalBank.Model
{
    public class Branch
    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public ICollection<Account> Accounts { get; set; } = new List<Account>();
        public int ManagerId { get; set; } 
        public Manager Manager { get; set; } = null!;
    }
}