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
    public class PublicationInfoConfiguration : IEntityTypeConfiguration<PublicationInfo>
    {
        public void Configure(EntityTypeBuilder<PublicationInfo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.PublicationDate).IsRequired();
            builder.Property(x => x.Edition).IsRequired();
        }
    }
}
