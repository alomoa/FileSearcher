using NUnit.Framework;
using FileSearcher;
using Moq;
using System.Security.Permissions;

namespace Test
{
    public class IntergrationTest
    {

        readonly string  dirName = "TestDir";
        Searcher searcher;

        [SetUp]
        public void Setup()
        {
            searcher = new Searcher(new SearchService());
        }
        

        

        [Test]
        public void ThrowsInvalidDirectoryException()
        {
            Assert.Throws<DirectoryNotFoundException>(() => searcher.Search("lol", "hello"));
        }

        //[Test]
        //public void CanLoadDirectory()
        //{
           

        //    //Arrange
        //    var path = Path.Combine(Directory.GetCurrentDirectory(), dirName);


        //    //Test
        //    var fileSearcher = new Seacher(path);

        //    //Assert
        //    Assert.That(dirName, Is.EqualTo(fileSearcher.GetPath()));
        //}

        [Test]
        public void GetsASingleFile()
        {
            //Arrange
            var path = Path.Combine(Directory.GetCurrentDirectory(), dirName);

            //Act
            var files = searcher.Search(path, "Goodbye");

            //Assert
            Assert.That(files.Count(), Is.EqualTo(1));
        }

        [Test]
        public void GetsMultipleFiles()
        {
            //Arrange
            var path = Path.Combine(Directory.GetCurrentDirectory(), dirName);

            //Test
            var files = searcher.Search(path, "Hello"); ;

            //Assert
            Assert.That(files.Count(), Is.EqualTo(2));
        }

        [Test]
        public void GetsPartialMatch()
        {
            //Arrange
            var path = Path.Combine(Directory.GetCurrentDirectory(), dirName);

            //Test
            var files = searcher.Search(path, "Hel"); ;

            //Assert
            Assert.That(files.Count(), Is.EqualTo(2));
        }

        [Test]
        public void IsCaseInsensitive()
        {
            //Arrange
            var path = Path.Combine(Directory.GetCurrentDirectory(), dirName);

            //Test
            var files = searcher.Search(path, "bob");

            //Assert
            Assert.That(files.Count(), Is.EqualTo(2));
        }
    }
}
