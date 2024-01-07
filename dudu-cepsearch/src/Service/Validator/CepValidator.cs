using Domain.Entities;
using FluentValidation;

namespace Service.Validator
{
    public class CepValidator : AbstractValidator<CepModel>
    {
        public CepValidator()
        {
            RuleFor(c => c.cep)
                .NotEmpty().WithMessage("Please enter the cep.")
                .NotNull().WithMessage("Please enter the cep.");
        }
    }
}
