using System.ComponentModel.DataAnnotations;
using Infrastructure.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.ClothesCategories.Commands
{
    public class CreateCategoryCommand : IRequest<OperationResult<int>>
    {
        [MaxLength(255), Required]
        [Remote(controller: "ClothesCategory", action: "CheckCategoyExists", areaName: "Panel")]
        public string Name { get; set; }
    }
}
