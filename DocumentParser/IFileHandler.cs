using System;
namespace DocumentParser
{
    public interface IFileHandler
    {
        string[] GetContents(string csvPath);
        void WriteToDisk(string outputFilePath, string contents, bool overwrite = true);
    }
}
