using DentalSchedulerAPI.DTOs;
using DentalSchedulerAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DentalSchedulerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DentistController : ControllerBase
{
    private readonly IDentistService _dentistService;

    public DentistController(IDentistService dentistService)
    {
        _dentistService = dentistService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DentistDto>>> GetAll()
    {
        var dentists = await _dentistService.GetAllAsync();
        return Ok(dentists);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DentistDto>> GetById(Guid id)
    {
        var dentist = await _dentistService.GetByIdAsync(id);
        if (dentist is null) 
            return NotFound();

        return Ok(dentist);
    }

    [HttpPost]
    public async Task<ActionResult<DentistDto>> Create(CreateDentistDto dto)
    {
        var newDentist = await _dentistService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = newDentist.Id }, newDentist);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<DentistDto>> Update(Guid id, CreateDentistDto dto)
    {
        var updatedDentist = await _dentistService.UpdateAsync(id, dto);
        if (updatedDentist is null)
            return NotFound();

        return Ok(updatedDentist);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DentistDto>> Delete(Guid id)
    {
        var deletedDentist = await _dentistService.DeleteAsync(id);
        if (deletedDentist is null) 
            return NotFound();

        return Ok(deletedDentist);
    }
}
