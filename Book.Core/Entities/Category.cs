using Book.Core.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Core.Entities
{
    public class Category:BaseModel
    {
        public string Name { get; set; }
        public List<Books>? Books { get; set; }
    }
}
