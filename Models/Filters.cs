
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex.Models
{
    //filters class to hold filtering information.
    //Not currently in use but could be implemented in a later build
    public class Filters
    {
        public Filters(string filterstring)
        {
            FilterString = filterstring ?? "all-all'all";
            string[] filters = FilterString.Split('-');
            BurialIdString = BurialId.ToString();
            BurialIdString = filters[0];
            BurialLocationNs = filters[1];
            BurialLocationEw = filters[2];
            BurialDepth = filters[3];
            YearFound = filters[4];
            HeadDirection = filters[5];

        }
        public string FilterString { get; }
        public int BurialId { get; }
        public string BurialIdString { get; set; }
        public string BurialLocationNs { get; }
        public string BurialLocationEw { get; }
        public string BurialDepth { get; }
        public string YearFound { get; }
        public string HeadDirection { get; }
        public string HairColor { get; }

        public bool HasBurialId => BurialIdString.ToLower() != "all";
        public bool HasBurialLocationNs => BurialLocationNs.ToLower() != "all";
        public bool HasBurialLocationEw => BurialLocationEw.ToLower() != "all";
        public bool HasBurialDepth => BurialDepth.ToLower() != "all";
        public bool HasYearFound => YearFound.ToLower() != "all";
        public bool HasHeadDirection => HeadDirection.ToLower() != "all";
        public bool HasHairColor => HairColor.ToLower() != "all";
        public static Dictionary<string, string> HeadDirectionFilterValues =>
            new Dictionary<string, string>
            {
                {"east", "East" },
                {"west", "West" },
            };
    }
}
