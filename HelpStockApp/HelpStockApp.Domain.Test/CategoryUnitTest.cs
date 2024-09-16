using FluentAssertions;
using HelpStockApp.Domain.Entities;
using HelpStockApp.Domain.Validation;
using Xunit;

namespace HelpStockApp.Domain.Test
{

    public class CategoryUnitTest
    {
        #region Testes Positivos de Categoria
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParemeters_ResultObjectsValidState()
        {
            Action action = () => new Category(1, "Category name");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Category With Name Alone")]
        public void CreateCategory_WithNameAlone_ResultException()
        {
            Action action = () => new Category("Name");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        #endregion

        #region Teste Negativos de Categoria

        [Fact(DisplayName = "Create Category With Invalid Id")]

        public void CreateCategory_WithInvalidParemetersId_ResultException()
        {
            Action action = () => new Category(-1, "Category name");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id value");
        }


        [Fact(DisplayName = "Create Category With Name Too Short")]
        public void CreateCategory_WithInvalidNameTooShort_ResultException()
        {
            Action action = () => new Category(1, "Ct");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, too short. Minimum 3 characters!");
        }


        [Fact(DisplayName = "Create Category With Name Null")]
        public void CreateCategory_WithNameNull_ResultException()
        {
            Action action = () => new Category(1, null);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required!");
        }

        [Fact(DisplayName = "Create Category With Name Missing")]
        public void CreateCategory_WithNameMissing_ResultException()
        {
            Action action = () => new Category(1, "");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required!");
        }
        #endregion

        /*
         * Create Category With Name Too Short Parameter
         * Create Category With Name Null Parameter
         * Create Category With Name Missing Parameter
         * Create Category With Id Caracter Id
         * Create Category With Parameter Name Alone
         */
    }
}
