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
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).UseIdentityColumn();
            builder.Property(x => x.BookName).HasMaxLength(250).IsRequired();
            builder.Property(x => x.AuthorName).HasMaxLength(250);
            builder.Property(x => x.Genre).HasMaxLength(100).IsRequired();
        }
    }
}
