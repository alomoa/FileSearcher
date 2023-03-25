namespace FileSearcher
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var searcher = new Searcher(new SearchService());
            int result = 1;
            string directory = GetUserInput("Enter a directory");
            try
            {
                string searchTerm = GetUserInput("Enter a search term");
                Console.WriteLine("Your results are:");  
                var files = searcher.Search(directory, searchTerm);
                Console.WriteLine(string.Join(Environment.NewLine, files));
                result = 0;

            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Directory not found");
                return result;
            }
            catch
            {
                Console.WriteLine("Unknown error");
                return result;
            }


            return result;
        }

        private static string GetUserInput(string prompt)
        {
            string? result = null;

            while (string.IsNullOrWhiteSpace(result))
            {
                Console.WriteLine(prompt);
                result = Console.ReadLine();
            }

            return result;
        }
    }
}