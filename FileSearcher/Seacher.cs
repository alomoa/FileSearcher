namespace FileSearcher
{
    public class Seacher
    {
        private DirectoryInfo directoryInfo { get; set; }
        public Seacher(string directory)
        {
            directoryInfo = new DirectoryInfo(directory);

            if (directoryInfo.Exists == false)
            {
                throw new DirectoryNotFoundException($"Directory not found: {directory}");
            }
        }

        public string GetPath()
        {
            return directoryInfo.Name;
        }

        public IEnumerable<FileInfo> Search(string search)
        {
            var filteredFiles = directoryInfo.GetFiles().Where(file => file.Name.Contains(search, StringComparison.InvariantCultureIgnoreCase));
            return filteredFiles;
        }
    }
}