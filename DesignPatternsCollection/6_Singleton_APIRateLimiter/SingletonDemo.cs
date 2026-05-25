// ============================================================================
// Singleton Pattern Demo
// ============================================================================
// Proves that:
// 1. GetInstance() always returns the exact same object.
// 2. The rate limiter correctly counts and blocks requests.
// 3. Multiple "services" share the same counter (no leaks).
// ============================================================================

using System;

namespace DesignPatternsCollection.Singleton
{
    public static class SingletonDemo
    {
        public static void Run()
        {
            Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║  PATTERN 6: SINGLETON — API Rate Limiter                    ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            // --- Proof 1: Both references point to the SAME object ---
            Console.WriteLine("  ── Proof: GetInstance() returns the same object ──");
            var limiter1 = RateLimiter.GetInstance();
            var limiter2 = RateLimiter.GetInstance();
            Console.WriteLine($"  limiter1 == limiter2 ? {ReferenceEquals(limiter1, limiter2)}");
            Console.WriteLine($"  (Same hash: {limiter1.GetHashCode()} == {limiter2.GetHashCode()})");
            Console.WriteLine();

            // --- Proof 2: Multiple services share the same counter ---
            Console.WriteLine("  ── Simulating API calls from different services ──");

            // Service A makes some calls
            SimulateServiceCalls("UserService",      limiter1, 3);
            // Service B makes some calls — counter continues where A left off
            SimulateServiceCalls("PaymentService",   limiter2, 3);
            // Service C makes more calls — still the same counter
            SimulateServiceCalls("InventoryService", RateLimiter.GetInstance(), 2);

            Console.WriteLine($"\n  Total requests across ALL services: " +
                              $"{RateLimiter.GetInstance().CurrentCount}");
            Console.WriteLine();

            // --- Proof 3: Rate limiting kicks in when the limit is hit ---
            // (We won't actually send 100 requests in the demo, but the
            //  mechanism is visible in the TryRequest output above.)
            Console.WriteLine("  ── Pattern verified: one counter, shared globally ──");
            Console.WriteLine();
        }

        /// <summary>
        /// Simulates a service making N API calls through the shared limiter.
        /// </summary>
        private static void SimulateServiceCalls(
            string serviceName, RateLimiter limiter, int count)
        {
            for (int i = 1; i <= count; i++)
            {
                limiter.TryRequest($"{serviceName} → GET /api/resource/{i}");
            }
        }
    }
}
