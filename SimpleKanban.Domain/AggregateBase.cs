using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimpleKanban.Domain
{
    public class AggregateBase
    {
        static readonly MethodInfo InternalPreserveStackTraceMethod =
            typeof(Exception).GetMethod("InternalPreserveStackTrace", BindingFlags.Instance | BindingFlags.NonPublic);

        private IList<Event> changes = new List<Event>();
        private IEnumerable<Event> Changes { get { return changes; } }

        protected void Apply(Event ev)
        {
            changes.Add(ev);
            InvokeEventOptional(ev);
        }

        private readonly Cache cache = new Cache();
        
        [DebuggerNonUserCode]
        protected void InvokeEventOptional(object ev)
        {
            MethodInfo info;
            var type = ev.GetType();
            if (!cache.Dict.TryGetValue(type, out info))
            {
                // we don't care if state does not consume events
                // they are persisted anyway
                return;
            }
            try
            {
                info.Invoke(this, new[] { ev });
            }
            catch (TargetInvocationException ex)
            {
                if (null != InternalPreserveStackTraceMethod)
                    InternalPreserveStackTraceMethod.Invoke(ex.InnerException, new object[0]);
                throw ex.InnerException;
            }
        }

        private class Cache
        {
            private IDictionary<Type, MethodInfo> dict;
            public IDictionary<Type, MethodInfo> Dict
            {
                get
                {
                    if (dict == null)
                    {
                        dict = this.GetType()
                            .GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                            .Where(m => m.Name == "Mutate")
                            .Where(m => m.GetParameters().Length == 1)
                            .ToDictionary(m => m.GetParameters().First().ParameterType, m => m);
                    }
                    return dict;
                }

            }
        }
    }
}
