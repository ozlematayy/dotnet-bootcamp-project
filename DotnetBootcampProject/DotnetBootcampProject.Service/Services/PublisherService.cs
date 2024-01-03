using DotnetBootcampProject.Core.Models;
using DotnetBootcampProject.Core.Repositories;
using DotnetBootcampProject.Core.Services;
using DotnetBootcampProject.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBootcampProject.Service.Services
{
    public class PublisherService : Service<Publisher>, IPublisherService
    {
        public PublisherService(IGenericRepository<Publisher> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
