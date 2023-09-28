using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using HYPEDanceStudio.Application.ApplicationUser;
using HYPEDanceStudio.Application.Mappings;
using HYPEDanceStudio.Application.Person.Commands.CreatePerson;
using HYPEDanceStudio.Application.Person.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HYPEDanceStudio.Application.Extensions
{
    public static class ServiceCollectionExtension
    {

        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreatePersonCommand));
            services.AddScoped(provider => new MapperConfiguration(cfg =>
            {
                var scope = provider.CreateScope();
                var userContext = scope.ServiceProvider.GetRequiredService<IUserContext>();
                cfg.AddProfile(new PersonMappingProfile(userContext));
            }).CreateMapper()
            );

            services.AddValidatorsFromAssemblyContaining<CreatePersonCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

            services.AddScoped<IUserContext, UserContext>();
        }
    }
}
