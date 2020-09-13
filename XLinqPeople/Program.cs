using System;
using System.Collections.Generic;
using System.Linq;
using XlingPeople.Models.Models;
using Xlinq.People.Filter;
using XLinqPeople.Extensions;

namespace XLinqPeople
{
    class Program
    {

        static IEnumerable<int> Range(int start, int end, int step = 1)
        {
            for (int i = start; i <= end; i += step)
            {
                yield return i;
            }
        }

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

            minmaxLen.ToConsole();

            var numberofdepartments = from person in people
                                      group person by person.Dept into depgroup
                                      select new
                                      {
                                          Dept = depgroup.Key,
                                          Num = depgroup.Count()
                                      };

            numberofdepartments.ToConsole();

            var biggestdep = numberofdepartments.OrderByDescending(x => x.Num).FirstOrDefault();
            Console.WriteLine(biggestdep);

            Console.WriteLine("************** Generator *****************");
            foreach (var item in Range(1, 1000))
            {
                Console.WriteLine(item);
            }
        }
    }
}
