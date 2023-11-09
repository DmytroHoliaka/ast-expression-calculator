using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
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

        public override bool Equals(object? obj)
        {
            return
                obj is Token token &&
                Type == token.Type &&
                Value == token.Value;
        }

        public override string ToString()
        {
            return $"{Type}: {Value}";
        }
    }
}
