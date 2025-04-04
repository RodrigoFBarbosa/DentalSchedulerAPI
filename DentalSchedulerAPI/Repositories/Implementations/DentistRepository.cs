using DentalSchedulerAPI.Data;
using DentalSchedulerAPI.Models;
using DentalSchedulerAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DentalSchedulerAPI.Repositories.Implementations;

public class DentistRepository : Repository<Dentist>, IDentistRepository
{
    public DentistRepository(ApplicationDbContext? context) : base(context) { }
    public async Task<Dentist?> GetByCROAsync(string cro) => await _context.Dentists.FirstOrDefaultAsync(d => d.CRO == cro);
}
