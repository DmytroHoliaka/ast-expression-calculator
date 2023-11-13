using Xunit;

namespace Calculator
{
    public class ParserTests
    {
        [Theory]
        [InlineData("1/0")]
        [InlineData("1+2/0")]
        [InlineData("1*2+3/0")]
        [InlineData("1/(2*5-10)")]
        [InlineData("1*3-4/(2*5-10)")]
        [InlineData("1*3-4/(-2*5+10)-8")]
        public void GetValue_DividingByZeroExpression_ThrowsDivideByZeroException(string expression)
        {
            // Arrange
            LexicalAnalysis lexer = new(expression);
            List<Token> tokens = lexer.GetTokens();
            Parser parser = new(tokens);

            // Assert
            Assert.Throws<DivideByZeroException>(() => parser.GetValue());
        }

        [Theory]
        [InlineData("1(*)2")]
        [InlineData("1(/)2")]
        [InlineData("(1)(2)")]
        public void GetValue_IncorrectExpression_ThrowsFormatException(string expression)
        {
            // Arrange
            LexicalAnalysis lexer = new(expression);
            List<Token> tokens = lexer.GetTokens();
            Parser parser = new(tokens);

            // Assert
            Assert.Throws<FormatException>(() => parser.GetValue());
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("1+2", 3)]
        [InlineData("1-2", -1)]
        [InlineData("1*2", 2)]
        [InlineData("1/2", 0.5)]
        [InlineData("2+2*2", 6)]
        [InlineData("(2+2)*2", 8)]
        [InlineData("(2+2)/2", 2)]
        [InlineData("(2+2)/2+(2+2)*2", 10)]
        [InlineData("-1", -1)]
        [InlineData("-1+-2", -3)]
        [InlineData("-1+(-2)", -3)]
        [InlineData("1--2", 3)]
        [InlineData("1-(-2)", 3)]
        [InlineData("1*-2", -2)]
        [InlineData("-1/2", -0.5)]
        [InlineData("2+2*-2", -2)]
        [InlineData("(2+2)*-2", -8)]
        [InlineData("(2+2)/-2", -2)]
        [InlineData("(2+2)/-2+(2+2)*-2", -10)]
        public void GetValue_CorrectExpression_ReturnsExpressionResult(string expression, double expected)
        {
            // Arrange
            LexicalAnalysis lexer = new(expression);
            List<Token> tokens = lexer.GetTokens();
            Parser parser = new(tokens);

            // Act
            double actual = parser.GetValue();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
