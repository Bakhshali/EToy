using Infrastructure.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.ClothesCategories.Commands
{
    public class DeleteCategoryCommand:IRequest<OperationResult<Unit>>
    {
        public Guid Id { get; set; }

        public DeleteCategoryCommand(Guid id)
        {
            Id = id;
        }
    }
}
