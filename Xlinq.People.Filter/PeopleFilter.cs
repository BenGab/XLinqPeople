using System;
using System.Collections.Generic;
using System.Linq;
using XlingPeople.Models.Models;

namespace Xlinq.Filter
{
    public static class PeopleFilter
    {
        static int NumbrOfDepartment(this IEnumerable<People> peoples, string department)
        {
            return peoples.Count(x => x.Dept == department);
        }

        static IEnumerable<People> ToPaged(this IEnumerable<People> peoples, Func<People, bool> predicate, int page, int itemsinpage)
        {

            return peoples.Where(predicate).Skip((page - 1) * itemsinpage).Take(itemsinpage);
        }
    }
}
