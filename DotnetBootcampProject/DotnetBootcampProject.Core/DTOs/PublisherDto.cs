using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBootcampProject.Core.DTOs
{
    public class PublisherDto:BaseDto
    {
        public string PublisherName { get; set; }
        public string City { get; set; }
        public string ContactEmail { get; set; }
    }
}
