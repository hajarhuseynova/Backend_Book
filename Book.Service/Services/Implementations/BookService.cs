using AutoMapper;
using Book.Core.Entities;
using Book.Core.Repositories;
using Book.Service.Dtos.Books;
using Book.Service.Extentions;
using Book.Service.Responses;
using Book.Service.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Service.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _http;

        public BookService(IBookRepository bookRepository, ICategoryRepository categoryRepository, IMapper mapper, IWebHostEnvironment env, IHttpContextAccessor http)
        {
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _env = env;
            _http = http;
        }

        public async Task<ApiResponse> CreateAsync(BookPostDto dto)
        {
            if (!await _categoryRepository.IsExsist(x => x.Id == dto.CategoryId))
            {
                return new ApiResponse { StatusCode = 404, Description = "Category Id is invalid" };
            }
            Books book = _mapper.Map<Books>(dto);

            book.Image = dto.File.SaveFile(_env.WebRootPath, "assets/images");
            book.ImageUrl = _http.HttpContext.Request.Scheme + "://" + _http.HttpContext.Request.Host + $"/assets/images/{book.Image}";
            await _bookRepository.AddAsync(book);
            await _bookRepository.SaveAsync();
            return new ApiResponse { StatusCode = 201 };
        }

        public async Task<ApiResponse> GetAllAsync()
        {
            var query = await _bookRepository.GetAllAsync(x => !x.IsDeleted, "Category");

            IEnumerable<BookGetDto> bookGetDtos = await
                query.Select(x => new BookGetDto
                {
                    Image = x.Image,
                    ImageUrl = x.ImageUrl,
                    CategoryId = x.CategoryId,
                    Name = x.Name,
                    Writer = x.Writer
                ,
                    CategoryName = x.Category.Name
                }).ToListAsync();
            return new ApiResponse { StatusCode = 200, Items = bookGetDtos };
        }

        public async Task<ApiResponse> GetAsync(int id)
        {
            Books book = await _bookRepository.GetAsync(x => !x.IsDeleted && x.Id == id, "Category");

            if (book == null)
            {
                return new ApiResponse { StatusCode = 404, Description = "Not found" };
            }

            BookGetDto bookGet = _mapper.Map<BookGetDto>(book);
            bookGet.CategoryName = book.Category.Name;
            return new ApiResponse { StatusCode = 200, Items = bookGet };
        }

        public async Task<ApiResponse> RemoveAsync(int id)
        {
            Books book = await _bookRepository.GetAsync(x => !x.IsDeleted && x.Id == id);

            if (book == null)
            {
                return new ApiResponse { StatusCode = 404, Description = "Not found" };
            }

            book.IsDeleted = true;
            await _bookRepository.Update(book);
            await _bookRepository.SaveAsync();
            return new ApiResponse { StatusCode = 204 };
        }

        public async Task<ApiResponse> UpdateAsync(int id, BookUpdateDto dto)
        {
            Books book = await _bookRepository.GetAsync(x => !x.IsDeleted && x.Id == id);

            if (book == null)
            {
                return new ApiResponse { StatusCode = 404, Description = "Not found" };
            }

            book.Name = dto.Name;
            book.Writer = dto.Writer;
            book.CategoryId = dto.CategoryId;
            book.Image = dto.File == null ? book.Image : dto.File.SaveFile(_env.WebRootPath, "assets/images");
            await _bookRepository.Update(book);
            await _bookRepository.SaveAsync();
            return new ApiResponse { StatusCode = 204 };
        }
    }
}
