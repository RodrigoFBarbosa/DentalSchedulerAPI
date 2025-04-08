using AutoMapper;
using DentalSchedulerAPI.DTOs;
using DentalSchedulerAPI.Models;

namespace DentalSchedulerAPI.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Patient
        CreateMap<Patient, PatientDto>();
        CreateMap<CreatePatientDto, Patient>();
        CreateMap<CreatePatientDto, Patient>().ReverseMap();

        //Dentist
        CreateMap<Dentist, DentistDto>();
        CreateMap<CreateDentistDto, Dentist>();
        CreateMap<CreateDentistDto, Dentist>().ReverseMap();

        // Appointment
        CreateMap<Appointment, AppointmentDto>()
            .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient!.Name))
            .ForMember(dest => dest.DentistName, opt => opt.MapFrom(src => src.Dentist!.Name));

        CreateMap<CreateAppointmentDto, Appointment>();
    }
    

}
