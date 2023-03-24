using Infrastructure.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Textiles.Commands
{
    public class DeleteTextileCommand : IRequest<OperationResult<Unit>>
    {
        public DeleteTextileCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
