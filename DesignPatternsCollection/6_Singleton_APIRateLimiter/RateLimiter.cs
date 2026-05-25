// ============================================================================
// SINGLETON PATTERN — API Rate Limiter
// ============================================================================
// THE PROBLEM:
// Your backend calls an external third-party API that strictly limits
// you to 100 requests per minute. If multiple services, threads, or
// controllers each maintain their own counters, requests will leak
// through uncounted and you'll exceed the limit — resulting in your
// API key being throttled or banned.
//
// THE SOLUTION:
// Make the RateLimiter a Singleton. A private constructor prevents
// anyone from creating additional instances. A thread-safe GetInstance()
// method ensures every single outgoing network request goes through the
// EXACT SAME counter, regardless of how many threads or services are
// making calls.
//
// THREAD SAFETY:
// We use double-checked locking on instance creation AND a lock on the
// request counter to handle concurrent access safely.
// ============================================================================

using System;
using System.Threading;

namespace DesignPatternsCollection.Singleton
{
    /// <summary>
    /// Thread-safe Singleton that enforces an API rate limit of
    /// 100 requests per minute across the entire application.
    /// </summary>
    public sealed class RateLimiter
    {
        // ── The single instance ──
        private static RateLimiter? _instance;

        // ── Lock for thread-safe instance creation ──
        private static readonly object _instanceLock = new object();

        // ── Lock for thread-safe counter operations ──
        private readonly object _counterLock = new object();

        // ── Rate limit configuration ──
        private const int MaxRequestsPerWindow = 100;
        private static readonly TimeSpan WindowDuration = TimeSpan.FromMinutes(1);

        // ── Internal state ──
        private int _requestCount;
        private DateTime _windowStart;

        /// <summary>
        /// PRIVATE constructor — prevents external instantiation.
        /// The only way to get a RateLimiter is through GetInstance().
        /// </summary>
        private RateLimiter()
        {
            _requestCount = 0;
            _windowStart = DateTime.UtcNow;
            Console.WriteLine("  [RateLimiter] Singleton instance created. " +
                              $"Limit: {MaxRequestsPerWindow} requests per {WindowDuration.TotalSeconds}s window.");
        }

        /// <summary>
        /// Returns the one-and-only RateLimiter instance.
        /// Uses double-checked locking: the outer check avoids the lock
        /// overhead on every call; the inner check prevents a race condition
        /// between two threads that both pass the outer check.
        /// </summary>
        public static RateLimiter GetInstance()
        {
            if (_instance == null)                   // Fast path — no lock
            {
                lock (_instanceLock)
                {
                    if (_instance == null)           // Race-condition guard
                    {
                        _instance = new RateLimiter();
                    }
                }
            }
            return _instance;
        }

        /// <summary>
        /// Attempts to make an API request. Returns true if the request
        /// is allowed under the rate limit, false if it must be rejected.
        ///
        /// Thread-safe: the counter is protected by a dedicated lock so
        /// multiple threads can call this concurrently without data races.
        /// </summary>
        /// <param name="requestDescription">
        /// A human-readable label for logging (e.g., "GET /users/42").
        /// </param>
        public bool TryRequest(string requestDescription)
        {
            lock (_counterLock)
            {
                // If the current time window has elapsed, reset the counter.
                if (DateTime.UtcNow - _windowStart >= WindowDuration)
                {
                    Console.WriteLine($"\n  [RateLimiter] Window expired — resetting counter " +
                                      $"(was {_requestCount}/{MaxRequestsPerWindow}).");
                    _requestCount = 0;
                    _windowStart = DateTime.UtcNow;
                }

                // Check if we're still under the limit.
                if (_requestCount < MaxRequestsPerWindow)
                {
                    _requestCount++;
                    Console.WriteLine($"  [RateLimiter] ✅ ALLOWED  ({_requestCount}/{MaxRequestsPerWindow}) " +
                                      $"→ {requestDescription}");
                    return true;
                }
                else
                {
                    Console.WriteLine($"  [RateLimiter] ❌ BLOCKED  ({_requestCount}/{MaxRequestsPerWindow}) " +
                                      $"→ {requestDescription}  — Rate limit exceeded!");
                    return false;
                }
            }
        }

        /// <summary>
        /// Returns the current request count (for diagnostic purposes).
        /// </summary>
        public int CurrentCount
        {
            get { lock (_counterLock) { return _requestCount; } }
        }

        /// <summary>
        /// Resets the instance for demo/testing purposes.
        /// In production, you would NOT expose this.
        /// </summary>
        internal static void ResetForTesting()
        {
            lock (_instanceLock)
            {
                _instance = null;
            }
        }
    }
}
