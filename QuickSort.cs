using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4
{
    public class QuickSort
    {

        public static void swapAlgo(List<int> dataset, int i, int j)
        {
            int temp = dataset[i];
            dataset[i] = dataset[j];
            dataset[j] = temp;
        }


        public static int partitionAlgo(List<int> dataset, int low, int high)
        {
            int pivot = dataset[high];
            int i = low - 1;
            for(int j=low; j <= high; j++)
            {
                if (dataset[j] < pivot)
                {
                    i++;
                    swapAlgo(dataset,i,j);
                }
            }
            swapAlgo(dataset,i+1,high);
            return i + 1;
        }

        public static void quickSort(List<int> dataset, int low, int high)
        {
            if (low < high)
            {
                int pivot = partitionAlgo(dataset, low, high);
                quickSort(dataset, low, pivot - 1);
                quickSort(dataset, pivot + 1, high);
            } 
        }
    }
}
