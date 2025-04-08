using System.ComponentModel.DataAnnotations;

namespace DentalSchedulerAPI.DTOs;

public class CreatePatientDto
{
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
