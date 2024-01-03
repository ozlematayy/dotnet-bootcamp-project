using DotnetBootcampProject.Core.Models;
using DotnetBootcampProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBootcampProject.Repository.Repositories
{
    public class PublisherRepository : GenericRepository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(AppDbContext context) : base(context)
        {
        }
    }
}
