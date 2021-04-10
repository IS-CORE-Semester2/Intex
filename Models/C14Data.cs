using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Intex
{
    public partial class C14Data
    {
        public int BurialNumber { get; set; }
        public int? Rack { get; set; }
        public int? NorthSouthNumber { get; set; }
        public string NorthSouthLetter { get; set; }
        public int? EastWestNumber { get; set; }
        public string EastWestLetter { get; set; }
        public string Square { get; set; }
        public int? Area { get; set; }
        public int? TubeNumber { get; set; }
        public string Description { get; set; }
        public int? SizeMl { get; set; }
        public int? Foci { get; set; }
        public int? C14Sample2017 { get; set; }
        public string Location { get; set; }
        public string QuestionS { get; set; }
        public int? OtherNumber { get; set; }
        public int? Conventional14cAgeBp { get; set; }
        public int? _14cCalendarDate { get; set; }
        public int? Calibrated95CalendarDateMax { get; set; }
        public int? Calibrated95CalendarDateMin { get; set; }
        public int? Calibrated95CalendarDateSpan { get; set; }
        public string Calibrated95CalendarDateAvg { get; set; }
        public string Category { get; set; }
        public string Notes { get; set; }
    }
}
