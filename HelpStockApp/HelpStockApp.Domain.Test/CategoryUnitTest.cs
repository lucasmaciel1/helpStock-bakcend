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
        #endregion

        #region Teste Negativos de Categoria

        [Fact(DisplayName = "Create Category With Invalid Id")]

        public void CreateCategory_WithInvalidParemetersId_ResultException()
        {
            Action action = () => new Category(-1, "Category name");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id value");
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
