using AutoMapper;
using DentalSchedulerAPI.DTOs;
using DentalSchedulerAPI.Models;
using DentalSchedulerAPI.Services.Interfaces;
using DentalSchedulerAPI.UnitOfWork;

namespace DentalSchedulerAPI.Services.Implementations;

public class AppointmentService : IAppointmentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AppointmentService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<AppointmentDto> CreateAsync(CreateAppointmentDto dto)
    {
        dto.AppointmentDate = dto.AppointmentDate
        .ToUniversalTime()
        .AddTicks(-(dto.AppointmentDate.Ticks % TimeSpan.TicksPerMinute));

        var existingAppointment = await _unitOfWork.Appointments
        .FindAsync(a => a.DentistId == dto.DentistId && a.AppointmentDate == dto.AppointmentDate);

        if (existingAppointment.Any())
            return null;

        var appointment = _mapper.Map<Appointment>(dto);
        await _unitOfWork.Appointments.AddAsync(appointment);
        await _unitOfWork.CommitAsync();

        var result = _mapper.Map<AppointmentDto>(appointment);
        result.PatientName = (await _unitOfWork.Patients.GetByIdAsync(dto.PatientId))?.Name;
        result.DentistName = (await _unitOfWork.Dentists.GetByIdAsync(dto.DentistId))?.Name;

        return result;
    }

    public async Task<AppointmentDto?> DeleteAsync(Guid id)
    {
        var appointment = await _unitOfWork.Appointments.GetByIdAsync(id);
        if (appointment == null)
            return null;

        _unitOfWork.Appointments.Remove(appointment);
        await _unitOfWork.CommitAsync();

        var dto = _mapper.Map<AppointmentDto>(appointment);
        dto.PatientName = (await _unitOfWork.Patients.GetByIdAsync(dto.PatientId))?.Name;
        dto.DentistName = (await _unitOfWork.Dentists.GetByIdAsync(dto.DentistId))?.Name;

        return dto;
    }

    public async Task<List<AppointmentDto>> GetAllAsync()
    {
        var appointments = await _unitOfWork.Appointments.GetAllAsync();
        var dtoList = _mapper.Map<List<AppointmentDto>>(appointments);

        foreach (var dto in dtoList)
        {
            dto.PatientName = (await _unitOfWork.Patients.GetByIdAsync(dto.PatientId))?.Name;
            dto.DentistName = (await _unitOfWork.Dentists.GetByIdAsync(dto.DentistId))?.Name;
        }

        return dtoList;
    }

    public async Task<AppointmentDto?> GetByIdAsync(Guid id)
    {
        var appointment = await _unitOfWork.Appointments.GetByIdAsync(id);
        if (appointment == null)
            return null;

        var dto = _mapper.Map<AppointmentDto>(appointment);
        dto.PatientName = (await _unitOfWork.Patients.GetByIdAsync(dto.PatientId))?.Name;
        dto.DentistName = (await _unitOfWork.Dentists.GetByIdAsync(dto.DentistId))?.Name;

        return dto;
    }

    public async Task<AppointmentDto?> UpdateAsync(Guid id, CreateAppointmentDto dto)
    {
        var appointment = await _unitOfWork.Appointments.GetByIdAsync(id);
        if (appointment == null)
            return null;

        appointment.PatientId = dto.PatientId;
        appointment.DentistId = dto.DentistId;
        appointment.Status = dto.Status;

        await _unitOfWork.CommitAsync();

        var result = _mapper.Map<AppointmentDto>(appointment);
        result.PatientName = (await _unitOfWork.Patients.GetByIdAsync(dto.PatientId))?.Name;
        result.DentistName = (await _unitOfWork.Dentists.GetByIdAsync(dto.DentistId))?.Name;

        return result;
    }
}
