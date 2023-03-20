using Infrastructure.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Industrials.Commands
{
    public class DeleteIndustrialCommand:IRequest<OperationResult<Unit>>
    {
        public DeleteIndustrialCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
