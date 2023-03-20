using Infrastructure.Common;
using Infrastructure.Industrials.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Industrials.Commands
{
    public class UpdateIndustrialCommand : IRequest<OperationResult<GetIndustrialVm>>
    {
        public Guid Id { get; set; }
        public GetIndustrialVm Model { get; set; }

        public UpdateIndustrialCommand(Guid id, GetIndustrialVm model)
        {
            Id = id;
            Model = model;
        }
    }
}
