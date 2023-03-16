namespace FileSearcher
{
    public class Program
    {
        public static int Main(string[] args)
        {
            int result = 1;
            string directory = GetUserInput("Enter a directory");

            try
            {
                var search = new Seacher(directory);
                string searchTerm = GetUserInput("Enter a search term");
                Console.WriteLine("Your results are:");  
                var files = search.Search(searchTerm);
                Console.WriteLine(string.Join(Environment.NewLine, files));
                result = 0;

            }
            catch (DirectoryNotFoundException e)
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