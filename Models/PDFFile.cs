using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intex.Models
{
    public class PDFFile
    {
        [Key]
        public int Id { get; set; }
        public string Path { get; set; }
        public int FileId { get; set; }
        public string Name { get; set; }
    }
}
