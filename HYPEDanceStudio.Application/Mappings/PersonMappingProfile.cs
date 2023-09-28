using HYPEDanceStudio.Application.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HYPEDanceStudio.Domain.Entities;
using HYPEDanceStudio.Application.Person.Commands.EditPerson;
using HYPEDanceStudio.Application.ApplicationUser;
using HYPEDanceStudio.Application.Assignment;
using HYPEDanceStudio.Application.Assignment.Commands.Done;

namespace HYPEDanceStudio.Application.Mappings
{
    public class PersonMappingProfile : Profile
    {
      
        public PersonMappingProfile (IUserContext userContext)
        {               var user = userContext.GetCurrentUser();
            CreateMap<PersonDto, Domain.Entities.Person>()
                .ForMember(e => e.ContactDetails, opt => opt.MapFrom(src => new PersonContactDetails()
                {
                    PhoneNumber = src.PhoneNumber,
                    Email = src.Email

                })) ;

            CreateMap<Domain.Entities.Person, PersonDto>()
                 .ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => user != null
                                                && (src.CreatedById == user.Id || user.isInRole("Owner") || user.isInRole("Moderator"))))
                .ForMember(e => e.PhoneNumber, opt => opt.MapFrom(src => src.ContactDetails.PhoneNumber))
                .ForMember(e => e.Email, opt => opt.MapFrom(src => src.ContactDetails.Email));

            CreateMap<PersonDto, EditPersonCommand>();
            CreateMap<Domain.Entities.Assignment, AssignmentDto>()
                .ReverseMap();

            CreateMap<AssignmentDto, DoneCommand>();
        }
    }
}
