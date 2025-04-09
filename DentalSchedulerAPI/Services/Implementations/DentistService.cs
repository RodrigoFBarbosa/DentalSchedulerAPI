using AutoMapper;
using DentalSchedulerAPI.DTOs;
using DentalSchedulerAPI.Models;
using DentalSchedulerAPI.Services.Interfaces;
using DentalSchedulerAPI.UnitOfWork;

namespace DentalSchedulerAPI.Services.Implementations;

public class DentistService : IDentistService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DentistService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<DentistDto> CreateAsync(CreateDentistDto dto)
    {
        var dentist =  _mapper.Map<Dentist>(dto);
        await _unitOfWork.Dentists.AddAsync(dentist);
        await _unitOfWork.CommitAsync();
        return _mapper.Map<DentistDto>(dentist);
    }

    public async Task<DentistDto?> DeleteAsync(Guid id)
    {
        var existing = await _unitOfWork.Dentists.GetByIdAsync(id);
        if (existing is null)
            return null;

        _unitOfWork.Dentists.Remove(existing);
        await _unitOfWork.CommitAsync();

        return _mapper.Map<DentistDto>(existing);
        
    }

    public async Task<IEnumerable<DentistDto>> GetAllAsync()
    {
        var dentists = await _unitOfWork.Dentists.GetAllAsync();
        return _mapper.Map<IEnumerable<DentistDto>>(dentists);
    }

    public async Task<DentistDto?> GetByIdAsync(Guid id)
    {
        var dentist = await _unitOfWork.Dentists.GetByIdAsync(id);
        return dentist == null ? null : _mapper.Map<DentistDto?>(dentist);
    }

    public async Task<DentistDto?> UpdateAsync(Guid id, CreateDentistDto dto)
    {
        var dentist = await _unitOfWork.Dentists.GetByIdAsync(id);
        if (dentist == null) return null;

        _mapper.Map(dto, dentist);
        _unitOfWork.Dentists.Update(dentist);
        await _unitOfWork.CommitAsync();

        return _mapper.Map<DentistDto>(dentist);
    }
}
