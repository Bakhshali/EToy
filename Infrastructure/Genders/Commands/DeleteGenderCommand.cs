using Infrastructure.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Genders.Commands
{
    public class DeleteGenderCommand:IRequest<OperationResult<Unit>>
    {
        public DeleteGenderCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
