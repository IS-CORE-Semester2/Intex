using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Intex
{
    public partial class OracleSpread
    {
        [Key]
        public int? Gamous { get; set; }
        public int? BurialSquare { get; set; }
        public string Nors { get; set; }
        public int? Sq2 { get; set; }
        public string Eorw { get; set; }
        public string Area { get; set; }
        public int? Burialnum { get; set; }
        public double? Westtohead { get; set; }
        public double? Westtofeet { get; set; }
        public double? Southtohead { get; set; }
        public double? Southtofeet { get; set; }
        public double? Depth { get; set; }
        public string Preservation { get; set; }
        public string Burialicon { get; set; }
        public string Sex { get; set; }
        public string Sexmethod { get; set; }
        public string Ageatdeath { get; set; }
        public string Agemethod { get; set; }
        public string Haircolor { get; set; }
        public bool? Sample { get; set; }

        public virtual Burials Burial { get; set; }

    }
}
