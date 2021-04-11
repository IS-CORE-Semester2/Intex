using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex.ViewModels
{
    public class PDFUploadViewModel
    {
        public IFormFile PDFFiles { get; set; }
    }
}
