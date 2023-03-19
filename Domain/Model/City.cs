using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class City:BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Palace> Palaces { get; set; }
    }
}
