using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class ClothesSize
    {
        public Clothes Clothes { get; set; }
        public Size Size { get; set; }

        public int ClothesId { get; set; }
        public int SizeId { get; set; }
    }
}
