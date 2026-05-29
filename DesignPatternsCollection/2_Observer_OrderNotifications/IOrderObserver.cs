namespace DesignPatternsCollection.Observer
{
    public interface IOrderObserver
    {
        void Update(string orderId, string newStatus);
    }
}
