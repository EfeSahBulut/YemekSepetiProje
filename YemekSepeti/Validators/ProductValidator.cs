using FluentValidation;
using YemekSepetiProje.Entities;

namespace YemekSepeti.Validators
{
	public class ProductValidator:AbstractValidator<Product>
	{
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotNull().WithMessage("Ürün Isimi Boş Olamaz!");
            RuleFor(x => x.ProductCategory).NotNull().WithMessage("Kategori Boş Olamaz!");
            RuleFor(x => x.UnitPrice).NotNull().WithMessage("Ürün Fiyatı Boş Olamaz!");
        }
    }
}
