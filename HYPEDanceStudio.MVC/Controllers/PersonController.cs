using AutoMapper;
using HYPEDanceStudio.Application.Assignment.Commands.Done;
using HYPEDanceStudio.Application.Person;
using HYPEDanceStudio.Application.Person.Commands.CreatePerson;
using HYPEDanceStudio.Application.Person.Commands.DeletePerson;
using HYPEDanceStudio.Application.Person.Commands.EditPerson;
using HYPEDanceStudio.Application.Person.Queries;
using HYPEDanceStudio.Application.Person.Queries.GetAllPersons;
using HYPEDanceStudio.Application.Person.Queries.GetPersonByEncodedName;
using HYPEDanceStudio.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HYPEDanceStudio.MVC.Controllers
{
    public class PersonController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PersonController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var persons = await _mediator.Send(new GetAllPersonsQuery());
            return View(persons);
        }

        [Authorize(Roles ="Owner")]

        public IActionResult Create()
        {
           /* if (User.Identity == null || !User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }*/
           /*if(!User.IsInRole("Owner"))
            {
                return RedirectToAction("NoAccess", "Home");
            }*/
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create (CreatePersonCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);

            return RedirectToAction(nameof(Index));
        }

        [Route("Person/{encodedName}/Details")]
        public async Task< IActionResult> Details( string encodedName)
        {
            var dto = await _mediator.Send(new GetPersonByEncodedNameQuery(encodedName));
            return View(dto);
        }

        [Route("Person/{encodedName}/Edit")]
        [Authorize(Roles = "Owner, Moderator")]
        
        public async Task<IActionResult> Edit (string encodedName)
        {
            var dto = await _mediator.Send(new GetPersonByEncodedNameQuery(encodedName));
            if(!dto.IsEditable)
            {
                return RedirectToAction("NoAccess", "Home");
            }
            EditPersonCommand model = _mapper.Map<EditPersonCommand>(dto);

            return View(model);
        }

        [HttpPost]
        [Route("Person/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(EditPersonCommand command, string encodedName)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }



        [Route("Person/{encodedName}/Delete")]
        [Authorize(Roles = "Owner, Moderator")]

        public async Task<IActionResult> Delete(DeletePersonCommand command, string encodedName)
        {
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }


    }
}
