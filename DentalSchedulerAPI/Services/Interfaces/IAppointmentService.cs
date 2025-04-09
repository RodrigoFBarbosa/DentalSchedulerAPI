using DentalSchedulerAPI.DTOs;

namespace DentalSchedulerAPI.Services.Interfaces;

public interface IAppointmentService
{
    Task<List<AppointmentDto>> GetAllAsync();
    Task<AppointmentDto?> GetByIdAsync(Guid id);
    Task<AppointmentDto> CreateAsync(CreateAppointmentDto dto);
    Task<AppointmentDto?> UpdateAsync(Guid id, CreateAppointmentDto dto);
    Task<AppointmentDto?> DeleteAsync(Guid id);
}
