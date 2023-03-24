using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Textiles.Queries
{
    public class CheckPositionExistQuery : IRequest<bool>
    {
        public CheckPositionExistQuery(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
