// Observer Interface — all observers must implement Update() to receive notifications.
namespace DesignPatternsCollection.Observer
{
    public interface IOrderObserver
    {
        void Update(string orderId, string newStatus);
    }
}
