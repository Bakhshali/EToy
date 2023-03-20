using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class ClothesColor
    {
        public Clothes Clothes { get; set; }
        public Color Color { get; set; }

        public Guid ClothesId { get; set; }
        public Guid ColorId { get; set; }
    }
}
