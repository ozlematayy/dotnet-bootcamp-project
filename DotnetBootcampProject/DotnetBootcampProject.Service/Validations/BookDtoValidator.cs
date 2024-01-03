using DotnetBootcampProject.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBootcampProject.Service.Validations
{
    public class BookDtoValidator:AbstractValidator<BookDto>
    {
        public BookDtoValidator()
        {
            RuleFor(x => x.BookName).NotNull().WithMessage("{PropertyName} null olamaz!").NotEmpty().WithMessage("{PropertyName} boş geçilemez!");
            RuleFor(x => x.Genre)
                .NotNull().WithMessage("{PropertyName} null olamaz!")
                .NotEmpty().WithMessage("{PropertyName} boş geçilemez!")
                .MaximumLength(100).WithMessage("En fazla 100 karakter girilebilir!");
        }
    }
}
