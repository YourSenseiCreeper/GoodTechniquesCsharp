using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeTimeConsumption
{
    public static class StatisticsHelper
    {
        public static double GetMedian(double[] sourceNumbers)
        {
            //Framework 2.0 version of this method. there is an easier way in F4        
            if (sourceNumbers == null || sourceNumbers.Length == 0)
                throw new System.Exception("Median of empty array not defined.");

            //make sure the list is sorted, but use a new array
            double[] sortedPNumbers = (double[])sourceNumbers.Clone();
            Array.Sort(sortedPNumbers);

            //get the median
            int size = sortedPNumbers.Length;
            int mid = size / 2;
            double median = (size % 2 != 0) ? (double)sortedPNumbers[mid] : ((double)sortedPNumbers[mid] + (double)sortedPNumbers[mid - 1]) / 2;
            return median;
        }

        public static double GetMedian(List<double> sourceNumbers) => GetMedian(sourceNumbers.ToArray());

        public static double StdDev(List<double> sourceNumbers)
        {
            double average = sourceNumbers.Average();
            double squareSum = 0;
            foreach(double element in sourceNumbers)
            {
                squareSum += Math.Pow((element - average), 2);
            }
            double division = squareSum / sourceNumbers.Count;
            return Math.Sqrt(division);
        }
    }
}
