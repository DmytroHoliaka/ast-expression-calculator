namespace Calculator
{
    public class PlusNode : IAbstractSyntaxTree
    {
        public IAbstractSyntaxTree LeftNode { get; init; }
        public IAbstractSyntaxTree RightNode { get; init; }

        public PlusNode(IAbstractSyntaxTree? leftNode, IAbstractSyntaxTree? rightNode)
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
            return LeftNode.Eval() + RightNode.Eval();
        }
    }
}
