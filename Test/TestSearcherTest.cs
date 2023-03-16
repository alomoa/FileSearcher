using System;
using System.Collections.Generic;
using FileSearcher;
using NUnit.Framework;


namespace Test
{
    public class TestSearcherTest
    {
       
        [Test]
        public void CanValidateDirectory()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            Assert.IsNotNull(currentDirectory);
        }
    }
}