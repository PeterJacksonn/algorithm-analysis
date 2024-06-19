using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4
{
    public class BubbleSort
    {
        public static List<int> bubbleSort(int n, List<int> dataset)
        {
            int temp;
            bool noswap = false;
            while(noswap == false)
            {
                noswap= true;
                for(int i = 0; i <= n - 2; i++)
                {
                    if (dataset[i] > dataset[i + 1])
                    {
                        temp = dataset[i];
                        dataset[i] = dataset[i + 1];
                        dataset[i + 1] = temp;
                        noswap= false;
                    }

                }
            }
            return dataset;
        }
    }
}
