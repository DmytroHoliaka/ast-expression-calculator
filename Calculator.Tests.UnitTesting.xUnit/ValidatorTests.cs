using Calculator.Services;
using Calculator.TokenManagement;
using Xunit;

namespace Calculator.Tests.UnitTesting.xUnit
{
    public class ValidatorTests
    {
        [Theory]
        [InlineData("1+2-")]
        [InlineData("1+2+")]
        [InlineData("1+2*")]
        [InlineData("1+2/")]
        [InlineData("1+2(")]
        [InlineData("1+2)")]
        [InlineData("(1+2")]
        [InlineData("(1+(2-3)")]
        [InlineData("1-*2")]
        [InlineData("1+*2")]
        public void IsTokensValid_IncorrectTokens_ReturnsFalse(string expression)
        {
            // Arrage
            LexicalAnalysis lexer = new(expression);
            List<Token> tokens = lexer.GetTokens();

            // Act
            bool actual = Validator.IsTokensValid(tokens);

            // Asert
            Assert.False(actual);
        }

        [Theory]
        [InlineData("1+2")]
        [InlineData("1-2")]
        [InlineData("1*2")]
        [InlineData("1/2")]
        [InlineData("(1+2)")]
        [InlineData("((1+2))")]
        [InlineData("(1+(2-3))")]
        [InlineData("(1+2)*3")]
        [InlineData("1+(2*3)")]
        [InlineData("1+2-3*5/5")]
        [InlineData("1-(-2)")]
        public void IsTokensValid_CorrectTokens_ReturnsTrue(string expression)
        {
            // Arrage
            LexicalAnalysis lexer = new(expression);
            List<Token> tokens = lexer.GetTokens();

            // Act
            bool actual = Validator.IsTokensValid(tokens);

            // Asert
            Assert.True(actual);
        }
    }
}
