using DotnetBootcampProject.Core.Models;
using DotnetBootcampProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBootcampProject.Repository.Repositories
{
    public class PublicationInfoRepository : GenericRepository<PublicationInfo>, IPublicationInfoRepository
    {
        public PublicationInfoRepository(AppDbContext context) : base(context)
        {
        }
    }
}
