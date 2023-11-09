namespace Calculator
{
    public class LeafNode : IAbstractSyntaxTree
    {
        public double Num { get; private set; }

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
