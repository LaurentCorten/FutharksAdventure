using System;
using System.Collections.Generic;

namespace FutharksAdventure.Core
{
    /// <summary>
    /// Bus d'evenements : permet a des emetteurs et des abonnes de communiquer
    /// sans se connaitre. Chacun ne depend que du bus.
    /// Instancie une seule fois par le Composition Root (Bootstrap) puis injecte.
    /// Un evenement est un struct : son TYPE sert de canal, ses CHAMPS sont les donnees.
    /// </summary>
    public class EventBus
    {
        private readonly Dictionary<Type, List<Delegate>> _subscribers = new Dictionary<Type, List<Delegate>>();

        /// <summary>Abonne une methode aux evenements de type T.</summary>
        public void Subscribe<T>(Action<T> handler) where T : struct
        {
            if(!_subscribers.TryGetValue(typeof(T), out List<Delegate> handlers))
            {
                handlers = new List<Delegate>();
                _subscribers.Add(typeof(T), handlers);
            }
            handlers.Add(handler);
        }

        /// <summary>Diffuse l'evenement a tous les abonnes de son type.</summary>
        public void Publish<T>(T evt) where T : struct
        {
            if (_subscribers.TryGetValue(typeof(T), out List<Delegate> handlers))
            {
                // ToArray() : on parcourt une copie, pour qu'un abonne puisse
                // s'abonner ou se desabonner pendant la diffusion sans casser la boucle.
                // Le type explicite Action<T> dans le foreach caste chaque element.
                // Ce cast est sur : seul Subscribe<T> remplit le tiroir typeof(T),
                // et il n'y range que des Action<T>.
                foreach (Action<T> handler in handlers.ToArray())
                {
                    handler(evt);
                }
            }
        }

        /// <summary>Desabonne une methode des evenements de type T.</summary>
        public void Unsubscribe<T>(Action<T> handler) where T : struct
        {
            if (_subscribers.TryGetValue(typeof(T), out List<Delegate> handlers))
            {
                handlers.Remove(handler);
            }
        }
    }
}
