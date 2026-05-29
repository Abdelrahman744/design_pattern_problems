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

            Console.WriteLine("  ── Proof: GetInstance() returns the same object ──");
            var board1 = GameScoreboard.GetInstance();
            var board2 = GameScoreboard.GetInstance();
            Console.WriteLine($"  board1 == board2 ? {ReferenceEquals(board1, board2)}");
            Console.WriteLine($"  (Same hash: {board1.GetHashCode()} == {board2.GetHashCode()})");
            Console.WriteLine();

            Console.WriteLine("  ── Simulating a game: collecting coins & defeating enemies ──");
            Console.WriteLine();

            var coin1 = new Coin("Level 1 — Forest Path");
            var coin2 = new Coin("Level 1 — Hidden Cave");
            var coin3 = new Coin("Level 2 — Rooftop");

            coin1.Collect();
            coin2.Collect();
            coin3.Collect();

            Console.WriteLine();

            var goblin  = new Enemy("Goblin",       25);
            var skeleton = new Enemy("Skeleton",     25);
            var dragon  = new Enemy("Dragon King",  100, isBoss: true);

            goblin.Defeat();
            skeleton.Defeat();

            Console.WriteLine();

            var coin4 = new Coin("Level 3 — Throne Room");
            coin4.Collect();

            Console.WriteLine();

            dragon.Defeat();

            Console.WriteLine();

            int expectedScore = (10 * 4) + (25 * 2) + 100;
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

