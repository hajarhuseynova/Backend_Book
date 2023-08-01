using AutoMapper;
using Book.Core.Entities;
using Book.Service.Dtos.Books;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Service.Profiles.Book
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookPostDto, Books>(); 
            CreateMap<Books, BookGetDto>();
        }
    }
}
