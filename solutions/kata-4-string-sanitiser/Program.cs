using System.Text.RegularExpressions;

namespace FizzBuzzPlus
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string to Sanitise:");
            string input = Console.ReadLine();
            string sanitised = SanitiseInput(input);
            Console.WriteLine("Sanitised string:");
            Console.WriteLine(sanitised);
        }

        static string SanitiseInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return string.Empty;
            }
            
            // Remove punctuation
            input = Regex.Replace(input, "[\\p{P}-[']]+", "");

            // Trim whitespace
            input = input.Trim();

            // Convert to lowercase
            input = input.ToLower();

            // Collapse multiple spaces into one
            input = Regex.Replace(input, "\\s+", " ");
            
            return input;
        }
    }
}
