using Book.Service.Dtos.Books;
using Book.Service.Extentions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Service.Validations.Books
{
	public class BookUpdateDtoValidation : AbstractValidator<BookUpdateDto>
	{
		public BookUpdateDtoValidation()
		{
			RuleFor(x => x.Name)
				.NotNull()
				.NotEmpty()
				.MaximumLength(30);
			RuleFor(x => x).Custom((x, context) =>
			{
				if (!x.File.IsImage())
				{
					context.AddFailure("File", "The file is not valid ");
				}
				if (!x.File.IsSizeOk(2))
				{
					context.AddFailure("File", "The file max length must be 2 mb");
				}
			});
		}
	}
		}
