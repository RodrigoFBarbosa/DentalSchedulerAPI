using System.ComponentModel.DataAnnotations;

namespace DentalSchedulerAPI.DTOs;

public class CreateDentistDto
{
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? CRO { get; set; }
    [Required]
    public string? Specialty { get; set; }
    [Required]
    public string? Phone { get; set; }
}
