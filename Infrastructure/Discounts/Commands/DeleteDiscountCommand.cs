using Infrastructure.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Discounts.Commands
{
    public class DeleteDiscountCommand : IRequest<OperationResult<Unit>>
    {
        public DeleteDiscountCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
