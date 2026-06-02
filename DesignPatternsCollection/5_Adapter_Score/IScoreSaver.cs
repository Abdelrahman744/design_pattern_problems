namespace DesignPatternsCollection.Adapter
{
    // Target Interface — the contract the modern game expects.
    public interface IScoreSaver
    {
        void SaveWin(string player);
    }
}
