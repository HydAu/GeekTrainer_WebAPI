using System;
using System.Collections.Generic;

namespace _06dVersioning.Models
{
    public class NewThing
    {
        public int Id { get; set; }
        public string DateType { get; set; }
        public DateTime Date { get; set; }

        public static IEnumerable<NewThing> FromOldThing(Thing oldThing)
        {
            var results = new List<NewThing>
            {
                new NewThing
                {
                    Id = oldThing.Id,
                    DateType = "Foo",
                    Date = oldThing.FooDate
                },
                new NewThing
                {
                    Id = oldThing.Id,
                    DateType = "Bar",
                    Date = oldThing.BarDate
                },
                new NewThing
                {
                    Id = oldThing.Id,
                    DateType = "Widget",
                    Date = oldThing.WidgetDate
                }
            };
            return results;
        }
    }
}