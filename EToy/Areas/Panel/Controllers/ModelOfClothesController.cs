using EToy.Controllers.Base;
using Infrastructure.Common;
using Infrastructure.Models.Commands;
using Infrastructure.Models.Queries;
using Infrastructure.Models.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EToy.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Route("[area]/[controller]/[action]")]
    public class ModelOfClothesController : MyController
    {
        [HttpGet]
        [Route("")]
        [Route("{page:int:min(1)}")]
        public async Task<IActionResult> Index(int page = 1)
        {
            var query = new GetAllModelOfClothesQuery(page, 20);
            var result = await Mediator.Send(query);
            return View(result);
        }

        [HttpGet("{id:Guid:min(1)}")]

        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetModelOfClothesByIdQuery(id);
            var result = await Mediator.Send(query);
            if(result is null)
            {
                return View("Not Found");
            }
            return View(result);
        }

        [HttpGet]

        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]

        public async Task<IActionResult> Add(CreateModelOfCloothesCommand model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var query = new CreateModelOfCloothesCommand();
            var result = await Mediator.Send(query);

            if (!result.Success)
            {
                ErrorHandler();
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]

        public async Task<IActionResult> Update(Guid id)
        {
            var query = new GetModelOfClothesByIdQuery(id);
            var result = await Mediator.Send(query);
            return View(result);
        }

        [HttpPost]

        public async Task<IActionResult> Update(Guid id,GetModelOfClothesVm model)
        {
            var command = new UpdateModelOfClothesCommand(id, model);
            OperationResult<GetModelOfClothesVm> result = await Mediator.Send(command);

            if (result.Success)
            {
                return RedirectToAction(nameof(Index));
            }

            ErrorHandler();
            return View(command.Model);
        }

        [HttpPost]

        public async Task<IActionResult> Delete(Guid id)
        {
            var query = new DeleteModelOfClothesCommand(id);
            var result = await Mediator.Send(query);
            return View(result);
        }

        [AcceptVerbs("Get", "Post")]

        public async Task<IActionResult> CheckTextileExist(string name)
        {
            var query = new CheckModelOfClothesExistQuery(name);
            var result = await Mediator.Send(query);

            return result ? Json($"Textile {name} already exists") : Json(true);
        }
    }
}
