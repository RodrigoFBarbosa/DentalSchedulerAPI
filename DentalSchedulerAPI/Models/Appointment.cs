using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalSchedulerAPI.Models;

public class Appointment
{
    [Key]
    public Guid Id { get; set; } = new Guid();
    [Required]
    [ForeignKey("Patient")]
    public Guid PatientId { get; set; }
    public Patient? Patient { get; set; }
    [Required]
    [ForeignKey("Dentist")]
    public Guid DentistId { get; set; }
    public Dentist? Dentist { get; set; }
    [Required]
    public string? Status { get; set; } = "Agendado";
}
