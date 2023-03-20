using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class ClothesImage:BaseEntity
    {
        public string PhotoUrl { get; set; }

        public Clothes Clothes { get; set; }
        public Guid ClothesId { get; set; }

        public bool? IsMain { get; set; }
    }
}
