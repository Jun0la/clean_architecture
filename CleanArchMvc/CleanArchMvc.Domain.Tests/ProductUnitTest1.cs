using CleanArchMvc.Domain.entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;


namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Valid State")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 9, "product image");
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }
        [Fact(DisplayName = "Invalid ID")]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 9.99m, 99, "product image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid ID value");
        }
        [Fact(DisplayName = "ShortName")]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr", "Product Description", 9.99m, 99, "product image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name, mínimo 3 caracteres");
        }
        [Fact(DisplayName = "LongName")]
        public void CreateProduct_LongNameValue_DomainExceptionLongName()
        {
            Action action = () => new Product(1, "Product", "Product Description", 9.99m, 99, "Img to Loooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooongooooooo");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid image name, too long, maximum 250 characters");
        }
        [Fact(DisplayName = "NullName")]
        public void CreateProduct_WithNullImageValue_DomainExceptionImageValue()
        {
            Action action = () => new Product(1, "Product", "Product Description", 9.99m, 99, null);
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }
        [Fact(DisplayName = "EmptyName")]
        public void CreateProduct_WithEmptyNameValue_DomainExceptionImageValue()
        {
            Action action = () => new Product(1, "Product", "Product Description", 9.99m, 99, "");
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }
        [Fact(DisplayName = "NegativePrice")]
        public void CreateProduct_WithNegativeValue_DomainExceptionValue()
        {
            Action action = () => new Product(1, "Product", "Product Description", -9.99m, 99, "");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid price value");
        }

        /*
        [Theory]
        [InlineData(-5)]
        public void CreateProduct_InvalidStockValue_DomainExceptionStockValue(int value)
        {
            Action action = () => new Product(1, "Pro", "Product Description", 9.99m, 99, "product image", value);
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().("Invalid name, mínimo 3 caracteres");
        }
        */
    }
}   
    