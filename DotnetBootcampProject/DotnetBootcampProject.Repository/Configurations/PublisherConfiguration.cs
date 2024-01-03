using DotnetBootcampProject.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBootcampProject.Repository.Configurations
{
    public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.PublisherName).HasMaxLength(250).IsRequired();
            builder.Property(x => x.City).HasMaxLength(150).IsRequired();
            builder.Property(x => x.ContactEmail).HasMaxLength(250).IsRequired();

        }
    }
}
