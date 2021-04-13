﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intex.ViewModels
{

    //Both a model and a viemwmodel are used to store an exhumation
    //this is what is required when using an IFormFile (like below) to store Photo information
    public class ExhumationCreateViewModel
    {
        [Required]
        public int LowPairNS { get; set; }
        [Required]
        public int HighPairNS { get; set; }
        [Required]
        public string BurialLocationNS { get; set; }
        [Required]
        public int LowPairEW { get; set; }
        [Required]
        public int HighPairEW { get; set; }
        [Required]
        public string BurialLocationEW { get; set; }
        [Required]
        public string Area { get; set; }
        public int? ShaftNumber { get; set; }
        [Required]
        public int BurialNumber { get; set; }
        [Required]
        public float SouthToHeadInMeters { get; set; }
        [Required]
        public float SouthToFeetInMeters { get; set; }
        [Required]
        public float WestToHeadInMeters { get; set; }
        [Required]
        public float WestToFeetInMeters { get; set; }
        [Required]
        public float LengthInMeters { get; set; }
        [Required]
        public float DepthInMeters { get; set; }
        public IFormFile Photo { get; set; }
        public bool BurialGoods { get; set; }
        public string Hair { get; set; }
        public string Age { get; set; }
        public bool BurialMaterials { get; set; }
        public string ExcavationRecorder { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
    }
}
