using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone
{
    public class Report
    {
        //holds data for the new report to write
        private Dictionary<string, int> _newReport = new Dictionary<string, int>();
        public decimal TotalSales = 0;
        
        /// <summary>
        /// Sets file pathway to current directory
        /// </summary>
        /// <param name="fileName">Name of file to create or write to</param>
        /// <returns></returns>
        private string SetDirectory(string fileName)
        {
            string directory = Environment.CurrentDirectory;
            string name = fileName;
            string fullPath = Path.Combine(directory, fileName);
            return fullPath;
        }

        /// <summary>
        /// Writes a new report file
        /// </summary>
        /// <param name="name">name of item to log</param>
        /// <param name="price">price of item to log  </param>
        public void PopulateNewReport(string name, decimal price)
        {
            //adds price of each item to total sales made
            TotalSales += price;

            if (_newReport.ContainsKey(name))
            {
                _newReport[name] = _newReport[name] + 1; //increments value of dictionary for every purchase made 
            }
            else
            {
                _newReport.Add(name, 1); //adds new item to dictionary if it does not exist and sets value to 1
            }

            string fullPath = SetDirectory("sales_report.txt");

            //opens the file to write the report
            using (StreamWriter sw = new StreamWriter(fullPath))
            {
                foreach (KeyValuePair<string, int> item in _newReport)
                {
                    sw.WriteLine($"{item.Key}|{item.Value}");
                }

                sw.WriteLine($"\r\n**TOTAL SALES** {TotalSales.ToString("C")}");
            }

        }

        /// <summary>
        /// gets old sales report from previous instances of the machine
        /// </summary>
        public void GetOldSalesReport()
        {
            string fullPath = SetDirectory("sales_report.txt");

            if (File.Exists(fullPath))
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        
                        string[] splitLine = new string[2];
                        string currentLine = sr.ReadLine();
                        if (currentLine.Contains("|"))
                        {
                            splitLine = currentLine.Split('|');
                            _newReport.Add(splitLine[0], int.Parse(splitLine[1]));
                        }
                        else if (currentLine.Contains('$'))
                        {
                            splitLine = currentLine.Split('$');
                            TotalSales = decimal.Parse(splitLine[1]);
                        }
                    }
                }
            }

        }
    }
}
