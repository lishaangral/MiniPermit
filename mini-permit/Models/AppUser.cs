using System.ComponentModel.DataAnnotations;

namespace MiniPermit.Models
{
    public class Employee
    {
        [Key]
        public string EmployeeId { get; set; } = String.Empty;
        public string Username { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
    
    }
}