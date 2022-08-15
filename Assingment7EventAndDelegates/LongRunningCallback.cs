using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment7EventAndDelegates
{

    /// <summary>
    /// Class contains a delegate and a method 
    /// </summary>
    class LongRunningTask
    {
        public delegate void Multiples(string number);


        /// <summary>
        /// Method that totals the number of Multiples of 3 between Zero and 10000000 and counts them using a delegate
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public double MultiplesOfThree(Multiples num)
        {
            int count = 0;
            int total = 0;
            try
            {
                for (int i = 2; i < 10000000; i++)
                {
                    if ((i % 3) == 0) // Look for only multiples of 3
                    {
                        total += i;
                        count++;
                        num(count.ToString());
                    }

                }
            }
            catch (Exception e)
            {

                Console.WriteLine($"Found {e.Message} exception during counting");
            }
            return total;
        }

    }


    /// <summary>
    /// Contains a method that writes to the console the number of Multiples of 3s using a callback 
    /// </summary>
    class CallBack
    {
        public void ShowCount()
        {
            var totalMultiplesOfThree = new LongRunningTask();

            var total = totalMultiplesOfThree.MultiplesOfThree(x => Console.WriteLine($"It has found {x} multiples of 3"));

        }
    }
}
