using Infrastructure.Discounts.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Discounts.QueryHandlers
{
    public class GetDiscountByIdQuery : IRequest<GetDiscountVm>
    {
        public GetDiscountByIdQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
