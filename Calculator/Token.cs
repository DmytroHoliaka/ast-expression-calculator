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
    }
}
