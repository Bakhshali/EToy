using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace EToy.Controllers.Base
{
    public class MyController : Controller
    {
        private IMediator _mediator;
        private IMapper _mapper;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        protected IMapper Mapper => _mapper ??= HttpContext.RequestServices.GetService<IMapper>();

        protected void ErrorHandler()
        {
            foreach (var error in ModelState.Values.SelectMany(e => e.Errors.Select(e => e.ErrorMessage)))
            {
                ModelState.AddModelError(string.Empty, error);
            }
        }
        protected void AddError(string errorName)
        {
            ModelState.AddModelError(string.Empty, errorName);
        }

        protected void AddError(List<string> errorNames)
        {
            foreach (var error in errorNames)
            {
                ModelState.AddModelError(string.Empty, error);
            }
        }
    }
}
