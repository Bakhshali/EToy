using Infrastructure.ClothesCategories.ViewModels;
using Infrastructure.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.ClothesCategories.Commands
{
    public class UpdateCategoryCommand : IRequest<OperationResult<GetCategoryVm>>
    {
        public Guid Id { get; set; }
        public GetCategoryVm Model { get; set; }

        public UpdateCategoryCommand(Guid id, GetCategoryVm model)
        {
            Id = id;
            Model = model;
        }
    }
}
