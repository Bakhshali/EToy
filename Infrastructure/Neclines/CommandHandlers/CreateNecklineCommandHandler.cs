using AutoMapper;
using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Domain.Model;
using Microsoft.AspNetCore.Hosting;
using Infrastructure.Common;
using Infrastructure.Neclines.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Neclines.CommandHandlers
{
    public class CreateNecklineCommandHandler : IRequestHandler<CreateNecklineCommand, OperationResult<int>>
    {
        private readonly AppDbContext _context;
        private readonly IPersistence _persistence;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

        public CreateNecklineCommandHandler(AppDbContext context, IPersistence persistence, IMapper mapper,IWebHostEnvironment environment)
        {
            _context = context;
            _persistence = persistence;
            _mapper = mapper;
            _environment = environment;
        }

        public async Task<OperationResult<int>> Handle(CreateNecklineCommand request, CancellationToken cancellationToken)
        {

            var result = new OperationResult<int>();

            if (request.Photo != null)
            {
                if (!request.Photo.IsOkay(1))
                {
                   return result.AddError(ErrorMessages.MistakeImage);                
                }

                request.ImageUrl = await request.Photo.FileCreate(_environment.WebRootPath, @"assets\images");
            }

            else
            {
                return result.AddError(ErrorMessages.ChooseImage);           
            }

            var neckline = _mapper.Map<Neckline>(request);
            await _context.Necklines.AddAsync(neckline, cancellationToken);

            var persistence = await _persistence.SaveChangesAsync();

            if (persistence == 0)
            {
                return result.AddError(ErrorMessages.CouldNotAddToDatabase);
            }

            return result;

        }
    }
}
