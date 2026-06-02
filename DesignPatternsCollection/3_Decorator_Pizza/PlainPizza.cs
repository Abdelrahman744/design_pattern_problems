namespace DesignPatternsCollection.Decorator
{
    // Concrete Component — the base pizza before any decorators are applied.
    public class PlainPizza : IPizza
    {
        public string GetDescription() => "Plain Margherita Pizza";
        public double GetCost() => 7.99;
    }
}
