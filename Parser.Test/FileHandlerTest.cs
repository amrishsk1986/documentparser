using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentParser;
using System.IO;

namespace Parser.Test
{
    [TestClass]
    public class FileHandlerTest
    {
        [TestMethod]
        public void GetContents_ValidFile_ReturnsContents()
        {
            //Arrange
            FileHandler fileHandler = new FileHandler();

            //Assert
            // this particular file resource can be mocked
            string[] contents = fileHandler.GetContents(Path.Combine(Environment.CurrentDirectory,"data.csv"));
            Assert.IsNotNull(contents);
        }

        [TestMethod]
        public void GetContents_InValidFile_ReturnsContents()
        {
            //Arrange
            FileHandler fileHandler = new FileHandler();

            //Assert
            Exception exception = null;
            try 
	        {	        
		        string[] contents = fileHandler.GetContents(Path.Combine(Environment.CurrentDirectory, "nodata.csv"));
	        }
	        catch (Exception ex)
	        {
		        exception = ex;
	        }
            Assert.IsNotNull(exception);
        }
    }
}
