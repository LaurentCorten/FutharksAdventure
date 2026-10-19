using System.Collections.Generic;

namespace FutharksAdventure.Core
{
    public static class EventBus<T> where T : struct
    {
        static readonly HashSet<IEventBinding<T>> s_Bindings  = new HashSet<IEventBinding<T>>();
        static readonly List<IEventBinding<T>>    s_Dispatch  = new List<IEventBinding<T>>();

        public static void Register(IEventBinding<T> binding)   => s_Bindings.Add(binding);
        public static void Deregister(IEventBinding<T> binding) => s_Bindings.Remove(binding);

        // Snapshot into pre-allocated list to avoid allocation and InvalidOperationException
        // if a handler deregisters during iteration.
        public static void Raise(T e)
        {
            s_Dispatch.Clear();
            s_Dispatch.AddRange(s_Bindings);
            foreach (var binding in s_Dispatch)
                binding.OnEvent?.Invoke(e);
        }

        public static void Clear() => s_Bindings.Clear();
    }
}
