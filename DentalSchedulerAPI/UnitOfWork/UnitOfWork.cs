using DentalSchedulerAPI.Data;
using DentalSchedulerAPI.Repositories.Implementations;
using DentalSchedulerAPI.Repositories.Interfaces;

namespace DentalSchedulerAPI.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        Patients = new PatientRepository(context);
        Dentists = new DentistRepository(context);
        Appointments = new AppointmentRepository(context);
    }
    public IPatientRepository Patients { get; }
    public IDentistRepository Dentists { get; }
    public IAppointmentRepository Appointments { get; }

    public async Task<int> CommitAsync() => await _context.SaveChangesAsync();
}
