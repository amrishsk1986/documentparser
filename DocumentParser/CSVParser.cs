using DocumentParser.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DocumentParser 
{
    public class CSVParser : IDocumentParser
    {
        IFileHandler fileHandler = new FileHandler();
        private IList<Client> clients = null;
        
        /// <summary>
        /// Reads client data from given CSV file.
        /// </summary>
        /// <param name="csvPath"></param>
        public CSVParser(string csvPath)
        {
            string[] records = fileHandler.GetContents(csvPath);
            clients = records.Select(record => new Client { FirstName = getTextByIndex(record,0), 
                LastName = getTextByIndex(record, 1), 
                Address = getTextByIndex(record, 2), 
                PhoneNumber = getTextByIndex(record, 3) }).Skip(1).ToList<Client>();
        }

        /// <summary>
        /// Groups FirstName and LastName of client, sorts with name in ascending order and occurrence frequency in descending order. Writes results to file.
        /// </summary>
        /// <param name="ouptFilePath"></param>
        public void AggregateAndSortNames(string ouptFilePath) {
            try
            {
                var names = clients.Select(x => x.FirstName).ToList();
                names.AddRange(clients.Select(x => x.LastName));

                var aggregateNames = names.GroupBy(i => i).OrderBy(i => i.Key).OrderByDescending(i => i.Count());
                string result = "";
                foreach (var groupedName in aggregateNames)
                {
                    result += String.Format("{0},{1}", groupedName.Key, groupedName.Count()) + Environment.NewLine;
                }
                fileHandler.WriteToDisk(ouptFilePath, result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        /// <summary>
        /// Sorts address of client in ascending order by ignoring Street numbers.
        /// </summary>
        /// <param name="ouptFilePath"></param>
        public void SortAddresses(string ouptFilePath)
        {
            try
            {
                var addresses = clients.Select(x => x.Address).OrderBy(x => ignoreStreetNumber(x)).ToArray();
                fileHandler.WriteToDisk(ouptFilePath, string.Join(Environment.NewLine, addresses));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        private string ignoreStreetNumber(string address)
        {
            if (address.Equals(String.Empty) || address.IndexOf(' ') == 0)
            {
                return String.Empty;   
            }
            return address.Split(' ')[1];
        }
        private string getTextByIndex(string source, int index)
        {
            try
            {
                return source.Split(',')[index];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
