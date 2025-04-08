﻿namespace DentalSchedulerAPI.DTOs;

public class PatientDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? CPF { get; set; }
    public DateTime BirthDate { get; set; }
    public string? Phone { get; set; }
    public string? EmailAddress { get; set; }
    

}
