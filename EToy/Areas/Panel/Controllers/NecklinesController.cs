using DataAccess.Pagination;
using Domain.Model;
using EToy.Controllers.Base;
using Infrastructure.Common;
using Infrastructure.Genders.Commands;
using Infrastructure.Neclines.Commands;
using Infrastructure.Neclines.Queries;
using Infrastructure.Neclines.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EToy.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Route("[area]/[controller]/[action]")]
    public class NecklinesController : MyController
    {

        [HttpGet]
        [Route("")]
        [Route("{page:int:min(1)}")]
        public async Task<IActionResult> Index(int page = 1)
        {
            var query = new GetAllNecklineQuery(page, 20);
            PaginatedList<Neckline> result = await Mediator.Send(query);
            return View(result);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateNecklineCommand model)
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

        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteNecklineCommand(id);
            var result = await Mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
}
