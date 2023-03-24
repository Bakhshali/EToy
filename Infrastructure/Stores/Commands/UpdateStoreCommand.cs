using Infrastructure.Common;
using Infrastructure.Stores.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Stores.Commands
{
    public class UpdateStoreCommand : IRequest<OperationResult<GetStoreVm>>
    {
        public UpdateStoreCommand(Guid id,GetStoreVm model)
        {
            Id = id;
            Model = model;
        }
        public Guid Id { get; set; }
        public GetStoreVm Model { get; set; }
    }
}
