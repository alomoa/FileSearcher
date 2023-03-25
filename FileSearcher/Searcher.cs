using System.IO;

namespace FileSearcher
{
    public class Searcher
    {
        private ISearchService _searchService;
        public Searcher(ISearchService searchService)
        {
            _searchService = searchService;
        }

        public IEnumerable<FileInfo> Search(string directory, string search)
        {
            return _searchService.Search(directory, search);   
        }
    }


}

//Make a searchservice interface with methods search(directory, search term)/get path/
// Implement and inject into this file
// create a mock of the search service interface and use that to test. 

public interface ISearchService
{
    public IEnumerable<FileInfo> Search(string directory, string searchTerm);
}

public class SearchService : ISearchService
{
    public IEnumerable<FileInfo> Search(string directory, string searchTerm)
    {
        var directoryInfo = new DirectoryInfo(directory);
        if (directoryInfo.Exists == false)
        {
            throw new DirectoryNotFoundException();
        }
        var filteredFiles = directoryInfo.GetFiles().Where(file => file.Name.Contains(searchTerm, StringComparison.InvariantCultureIgnoreCase));
        return filteredFiles;
    }


}