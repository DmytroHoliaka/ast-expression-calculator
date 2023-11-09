using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Validator
    {
        public static bool IsTokensValid(List<Token> tokens)
        {
            if (IsCorrectEdges(tokens) == false ||
                IsCorrectBrackets(tokens) == false ||
                IsCorrectOperations(tokens) == false)
            {
                return false;
            }

            return true;
        }

        private static bool IsCorrectEdges(List<Token> tokens)
        {
            if (tokens[0].Type != TokenType.Start || tokens[^1].Type != TokenType.EOF)
            {
                return false;
            }

            return true;
        }

        private static bool IsCorrectBrackets(List<Token> tokens)
        {
            Stack<Token> brackets = new();

            foreach (Token token in tokens)
            {
                if (token.Type == TokenType.LeftBracket)
                {
                    brackets.Push(token);
                }
                else if (token.Type == TokenType.RightBracket)
                {
                    if (brackets.Count == 0)
                    {
                        return false;
                    }

                    brackets.Pop();
                }
            }

            return brackets.Count == 0;
        }

        private static bool IsCorrectOperations(List<Token> tokens)
        {
            List<TokenType> simpleOperations = new()
            {
                TokenType.Plus,
                TokenType.Minus
            };

            List<TokenType> complexOperations = new()
            {
                TokenType.Multiply,
                TokenType.Divide
            };

            if (simpleOperations.Contains(tokens[^2].Type) ||
                complexOperations.Contains(tokens[^2].Type))
            {
                return false;
            }

            TokenType previous = tokens[0].Type;
            TokenType current;

            for (int i = 1; i < tokens.Count; ++i)
            {
                current = tokens[i].Type;

                if (complexOperations.Contains(current) &&
                    simpleOperations.Contains(previous))
                {
                    return false;
                }

                previous = current;
            }


            return true;
        }
    }
}
