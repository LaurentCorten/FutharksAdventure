using System;
using System.Collections.Generic;

namespace FutharksAdventure.Core
{
    public class EventBus
    {
        private readonly Dictionary<Type, List<Delegate>> _subscribers = new Dictionary<Type, List<Delegate>>();
        
        public void Subscribe<T>(Action<T> handler) where T : struct
        {
            if(!_subscribers.TryGetValue(typeof(T), out List<Delegate> handlers))
            {
                handlers = new List<Delegate>();
                _subscribers.Add(typeof(T), handlers);
            }
            handlers.Add(handler);
        }

        public void Publish<T>(T evt) where T : struct
        {
            if (_subscribers.TryGetValue(typeof(T), out List<Delegate> handlers))
            {
                foreach (Action<T> handler in handlers.ToArray())
                {
                    handler(evt);
                }
            }
        }

        public void Unsubscribe<T>(Action<T> handler) where T : struct
        {
            if (_subscribers.TryGetValue(typeof(T), out List<Delegate> handlers))
            {
                handlers.Remove(handler);
            }
        }
    }
}
