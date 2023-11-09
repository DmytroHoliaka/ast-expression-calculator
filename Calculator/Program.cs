namespace Calculator
{
    public class Program
    {
        // ToDo: Change "private set" properties to "init"
        public static void Main(string[] args)
        {
            try
            {
                //string expression = "1+2*3-(4/5*6+7)-8*9-";
                string expression = "1-*/*2";

                LexicalAnalysis lexer = new(expression);
                List<Token> tokens = lexer.GetTokens();

                Parser parser = new(tokens);
                Console.WriteLine(parser.GetValue());
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}