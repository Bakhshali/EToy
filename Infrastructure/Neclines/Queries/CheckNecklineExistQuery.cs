using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Neclines.Queries
{
    public class CheckNecklineExistQuery:IRequest<bool>
    {
        public CheckNecklineExistQuery(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
