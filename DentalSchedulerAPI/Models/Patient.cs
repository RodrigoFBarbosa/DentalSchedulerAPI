using System.ComponentModel.DataAnnotations;

namespace DentalSchedulerAPI.Models;

public class Patient
{
    [Key]
    public Guid Id { get; set; } = new Guid();
    [Required]
    public string? Name { get; set; } 
    [Required]
    public string? CPF { get; set; }
    [Required]
    public DateTime BirthDate { get; set; }
    [Phone]
    public string? Phone { get; set; }
    [EmailAddress]
    public string? EmailAddress { get; set; }
}
