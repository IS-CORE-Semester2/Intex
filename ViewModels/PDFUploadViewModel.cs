using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex.ViewModels
{
    //Both a model and a viemwmodel are used to store a PDF file
    //this is what is required when using an IFormFile (like below) to store pdf information
    public class PDFUploadViewModel
    {
        public IFormFile PDFFiles { get; set; }
    }
}
