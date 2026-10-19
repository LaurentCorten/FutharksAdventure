using System;

namespace FutharksAdventure.Core
{
    // Usage in MonoBehaviour:
    // EventBinding<RoomValidatedEvent> _binding;
    // void Awake()    => _binding = new EventBinding<RoomValidatedEvent>(OnRoomValidated);
    // void OnEnable()  => EventBus<RoomValidatedEvent>.Register(_binding);
    // void OnDisable() => EventBus<RoomValidatedEvent>.Deregister(_binding);
    public class EventBinding<T> : IEventBinding<T> where T : struct
    {
        readonly Action<T> m_OnEvent;
        public Action<T> OnEvent => m_OnEvent;

        public EventBinding(Action<T> onEvent) => m_OnEvent = onEvent;
    }
}
