using Infrastructure.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Models.Commands
{
    public class DeleteModelOfClothesCommand : IRequest<OperationResult<Unit>>
    {
        public DeleteModelOfClothesCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
