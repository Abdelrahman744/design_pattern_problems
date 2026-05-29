// ============================================================================
// SINGLETON PATTERN — Game Scoreboard
// ============================================================================
// THE PROBLEM:
// You are making a simple console game. When a player collects a coin,
// the Coin class needs to add points. When the player kills an enemy,
// the Enemy class needs to add points. If you have to pass a Score
// object into every single class in your game, your code becomes messy
// and tightly coupled.
//
// THE SOLUTION:
// Make the GameScoreboard a Singleton. A private constructor prevents
// anyone from creating additional instances. A thread-safe GetInstance()
// method ensures every class in the entire game — Coin, Enemy, Boss,
// PowerUp — can just call GameScoreboard.GetInstance().AddPoints(10)
// to update the EXACT SAME, globally shared score.
//
// THREAD SAFETY:
// We use double-checked locking on instance creation AND a lock on the
// score counter to handle concurrent access safely.
// ============================================================================

using System;

namespace DesignPatternsCollection.Singleton
{
    /// <summary>
    /// Thread-safe Singleton that holds the global game score.
    /// Any class can access it via GameScoreboard.GetInstance().
    /// </summary>
    public sealed class GameScoreboard
    {
        // ── The single instance ──
        private static GameScoreboard? _instance;

        // ── Lock for thread-safe instance creation ──
        private static readonly object _instanceLock = new object();

        // ── Lock for thread-safe score operations ──
        private readonly object _scoreLock = new object();

        // ── Internal state ──
        private int _score;

        /// <summary>
        /// PRIVATE constructor — prevents external instantiation.
        /// The only way to get a GameScoreboard is through GetInstance().
        /// </summary>
        private GameScoreboard()
        {
            _score = 0;
            Console.WriteLine("  [GameScoreboard] 🎮 Singleton instance created. Score starts at 0.");
        }

        /// <summary>
        /// Returns the one-and-only GameScoreboard instance.
        /// Uses double-checked locking: the outer check avoids the lock
        /// overhead on every call; the inner check prevents a race condition
        /// between two threads that both pass the outer check.
        /// </summary>
        public static GameScoreboard GetInstance()
        {
            if (_instance == null)                   // Fast path — no lock
            {
                lock (_instanceLock)
                {
                    if (_instance == null)           // Race-condition guard
                    {
                        _instance = new GameScoreboard();
                    }
                }
            }
            return _instance;
        }

        /// <summary>
        /// Adds points to the global score. Thread-safe.
        /// </summary>
        /// <param name="points">The number of points to add.</param>
        public void AddPoints(int points)
        {
            lock (_scoreLock)
            {
                _score += points;
                Console.WriteLine($"  [GameScoreboard] ➕ Added {points} points  →  Total: {_score}");
            }
        }

        /// <summary>
        /// Returns the current score (for diagnostic / display purposes).
        /// </summary>
        public int Score
        {
            get { lock (_scoreLock) { return _score; } }
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

    // ========================================================================
    // GAME CLASSES — These do NOT receive a score object as a parameter.
    // They simply call GameScoreboard.GetInstance() whenever they need it.
    // This is the entire point of the Singleton pattern.
    // ========================================================================

    /// <summary>
    /// Represents a collectible coin in the game.
    /// Adds 10 points to the global scoreboard when collected.
    /// </summary>
    public class Coin
    {
        private readonly string _location;

        public Coin(string location)
        {
            _location = location;
        }

        /// <summary>
        /// Player collects this coin — adds 10 points via the Singleton.
        /// No need to receive a Score object as a parameter!
        /// </summary>
        public void Collect()
        {
            Console.WriteLine($"  🪙 Coin collected at {_location}!");
            GameScoreboard.GetInstance().AddPoints(10);
        }
    }

    /// <summary>
    /// Represents an enemy in the game.
    /// Adds points to the global scoreboard when defeated.
    /// Standard enemies = 25 pts, bosses = 100 pts.
    /// </summary>
    public class Enemy
    {
        private readonly string _name;
        private readonly int _pointValue;
        private readonly bool _isBoss;

        public Enemy(string name, int pointValue, bool isBoss = false)
        {
            _name = name;
            _pointValue = pointValue;
            _isBoss = isBoss;
        }

        /// <summary>
        /// Player defeats this enemy — adds points via the Singleton.
        /// No need to receive a Score object as a parameter!
        /// </summary>
        public void Defeat()
        {
            string label = _isBoss ? "👹 BOSS" : "👾 Enemy";
            Console.WriteLine($"  {label} \"{_name}\" defeated!");
            GameScoreboard.GetInstance().AddPoints(_pointValue);
        }
    }
}
