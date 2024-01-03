using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBootcampProject.Core.DTOs
{
    public class BookDto: BaseDto
    {
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public string Genre { get; set; }
    }
}
