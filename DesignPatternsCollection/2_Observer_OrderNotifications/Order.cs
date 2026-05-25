// ============================================================================
// The Subject — Order class that broadcasts status changes
// ============================================================================
// The Order is the "publisher." It doesn't know what its subscribers do;
// it just maintains a list and calls Update() on each one when something
// interesting happens.
// ============================================================================

using System;
using System.Collections.Generic;

namespace DesignPatternsCollection.Observer
{
    /// <summary>
    /// The Subject (a.k.a. Publisher).
    /// Holds a list of observers and notifies all of them when the
    /// order status changes.
    /// </summary>
    public class Order
    {
        // ── Subscriber list ──
        private readonly List<IOrderObserver> _observers = new List<IOrderObserver>();

        /// <summary>Unique identifier for this order.</summary>
        public string OrderId { get; }

        /// <summary>Current status of the order.</summary>
        public string Status { get; private set; }

        public Order(string orderId)
        {
            OrderId = orderId;
            Status = "Created";
            Console.WriteLine($"  Order [{OrderId}] created with status '{Status}'.");
        }

        // ── Subscription management ──

        /// <summary>Add a new observer to the notification list.</summary>
        public void Subscribe(IOrderObserver observer)
        {
            _observers.Add(observer);
            Console.WriteLine($"  + Observer '{observer.GetType().Name}' subscribed to Order [{OrderId}].");
        }

        /// <summary>Remove an observer from the notification list.</summary>
        public void Unsubscribe(IOrderObserver observer)
        {
            _observers.Remove(observer);
            Console.WriteLine($"  - Observer '{observer.GetType().Name}' unsubscribed from Order [{OrderId}].");
        }

        // ── The core of the Observer pattern ──

        /// <summary>
        /// Change the order status and immediately push the update to
        /// every registered observer. This is the "publish" action.
        /// </summary>
        public void SetStatus(string newStatus)
        {
            Status = newStatus;
            Console.WriteLine($"\n  >> Order [{OrderId}] status changed to: '{Status}'");
            Console.WriteLine("     Notifying all observers...");
            NotifyAll();
        }

        /// <summary>
        /// Loop through every subscriber and call Update().
        /// The Order has NO idea what happens inside Update() — that's
        /// the whole point of the decoupling.
        /// </summary>
        private void NotifyAll()
        {
            foreach (var observer in _observers)
            {
                observer.Update(OrderId, Status);
            }
        }
    }
}
