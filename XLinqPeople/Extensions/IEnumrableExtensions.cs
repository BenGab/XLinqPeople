using System;
using System.Collections.Generic;

namespace XLinqPeople.Extensions
{
    public static class IEnumrableExtensions
    {
        public static void ToConsole<T>(this IEnumerable<T> result) where T: class
        {
            Console.WriteLine("**** BEGIN ******");

            foreach(var item in result)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("***** END *******");
        }
    }
}
