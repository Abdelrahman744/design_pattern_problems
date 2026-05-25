// ============================================================================
// Concrete Observers — services that react to order changes
// ============================================================================
// Each observer implements IOrderObserver and handles the update in its
// own way. They are completely independent of each other and of the Order.
//
// Adding a new notification channel (e.g., Slack, push notifications)
// means creating ONE new class — the Order class is never modified.
// ============================================================================

using System;

namespace DesignPatternsCollection.Observer
{
    /// <summary>
    /// Sends an email to the customer when the order status changes.
    /// In production, this would call an SMTP service or SendGrid API.
    /// </summary>
    public class EmailService : IOrderObserver
    {
        public void Update(string orderId, string newStatus)
        {
            Console.WriteLine($"     📧 EmailService: Sending email — " +
                              $"\"Your order [{orderId}] is now '{newStatus}'.\"");
        }
    }

    /// <summary>
    /// Fires an SMS text to the customer's phone number.
    /// In production, this would call Twilio or a similar SMS gateway.
    /// </summary>
    public class SmsService : IOrderObserver
    {
        public void Update(string orderId, string newStatus)
        {
            Console.WriteLine($"     📱 SmsService: Sending SMS — " +
                              $"\"Order [{orderId}] update: {newStatus}.\"");
        }
    }

    /// <summary>
    /// Updates the inventory database when an order ships.
    /// In production, this would call a database or inventory microservice.
    /// </summary>
    public class InventoryService : IOrderObserver
    {
        public void Update(string orderId, string newStatus)
        {
            Console.WriteLine($"     📦 InventoryService: Logging status '{newStatus}' " +
                              $"for order [{orderId}] in the database.");
        }
    }
}
