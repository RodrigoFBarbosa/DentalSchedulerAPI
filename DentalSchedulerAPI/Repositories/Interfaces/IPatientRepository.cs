using DentalSchedulerAPI.Models;

namespace DentalSchedulerAPI.Repositories.Interfaces;

public interface IPatientRepository : IRepository<Patient>
{
    Task<Patient?> GetByCPFAsync(string cpf);
}
