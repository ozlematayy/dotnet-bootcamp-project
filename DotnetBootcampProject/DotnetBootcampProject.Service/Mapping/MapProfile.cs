using AutoMapper;
using DotnetBootcampProject.Core.DTOs;
using DotnetBootcampProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBootcampProject.Service.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Publisher, PublisherDto>().ReverseMap();
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<PublicationInfo, PublicationInfoDto>().ReverseMap();

            CreateMap<PublisherDto, Publisher>();
            CreateMap<BookDto, Book>();
            CreateMap<PublicationInfoDto, PublicationInfo>();
        }
    }
}
