using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment7EventAndDelegates
{

    internal class Delegates1
    {
        public delegate bool Predicate(XClass x);  // Declaration of a Delegate that returns bool and takes an instance of XClass

        void LambdaExpansion()
        {

            var likelyUsername = "Abayomi";

            Predicate classwork = (XClass x) =>
            {
                if (x.UserName == likelyUsername)  //check if Username is equal to LikelyUsername
                {
                    return true;
                }
                else
                {
                    return false;
                }
            };
        }
    }


    /// <summary>
    /// Class Contains properties for Student Identification
    /// </summary>
    class XClass
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        public string UserName { get; set; }

    }
}
