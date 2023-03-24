using DataAccess.Pagination;
using Domain.Model;
using EToy.Controllers.Base;
using Infrastructure.ClothesCategories.Commands;
using Infrastructure.ClothesCategories.Queries;
using Infrastructure.ClothesCategories.ViewModels;
using Infrastructure.Common;
using Infrastructure.Genders.Commands;
using Infrastructure.Genders.Queries;
using Infrastructure.Genders.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EToy.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Route("[area]/[controller]/[action]")]
    public class GendersController : MyController
    {
        [HttpGet]
        [Route("")]
        [Route("{page:int:min(1)}")]
        public async Task<IActionResult> Index(int page = 1)
        {
            var query = new GetAllGenderQuery(page,20);
            PaginatedList<Gender> result = await Mediator.Send(query);
            return View(result);
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateGenderCommand model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            OperationResult<int> result = await Mediator.Send(model);
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
            GetGenderByIdQuery query = new GetGenderByIdQuery(id);
            GetGenderVm result = await Mediator.Send(query);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Guid id,GetGenderVm model)
        {
            var command = new UpdateGenderCommand(model, id);
            OperationResult<GetGenderVm> result = await Mediator.Send(command);
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
            var command = new DeleteGenderCommand(id);
            var result = await Mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }


        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> CheckGenderExists(string name)
        {
            var query = new CheckGenderExistQuery(name);
            var result = await Mediator.Send(query);

            return result ? Json($"Category {name} already exists") : Json(true);
        }
    }
}
