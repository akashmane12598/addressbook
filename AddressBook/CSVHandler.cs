﻿using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace AddressBook
{
    public class CSVHandler
    {
        static string filePathCSV = @"C:\Users\LENOVO\source\repos\AddressBook\AddressBook\AddressBookCSV.csv";

        public static void WriteIntoCSVFile(Dictionary<string, List<Contacts>> sorted)
        {
            using(StreamWriter stw=new StreamWriter(filePathCSV))
            {
                using (CsvWriter writer=new CsvWriter(stw, CultureInfo.InvariantCulture))
                {
                    foreach (KeyValuePair<string, List<Contacts>> kv in sorted)
                    {
                        string a = kv.Key;
                        List<Contacts> contacts = kv.Value;

                        writer.WriteRecord<string>(a);

                        foreach (Contacts c in contacts)
                        {
                            writer.WriteRecord<Contacts>(c);
                        }
                    }

                    using (StreamReader str = new StreamReader(filePathCSV))
                    {
                        using (CsvReader reader = new CsvReader(str, CultureInfo.InvariantCulture))
                        {
                            var records = reader.GetRecords<Contacts>().ToList();

                            foreach (Contacts c in records)
                            {
                                Console.WriteLine(c);
                            }
                        }
                    }

                }
            }
        }

       /* public static void ReadFromCSVFile()
        {
            Console.WriteLine("Reading from CSV File");

            using (StreamReader str=new StreamReader(filePathCSV))
            {
                using(CsvReader reader=new CsvReader(str, CultureInfo.InvariantCulture))
                {
                    var records = reader.GetRecords<Contacts>().ToList();

                    foreach (Contacts c in records)
                    {
                        Console.WriteLine(c);
                    }
                }
            }
        }*/
    }
}
