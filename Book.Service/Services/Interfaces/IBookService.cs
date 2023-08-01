using Book.Service.Dtos.Books;
using Book.Service.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Service.Services.Interfaces
{
	public interface IBookService
	{
		public Task<ApiResponse> CreateAsync(BookPostDto dto);
		public Task<ApiResponse> UpdateAsync(int id, BookUpdateDto dto);
		public Task<ApiResponse> RemoveAsync(int id);
		public Task<ApiResponse> GetAsync(int id);
		public Task<ApiResponse> GetAllAsync();
	}
}
