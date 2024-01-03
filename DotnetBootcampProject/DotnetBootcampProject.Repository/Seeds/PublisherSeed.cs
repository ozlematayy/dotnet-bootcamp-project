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
    public class PublisherSeed : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.HasData(
               new Publisher { Id = 1, PublisherName = "Yapı Kredi Yayınları", City = "İstanbul", ContactEmail = "iletisim@ykykultur.com", CreatedDate = DateTime.Now },
               new Publisher { Id = 2, PublisherName = "Pegasus Yayınları", City = "İstanbul", ContactEmail = "iletisim@pegasus.com", CreatedDate = DateTime.Now },
               new Publisher { Id = 3, PublisherName = "İş Bankası Kültür Yayınları", City = "Ankara", ContactEmail = "iletisim@iskultur.com", CreatedDate = DateTime.Now },
               new Publisher { Id = 4, PublisherName = "Everest Yayınları", City = "İstanbul", ContactEmail = "info@everest.com", CreatedDate = DateTime.Now }
                );
        }
    }
}
