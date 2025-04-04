using DentalSchedulerAPI.Data;
using DentalSchedulerAPI.Models;
using DentalSchedulerAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DentalSchedulerAPI.Repositories.Implementations;

public class PatientRepository : Repository<Patient>, IPatientRepository
{
    public PatientRepository(ApplicationDbContext context) : base(context) { }
    public async Task<Patient?> GetByCPFAsync(string cpf) => await _context.Patients.FirstOrDefaultAsync(p => p.CPF == cpf);
    
}
