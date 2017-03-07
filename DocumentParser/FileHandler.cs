using System;
using System.IO;

namespace DocumentParser
{
    public class FileHandler : IFileHandler
    {
        /// <summary>
        /// Read input file contents in string array where each element of array represents single record.
        /// </summary>
        /// <param name="path">Path of file to read.</param>
        /// <returns>string[]</returns>
        public string[] GetContents(string path) {
            try
            {
                // Logger.log(String.Format("Loading CSV file from {0}.",path),EventType.Info);
                return File.ReadAllLines(path);
            }
            catch (FileNotFoundException ex)
            {
                // can have logger utility to log exceptions to file or persisted storage e.g.
                // Logger.log(ex,EventType.ERROR);
                throw ex;
            }
            catch (Exception ex)
            {
                // can have logger utility to log exceptions to file or persisted storage e.g.
                // Logger.log(ex,EventType.ERROR);
                throw ex;
            }
            
        }

        /// <summary>
        /// Creates output file on specified path with given contents.
        /// </summary>
        /// <param name="outputFilePath"></param>
        /// <param name="contents"></param>
        /// <param name="overwrite"></param>
        public void WriteToDisk(string outputFilePath, string contents,bool overwrite = true) {
            try
            {
                if (overwrite)
                {
                    File.WriteAllText(outputFilePath, contents);
                }
                else
                {
                    File.AppendAllText(outputFilePath, contents);
                }
            }
            catch (Exception)
            {
                // can have logger utility to log exceptions to file or persisted storage e.g.
                // Logger.log(ex,EventType.ERROR);
                throw;
            }
        }
    }
}
