using System;

namespace FutharksAdventure.Core
{
    public interface IEventBinding<T> where T : struct
    {
        Action<T> OnEvent { get; }
    }
}
