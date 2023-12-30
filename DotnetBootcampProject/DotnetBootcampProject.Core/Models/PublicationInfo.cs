using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBootcampProject.Core.Models
{
    public class PublicationInfo:BaseEntity
    {
        public DateTime PublicationDate { get; set; }
        public int Edition { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }

    }
}
