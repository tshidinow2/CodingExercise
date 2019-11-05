using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingExercise.HighestOrder
{
    public class HighestCommonDivisorService
    {
        private static int CalculateHighestCommonFactor(List<int> numbers,int currentvalue =  1,int highestcommonfactor = 0)
        {
            //if the current value is now greater than the lowers value close the recursion
            if (currentvalue > numbers.Min())
                return highestcommonfactor;

            var iscommonfactor = true;
            for (int j = 0; j < numbers.Count; j++)
            {
               if ((numbers[j] % currentvalue) != 0)
               {
                  iscommonfactor = false;
                  break;
               }
            }
            if (iscommonfactor == true)
               highestcommonfactor = currentvalue;
            
            return CalculateHighestCommonFactor(numbers,currentvalue: currentvalue + 1 ,highestcommonfactor);
        }
        public static int GetHighestCommonDivisor(List<int> numbers)
        {
            return CalculateHighestCommonFactor(numbers);
        }
    }
}
