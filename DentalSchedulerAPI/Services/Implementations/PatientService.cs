﻿using AutoMapper;
using DentalSchedulerAPI.DTOs;
using DentalSchedulerAPI.Models;
using DentalSchedulerAPI.Services.Interfaces;
using DentalSchedulerAPI.UnitOfWork;

namespace DentalSchedulerAPI.Services.Implementations;

public class PatientService : IPatientService
{
    private readonly IUnitOfWork? _unitOfWork;
    private readonly IMapper? _mapper;

    public PatientService(IUnitOfWork? unitOfWork, IMapper? mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PatientDto> CreateAsync(CreatePatientDto dto)
    {
        var patient = _mapper.Map<Patient>(dto);
        await _unitOfWork.Patients.AddAsync(patient);
        await _unitOfWork.CommitAsync();
        return _mapper.Map<PatientDto>(patient);
    }

    public async Task<PatientDto?> DeleteAsync(Guid id)
    {
        var patient = await _unitOfWork.Patients.GetByIdAsync(id);
        if (patient == null) return null;

        _unitOfWork.Patients.Remove(patient);
        await _unitOfWork.CommitAsync();

        return _mapper.Map<PatientDto>(patient);
    }

    public async Task<IEnumerable<PatientDto>> GetAllAsync()
    {
        var patients = await _unitOfWork.Patients.GetAllAsync();
        return _mapper.Map<IEnumerable<PatientDto>>(patients);
    }

    public async Task<PatientDto?> GetByIdAsync(Guid id)
    {
        var patient = await _unitOfWork.Patients.GetByIdAsync(id);
        return patient == null ? null : _mapper.Map<PatientDto>(patient);
    }

    public async Task<PatientDto?> UpdateAsync(Guid id, CreatePatientDto dto)
    {
        var patient = await _unitOfWork.Patients.GetByIdAsync(id);
        if (patient == null) return null;

        _mapper.Map(dto, patient);
        _unitOfWork.Patients.Update(patient);
        await _unitOfWork.CommitAsync();

        return _mapper.Map<PatientDto>(patient);
    }
}
