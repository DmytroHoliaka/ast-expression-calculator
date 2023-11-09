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
        private List<TokenType> _termItems = new() { TokenType.Plus, TokenType.Minus };
        private List<TokenType> _factorItems = new() { TokenType.Multiply, TokenType.Divide };
        private readonly List<Token> _tokens;
        private int _currPos;
        private Token _currToken;


        public Parser(List<Token> tokens)
        {
            if (!Validator.IsTokensValid(tokens))
            {
                throw new ArgumentException("Incorrect set of tokens", nameof(tokens));
            }

            _tokens = tokens;
            _currPos = 2;
            _currToken = _tokens[1];
        }

        public double GetValue()
        {
            // ToDo: Add null check
            IAbstractSyntaxTree ast = ParseExpression();
            return ast.Eval();
        }

        private IAbstractSyntaxTree ParseExpression()
        {
            IAbstractSyntaxTree result = Factor();

            while (_currToken.Type != TokenType.EOF && result != null && _termItems.Contains(_currToken.Type))
            {
                if (_currToken.Type == TokenType.Plus)
                {
                    GetNextToken();
                    IAbstractSyntaxTree rigthNode = Factor();
                    result = new PlusNode(result, rigthNode);
                }
                else if (_currToken.Type == TokenType.Minus)
                {
                    GetNextToken();
                    IAbstractSyntaxTree rigthNode = Factor();
                    result = new MinusNode(result, rigthNode);
                }
            }

            return result;
        }

        private IAbstractSyntaxTree Factor()
        {
            IAbstractSyntaxTree factor = Term();

            while (_currToken.Type != TokenType.EOF && factor != null && _factorItems.Contains(_currToken.Type))
            {
                if (_currToken.Type == TokenType.Multiply)
                {
                    GetNextToken();
                    IAbstractSyntaxTree rigthNode = Term();
                    factor = new MultiplyNode(factor, rigthNode);
                }
                else if (_currToken.Type == TokenType.Divide)
                {
                    GetNextToken();
                    IAbstractSyntaxTree rigthNode = Term();
                    factor = new DivideNode(factor, rigthNode);
                }
            }

            return factor;
        }

        private IAbstractSyntaxTree Term()
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
                // ToDo: Add null check
                term = new LeafNode(_currToken.Value!.Value);
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
