namespace Calculator.Tests.UnitTesting.xUnit
{
    public static class ExampleCorrectExpression
    {
        public const string Expression1 = 
            "1 + 2 * 3 - (4 / 5 * 6 + 7) - 8 * 9";

        public const string Expression2 = 
            "1+ 2 *       3- (    4 / 5       * 6+7) -8*  9";

        public const string Expression3 = 
            "11 + 22*33 - (44/55*66 + 77) - 88*99";

        public const string Expression4 = 
            "111 + 222*333 - (444/555*666 + 777) - 888*999";

        public const string Expression5 = 
            "1.5 + 2.8*3.45 - (4.23/5.78*6.91 + 7.56) - 8.90*9.12";

        public const string Expression6 = 
            "12.45 + 23.65*37.81 - (45.98/51.67*68.20 + 77.23) - 80.12*99.32";

        public const string Expression7 = 
            "152.415 + 233.645*357.821 - (453.918/561.687*638.260 + 717.263) - 820.142*969.312";

        public const string Expression8 = 
            ".45*.97/.32(.56+.78-.56)";

        public const string Expression9 = 
            ".45 *        .97/  .32 ( .56 +   .78  -.56   )";

        public const string Expression10 =
            "-124.6789 + 245*-367.1234-(-4567.1233/4*-90.25 + -0.6753) - -445.56*.2";

        public const string Expression11 =
           "(-124.6789) + 245*(-367.1234)-((-4567.1233)/4*(-90.25) + (-0.6753)) - (-445.56)*.2";

        public const string Expression12 =
           "--1";

        public const string Expression13 =
           "---1";

        public const string Expression14 =
           "1---2";

        public const string Expression15 =
           "1------2";

        public const string Expression16 =
           "++1";

        public const string Expression17 =
           "+++++1";

        public const string Expression18 =
           "1-++2";

        public const string Expression19 =
           "1+--2";

        public const string Expression20 =
           "1+---2";

        public const string Expression21 =
           "1*+2";

        public const string Expression22 =
           "1*-2";

        public const string Expression23 =
           "1/+2";

        public const string Expression24 =
           "1/-2";

        public const string Expression25 =
           "1*--2";

        public const string Expression26 =
           "1*++2";

        public const string Expression27 =
           "1*---2";

        public const string Expression28 =
           "1/--2";

        public const string Expression29 =
           "1/++2";

        public const string Expression30 =
           "1/---2";

        public const string Expression31 =
           "1*-------2";

        public const string Expression32 =
           "1*--------2";

        public const string Expression33 =
           "1/-------2";

        public const string Expression34 =
           "1/--------2";

        public const string Expression35 =
           "1*++++++2";

        public const string Expression36 =
           "1*---2/3";

        public const string Expression37 =
           "1*----2/3";

        public const string Expression38 =
           "1*++++2/3";
    }
}
