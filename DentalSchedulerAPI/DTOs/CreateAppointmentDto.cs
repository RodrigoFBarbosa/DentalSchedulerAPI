using System.ComponentModel.DataAnnotations;

namespace DentalSchedulerAPI.DTOs;

public class CreateAppointmentDto
{
    [Required]
    public Guid PatientId { get; set; }
    [Required]
    public Guid DentistId { get; set; }
    [Required]
    public DateTime AppointmentDate { get; set; }
    public string Status { get; set; } = "Agendado";
}
