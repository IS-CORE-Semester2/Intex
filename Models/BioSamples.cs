using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Intex
{
    public partial class BioSamples
    {
        [Key]
        public int BioSampleId { get; set; }
        public double? RackNumber { get; set; }
        public string BagNumber { get; set; }
        public double? LowPairNs { get; set; }
        public double? HighPairNs { get; set; }
        public string BurialLocationNs { get; set; }
        public double? LowPairEw { get; set; }
        public double? HighPairEw { get; set; }
        public string BurialLocationEw { get; set; }
        public string BurialSubplot { get; set; }
        public double? BurialNumber { get; set; }
        public double? Date { get; set; }
        public string PreviouslySampled { get; set; }
        public string Notes { get; set; }
        public string Initials { get; set; }
        public int? BurialId { get; set; }

        public virtual Burials Burial { get; set; }
    }
}
