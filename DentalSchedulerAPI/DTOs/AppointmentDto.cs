namespace DentalSchedulerAPI.DTOs;

public class AppointmentDto
{
    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public string? PatientName { get; set; }
    public Guid DentistId { get; set; }
    public string? DentistName { get; set; }
    public DateTime AppointmentDate { get; set; }
    public string Status { get; set; } = "Agendado";
}
