namespace Calculator
{
    public class DivideNode : IAbstractSyntaxTree
    {
        public IAbstractSyntaxTree LeftNode { get; init; }
        public IAbstractSyntaxTree RightNode { get; init; }

        public DivideNode(IAbstractSyntaxTree? leftNode, IAbstractSyntaxTree? rightNode)
        {
            if (leftNode is null)
            {
                throw new ArgumentNullException(nameof(leftNode), "Left node cannot be null");
            }

            if (rightNode is null)
            {
                throw new ArgumentNullException(nameof(rightNode), "Right node cannot be null");
            }

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
