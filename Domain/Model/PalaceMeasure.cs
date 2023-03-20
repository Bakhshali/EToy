using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class PalaceMeasure
    {
        public Palace Palace { get; set; }
        public Measure Measure { get; set; }

        public Guid PalaceId { get; set; }
        public Guid MeasureId { get; set; }
    }
}
