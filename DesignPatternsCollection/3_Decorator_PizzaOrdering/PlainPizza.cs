namespace DesignPatternsCollection.Decorator
{
    public class PlainPizza : IPizza
    {
        public string GetDescription() => "Plain Margherita Pizza";
        public double GetCost() => 7.99;
    }
}
