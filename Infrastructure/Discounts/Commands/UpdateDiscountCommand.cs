using Infrastructure.Common;
using Infrastructure.Discounts.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Discounts.Commands
{
    public class UpdateDiscountCommand : IRequest<OperationResult<GetDiscountVm>>
    {
        public UpdateDiscountCommand(Guid id,GetDiscountVm model)
        {
            Id = id;
            Model = model;
        }
        public Guid Id { get; set; }
        public GetDiscountVm Model { get; set; }
    }
}
