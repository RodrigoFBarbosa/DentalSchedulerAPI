using DentalSchedulerAPI.DTOs;

namespace DentalSchedulerAPI.Services.Interfaces;

public interface IDentistService
{
    Task<IEnumerable<DentistDto>> GetAllAsync();
    Task<DentistDto?> GetByIdAsync(Guid id);
    Task<DentistDto> CreateAsync(CreateDentistDto dto);
    Task<DentistDto?> UpdateAsync(Guid id, CreateDentistDto dto);
    Task<DentistDto?> DeleteAsync(Guid id);
}
