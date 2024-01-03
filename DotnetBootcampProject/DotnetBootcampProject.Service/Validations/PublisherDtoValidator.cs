using DotnetBootcampProject.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBootcampProject.Service.Validations
{
    public class PublisherDtoValidator: AbstractValidator<PublisherDto>
    {
        public PublisherDtoValidator()
        {
            RuleFor(x => x.PublisherName).NotNull().WithMessage("{PropertyName} null olamaz!").NotEmpty().WithMessage("{PropertyName} boş geçilemez!");
            RuleFor(x => x.City).NotNull().WithMessage("{PropertyName} null olamaz!").NotEmpty().WithMessage("{PropertyName} boş geçilemez!");
            RuleFor(x => x.ContactEmail)
                .NotNull().WithMessage("{PropertyName} null olamaz!")
                .NotEmpty().WithMessage("{PropertyName} boş geçilemez!")
                .EmailAddress().WithMessage("Geçerli bir mail adresi giriniz.");
        }
    }
}
