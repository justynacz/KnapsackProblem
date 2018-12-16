using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace ProblemPlecakowy
{
    public class Data
    {
        private List<object[]> _listOfItems;
        private double _knapsackVolume;

        public List<object[]> ListOfItems
        {
            get { return _listOfItems; }
        }

        public double KnapsackVolume
        {
            get { return _knapsackVolume; }
        }

        public int ItemsCount
        {
            get { return _listOfItems.Count; }
        }

        public Data()
        {
            _listOfItems = new List<object[]>();
            GetDataFromFile();
        }

        private void GetDataFromFile()
        {
            try
            {
                using (var reader = new StreamReader("Data.txt"))
                {
                    if (reader.EndOfStream)
                        return;

                    var knapsackVolume = reader.ReadLine();
                    _knapsackVolume = Double.Parse(knapsackVolume, CultureInfo.InvariantCulture);

                    while (!reader.EndOfStream)
                    {
                        var itemData = reader.ReadLine();
                        var elements = itemData.Split('<');

                        object[] itemDescription = new object[3];
                        itemDescription[0] = Int32.Parse(elements[1].Remove(elements[1].Length - 1));
                        itemDescription[1] = Double.Parse(elements[2].Remove(elements[2].Length - 1), CultureInfo.InvariantCulture);
                        itemDescription[2] = Double.Parse(elements[3].Remove(elements[3].Length - 1), CultureInfo.InvariantCulture);
                        _listOfItems.Add(itemDescription);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Problem z danymi w pliku tekstowym:" + ex.Message);
            }
            
        }
    }
}
