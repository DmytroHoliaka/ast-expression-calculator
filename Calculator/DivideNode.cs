using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class DivideNode : IAbstractSyntaxTree
    {
        public IAbstractSyntaxTree LeftNode { get; private set; }
        public IAbstractSyntaxTree RightNode { get; private set; }

        public DivideNode(IAbstractSyntaxTree leftNode, IAbstractSyntaxTree rightNode)
        {
            LeftNode = leftNode;
            RightNode = rightNode;
        }

        public double Eval()
        {
            double leftValue = LeftNode.Eval();
            double rightValue = RightNode.Eval();

            if (rightValue == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero");
            }

            return leftValue / rightValue;
        }
    }
}
