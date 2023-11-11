using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Parser
    {
        private readonly List<TokenType> _termItems = new() { TokenType.Plus, TokenType.Minus };
        private readonly List<TokenType> _factorItems = new() { TokenType.Multiply, TokenType.Divide };
        private readonly List<Token> _tokens;
        private int _currPos;
        private Token _currToken;


        public Parser(List<Token>? tokens)
        {
            if (!Validator.IsTokensValid(tokens))
            {
                throw new ArgumentException("Incorrect set of tokens", nameof(tokens));
            }

            _tokens = tokens!;
            _currPos = 2;
            _currToken = _tokens![1];
        }

        public double GetValue()
        {
            IAbstractSyntaxTree? ast = ParseExpression();

            if (ast is null)
            {
                throw new ArgumentNullException("Abstract syntax tree null", nameof(ast));
            }
            else if (_currToken.Type != TokenType.EOF)
            {
                throw new FormatException("Incorrect order of tokens in expression");
            }

            return ast.Eval();
        }

        private IAbstractSyntaxTree? ParseExpression()
        {
            IAbstractSyntaxTree? result = Factor();

            while (_currToken.Type != TokenType.EOF && result != null && _termItems.Contains(_currToken.Type))
            {
                if (_currToken.Type == TokenType.Plus)
                {
                    GetNextToken();
                    IAbstractSyntaxTree? rightNode = Factor();

                    if (rightNode is null)
                    {
                        throw new ArgumentNullException("The result of the calculation is undefined", nameof(rightNode));
                    }

                    result = new PlusNode(result, rightNode);
                }
                else if (_currToken.Type == TokenType.Minus)
                {
                    GetNextToken();
                    IAbstractSyntaxTree? rightNode = Factor();

                    if (rightNode is null)
                    {
                        throw new ArgumentNullException("The result of the calculation is undefined", nameof(rightNode));
                    }

                    result = new MinusNode(result, rightNode);
                }
            }

            return result;
        }

        private IAbstractSyntaxTree? Factor()
        {
            IAbstractSyntaxTree? factor = Term();

            while (_currToken.Type != TokenType.EOF && factor != null && _factorItems.Contains(_currToken.Type))
            {
                if (_currToken.Type == TokenType.Multiply)
                {
                    GetNextToken();
                    IAbstractSyntaxTree? rightNode = Term();

                    if (rightNode is null)
                    {
                        throw new ArgumentNullException("The result of the calculation is undefined", nameof(rightNode));
                    }

                    factor = new MultiplyNode(factor, rightNode);
                }
                else if (_currToken.Type == TokenType.Divide)
                {
                    GetNextToken();
                    IAbstractSyntaxTree? rightNode = Term();

                    if (rightNode is null)
                    {
                        throw new ArgumentNullException("The result of the calculation is undefined", nameof(rightNode));
                    }

                    factor = new DivideNode(factor, rightNode);
                }
            }

            return factor;
        }

        private IAbstractSyntaxTree? Term()
        {
            IAbstractSyntaxTree? term = null;

            if (_currToken.Type == TokenType.LeftBracket)
            {
                GetNextToken();
                term = ParseExpression();

                if (_currToken.Type != TokenType.RightBracket)
                {
                    throw new FormatException("Missing )");
                }
            }
            else if (_currToken.Type == TokenType.Number)
            {
                term = new LeafNode(_currToken.Value!.Value);
            }
            else
            {
                throw new FormatException("Incorrect order of tokens");
            }

            GetNextToken();
            return term;
        }

        private void GetNextToken()
        {
            if (_currPos < _tokens.Count)
            {
                _currToken = _tokens[_currPos];
                _currPos++;
            }
        }
    }
}
