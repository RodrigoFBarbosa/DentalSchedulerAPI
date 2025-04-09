using System.ComponentModel.DataAnnotations;
using DentalSchedulerAPI.ValidationAttributes;

namespace DentalSchedulerAPI.DTOs;

public class CreateAppointmentDto
{
    [Required]
    public Guid PatientId { get; set; }
    [Required]
    public Guid DentistId { get; set; }
    [Required]
    [FutureDate(ErrorMessage = "A data do agendamento deve ser no futuro.")]
    public DateTime AppointmentDate { get; set; }
    public string Status { get; set; } = "Agendado";
}
