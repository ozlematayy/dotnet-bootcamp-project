using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBootcampProject.Core.DTOs
{
    public class PublicationInfoDto:BaseDto
    {
        public DateTime PublicationDate { get; set; }
        public int Edition { get; set; }
        public int BookId { get; set; }
    }
}
