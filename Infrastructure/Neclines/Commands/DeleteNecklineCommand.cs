using Infrastructure.Common;
using MediatR;
using Microsoft.AspNetCore.JsonPatch.Operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Neclines.Commands
{
    public class DeleteNecklineCommand : IRequest<OperationResult<Unit>>
    {
        public Guid Id { get; set; }

        public DeleteNecklineCommand(Guid id)
        {
            Id = id;
        }

        
    }
}
