using DentalSchedulerAPI.Models;

namespace DentalSchedulerAPI.Repositories.Interfaces;

public interface IDentistRepository : IRepository<Dentist>
{
    Task<Dentist> GetByCROAsync(string cro);
}
