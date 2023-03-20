using Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.ClothesCategories.ViewModels
{
    public class GetCategoryVm
    {
        public Guid Id { get; set; }

        [Required,MaxLength(255)]
        public string Name { get; set; }

        public List<Clothes> Clothes { get; set; } = new List<Clothes>();
    }
}
