using DataAccess.Pagination;
using Domain.Model;
using EToy.Controllers.Base;
using Infrastructure.Common;
using Infrastructure.Stores.Commands;
using Infrastructure.Stores.Queries;
using Infrastructure.Stores.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EToy.Areas.Controllers
{
    [Area("Panel")]
    [Route("[area]/[controller]/[action]")]
    public class StoresController : MyController
    {
        [HttpGet]
        [Route("")]
        [Route("{page:int:min(1)}")]
        public async Task<IActionResult> Index(int page = 1)
        {
            var query = new GetAllStoresQuery(page, 20);
            PaginatedList<Store> result = await Mediator.Send(query);
            return View(result);
        }

        [HttpGet("{id:Guid:min(1)}")]

        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetStoreByIdQuery(id);
            var result = await Mediator.Send(query);

            if(result is null)
            {
                return View("NotFound");
            }

            return View(result);
        }

        [HttpGet]

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Add(CreateStoreCommand model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            OperationResult<Guid> result = await Mediator.Send(model);
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
            GetStoreByIdQuery query = new GetStoreByIdQuery(id);
            GetStoreVm result = await Mediator.Send(query);
            return View(result);
        }
        [HttpPost]

        public async Task<IActionResult> Update(Guid id,GetStoreVm model)
        {
            var command = new UpdateStoreCommand(id, model);
            OperationResult<GetStoreVm> result = await Mediator.Send(command);

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
            var command = new DeleteStoreCommand(id);
            var result = await Mediator.Send(command);

            return RedirectToAction(nameof(Index));
        }

    }
}
