using FluentValidation;
using YemekSepetiProje.Entitys;

namespace YemekSepeti.Validators
{
	public class CustomerValidator:AbstractValidator<Customer>
	{
        public CustomerValidator()
        {
			RuleFor(x => x.FirstName).NotNull();
			RuleFor(x => x.LastName).NotNull();
			RuleFor(x => x.Email).EmailAddress().NotNull();
			RuleFor(x => x.Password).MaximumLength(12).NotNull();

		}
    }
}
