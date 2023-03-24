using Infrastructure.Textiles.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Textiles.Queries
{
    public class GetTextileByIdQuery : IRequest<GetTextileVm>
    {
        public GetTextileByIdQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
