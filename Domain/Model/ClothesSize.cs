using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class ClothesSize
    {
        public Clothes Clothes { get; set; }
        public Size Size { get; set; }

        public Guid ClothesId { get; set; }
        public Guid SizeId { get; set; }
    }
}
