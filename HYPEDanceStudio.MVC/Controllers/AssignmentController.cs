using AutoMapper;
using HYPEDanceStudio.Application.Assignment.Commands.CreateAssignment;
using HYPEDanceStudio.Application.Assignment.Commands.DeleteAssignment;
using HYPEDanceStudio.Application.Assignment.Commands.Done;
using HYPEDanceStudio.Application.Assignment.Queries.GetAssignmentById;
using HYPEDanceStudio.Application.Assignment.Queries.GetAssignments;
using HYPEDanceStudio.Application.Person.Commands.DeletePerson;
using HYPEDanceStudio.Application.Person.Commands.EditPerson;
using HYPEDanceStudio.Application.Person.Queries.GetPersonByEncodedName;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HYPEDanceStudio.MVC.Controllers
{
    public class AssignmentController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AssignmentController(IMediator mediator, IMapper mapper)
        {
            _mediator=mediator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _mediator.Send(new GetAssignmentsQuery());
            return View(data);
        }

        [Authorize(Roles = "Owner")]

        public IActionResult CreateAssignment()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Owner, Moderator")]
        public async Task<IActionResult> CreateAssignment(CreateAssignmentCommand createAssignmentCommand)
        {
            if(!ModelState.IsValid)
            {
                return View(createAssignmentCommand);
            }
            await _mediator.Send(createAssignmentCommand);
            return RedirectToAction(nameof(Index));
        }

        [Route("Assignment/Done/{id}")]
        [Authorize(Roles = "Owner, Moderator")]
        public async Task<IActionResult> Done(DoneCommand command, int id)

        {    await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }


        [Route("Person/Delete/{id}")]
        [Authorize(Roles = "Owner, Moderator")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteAssignmentCommand(id));
            return RedirectToAction(nameof(Index));
        }



    }
}
