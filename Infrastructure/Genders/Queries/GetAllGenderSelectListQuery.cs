using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Genders.Queries
{
    public class GetAllGenderSelectListQuery:IRequest<SelectList>
    {
        public Guid Id { get; set; }

        public GetAllGenderSelectListQuery(Guid id)
        {
            Id = id;
        }
    }
}
