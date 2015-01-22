using System;
using System.Collections.Generic;
using _06dVersioning.Models;

namespace _06dVersioning.Controllers
{
    public class ThingRepository
    {
        public static readonly ThingRepository Current = new ThingRepository();
        
        private readonly List<Thing> _things = new List<Thing>();

        public ThingRepository()
        {
            var random = new Random();

            for (var x = 0; x < 10; x++)
            {
                var thing = new Thing
                {
                    Id = x + 1,
                    BarDate = DateTime.Now.AddDays(-1*random.Next(1, 1000)),
                    FooDate = DateTime.Now.AddDays(-1*random.Next(1, 1000)),
                    WidgetDate = DateTime.Now.AddDays(-1*random.Next(1, 1000))
                };
                
                _things.Add(thing);
            }
        }

        public IEnumerable<Thing> Get()
        {
            return _things;
        }

        public IEnumerable<NewThing> GetNew()
        {
            var result = new List<NewThing>();
            foreach (var thing in _things)
            {
                result.AddRange(NewThing.FromOldThing(thing));
            }
            return result;
        }
    }
}