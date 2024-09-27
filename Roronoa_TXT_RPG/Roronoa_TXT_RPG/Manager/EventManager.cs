using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roronoa_TXT_RPG
{
    internal class EventManager
    {
        private Dictionary<Type, List<Delegate>>? eventHandlers;

        public static EventManager? instance { get; private set; }

        public static void InitEventManager()
        {
            if (instance == null)
            {
                instance = new EventManager();
                instance.eventHandlers = new Dictionary<Type, List<Delegate>>();
            }
        }

        public void Subscribe<TEvent>(Action<TEvent> handler) where TEvent : EventArgs
        {
            Type eventType = typeof(TEvent);

            if (false == eventHandlers?.ContainsKey(eventType))
                eventHandlers[eventType] = new List<Delegate>();

            eventHandlers?[eventType].Add(handler);
        }

        public void Unsubscribe<TEvent>(Action<TEvent> handler) where TEvent : EventArgs
        {
            Type eventType = typeof(TEvent);
            if (true == eventHandlers?.ContainsKey(eventType))
                eventHandlers[eventType].Remove(handler);
        }

        public void Publish<TEvent>(TEvent eventArgs) where TEvent : EventArgs
        {
            Type eventType = typeof(TEvent);
            if(true == eventHandlers?.ContainsKey(eventType))
            {
                List<Delegate> handlers = eventHandlers[eventType];
                foreach (var handler in handlers)
                {
                    ((Action<TEvent>)handler)(eventArgs);
                }
            }
        }
    }
}
