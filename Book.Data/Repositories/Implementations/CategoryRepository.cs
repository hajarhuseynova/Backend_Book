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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {

        private readonly BookDbContext _context;

        public CategoryRepository(BookDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
