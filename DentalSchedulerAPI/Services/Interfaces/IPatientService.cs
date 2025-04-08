using DentalSchedulerAPI.DTOs;

namespace DentalSchedulerAPI.Services.Interfaces;

public interface IPatientService
{
    Task<IEnumerable<PatientDto>> GetAllAsync();
    Task<PatientDto?> GetByIdAsync(Guid id);
    Task<PatientDto> CreateAsync(CreatePatientDto dto);
    Task<PatientDto?> UpdateAsync(Guid id, CreatePatientDto dto);
    Task<PatientDto?> DeleteAsync(Guid id);
}
