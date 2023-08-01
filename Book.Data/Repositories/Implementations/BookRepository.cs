using Book.Core.Entities;
using Book.Core.Repositories;
using Book.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Data.Repositories.Implementations
{
	public class BookRepository : Repository<Books>, IBookRepository
	{
        private readonly BookDbContext _context;

        public BookRepository(BookDbContext context) : base(context)
        {

        }
    }
}
