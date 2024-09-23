using FluentAssertions;
using HelpStockApp.Domain.Entities;
using HelpStockApp.Domain.Validation;
using Xunit;

namespace HelpStockApp.Domain.Test
{
    public class ProductUnitTest
    {

        #region Testes Positivos de Produto

        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidParemeters_ResultObjectsValidState()
        {
            Action action = () => new Product(1, "Notebook", "Notebook Intel I7 13° Geração", 5799, 12, "https://imagenotebooki7.png");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With No Id")]
        public void CreateCategory_WithNameAlone_ResultException()
        {
            Action action = () => new Product("Notebook", "Notebook Intel I7 13° Geração", 5799, 12, "https://imagenotebooki7.png");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        #endregion



        #region Testes Negativos de Produto

        [Fact(DisplayName = "Create Product With Invalid Id")]
        public void CreateProduct_WithInvalidParemetersId_ResultException()
        {
            Action action = () => new Product(-1, "Notebook", "Notebook Intel I7 13° Geração", 5799, 12, "https://imagenotebooki7.png");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id value");
        }

        [Fact(DisplayName = "Create Product With Invalid Name")]
        public void CreateProduct_WithInvalidName_ResultException()
        {
            Action action = () => new Product(1, "", "Notebook Intel I7 13° Geração", 5799, 12, "https://imagenotebooki7.png");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required!");
        }


        [Fact(DisplayName = "Create Product With Null Name")]
        public void CreateProduct_WithNullName_ResultException()
        {
            Action action = () => new Product(1, null, "Notebook Intel I7 13° Geração", 5799, 12, "https://imagenotebooki7.png");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required!");
        }


        [Fact(DisplayName = "Create Product With Too Short Name")]
        public void CreateProduct_WithTooShortName_ResultException()
        {
            Action action = () => new Product(1, "Nt", "Notebook Intel I7 13° Geração", 5799, 12, "https://imagenotebooki7.png");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, too short. Minimum 3 characters!");
        }



        [Fact(DisplayName = "Create Product With Long Image")]
        public void CreateProduct_WithLongImage_ResultException()
        {
            Action action = () => new Product
            (
                1,
                "Notebook",
                "Notebook Intel I7 13° Geração",
                5799,
                12,
                "https://imageeeeeeeeeeeeeeeeeeeeeeeenoteeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeboooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooookkkkkkki7777777777777777777777777777777777777777777.png"
            );
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid URL image, too long. Maximum 250 characters");
        }

        [Fact(DisplayName = "Create Product With Null Image")]
        public void CreateProduct_WithNullImage_ResultException()
        {
            Action action = () => new Product(1, "Notebook", "Notebook Intel I7 13° Geração", 5799, 12, null);
            action.Should().Throw<System.NullReferenceException>();
                //.WithMessage("Image is null, image is required!");
        }

        [Fact(DisplayName = "Create Product With Alone Image")]
        public void CreateProduct_WithAloneImage_ResultException()
        {
            Action action = () => new Product(1, "Notebook", "Notebook Intel I7 13° Geração", 5799, 12, "");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid image, image is required!");
        }

        [Fact(DisplayName = "Create Product Negative Stock")]
        public void CreateProduct_WithNegativeStock_ResultException()
        {
            Action action = () => new Product(1, "Notebook", "Notebook Intel I7 13° Geração", 5799, -12, "https://imagenotebooki7.png");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid stock, stock cannot be negative");
        }

        [Fact(DisplayName = "Create Product Negative Price")]
        public void CreateProduct_WithNegativePrice_ResultException()
        {
            Action action = () => new Product(1, "Notebook", "Notebook Intel I7 13° Geração", -5799, 12, "https://imagenotebooki7.png");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Price, price negative value is unlikel.");
        }


        [Fact(DisplayName = "Create Product With Too Short Description")]
        public void CreateProduct_WithTooShortDescription_ResultException()
        {
            Action action = () => new Product(1, "Notebook", "Ntbk", 5799, 12, "https://imagenotebooki7.png");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Description, too short. Minimum 5 characters!");
        }

        [Fact(DisplayName = "Create Product With Empty Description")]
        public void CreateProduct_WithEmptyDescription_ResultException()
        {
            Action action = () => new Product(1, "Notebook", string.Empty, 5799, 12, "https://imagenotebooki7.png");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid description, description is required!");
        }

        [Fact(DisplayName = "Create Product With Null Description")]
        public void CreateProduct_WithNullDescription_ResultException()
        {
            Action action = () => new Product(1, "Notebook", null, 5799, 12, "https://imagenotebooki7.png");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid description, description is required!");
        }


        #endregion
    }
}
