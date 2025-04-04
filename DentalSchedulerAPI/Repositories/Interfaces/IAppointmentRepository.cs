using DentalSchedulerAPI.Models;

namespace DentalSchedulerAPI.Repositories.Interfaces;

public interface IAppointmentRepository : IRepository<Appointment>
{
    Task<IEnumerable<Appointment>> GetAppointmentsByPatientAsync(Guid patientId);
    Task<IEnumerable<Appointment>> GetAppointmentsByDentistAsync(Guid dentistId);
}
