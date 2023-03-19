using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class PalaceMeasure
    {
        public Palace Palace { get; set; }
        public Measure Measure { get; set; }

        public int PalaceId { get; set; }
        public int MeasureId { get; set; }
    }
}
