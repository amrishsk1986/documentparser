using DocumentParser;
using System;
using System.IO;

namespace ParserClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFile = Path.Combine(Environment.CurrentDirectory, "data.csv");
            string sortedNames = Path.Combine(Environment.CurrentDirectory, "sorted_names.csv");
            string sortedAddresses = Path.Combine(Environment.CurrentDirectory, "sorted_addresses.csv");

            IDocumentParser parser = new CSVParser(inputFile);
            parser.AggregateAndSortNames(sortedNames);
            parser.SortAddresses(sortedAddresses);
        }
    }
}
