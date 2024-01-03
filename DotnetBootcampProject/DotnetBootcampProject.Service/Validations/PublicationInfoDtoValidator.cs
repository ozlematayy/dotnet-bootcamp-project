using DotnetBootcampProject.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBootcampProject.Service.Validations
{
    public class PublicationInfoDtoValidator: AbstractValidator<PublicationInfoDto>
    {
        public PublicationInfoDtoValidator()
        {
            RuleFor(x => x.PublicationDate)
                .NotNull().WithMessage("{PropertyName} null olamaz!")
                .NotEmpty().WithMessage("{PropertyName} boş geçilemez!")
                .Must(date => date != DateTime.MinValue).WithMessage("{PropertyName} geçerli bir tarih olmalıdır!");
            RuleFor(x => x.Edition)
                .NotEmpty().WithMessage("{PropertyName} boş olamaz!")
                .Must(edition => int.TryParse(edition.ToString(), out _)).WithMessage("Bu alan sadece sayı olmalı!");
                //.Must(edition => edition.All(char.IsDigit).WithMessage("{PropertyName} alanı bir sayı olmalıdır!");
        }
    }
}
