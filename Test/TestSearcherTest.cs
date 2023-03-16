using NUnit.Framework;
using FileSearcher;


namespace Test
{
    public class TestSearcherTest
    {

        readonly string  dirName = "TestDir";
        

        [Test]
        public void ThrowsInvalidDirectoryException()
        {
            Assert.Throws<DirectoryNotFoundException>(() => new Seacher("lol")); ;
        }

        [Test]
        public void CanLoadDirectory()
        {
           

            //Arrange
            var path = Path.Combine(Directory.GetCurrentDirectory(), dirName);


            //Test
            var fileSearcher = new Seacher(path);

            //Assert
            Assert.That(dirName, Is.EqualTo(fileSearcher.GetPath()));
        }

        [Test]
        public void GetsASingleFile()
        {
            //Arrange
            var path = Path.Combine(Directory.GetCurrentDirectory(), dirName);

            //Test
            var fileSearcher = new Seacher(path);
            var files = fileSearcher.Search("Goodbye");

            //Assert
            Assert.That(files.Count(), Is.EqualTo(1));
        }

        [Test]
        public void GetsMultipleFiles()
        {
            //Arrange
            var path = Path.Combine(Directory.GetCurrentDirectory(), dirName);

            //Test
            var fileSearcher = new Seacher(path);
            var files = fileSearcher.Search("Hello");

            //Assert
            Assert.That(files.Count(), Is.EqualTo(2));
        }

        [Test]
        public void GetsPartialMatch()
        {
            //Arrange
            var path = Path.Combine(Directory.GetCurrentDirectory(), dirName);

            //Test
            var fileSearcher = new Seacher(path);
            var files = fileSearcher.Search("Hel");

            //Assert
            Assert.That(files.Count(), Is.EqualTo(2));
        }

        [Test]
        public void IsCaseInsensitive()
        {
            //Arrange
            var path = Path.Combine(Directory.GetCurrentDirectory(), dirName);

            //Test
            var fileSearcher = new Seacher(path);
            var files = fileSearcher.Search("bob");

            //Assert
            Assert.That(files.Count(), Is.EqualTo(2));
        }
    }
}
