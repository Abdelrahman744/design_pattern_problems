// ============================================================================
// Singleton Pattern Demo — Game Scoreboard
// ============================================================================
// Proves that:
// 1. GetInstance() always returns the exact same object.
// 2. Coin and Enemy classes share the same global score.
// 3. No Score object is ever passed as a parameter — the Singleton
//    provides a clean, globally accessible point of contact.
// ============================================================================

using System;

namespace DesignPatternsCollection.Singleton
{
    public static class SingletonDemo
    {
        public static void Run()
        {
            Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║  PATTERN 6: SINGLETON — Game Scoreboard                     ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            // --- Proof 1: Both references point to the SAME object ---
            Console.WriteLine("  ── Proof: GetInstance() returns the same object ──");
            var board1 = GameScoreboard.GetInstance();
            var board2 = GameScoreboard.GetInstance();
            Console.WriteLine($"  board1 == board2 ? {ReferenceEquals(board1, board2)}");
            Console.WriteLine($"  (Same hash: {board1.GetHashCode()} == {board2.GetHashCode()})");
            Console.WriteLine();

            // --- Proof 2: Coin and Enemy classes share the same score ---
            Console.WriteLine("  ── Simulating a game: collecting coins & defeating enemies ──");
            Console.WriteLine();

            // Player explores and collects coins
            var coin1 = new Coin("Level 1 — Forest Path");
            var coin2 = new Coin("Level 1 — Hidden Cave");
            var coin3 = new Coin("Level 2 — Rooftop");

            coin1.Collect();
            coin2.Collect();
            coin3.Collect();

            Console.WriteLine();

            // Player fights enemies
            var goblin  = new Enemy("Goblin",       25);
            var skeleton = new Enemy("Skeleton",     25);
            var dragon  = new Enemy("Dragon King",  100, isBoss: true);

            goblin.Defeat();
            skeleton.Defeat();

            Console.WriteLine();

            // Collect one more coin between fights
            var coin4 = new Coin("Level 3 — Throne Room");
            coin4.Collect();

            Console.WriteLine();

            // Boss fight!
            dragon.Defeat();

            Console.WriteLine();

            // --- Final score ---
            int expectedScore = (10 * 4) + (25 * 2) + 100;   // 40 + 50 + 100 = 190
            int actualScore   = GameScoreboard.GetInstance().Score;

            Console.WriteLine($"  ── Final Score: {actualScore} points ──");
            Console.WriteLine($"  ── Expected:    {expectedScore} points ──");
            Console.WriteLine($"  ── Match: {(actualScore == expectedScore ? "✅ YES" : "❌ NO")} ──");
            Console.WriteLine();
            Console.WriteLine("  ── Pattern verified: one scoreboard, shared globally ──");
            Console.WriteLine();
        }
    }
}
