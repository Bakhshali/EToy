using AutoMapper;
using DataAccess.Database;
using DataAccess.Persistence;
using Infrastructure.Models.Queries;
using Infrastructure.Models.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Models.QueryHandlers
{
    public class GetModelOfClothesByIdQueryHandler : IRequestHandler<GetModelOfClothesByIdQuery, GetModelOfClothesVm>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetModelOfClothesByIdQueryHandler(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GetModelOfClothesVm> Handle(GetModelOfClothesByIdQuery request, CancellationToken cancellationToken)
        {
            var models = await _context.ModelOfClothes.SingleOrDefaultAsync(m => m.Id == request.Id, cancellationToken);
            if(models is null)
            {
                return null;
            }

            return _mapper.Map<GetModelOfClothesVm>(request);
        }
    }
}
