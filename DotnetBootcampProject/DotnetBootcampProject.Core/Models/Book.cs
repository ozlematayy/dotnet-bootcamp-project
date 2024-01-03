using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBootcampProject.Core.Models
{
    public class Book : BaseEntity
    {
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public string Genre { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public ICollection<PublicationInfo> PublicationInfo { get; set; }
    }
}
