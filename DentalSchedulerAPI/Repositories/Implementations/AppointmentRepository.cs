using DentalSchedulerAPI.Data;
using DentalSchedulerAPI.Models;
using DentalSchedulerAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DentalSchedulerAPI.Repositories.Implementations;

public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
{
    public AppointmentRepository(ApplicationDbContext context) : base(context) { }
    public async Task<IEnumerable<Appointment>> GetAppointmentsByDentistAsync(Guid dentistId) => await _context.Appointments.Where(a => a.DentistId == dentistId).ToListAsync();

    public async Task<IEnumerable<Appointment>> GetAppointmentsByPatientAsync(Guid patientId) => await _context.Appointments.Where(a => a.PatientId == patientId).ToListAsync();
    
}
