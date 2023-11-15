using Calculator.AST;
using Calculator.Services;
using Calculator.TokenManagement;

namespace Calculator.Running
{
    public class Launch
    {
        public Settings Tools => new(_tools);
        private readonly Settings _tools;

        public Launch(Settings? settings)
        {
            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings), "Input instance of settings cannot be null");
            }

            _tools = settings;
        }

        public void Execute()
        {
            if (_tools.IsUploaded == true)
            {
                EvalFile();
                Console.WriteLine($"The source file was created. Name: {Path.GetFileName(_tools.OutputFilePath)}");
            }
            else if (_tools.IsEvaled == true)
            {
                double result = EvalExpression();
                Console.WriteLine(result);
            }
            else
            {
                throw new InvalidOperationException("System error. Try again.");
            }
        }

        private double EvalExpression()
        {
            LexicalAnalysis lexer = new(_tools.Record);
            List<Token> tokens = lexer.GetTokens();

            Parser parser = new(tokens);
            return parser.GetValue();
        }

        private void EvalFile()
        {
            FileManager file = new(_tools.Record, _tools.OutputFilePath);
            file.EvalFileExpressions();
        }
    }
}
