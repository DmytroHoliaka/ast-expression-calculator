using Xunit;

namespace Calculator.Tests.UnitTesting.xUnit
{
    public class LexicalAnalysisTests
    {
        [Fact]
        public void LexicalAnalysisCtor_Null_ThrowsArgumentNullException()
        {
            // Arrange
            string? expression = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new LexicalAnalysis(expression));
        }

        [Fact]
        public void LexicalAnalysisCtor_EmptyExpression_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            string expression = string.Empty;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new LexicalAnalysis(expression));
        }

        [Theory]
        [MemberData(nameof(TestingData.IncorrectTokens), MemberType = typeof(TestingData))]
        public void GetTokens_IncorrectExpression_ThrowsFormatException(string expression)
        {
            // Arrange
            LexicalAnalysis lexer = new(expression);

            // Act & Assert
            Assert.Throws<FormatException>(() => lexer.GetTokens());
        }

        [Theory]
        [MemberData(nameof(TestingData.CorrectTokens), MemberType = typeof(TestingData))]
        public void GetTokens_CorrectExpression_ReturnsTokenList(string expression, List<Token> expected)
        {
            // Arrange
            LexicalAnalysis lexer = new(expression);

            // Act
            List<Token> actual = lexer.GetTokens();

            // Assert
            Assert.Equal(expected, actual);
        }

        private static class TestingData
        {
            public static IEnumerable<object[]> CorrectTokens()
            {
                // ToDo: Write tokens for every expression from ExampleCorrectExpression

                List<Token> TokensForExpression1 = new()
                {
                    new Token(TokenType.Start, null),
                    new Token(TokenType.Number, 1),
                    new Token(TokenType.Plus, null),
                    new Token(TokenType.Number, 2),
                    new Token(TokenType.Multiply, null),
                    new Token(TokenType.Number, 3),
                    new Token(TokenType.Minus, null),
                    new Token(TokenType.LeftBracket, null),
                    new Token(TokenType.Number, 4),
                    new Token(TokenType.Divide, null),
                    new Token(TokenType.Number, 5),
                    new Token(TokenType.Multiply, null),
                    new Token(TokenType.Number, 6),
                    new Token(TokenType.Plus, null),
                    new Token(TokenType.Number, 7),
                    new Token(TokenType.RightBracket, null),
                    new Token(TokenType.Minus, null),
                    new Token(TokenType.Number, 8),
                    new Token(TokenType.Multiply, null),
                    new Token(TokenType.Number, 9),
                    new Token(TokenType.EOF, null)
                };

                List<Token> TokensForExpression2 = new()
                {
                    new Token(TokenType.Start, null),
                    new Token(TokenType.Number, 1),
                    new Token(TokenType.Plus, null),
                    new Token(TokenType.Number, 2),
                    new Token(TokenType.Multiply, null),
                    new Token(TokenType.Number, 3),
                    new Token(TokenType.Minus, null),
                    new Token(TokenType.LeftBracket, null),
                    new Token(TokenType.Number, 4),
                    new Token(TokenType.Divide, null),
                    new Token(TokenType.Number, 5),
                    new Token(TokenType.Multiply, null),
                    new Token(TokenType.Number, 6),
                    new Token(TokenType.Plus, null),
                    new Token(TokenType.Number, 7),
                    new Token(TokenType.RightBracket, null),
                    new Token(TokenType.Minus, null),
                    new Token(TokenType.Number, 8),
                    new Token(TokenType.Multiply, null),
                    new Token(TokenType.Number, 9),
                    new Token(TokenType.EOF, null)
                };

                List<Token> TokensForExpression3 = new()
                {
                    new Token(TokenType.Start, null),
                    new Token(TokenType.Number, 11),
                    new Token(TokenType.Plus, null),
                    new Token(TokenType.Number, 22),
                    new Token(TokenType.Multiply, null),
                    new Token(TokenType.Number, 33),
                    new Token(TokenType.Minus, null),
                    new Token(TokenType.LeftBracket, null),
                    new Token(TokenType.Number, 44),
                    new Token(TokenType.Divide, null),
                    new Token(TokenType.Number, 55),
                    new Token(TokenType.Multiply, null),
                    new Token(TokenType.Number, 66),
                    new Token(TokenType.Plus, null),
                    new Token(TokenType.Number, 77),
                    new Token(TokenType.RightBracket, null),
                    new Token(TokenType.Minus, null),
                    new Token(TokenType.Number, 88),
                    new Token(TokenType.Multiply, null),
                    new Token(TokenType.Number, 99),
                    new Token(TokenType.EOF, null)
                };

                List<Token> TokensForExpression4 = new()
                {
                    new Token(TokenType.Start, null),
                    new Token(TokenType.Number, 111),
                    new Token(TokenType.Plus, null),
                    new Token(TokenType.Number, 222),
                    new Token(TokenType.Multiply, null),
                    new Token(TokenType.Number, 333),
                    new Token(TokenType.Minus, null),
                    new Token(TokenType.LeftBracket, null),
                    new Token(TokenType.Number, 444),
                    new Token(TokenType.Divide, null),
                    new Token(TokenType.Number, 555),
                    new Token(TokenType.Multiply, null),
                    new Token(TokenType.Number, 666),
                    new Token(TokenType.Plus, null),
                    new Token(TokenType.Number, 777),
                    new Token(TokenType.RightBracket, null),
                    new Token(TokenType.Minus, null),
                    new Token(TokenType.Number, 888),
                    new Token(TokenType.Multiply, null),
                    new Token(TokenType.Number, 999),
                    new Token(TokenType.EOF, null)
                };

                List<Token> TokensForExpression5 = new()
                {
                    new Token(TokenType.Start, null),
                    new Token(TokenType.Number, 1.5),
                    new Token(TokenType.Plus, null),
                    new Token(TokenType.Number, 2.8),
                    new Token(TokenType.Multiply, null),
                    new Token(TokenType.Number, 3.45),
                    new Token(TokenType.Minus, null),
                    new Token(TokenType.LeftBracket, null),
                    new Token(TokenType.Number, 4.23),
                    new Token(TokenType.Divide, null),
                    new Token(TokenType.Number, 5.78),
                    new Token(TokenType.Multiply, null),
                    new Token(TokenType.Number, 6.91),
                    new Token(TokenType.Plus, null),
                    new Token(TokenType.Number, 7.56),
                    new Token(TokenType.RightBracket, null),
                    new Token(TokenType.Minus, null),
                    new Token(TokenType.Number, 8.90),
                    new Token(TokenType.Multiply, null),
                    new Token(TokenType.Number, 9.12),
                    new Token(TokenType.EOF, null)
                };

                List<Token> TokensForExpression6 = new()
                {
                    new Token(TokenType.Start, null),
                    new Token(TokenType.Number, 12.45),
                    new Token(TokenType.Plus, null),
                    new Token(TokenType.Number, 23.65),
                    new Token(TokenType.Multiply, null),
                    new Token(TokenType.Number, 37.81),
                    new Token(TokenType.Minus, null),
                    new Token(TokenType.LeftBracket, null),
                    new Token(TokenType.Number, 45.98),
                    new Token(TokenType.Divide, null),
                    new Token(TokenType.Number, 51.67),
                    new Token(TokenType.Multiply, null),
                    new Token(TokenType.Number, 68.20),
                    new Token(TokenType.Plus, null),
                    new Token(TokenType.Number, 77.23),
                    new Token(TokenType.RightBracket, null),
                    new Token(TokenType.Minus, null),
                    new Token(TokenType.Number, 80.12),
                    new Token(TokenType.Multiply, null),
                    new Token(TokenType.Number, 99.32),
                    new Token(TokenType.EOF, null)
                };

                List<Token> TokensForExpression7 = new()
                {
                    new Token(TokenType.Start, null),
                    new Token(TokenType.Number, 152.415),
                    new Token(TokenType.Plus, null),
                    new Token(TokenType.Number, 233.645),
                    new Token(TokenType.Multiply, null),
                    new Token(TokenType.Number, 357.821),
                    new Token(TokenType.Minus, null),
                    new Token(TokenType.LeftBracket, null),
                    new Token(TokenType.Number, 453.918),
                    new Token(TokenType.Divide, null),
                    new Token(TokenType.Number, 561.687),
                    new Token(TokenType.Multiply, null),
                    new Token(TokenType.Number, 638.260),
                    new Token(TokenType.Plus, null),
                    new Token(TokenType.Number, 717.263),
                    new Token(TokenType.RightBracket, null),
                    new Token(TokenType.Minus, null),
                    new Token(TokenType.Number, 820.142),
                    new Token(TokenType.Multiply, null),
                    new Token(TokenType.Number, 969.312),
                    new Token(TokenType.EOF, null)
                };

                List<Token> TokensForExpression8 = new()
                {
                    new Token(TokenType.Start, null),
                    new Token(TokenType.Number, 0.45),
                    new Token(TokenType.Multiply, null),
                    new Token(TokenType.Number, 0.97),
                    new Token(TokenType.Divide, null),
                    new Token(TokenType.Number, 0.32),
                    new Token(TokenType.LeftBracket, null),
                    new Token(TokenType.Number, 0.56),
                    new Token(TokenType.Plus, null),
                    new Token(TokenType.Number, 0.78),
                    new Token(TokenType.Minus, null),
                    new Token(TokenType.Number, 0.56),
                    new Token(TokenType.RightBracket, null),
                    new Token(TokenType.EOF, null)
                };

                List<Token> TokensForExpression9 = new()
                {
                    new Token(TokenType.Start, null),
                    new Token(TokenType.Number, 0.45),
                    new Token(TokenType.Multiply, null),
                    new Token(TokenType.Number, 0.97),
                    new Token(TokenType.Divide, null),
                    new Token(TokenType.Number, 0.32),
                    new Token(TokenType.LeftBracket, null),
                    new Token(TokenType.Number, 0.56),
                    new Token(TokenType.Plus, null),
                    new Token(TokenType.Number, 0.78),
                    new Token(TokenType.Minus, null),
                    new Token(TokenType.Number, 0.56),
                    new Token(TokenType.RightBracket, null),
                    new Token(TokenType.EOF, null)
                };

                List<Token> TokensForExpression10 = new()
                {
                    new Token(TokenType.Start, null),
                    new Token(TokenType.Number, -124.6789),
                    new Token(TokenType.Plus, null),
                    new Token(TokenType.Number, 245),
                    new Token(TokenType.Multiply, null),
                    new Token(TokenType.Number, -367.1234),
                    new Token(TokenType.Minus, null),
                    new Token(TokenType.LeftBracket, null),
                    new Token(TokenType.Number, -4567.1233),
                    new Token(TokenType.Divide, null),
                    new Token(TokenType.Number, 4),
                    new Token(TokenType.Multiply, null),
                    new Token(TokenType.Number, -90.25),
                    new Token(TokenType.Plus, null),
                    new Token(TokenType.Number, -0.6753),
                    new Token(TokenType.RightBracket, null),
                    new Token(TokenType.Minus, null),
                    new Token(TokenType.Number, -445.56),
                    new Token(TokenType.Multiply, null),
                    new Token(TokenType.Number, .2),
                    new Token(TokenType.EOF, null)
                };

                List<Token> TokensForExpression11 = new()
                {
                    new Token(TokenType.Start, null),
                    new Token(TokenType.LeftBracket, null),
                    new Token(TokenType.Number, -124.6789),
                    new Token(TokenType.RightBracket, null),
                    new Token(TokenType.Plus, null),
                    new Token(TokenType.Number, 245),
                    new Token(TokenType.Multiply, null),
                    new Token(TokenType.LeftBracket, null),
                    new Token(TokenType.Number, -367.1234),
                    new Token(TokenType.RightBracket, null),
                    new Token(TokenType.Minus, null),
                    new Token(TokenType.LeftBracket, null),
                    new Token(TokenType.LeftBracket, null),
                    new Token(TokenType.Number, -4567.1233),
                    new Token(TokenType.RightBracket, null),
                    new Token(TokenType.Divide, null),
                    new Token(TokenType.Number, 4),
                    new Token(TokenType.Multiply, null),
                    new Token(TokenType.LeftBracket, null),
                    new Token(TokenType.Number, -90.25),
                    new Token(TokenType.RightBracket, null),
                    new Token(TokenType.Plus, null),
                    new Token(TokenType.LeftBracket, null),
                    new Token(TokenType.Number, -0.6753),
                    new Token(TokenType.RightBracket, null),
                    new Token(TokenType.RightBracket, null),
                    new Token(TokenType.Minus, null),
                    new Token(TokenType.LeftBracket, null),
                    new Token(TokenType.Number, -445.56),
                    new Token(TokenType.RightBracket, null),
                    new Token(TokenType.Multiply, null),
                    new Token(TokenType.Number, .2),
                    new Token(TokenType.EOF, null)
                };

                List<Token> TokensForExpression12 = new()
                {
                    new Token(TokenType.Start, null),
                    new Token(TokenType.Number, 1),
                    new Token(TokenType.EOF, null)
                };

                List<Token> TokensForExpression13 = new()
                {
                    new Token(TokenType.Start, null),
                    new Token(TokenType.Number, -1),
                    new Token(TokenType.EOF, null)
                };

                List<Token> TokensForExpression14 = new()
                {
                    new Token(TokenType.Start, null),
                    new Token(TokenType.Number, 1),
                    new Token(TokenType.Minus, null),
                    new Token(TokenType.Number, 2),
                    new Token(TokenType.EOF, null)
                };

                List<Token> TokensForExpression15 = new()
                {
                    new Token(TokenType.Start, null),
                    new Token(TokenType.Number, 1),
                    new Token(TokenType.Minus, null),
                    new Token(TokenType.Number, -2),
                    new Token(TokenType.EOF, null)
                };

                List<Token> TokensForExpression16 = new()
                {
                    new Token(TokenType.Start, null),
                    new Token(TokenType.Number, 1),
                    new Token(TokenType.EOF, null)
                };

                List<Token> TokensForExpression17 = new()
                {
                    new Token(TokenType.Start, null),
                    new Token(TokenType.Number, 1),
                    new Token(TokenType.EOF, null)
                };

                List<Token> TokensForExpression18 = new()
                {
                    new Token(TokenType.Start, null),
                    new Token(TokenType.Number, 1),
                    new Token(TokenType.Minus, null),
                    new Token(TokenType.Number, 2),
                    new Token(TokenType.EOF, null)
                };

                List<Token> TokensForExpression19 = new()
                {
                    new Token(TokenType.Start, null),
                    new Token(TokenType.Number, 1),
                    new Token(TokenType.Plus, null),
                    new Token(TokenType.Number, 2),
                    new Token(TokenType.EOF, null)
                };

                List<Token> TokensForExpression20 = new()
                {
                    new Token(TokenType.Start, null),
                    new Token(TokenType.Number, 1),
                    new Token(TokenType.Plus, null),
                    new Token(TokenType.Number, -2),
                    new Token(TokenType.EOF, null)
                };

                List<Token> TokensForExpression21 = new()
                {
                    new Token(TokenType.Start, null),
                    new Token(TokenType.Number, 1),
                    new Token(TokenType.Multiply, null),
                    new Token(TokenType.Number, 2),
                    new Token(TokenType.EOF, null)
                };

                List<Token> TokensForExpression22 = new()
                {
                    new Token(TokenType.Start, null),
                    new Token(TokenType.Number, 1),
                    new Token(TokenType.Multiply, null),
                    new Token(TokenType.Number, -2),
                    new Token(TokenType.EOF, null)
                };

                List<Token> TokensForExpression23 = new()
                {
                    new Token(TokenType.Start, null),
                    new Token(TokenType.Number, 1),
                    new Token(TokenType.Divide, null),
                    new Token(TokenType.Number, 2),
                    new Token(TokenType.EOF, null)
                };

                List<Token> TokensForExpression24 = new()
                {
                    new Token(TokenType.Start, null),
                    new Token(TokenType.Number, 1),
                    new Token(TokenType.Divide, null),
                    new Token(TokenType.Number, -2),
                    new Token(TokenType.EOF, null)
                };

                List<Token> TokensForExpression25 = new()
                {
                    new Token(TokenType.Start, null),
                    new Token(TokenType.Number, 1),
                    new Token(TokenType.Multiply, null),
                    new Token(TokenType.Number, 2),
                    new Token(TokenType.EOF, null)
                };

                List<Token> TokensForExpression26 = new()
                {
                    new Token(TokenType.Start, null),
                    new Token(TokenType.Number, 1),
                    new Token(TokenType.Multiply, null),
                    new Token(TokenType.Number, 2),
                    new Token(TokenType.EOF, null)
                };

                List<Token> TokensForExpression27 = new()
                {
                    new Token(TokenType.Start, null),
                    new Token(TokenType.Number, 1),
                    new Token(TokenType.Multiply, null),
                    new Token(TokenType.Number, -2),
                    new Token(TokenType.EOF, null)
                };

                List<Token> TokensForExpression28 = new()
                {
                    new Token(TokenType.Start, null),
                    new Token(TokenType.Number, 1),
                    new Token(TokenType.Divide, null),
                    new Token(TokenType.Number, 2),
                    new Token(TokenType.EOF, null)
                };

                List<Token> TokensForExpression29 = new()
                {
                    new Token(TokenType.Start, null),
                    new Token(TokenType.Number, 1),
                    new Token(TokenType.Divide, null),
                    new Token(TokenType.Number, 2),
                    new Token(TokenType.EOF, null)
                };

                List<Token> TokensForExpression30 = new()
                {
                    new Token(TokenType.Start, null),
                    new Token(TokenType.Number, 1),
                    new Token(TokenType.Divide, null),
                    new Token(TokenType.Number, -2),
                    new Token(TokenType.EOF, null)
                };

                List<Token> TokensForExpression31 = new()
                {
                    new Token(TokenType.Start, null),
                    new Token(TokenType.Number, 1),
                    new Token(TokenType.Multiply, null),
                    new Token(TokenType.Number, -2),
                    new Token(TokenType.EOF, null)
                };

                List<Token> TokensForExpression32 = new()
                {
                    new Token(TokenType.Start, null),
                    new Token(TokenType.Number, 1),
                    new Token(TokenType.Multiply, null),
                    new Token(TokenType.Number, 2),
                    new Token(TokenType.EOF, null)
                };

                List<Token> TokensForExpression33 = new()
                {
                    new Token(TokenType.Start, null),
                    new Token(TokenType.Number, 1),
                    new Token(TokenType.Divide, null),
                    new Token(TokenType.Number, -2),
                    new Token(TokenType.EOF, null)
                };

                List<Token> TokensForExpression34 = new()
                {
                    new Token(TokenType.Start, null),
                    new Token(TokenType.Number, 1),
                    new Token(TokenType.Divide, null),
                    new Token(TokenType.Number, 2),
                    new Token(TokenType.EOF, null)
                };

                List<Token> TokensForExpression35 = new()
                {
                    new Token(TokenType.Start, null),
                    new Token(TokenType.Number, 1),
                    new Token(TokenType.Multiply, null),
                    new Token(TokenType.Number, 2),
                    new Token(TokenType.EOF, null)
                };

                List<Token> TokensForExpression36 = new()
                {
                    new Token(TokenType.Start, null),
                    new Token(TokenType.Number, 1),
                    new Token(TokenType.Multiply, null),
                    new Token(TokenType.Number, -2),
                    new Token(TokenType.Divide, null),
                    new Token(TokenType.Number, 3),
                    new Token(TokenType.EOF, null)
                };

                List<Token> TokensForExpression37 = new()
                {
                    new Token(TokenType.Start, null),
                    new Token(TokenType.Number, 1),
                    new Token(TokenType.Multiply, null),
                    new Token(TokenType.Number, 2),
                    new Token(TokenType.Divide, null),
                    new Token(TokenType.Number, 3),
                    new Token(TokenType.EOF, null)
                };

                List<Token> TokensForExpression38 = new()
                {
                    new Token(TokenType.Start, null),
                    new Token(TokenType.Number, 1),
                    new Token(TokenType.Multiply, null),
                    new Token(TokenType.Number, 2),
                    new Token(TokenType.Divide, null),
                    new Token(TokenType.Number, 3),
                    new Token(TokenType.EOF, null)
                };


                return new List<object[]>()
                {
                    new object[] {ExampleCorrectExpression.Expression1, TokensForExpression1},
                    new object[] {ExampleCorrectExpression.Expression2, TokensForExpression2},
                    new object[] {ExampleCorrectExpression.Expression3, TokensForExpression3},
                    new object[] {ExampleCorrectExpression.Expression4, TokensForExpression4},
                    new object[] {ExampleCorrectExpression.Expression5, TokensForExpression5},
                    new object[] {ExampleCorrectExpression.Expression6, TokensForExpression6},
                    new object[] {ExampleCorrectExpression.Expression7, TokensForExpression7},
                    new object[] {ExampleCorrectExpression.Expression8, TokensForExpression8},
                    new object[] {ExampleCorrectExpression.Expression9, TokensForExpression9},
                    new object[] {ExampleCorrectExpression.Expression10, TokensForExpression10},
                    new object[] {ExampleCorrectExpression.Expression11, TokensForExpression11},
                    new object[] {ExampleCorrectExpression.Expression12, TokensForExpression12},
                    new object[] {ExampleCorrectExpression.Expression13, TokensForExpression13},
                    new object[] {ExampleCorrectExpression.Expression14, TokensForExpression14},
                    new object[] {ExampleCorrectExpression.Expression15, TokensForExpression15},
                    new object[] {ExampleCorrectExpression.Expression16, TokensForExpression16},
                    new object[] {ExampleCorrectExpression.Expression17, TokensForExpression17},
                    new object[] {ExampleCorrectExpression.Expression18, TokensForExpression18},
                    new object[] {ExampleCorrectExpression.Expression19, TokensForExpression19},
                    new object[] {ExampleCorrectExpression.Expression20, TokensForExpression20},
                    new object[] {ExampleCorrectExpression.Expression21, TokensForExpression21},
                    new object[] {ExampleCorrectExpression.Expression22, TokensForExpression22},
                    new object[] {ExampleCorrectExpression.Expression23, TokensForExpression23},
                    new object[] {ExampleCorrectExpression.Expression24, TokensForExpression24},
                    new object[] {ExampleCorrectExpression.Expression25, TokensForExpression25},
                    new object[] {ExampleCorrectExpression.Expression26, TokensForExpression26},
                    new object[] {ExampleCorrectExpression.Expression27, TokensForExpression27},
                    new object[] {ExampleCorrectExpression.Expression28, TokensForExpression28},
                    new object[] {ExampleCorrectExpression.Expression29, TokensForExpression29},
                    new object[] {ExampleCorrectExpression.Expression30, TokensForExpression30},
                    new object[] {ExampleCorrectExpression.Expression31, TokensForExpression31},
                    new object[] {ExampleCorrectExpression.Expression32, TokensForExpression32},
                    new object[] {ExampleCorrectExpression.Expression33, TokensForExpression33},
                    new object[] {ExampleCorrectExpression.Expression34, TokensForExpression34},
                    new object[] {ExampleCorrectExpression.Expression35, TokensForExpression35},
                    new object[] {ExampleCorrectExpression.Expression36, TokensForExpression36},
                    new object[] {ExampleCorrectExpression.Expression37, TokensForExpression37},
                    new object[] {ExampleCorrectExpression.Expression38, TokensForExpression38},
                };
            }

            public static IEnumerable<object[]> IncorrectTokens()
            {
                return new List<object[]>()
                {
                    new object[] {ExampleIncorrectExpression.Expression1},
                    new object[] {ExampleIncorrectExpression.Expression2},
                    new object[] {ExampleIncorrectExpression.Expression3},
                    new object[] {ExampleIncorrectExpression.Expression4},
                    new object[] {ExampleIncorrectExpression.Expression5},
                    new object[] {ExampleIncorrectExpression.Expression6},
                    new object[] {ExampleIncorrectExpression.Expression7},
                    new object[] {ExampleIncorrectExpression.Expression8},
                    new object[] {ExampleIncorrectExpression.Expression9},
                    new object[] {ExampleIncorrectExpression.Expression10},
                    new object[] {ExampleIncorrectExpression.Expression11},
                    new object[] {ExampleIncorrectExpression.Expression12},
                    new object[] {ExampleIncorrectExpression.Expression13},
                    new object[] {ExampleIncorrectExpression.Expression14},
                    new object[] {ExampleIncorrectExpression.Expression15},
                    new object[] {ExampleIncorrectExpression.Expression16},
                    new object[] {ExampleIncorrectExpression.Expression17},
                    new object[] {ExampleIncorrectExpression.Expression18},
                    new object[] {ExampleIncorrectExpression.Expression19},
                    new object[] {ExampleIncorrectExpression.Expression20},
                    new object[] {ExampleIncorrectExpression.Expression21},
                    new object[] {ExampleIncorrectExpression.Expression22},
                    new object[] {ExampleIncorrectExpression.Expression23},
                    new object[] {ExampleIncorrectExpression.Expression24},
                    new object[] {ExampleIncorrectExpression.Expression25},
                };
            }
        }
    }
}