using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// a viewmodel is a model built for a specific view
// this is populated by the linq statement in the controller at project runtime
// it is then brought into the index page through the "@model ProjectsListViewModel" statement
namespace Intex.ViewModels
{
    public class IndexViewModel
    {
        // The IEnumberable is only pulled in the index page with the following statement
        public List<Burials> Burials { get; set; }
        public List<BioSamples> BioSamples { get; set; }
        public List<Cranial2002> Cranial2002s { get; set; }
        public List<OracleSpreads> OracleSpreads { get; set; }
        public List<C14Data> C14Datas { get; set; }

        //this one is used to set how many pages there are
        public PagingInfo PagingInfo { get; set; }
    }
}
