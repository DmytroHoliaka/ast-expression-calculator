namespace Calculator.TokenManagement
{
    public class Token
    {
        public TokenType Type { get; init; }
        public double? Value { get; init; }

        public Token(TokenType type, double? value)
        {
            Type = type;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Type}: {Value}";
        }

        public override bool Equals(object? obj)
        {
            return
                obj is Token token &&
                Type == token.Type &&
                Value == token.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Type, Value);
        }
    }
}
