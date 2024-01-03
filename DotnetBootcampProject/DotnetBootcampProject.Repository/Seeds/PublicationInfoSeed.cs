using DotnetBootcampProject.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBootcampProject.Repository.Seeds
{
    public class PublicationInfoSeed : IEntityTypeConfiguration<PublicationInfo>
    {
        public void Configure(EntityTypeBuilder<PublicationInfo> builder)
        {
            builder.HasData
                (
                new PublicationInfo { Id =1, PublicationDate= new DateTime(1866,12,05), Edition=1,BookId=1,CreatedDate=DateTime.Now},
                new PublicationInfo { Id = 2, PublicationDate = new DateTime(1954, 05, 15), Edition = 1, BookId = 2 , CreatedDate = DateTime.Now },
                new PublicationInfo { Id = 3, PublicationDate = new DateTime(1982, 06, 10), Edition = 1, BookId = 3,CreatedDate=DateTime.Now },
                new PublicationInfo { Id = 4, PublicationDate = new DateTime(1981, 08, 22), Edition = 1, BookId = 4 , CreatedDate = DateTime.Now },
                new PublicationInfo { Id = 5, PublicationDate = new DateTime(2001, 07, 15), Edition = 2, BookId = 4 , CreatedDate = DateTime.Now }
                );
        }
    }
}
