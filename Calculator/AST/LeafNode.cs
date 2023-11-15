namespace Calculator.AST
{
    public class LeafNode : IAbstractSyntaxTree
    {
        public double Num { get; init; }

        public LeafNode(double num)
        {
            Num = num;
        }

        public double Eval()
        {
            return Num;
        }
    }
}
