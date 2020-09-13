using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace XlingPeople.Models.Models
{
    public class People
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Dept { get; set; }

        public string Rank { get; set; }

        public string Phone { get; set; }

        public string Room { get; set; }

        public static People Parse(XElement node)
        {
            return new People()
            {
                Name = node.Element("name")?.Value,
                Email = node.Element("email")?.Value,
                Dept = node.Element("dept")?.Value,
                Rank = node.Element("rank")?.Value,
                Phone = node.Element("phone")?.Value,
                Room = node.Element("room")?.Value
            };
        }

        public static IEnumerable<People> LoadXml(string url)
        {
            XDocument node = XDocument.Load(url);

            return node.Descendants("person").Select(x => People.Parse(x));
        }
    }
}
