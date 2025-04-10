using DentalSchedulerAPI.DTOs;
using DentalSchedulerAPI.Services.Implementations;
using DentalSchedulerAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DentalSchedulerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppointmentController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;

    public AppointmentController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    [HttpGet]
    public async Task<ActionResult<List<AppointmentDto>>> GetAllAsync()
    {
        var appointments = await _appointmentService.GetAllAsync();
        return Ok(appointments);
    }

    [HttpGet("{id}", Name = "GetAppointmentById")]
    public async Task<ActionResult<AppointmentDto>> GetByIdAsync(Guid id)
    {
        var appointment = await _appointmentService.GetByIdAsync(id);
        if (appointment == null)
            return NotFound();

        return Ok(appointment);
    }

    [HttpPost]
    public async Task<ActionResult<AppointmentDto>> CreateAsync(CreateAppointmentDto dto)
    {
        var createdAppointment = await _appointmentService.CreateAsync(dto);

        return CreatedAtRoute(
            routeName: "GetAppointmentById",
            routeValues: new { id = createdAppointment.Id },
            value: createdAppointment
);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<AppointmentDto>> UpdateAsync(Guid id, [FromBody] CreateAppointmentDto dto)
    {
        var updatedAppointment = await _appointmentService.UpdateAsync(id, dto);
        if (updatedAppointment == null)
            return NotFound();

        return Ok(updatedAppointment);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<AppointmentDto>> DeleteAsync(Guid id)
    {
        var deletedAppointment = await _appointmentService.DeleteAsync(id);
        if (deletedAppointment == null)
            return NotFound();

        return Ok(deletedAppointment);
    }
}
