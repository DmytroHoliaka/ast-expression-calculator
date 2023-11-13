using System.Text;

namespace Calculator
{
    public class LexicalAnalysis
    {
        public string Expression { get; init; }

        private char _currChar;
        private int _currIndex;

        public LexicalAnalysis(string? inputExpression)
        {
            if (inputExpression is null)
            {
                throw new ArgumentNullException(nameof(inputExpression), "Input expression cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(inputExpression))
            {
                throw new ArgumentOutOfRangeException(nameof(inputExpression), "Input expression cannot be empty or having only spaces.");
            }

            Expression = new string(inputExpression!.Where(ch => ch != Symbol.Space).ToArray());
            _currIndex = 0;
            _currChar = Expression[0];
        }   

        public List<Token> GetTokens()
        {
            List<Token> tokens = new() { new Token(TokenType.Start, null) };

            while (_currChar != Symbol.EOF)
            {
                if (Char.IsDigit(_currChar) || _currChar == Symbol.Point)
                {
                    double number = GetNextNumber();
                    tokens.Add(new Token(TokenType.Number, number));
                    continue;
                }

                switch (_currChar)
                {
                    case Symbol.Plus:
                        char[] positiveNumberSignals = new char[]
                        {
                            Symbol.Start,
                            Symbol.Plus,
                            Symbol.Minus,
                            Symbol.Multiply,
                            Symbol.Divide,
                            Symbol.LeftBracket
                        };

                        GoToPreviousChar();

                        if (positiveNumberSignals.Contains(_currChar))
                        {
                            GoToNextChar();

                            double positiveNumber = GetNextNumber();
                            tokens.Add(new Token(TokenType.Number, positiveNumber));

                            GoToPreviousChar();
                            break;
                        }

                        GoToNextChar();
                        tokens.Add(new Token(TokenType.Plus, null));
                        break;

                    case Symbol.Minus:
                        char[] negativeNumberSignals = new char[]
                        {
                            Symbol.Start,
                            Symbol.Plus,
                            Symbol.Minus,
                            Symbol.Multiply,
                            Symbol.Divide,
                            Symbol.LeftBracket
                        };

                        GoToPreviousChar();

                        if (negativeNumberSignals.Contains(_currChar))
                        {
                            GoToNextChar();

                            double negativeNumber = GetNextNumber();
                            tokens.Add(new Token(TokenType.Number, negativeNumber));

                            GoToPreviousChar();
                            break;
                        }

                        GoToNextChar();

                        if (_currChar == Symbol.EOF)
                        {
                            throw new FormatException("Expression have incorrect format");
                        }

                        tokens.Add(new Token(TokenType.Minus, null));
                        break;

                    case Symbol.Multiply:
                        tokens.Add(new Token(TokenType.Multiply, null));
                        break;

                    case Symbol.Divide:
                        tokens.Add(new Token(TokenType.Divide, null));
                        break;

                    case Symbol.LeftBracket:
                        tokens.Add(new Token(TokenType.LeftBracket, null));
                        break;

                    case Symbol.RightBracket:
                        tokens.Add(new Token(TokenType.RightBracket, null));
                        break;

                    default:
                        throw new FormatException("Input expression has incorrect symbol");
                }

                GoToNextChar();
            }

            tokens.Add(new Token(TokenType.EOF, null));

            return tokens;
        }

        private void GoToNextChar()
        {
            ++_currIndex;

            if (_currIndex < Expression.Length)
            {
                _currChar = Expression[_currIndex];
            }
            else
            {
                _currChar = Symbol.EOF;
            }
        }

        private void GoToPreviousChar()
        {
            --_currIndex;

            if (_currIndex >= 0)
            {
                _currChar = Expression[_currIndex];
            }
            else
            {
                _currChar = Symbol.Start;
            }
        }

        private double GetNextNumber()
        {
            List<char> stopSignal = new()
            {
                Symbol.EOF,
                Symbol.Point,
                Symbol.Multiply,
                Symbol.Divide,
                Symbol.LeftBracket,
                Symbol.RightBracket
            };
            
            StringBuilder strNum = new();

            int minusCount = 0;
            bool isNegative = false;
            bool isPositive = false;

            while (Char.IsDigit(_currChar) == false && 
                   stopSignal.Contains(_currChar) == false)
            {
                if (_currChar == Symbol.Minus)
                {
                    isNegative = true;
                    minusCount += 1;
                }
                else if (_currChar == Symbol.Plus)
                {
                    isPositive = true;
                }

                GoToNextChar();
            }

            if (isNegative == true && isPositive == true)
            {
                throw new FormatException("Incorrect recording of plus and minus");
            }

            while (Char.IsDigit(_currChar) || _currChar == Symbol.Point)
            {
                strNum.Append(_currChar);
                GoToNextChar();
            }

            if (strNum.Length == 0)
            {
                throw new FormatException("Incorrect tokens");
            }
            
            if (!double.TryParse(strNum.ToString(), out double number))
            {
                throw new FormatException("Incorrect number format");
            }

            return (minusCount % 2 == 1) ? -number : number;
        }
    }
}
