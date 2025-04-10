namespace DentalSchedulerAPI.Validators;

using DentalSchedulerAPI.DTOs;
using FluentValidation;

public class CreateAppointmentDtoValidator : AbstractValidator<CreateAppointmentDto>
{
    public CreateAppointmentDtoValidator() 
    {
        RuleFor(x => x.PatientId)
            .NotEmpty().WithMessage("O paciente é obrigatório.");

        RuleFor(x => x.DentistId)
            .NotEmpty().WithMessage("O dentista é obrigatório.");

        RuleFor(x => x.AppointmentDate)
            .Must(BeInTheFuture)
            .WithMessage("A data do agendamento deve ser no futuro.");
    }

    private bool BeInTheFuture(DateTime date)
    {
        return date > DateTime.UtcNow;
    }
}
