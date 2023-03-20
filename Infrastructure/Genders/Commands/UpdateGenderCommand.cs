using Infrastructure.Common;
using Infrastructure.Genders.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Genders.Commands
{
    public class UpdateGenderCommand:IRequest<OperationResult<GetGenderVm>>
    {
        public GetGenderVm Model { get; set; }
        public Guid Id { get; set; }

        public UpdateGenderCommand(GetGenderVm model,Guid id)
        {
            Id = id;
            Model = model;
        }
    }
}
