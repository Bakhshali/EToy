using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Model
{
    public class Discount:BaseEntity
    {
        [MaxLength(255)]
        public byte Percent { get; set; }

        public ICollection<Clothes> ClothesDiscount { get; set; }
    }
}
