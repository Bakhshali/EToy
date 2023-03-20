using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Genders.Queries
{
    public class CheckGenderExistQuery:IRequest<bool>
    {
        public string Name { get; set; }

        public CheckGenderExistQuery(string name)
        {
            Name = name;
        }
    }
}
