using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Service.Dtos.Categories
{
    public record CategoryUpdateDto
    {
        public string Name { get; set; } = null!;
    }
}
