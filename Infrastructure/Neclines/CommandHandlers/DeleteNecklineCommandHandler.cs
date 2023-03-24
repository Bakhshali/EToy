using DataAccess.Constants;
using DataAccess.Database;
using DataAccess.Persistence;
using Domain.Model;
using Infrastructure.Common;
using Infrastructure.Neclines.Commands;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Neclines.CommandHandlers
{
    public class DeleteNecklineCommandHandler : IRequestHandler<DeleteNecklineCommand, OperationResult<Unit>>
    {
        private readonly AppDbContext _context;
        private readonly IPersistence _persistence;
        private readonly IWebHostEnvironment _environment;

        public DeleteNecklineCommandHandler(AppDbContext context,IPersistence persistence,IWebHostEnvironment environment)
        {
            _context = context;
            _persistence = persistence;
            _environment = environment;
        }

        public async Task<OperationResult<Unit>> Handle(DeleteNecklineCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<Unit>();

            var neckline = await _context.Necklines.Include(c=>c.DressNeckline).SingleOrDefaultAsync(c=>c.Id == request.Id,cancellationToken);

            if (neckline.DressNeckline.Any())
            {
                return result.AddError("Could not delete position which has employee associated to it\nRemove employee from that position first!");
            }


            string path = Path.Combine(_environment.WebRootPath, @"assets\images\", neckline.ImageUrl);

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            _context.Necklines.Remove(neckline);

            var persistenceResult = await _persistence.SaveChangesAsync();

            if (persistenceResult == 0)
            {
                return result.AddError(ErrorMessages.CouldNotDelete);
            }

            result.Entity = Unit.Value;
            return result;
        }
    }
}
