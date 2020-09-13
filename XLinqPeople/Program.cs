using System;
using XlingPeople.Models.Models;
using Xlinq.People.Filter;

namespace XLinqPeople
{
    class Program
    {
        static void Main(string[] args)
        {
            const string dataSourceUrl = "http://users.nik.uni-obuda.hu/prog3/_data/people.xml";

            Console.WriteLine("Filter for department");

            var people = People.LoadXml(dataSourceUrl);

            var depts = people.NumberOfDepartment("Alkalmazott Informatikai Intézet");
        }
    }
}
