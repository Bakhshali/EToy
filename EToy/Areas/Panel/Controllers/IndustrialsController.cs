using DataAccess.Pagination;
using Domain.Model;
using EToy.Controllers.Base;
using Infrastructure.Common;
using Infrastructure.Genders.Commands;
using Infrastructure.Industrials.Commands;
using Infrastructure.Industrials.Queries;
using Infrastructure.Industrials.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Threading.Tasks;

namespace EToy.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Route("[area]/[controller]/[action]")]
    public class IndustrialsController : MyController
    {
        [HttpGet]
        [Route("")]
        [Route("{page:int:min(1)}")]

        public async Task<IActionResult> Index(int page = 1)
        {
            var query = new GetAllIndustrialQuery(page, 20);
            PaginatedList<Industrial> result = await Mediator.Send(query);
            return View(result);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateIndustrialCommand model)
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
            GetIndustrialByIdQuery query = new GetIndustrialByIdQuery(id);
            GetIndustrialVm result = await Mediator.Send(query);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Guid id, GetIndustrialVm model)
        {
            var command = new UpdateIndustrialCommand(id,model);
            OperationResult<GetIndustrialVm> result = await Mediator.Send(command);
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
            var command = new DeleteIndustrialCommand(id);
            var result = await Mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

    }
}
