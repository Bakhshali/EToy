using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Models.Queries
{
    public class GetModelOfClothesSelectListQuery : IRequest<SelectList>
    {
        public GetModelOfClothesSelectListQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
