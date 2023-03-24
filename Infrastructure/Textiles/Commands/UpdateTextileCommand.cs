using Infrastructure.Common;
using Infrastructure.Textiles.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Textiles.Commands
{
    public class UpdateTextileCommand : IRequest<OperationResult<GetTextileVm>>
    {
        public UpdateTextileCommand(Guid id,GetTextileVm model)
        {
            Id = id;
            Model = model;
        }
        public Guid Id { get; set; }
        public GetTextileVm Model { get; set; }
    }
}
