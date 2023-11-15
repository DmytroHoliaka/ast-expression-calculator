namespace Calculator
{
    public class Program
    {
        // ToDo: Change name of commit "034b37e" -> "Add symbol «Start»"

        public static void Main(string[] args)
        {
            try
            {
                Settings settings = new(args);
                Launch launch = new(settings);
                launch.Execute();
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"[ArgumentNullException] {ex.Message}.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"[ArgumentOutOfRangeException] {ex.Message}.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"[ArgumentException] {ex.Message}.");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"[DivideByZeroException] {ex.Message}.");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"[FormatException] {ex.Message}.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"[IOException] {ex.Message}.");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"[InvalidOperationException] {ex.Message}.");
            }
        }
    }
}