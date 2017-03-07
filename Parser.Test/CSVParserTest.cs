using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentParser;
using System.IO;

namespace Parser.Test
{
    [TestClass]
    public class CSVParserTest
    {
        string validInputFile = Path.Combine(Environment.CurrentDirectory, "data.csv");
        string outputFile = Path.Combine(Environment.CurrentDirectory, "output.csv");

        [TestInitialize()]
        public void Initialize() { 
        
        }

        [TestCleanup()]
        public void Cleanup() {
            if (File.Exists(outputFile)) File.Delete(outputFile);
        }

        [TestMethod]
        public void AggregatedAndSortedNames_ValidCSV_WritesNewCSV()
        {

            //Arrange
            // This particular file resource should be mocked in actual practice
            IDocumentParser parser = new CSVParser(validInputFile);

            //Assert
            parser.AggregateAndSortNames(outputFile);
            Assert.IsTrue(File.Exists(outputFile));
        }
    }
}
