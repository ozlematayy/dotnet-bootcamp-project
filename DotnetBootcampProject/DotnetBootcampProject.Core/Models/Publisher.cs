using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBootcampProject.Core.Models
{
    public class Publisher:BaseEntity
    {
        public string PublisherName { get; set; }
        public string City { get; set; }
        public string ContactEmail { get; set; }
        public ICollection<Book> Book { get; set; }

    }
}
