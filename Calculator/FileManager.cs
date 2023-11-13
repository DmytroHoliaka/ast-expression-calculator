namespace Calculator
{
    public class FileManager
    {
        public string InputPath { get; init; }
        public string OutputPath { get; init; }

        public FileManager(string? inputPath, string? outputPath)
        {
            if (inputPath is null)
            {
                throw new ArgumentNullException(nameof(inputPath), "Path to input file cannot be null");
            }
            else if (outputPath is null)
            {
                throw new ArgumentNullException(nameof(outputPath), "Path to output file cannot be null");
            }

            InputPath = inputPath;
            OutputPath = outputPath;
        }

        public void EvalFileExpressions()
        {
            if (File.Exists(InputPath) == false)
            {
                throw new IOException("Input file doesn't exists");
            }

            using StreamReader reader = new(InputPath);
            using StreamWriter writer = new(OutputPath);
            string? line;

            while ((line = reader.ReadLine()) != null)
            {
                try
                {
                    LexicalAnalysis lexer = new(line);
                    List<Token> tokens = lexer.GetTokens();

                    Parser parser = new(tokens);
                    writer.WriteLine($"{line} = {parser.GetValue()}");
                }
                catch (Exception ex)
                {
                    writer.WriteLine($"{line} = {ex.Message}");
                }
            }
        }
    }
}
