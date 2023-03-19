using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class ClothesColor
    {
        public Clothes Clothes { get; set; }
        public Color Color { get; set; }

        public int ClothesId { get; set; }
        public int ColorId { get; set; }
    }
}
