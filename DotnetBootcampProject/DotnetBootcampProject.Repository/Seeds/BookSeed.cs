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
    public class BookSeed : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book { Id = 1, BookName = "Suç ve Ceza" , AuthorName= "Fyodor Dostoyevski", Genre="Psikolojik Roman", PublisherId=3, CreatedDate=DateTime.Now },
                new Book { Id = 2, BookName = "Saatleri Ayarlama Enstitüsü", AuthorName = "Ahmet Hamdi Tanpınar", Genre = "Edebi Kurgu", PublisherId = 1, CreatedDate = DateTime.Now },
                new Book { Id = 3, BookName = "Kara Kule: Silahşör", AuthorName = " Stephen King", Genre = "Bilim Kurgu", PublisherId = 2, CreatedDate = DateTime.Now },
                new Book { Id = 4, BookName = "Kürk Mantolu Madonna", AuthorName = "Sabahattin Ali", Genre = "Edebi Kurgu romanı", PublisherId = 4, CreatedDate = DateTime.Now }
                );
        }
    }
}
