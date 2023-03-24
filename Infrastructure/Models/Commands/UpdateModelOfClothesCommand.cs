using Infrastructure.Common;
using Infrastructure.Models.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Models.Commands
{
    public class UpdateModelOfClothesCommand : IRequest<OperationResult<GetModelOfClothesVm>>
    {
        public UpdateModelOfClothesCommand(Guid id,GetModelOfClothesVm model)
        {
            Model = model;
            Id = id;
        }
        public Guid Id { get; set; }
        public GetModelOfClothesVm Model { get; set; }
    }
}
