using System;
using System.Linq;
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

            for (int i = 1; i <= 5; i++)
            {
                var page = people.ToPaged(x => x.Dept == "Alkalmazott Informatikai Intézet", i, 10);
            }

            var minmaxLen = from person in people
                            let minlen = people.Min(x => x.Name.Length)
                            let maxlen = people.Max(x => x.Name.Length)
                            where person.Name.Length == minlen || person.Name.Length == maxlen
                            select new
                            {
                                person.Name,
                                NameLength = person.Name.Length
                            };
        }
    }
}
