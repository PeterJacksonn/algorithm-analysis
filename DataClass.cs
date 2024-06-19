using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4
{
    public class DataClass
    {
        public static List<int> genRanNums(int n) //generate the dataset
        {
            List<int> dataset = new List<int>(n);
            Random rand = new Random();

            while(dataset.Count < n)
            {
                int number = rand.Next(0, 1000000);
                if (!dataset.Contains(number))
                    dataset.Add(number);
            }

            return dataset;

        }

        public static void writeDataToFile(List<int> dataset, string fileName) // writes to data.txt & result.txt
        {
            using (StreamWriter write = new StreamWriter(fileName))
            {
                foreach (int i in dataset)
                {
                    write.WriteLine(i);
                }
            }
            

        }

        public static List<int> readDataFile(string fileName) //read data.txt into a list
        {
            List<int> dataset = new List<int>();
            var lines = System.IO.File.ReadLines(fileName).ToList();
            dataset = lines.Select(int.Parse).ToList();
            return dataset;
        }

    }
}
