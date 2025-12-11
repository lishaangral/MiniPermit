using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniPermit.Models;

public class Permit
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime IssuedOn { get; set; } = DateTime.Now;

    [ForeignKey("Employee")]
    public string EmployeeId { get; set; } = string.Empty;

    // Need of Navigation as we need to load the User Attributes from Permit
    public Employee Employee { get; set; } = null!;
}
