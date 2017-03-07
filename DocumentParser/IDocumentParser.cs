using System;
namespace DocumentParser
{
    public interface IDocumentParser
    {
        void AggregateAndSortNames(string ouptFilePath);
        void SortAddresses(string ouptFilePath);
    }
}
