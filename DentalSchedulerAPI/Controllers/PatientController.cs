using DentalSchedulerAPI.DTOs;
using DentalSchedulerAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DentalSchedulerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController : ControllerBase
{
    private readonly IPatientService _patientService;

    public PatientController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PatientDto>>> GetAll()
    {
        var patients = await _patientService.GetAllAsync();
        return Ok(patients);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PatientDto>> GetById(Guid id)
    {
        var patient = await _patientService.GetByIdAsync(id);
        if (patient == null)
            return NotFound();

        return Ok(patient);
    }

    [HttpPost]
    public async Task<ActionResult> Create(CreatePatientDto dto)
    {
        var newPatient = await _patientService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = newPatient.Id }, newPatient);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(Guid id, CreatePatientDto dto)
    {
        var updatedPatient = await _patientService.UpdateAsync(id, dto);
        if (updatedPatient == null)
            return NotFound();

        return Ok(updatedPatient);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var deletedPatient = await _patientService.DeleteAsync(id);
        if (deletedPatient == null)
            return NotFound();

        return Ok(deletedPatient);
    }
}
