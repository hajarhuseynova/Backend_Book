using Book.Service.Dtos.Categories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Service.Validations.Categories
{
    public class CategoryUpdateDtoValidation : AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateDtoValidation()
        {
            RuleFor(x => x.Name)
                   .NotEmpty().WithMessage("Name can not be empty")
                   .NotNull().WithMessage("Name can not be null")
                   .MinimumLength(3)
                   .MaximumLength(30);
     
        }
    }
}
