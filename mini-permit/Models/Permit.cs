namespace MiniPermit.Models;

public class Permit
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime IssuedOn { get; set; } = DateTime.Now;
}
