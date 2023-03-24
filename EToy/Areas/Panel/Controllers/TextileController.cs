using EToy.Controllers.Base;
using Infrastructure.Common;
using Infrastructure.Textiles.Commands;
using Infrastructure.Textiles.Queries;
using Infrastructure.Textiles.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EToy.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Route("[area]/[controller]/[action]")]
    public class TextileController : MyController
    {
        
        [HttpGet]
        [Route("")]
        [Route("{page:int:min(1)}")]
        public async Task<IActionResult> Index(int page = 1)
        {
            var query = new GetAllTextilesQuery(page, 20);
            var result = await Mediator.Send(query);
            return View(result);
        }

        [HttpGet("{id:Guid:min(1)}")]

        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetTextileByIdQuery(id);
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

        [HttpPost]

        public async Task<IActionResult> Add(CreateTextileCommand model)
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
            GetTextileByIdQuery query = new GetTextileByIdQuery(id);
            GetTextileVm result = await Mediator.Send(query);
            return View(result);
        }

        [HttpPost]

        public async Task<IActionResult> Update(Guid id,GetTextileVm model)
        {
            var command = new UpdateTextileCommand(id, model);
            OperationResult<GetTextileVm> result = await Mediator.Send(command);

            if (!result.Success)
            {
                return RedirectToAction(nameof(Index));
            }
            ErrorHandler();
            return View(command.Model);
        }

        [HttpPost]

        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteTextileCommand(id);
            var result = await Mediator.Send(command);

            return RedirectToAction(nameof(Index));
        }

        [AcceptVerbs("Get","Post")]

        public async Task<IActionResult> CheckTextileExists(string name)
        {
            var query = new CheckPositionExistQuery(name);
            var result = await Mediator.Send(query);

            return result ? Json($"Textile {name} already exists") : Json(true);
        }
    }
}
