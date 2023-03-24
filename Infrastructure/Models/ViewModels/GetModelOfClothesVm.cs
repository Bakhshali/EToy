using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Models.ViewModels
{
    public class GetModelOfClothesVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Clothes> Clothes { get; set; } = new List<Clothes>();
    }
}
