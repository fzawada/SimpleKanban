using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimpleKanban.Domain.Tests
{
    public static class AggregateRootExtensions
    {
        public static void Apply(this AggregateBase that, Event ev)
        {
            typeof(AggregateBase).GetMethod("InvokeEventOptional", BindingFlags.Instance | BindingFlags.NonPublic)
                .Invoke(that, new [] {ev});
        }

        public static IEnumerable<Event> GetChanges(this AggregateBase that)
        {
            var dynthat = that as dynamic;
            return (IEnumerable<Event>)dynthat.Changes;
        }
    }
}
