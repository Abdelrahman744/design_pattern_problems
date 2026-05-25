// ============================================================================
// Concrete Component — the base pizza before any decorations
// ============================================================================

namespace DesignPatternsCollection.Decorator
{
    /// <summary>
    /// A plain Margherita pizza — the simplest starting point.
    /// All decorator chains begin here.
    /// </summary>
    public class PlainPizza : IPizza
    {
        public string GetDescription() => "Plain Margherita Pizza";
        public double GetCost() => 7.99;
    }
}
