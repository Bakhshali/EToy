using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Models.Queries
{
    public class CheckModelOfClothesExistQuery : IRequest<bool>
    {
        public CheckModelOfClothesExistQuery(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
