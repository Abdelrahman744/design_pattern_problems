// ============================================================================
// Observer Pattern Demo
// ============================================================================
// This demo shows how an Order (Subject) notifies multiple services
// (Observers) automatically when its status changes, and how observers
// can be dynamically subscribed/unsubscribed.
// ============================================================================

using System;

namespace DesignPatternsCollection.Observer
{
    public static class ObserverDemo
    {
        public static void Run()
        {
            Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║  PATTERN 2: OBSERVER — Order Notifications                  ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            // --- Create the Subject (Order) ---
            var order = new Order("ORD-20260525-001");

            // --- Create Observers (the services that care about updates) ---
            var emailService     = new EmailService();
            var smsService       = new SmsService();
            var inventoryService = new InventoryService();

            // --- Subscribe all observers ---
            order.Subscribe(emailService);
            order.Subscribe(smsService);
            order.Subscribe(inventoryService);

            // --- Change status → all three observers are notified ---
            order.SetStatus("Processing");
            order.SetStatus("Shipped");

            // --- Unsubscribe SMS (customer opted out of texts) ---
            Console.WriteLine();
            order.Unsubscribe(smsService);

            // --- Change status again → only Email and Inventory are notified ---
            order.SetStatus("Delivered");

            Console.WriteLine();
        }
    }
}
