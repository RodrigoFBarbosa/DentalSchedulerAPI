using DentalSchedulerAPI.Repositories.Interfaces;

namespace DentalSchedulerAPI.UnitOfWork;

public interface IUnitOfWork
{
    IPatientRepository Patients { get; }
    IDentistRepository Dentists { get; }
    IAppointmentRepository Appointments { get; }
    Task<int> CommitAsync();
}
