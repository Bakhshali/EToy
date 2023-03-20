using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.ClothesCategories.Queries
{
    public class CheckCategoryExistQuery: IRequest<bool>
    {
        public string Name { get; set; }

        public CheckCategoryExistQuery(string name)
        {
            Name = name;
        }
    }
}
