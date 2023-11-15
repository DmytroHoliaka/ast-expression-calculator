namespace Calculator.Tests.UnitTesting.xUnit
{
    public class ExampleIncorrectExpression
    {
        public const string Expression1 =
           "0.45.15";

        public const string Expression2 =
           "statement";

        public const string Expression3 =
           "-+1";

        public const string Expression4 =
           "+-1";

        public const string Expression5 =
           "1+-+2";

        public const string Expression6 =
           "1-+-2";

        public const string Expression7 =
           "1+---+2";

        public const string Expression8 =
           "1-+++-2";
        
        public const string Expression9 =
           "1-+-+-+2";

        public const string Expression10 =
           "1--/2";

        public const string Expression11 =
           "1---*2";

        public const string Expression12 =
           "1++*2";

        public const string Expression13 =
           "1+++/2";

        public const string Expression14 =
           "1+-+*2";

        public const string Expression15 =
           "1-+-/2";

        public const string Expression16 =
            "1(-(-2))";

        public const string Expression17 =
            "1(-)-2";

        public const string Expression18 =
            "1-(-)-2";

        public const string Expression19 =
            "1-(-)+2";

        public const string Expression20 =
            "1+(-)-2";

        public const string Expression21 =
            "1-(+)-2";

        public const string Expression22 =
            "1+(+)+2";

        public const string Expression23 =
            "1+(-)+2";

        public const string Expression24 =
            "1+(+)-2";
        
        public const string Expression25 =
            "1-(+)+2";

        public const string Expression26 =
            "1(-)2";

        public const string Expression27 =
            "1(+)2";
    }
}
