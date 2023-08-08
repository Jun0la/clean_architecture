using CleanArchMvc.Domain.entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Invalid ID")]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid ID.");
        }

        [Fact(DisplayName = "ShortType")]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Category(1, "XD");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid Name");
        }

        [Fact(DisplayName = "Empty")]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Category(1, "");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid Name, field is required.");
        }
        [Fact(DisplayName = "Null")]
        public void CreateCategory_NullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, null);
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("");
        }
    }
}