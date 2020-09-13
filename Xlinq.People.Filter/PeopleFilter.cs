using System;
using System.Collections.Generic;
using System.Linq;

namespace Xlinq.People.Filter
{
    public static class PeopleFilter
    {
        public static int NumberOfDepartment(this IEnumerable<XlingPeople.Models.Models.People> peoples, string department)
        {
            return peoples.Count(x => x.Dept == department);
        }

        public static IEnumerable<XlingPeople.Models.Models.People> ToPaged(this IEnumerable<XlingPeople.Models.Models.People> peoples, Func<XlingPeople.Models.Models.People, bool> predicate, int page, int itemsinpage)
        {

            return peoples.Where(predicate).Skip((page - 1) * itemsinpage).Take(itemsinpage);
        }
    }
}
