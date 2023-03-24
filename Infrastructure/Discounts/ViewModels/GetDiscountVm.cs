using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Discounts.ViewModels
{
    public class GetDiscountVm
    {
        public Guid Id { get; set; }
        public byte DiscountPercent { get; set; }
        public List<Clothes> Clothes { get; set; } = new List<Clothes>();
    }
}
