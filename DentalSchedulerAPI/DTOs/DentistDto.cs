namespace DentalSchedulerAPI.DTOs;

public class DentistDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? CRO { get; set; }
    public string? Specialty { get; set; }
    public string? Phone { get; set; }
}
