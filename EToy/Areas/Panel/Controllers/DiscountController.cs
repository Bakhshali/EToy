using DataAccess.Pagination;
using Domain.Model;
using EToy.Controllers.Base;
using Infrastructure.Common;
using Infrastructure.Discounts.Commands;
using Infrastructure.Discounts.Queries;
using Infrastructure.Discounts.QueryHandlers;
using Infrastructure.Discounts.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EToy.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Route("[area]/[controller]/[action]")]
    public class DiscountController : MyController
    {
        [HttpGet]
        [Route("")]
        [Route("{page:int:min(1)}")]
        public async Task<IActionResult> Index(int page = 1)
        {
            var query = new GetAllDiscountsQuery(1, 20);
            PaginatedList<Discount> result = await Mediator.Send(query);
            return View(result);
        }

        [HttpGet("{id:Guid:min(1)}")]

        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetDiscountByIdQuery(id);
            var result = await Mediator.Send(query);

            if(result is null)
            {
                return View("Not Found");
            }

            return View(result);
        }

        [HttpPost]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Add(CreateDiscountCommand model)
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
            var query = new GetDiscountByIdQuery(id);
            GetDiscountVm result = await Mediator.Send(query);
            return View(result);
        }

        [HttpPost]

        public async Task<IActionResult> Update(Guid id,GetDiscountVm model)
        {
            var command = new UpdateDiscountCommand(id,model);
            OperationResult<GetDiscountVm> result = await Mediator.Send(command);

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
            var command = new DeleteDiscountCommand(id);
            var result = await Mediator.Send(command);
            return View(result);
        }
    }
}
