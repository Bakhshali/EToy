using Infrastructure.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Stores.Commands
{
    public class DeleteStoreCommand : IRequest<OperationResult<Unit>>
    {
        public DeleteStoreCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
