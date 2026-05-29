using System;
using System.Collections.Generic;

namespace DesignPatternsCollection.Observer
{
    public class Order
    {
        private readonly List<IOrderObserver> _observers = new List<IOrderObserver>();

        public string OrderId { get; }

        public string Status { get; private set; }

        public Order(string orderId)
        {
            OrderId = orderId;
            Status = "Created";
            Console.WriteLine($"  Order [{OrderId}] created with status '{Status}'.");
        }

        public void Subscribe(IOrderObserver observer)
        {
            _observers.Add(observer);
            Console.WriteLine($"  + Observer '{observer.GetType().Name}' subscribed to Order [{OrderId}].");
        }

        public void Unsubscribe(IOrderObserver observer)
        {
            _observers.Remove(observer);
            Console.WriteLine($"  - Observer '{observer.GetType().Name}' unsubscribed from Order [{OrderId}].");
        }

        public void SetStatus(string newStatus)
        {
            Status = newStatus;
            Console.WriteLine($"\n  >> Order [{OrderId}] status changed to: '{Status}'");
            Console.WriteLine("     Notifying all observers...");
            NotifyAll();
        }

        private void NotifyAll()
        {
            foreach (var observer in _observers)
            {
                observer.Update(OrderId, Status);
            }
        }
    }
}
