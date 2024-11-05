using System.ComponentModel.DataAnnotations;

namespace testAPI.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public required string Name { get; set; } 
        public required string Role { get; set; } 
        public required string Email { get; set; } 
        public required string Gender { get; set; }
        public required string DOB { get; set; } 
        public required string Address { get; set; } 
        public required string PhoneNo { get; set; } 
    }
}
