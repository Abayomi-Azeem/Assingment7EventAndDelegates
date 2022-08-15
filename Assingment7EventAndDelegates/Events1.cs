using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment7EventAndDelegates
{

    /// <summary>
    /// Publisher Class that raises an even when a special number is generated
    /// </summary>
    internal class SpecialNumberPublisher                                   //Publisher Class
    {
        public delegate void SpecialNumber( EventArgs arg);                 //Delegate that takes in an event argument

        public event SpecialNumber FoundSpecialNum;                         

        public void RandomNumGen()
        {
            var rnd = new Random();
            ArrayList specialNumbers = new ArrayList() { 1089, 6174, 1729, 666 };
            try
            {
                for (int i = 0; i < 100000; i++)
                {
                    Console.WriteLine("Checking for Special Numbers");
                    var num = rnd.NextInt64(500, 7000);                          //Generate random number ebtween 500 and 7000
                    if (specialNumbers.Contains(num))
                    {
                        EventhandlerArg arg = new EventhandlerArg();                //Instantiate the Event handler  argument class to set a property of an argument
                        arg.SpecialNumber = (int)num;
                        OnSpecialNumber(arg);                                       // invoke the event with the special number as an argument
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Found {e.Message} exception during counting");
            }
        }

        protected virtual void OnSpecialNumber(EventArgs arg)
        {
            FoundSpecialNum?.Invoke(arg);
        } 
    }



    /// <summary>
    /// Event Subscriber Class called when a special number is found and writes the number to the console
    /// </summary>
    class SpecialNumberSubscriber                                                                    //Subscruber Class
    {
        public void FoundSpecialNumber()
        {
            var specialNum = new SpecialNumberPublisher();                                              //instantiate the Publisher class
            specialNum.FoundSpecialNum += (x) => Console.WriteLine($"Found Special Number {x}");           //Write the Special number found to the screen
            Console.ReadLine();
            specialNum.RandomNumGen();

        }
    }


    /// <summary>
    /// Event handler Arguments class that inherits from the Event Args class used to add a Special number method to the class
    /// </summary>
    public class EventhandlerArg : EventArgs                                                            // 
    {
        public int SpecialNumber { get; set; }
    }
}
