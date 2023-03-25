using FileSearcher;
using Moq;
using NUnit.Framework;

namespace Test
{
    public class UnitTest
    {
        Mock<ISearchService> searchServiceMock;
        Searcher searcher;

        [SetUp]
        public void Setup()
        {
            searchServiceMock = new Mock<ISearchService>();
            searchServiceMock.Setup(m => m.Search(It.IsAny<string>(), It.IsAny<string>())).Returns(new List<FileInfo>());
            searcher = new Searcher(searchServiceMock.Object);
        }

        [Test]
        public void ReturnsAList() {
            //Arrange
            var directory = "dir";
            var searchTerm = "term";

            //Act
            var list = searcher.Search(directory, searchTerm);

            //Assert
            List<FileInfo> fileInfos = new List<FileInfo>();
            Assert.That(fileInfos.GetType(), Is.EqualTo(list.GetType()));
        }
        
    }
}
