using System;
using System.Collections.Generic;

namespace CQRSWithEvents.Src
{
    public class EventPublisher
    {
        private readonly Dictionary<Type, Handler> _subscribers =
                        new Dictionary<Type, Handler>();

        public void AddHandler<T>(Type type, Handler handler) where T:Event
        {
            _subscribers.Add(type, handler);
        }

        public void Publish(Event e)
        {
            _subscribers[e.GetType()].Handle(e);
        }

    }
}