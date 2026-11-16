using System.ComponentModel.DataAnnotations;

namespace NationalBank.Models
{
    public class Branch
    {
        public string Code { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;
    }
}