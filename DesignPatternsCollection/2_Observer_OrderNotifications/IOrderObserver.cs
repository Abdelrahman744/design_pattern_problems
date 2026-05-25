// ============================================================================
// OBSERVER PATTERN — Order Notifications
// ============================================================================
// THE PROBLEM:
// When a customer's order status changes to "Shipped," several independent
// systems must react simultaneously:
//   1. An email notification must be sent to the customer.
//   2. An SMS text must be fired to their phone.
//   3. The inventory database must be updated (e.g., decrement stock).
//
// If the Order class directly calls EmailService, SmsService, and
// InventoryService, it becomes tightly coupled to all of them. Adding
// a new notification channel (push notifications, Slack, etc.) would
// require modifying the Order class every single time.
//
// THE SOLUTION:
// The Observer pattern decouples the Order (Subject) from its dependents
// (Observers). The Order maintains a list of IOrderObserver subscribers.
// When its status changes, it loops through the list and calls Update()
// on each one — without knowing or caring what they do.
// ============================================================================

namespace DesignPatternsCollection.Observer
{
    /// <summary>
    /// The Observer interface.
    /// Any service that wants to react to order changes implements this.
    /// </summary>
    public interface IOrderObserver
    {
        /// <summary>
        /// Called by the Subject (Order) whenever the order status changes.
        /// </summary>
        /// <param name="orderId">The ID of the order that changed.</param>
        /// <param name="newStatus">The new status value.</param>
        void Update(string orderId, string newStatus);
    }
}
