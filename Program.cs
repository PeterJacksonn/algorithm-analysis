using System;
using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;
using System.Data;

namespace Project4
{
    class Program
    {

        static void Main(string[] args)
        {
            //directory for where dataset is stored
            string fileName = "PATH TO FILE... -> \\data.txt";

            //directory for where the sorted dataset is stored
            string resultFile = "PATH TO FILE... -> \\result.txt";

            //directory for where to times (for testing) are stored
            string timesFile = "PATH TO FILE... -> \\times.txt";

            //size of dataset
            int n = 16000;

            bool inputCheck = false;
            while(inputCheck == false)
            {
                string useCase;
                Console.WriteLine("Normal mode or testing mode? n/t");
                useCase = Console.ReadLine();

                if(useCase == "n")
                {
                    inputCheck = true;
                    normalMode(fileName, timesFile, resultFile, n);
                }
                else if (useCase == "t")
                {
                    inputCheck = true;
                    testingMode(timesFile, n);

                    
                }
            }
        }

        static void normalMode(string fileName, string timesFile, string resultFile, int n)
        {
            //creates new list of random nums (dataset) and writes to dataset file
            List<int> data = DataClass.genRanNums(n);
            DataClass.writeDataToFile(data, fileName);

            //reads dataset from file into list
            List<int> dataset = DataClass.readDataFile(fileName);

            //clears the result file (can be certain result isn't from previous time)
            File.WriteAllText(resultFile, string.Empty);

            bool validIn = false;
            while (validIn == false)
            { 
                string sortChoice;
                Console.WriteLine("Bubble sort or quick sort? b/q");
                sortChoice = Console.ReadLine();


                if (sortChoice == "b")
                {
                    //bubblesort
                    validIn = true;
                    Stopwatch stopwatch = Timer.startTimer();
                    dataset = BubbleSort.bubbleSort(n, dataset);
                    Timer.timeResult(stopwatch);
                    DataClass.writeDataToFile(dataset, resultFile);


                }
                else if (sortChoice == "q")
                {
                    //quicksort
                    validIn = true;
                    Stopwatch stopwatch = Timer.startTimer();                   //start timer
                    QuickSort.quickSort(dataset, 0, (n - 1));                   //do sort
                    Timer.timeResult(stopwatch);                                //stop timer    
                    DataClass.writeDataToFile(dataset, resultFile);             //add to result.txt


                }
                else
                {
                    Console.WriteLine("not an option");
                }
            }

        }

        static void testingMode(string timesFile, int n)
        {
            //clear the testing results file
            File.WriteAllText(timesFile, string.Empty);

            int testAmount = 3;

            for (int j = 0; j < testAmount; j++)
            {
                //make new dataset
                List<int> datasetBubble = DataClass.genRanNums(n);
                
                //copy dataset for quicksort
                List<int> datasetQuick = new List<int>(datasetBubble);

                //bubble sort
                Stopwatch stopwatch = Timer.startTimer();
                datasetBubble = BubbleSort.bubbleSort(n, datasetBubble);
                Timer.timeResultTesting("Bubble sort: ", stopwatch, timesFile); ;

                //quick sort
                Stopwatch stopwatch2 = Timer.startTimer();                          //start timer
                QuickSort.quickSort(datasetQuick, 0, (n - 1));                      //do sort
                Timer.timeResultTesting("Quick sort: ", stopwatch2, timesFile);     //stops timer and adds time to times.txt  
            }

            List<double> quickTimes = new List<double>();
            List<double> bubbleTimes = new List<double>();

            // Read lines from the file
            string[] lines = File.ReadAllLines(timesFile);

            foreach (string line in lines)
            {
                string[] parts = line.Split(':'); 
                if (parts.Length == 2 && double.TryParse(parts[1].Trim(), out double time))
                {
                    if (parts[0].StartsWith("Bubble"))
                    {
                        bubbleTimes.Add(time);
                    }
                    else if (parts[0].StartsWith("Quick"))
                    {
                        quickTimes.Add(time);
                    }
                }
            }
            double averageBubble = (bubbleTimes.Sum()) / testAmount;
            double averageQuick = (quickTimes.Sum()) / testAmount;

            Console.WriteLine("Average bubble sort time: " + averageBubble+ " microseconds");
            Console.WriteLine("Average quick sort time: " + averageQuick+ " microseconds");


        }
    }
}