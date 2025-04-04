using System.ComponentModel.DataAnnotations;

namespace DentalSchedulerAPI.Models;

public class Dentist
{
    [Key]
    public Guid Id { get; set; } = new Guid();
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? CRO { get; set; }
    [Required]
    public string? Specialty { get; set; }
    [Required]
    public string? Phone { get; set; }
}
