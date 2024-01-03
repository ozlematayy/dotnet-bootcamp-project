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
    public class BookService : Service<Book>, IBookService
    {
        public BookService(IGenericRepository<Book> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
