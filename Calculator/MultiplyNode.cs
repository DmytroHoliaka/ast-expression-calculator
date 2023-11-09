using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class MultiplyNode : IAbstractSyntaxTree
    {
        public IAbstractSyntaxTree LeftNode { get; private set; }
        public IAbstractSyntaxTree RightNode { get; private set; }

        public MultiplyNode(IAbstractSyntaxTree leftNode, IAbstractSyntaxTree rightNode)
        {
            LeftNode = leftNode;
            RightNode = rightNode;
        }

        public double Eval()
        {
            return LeftNode.Eval() * RightNode.Eval();
        }
    }
}
