namespace Dariyal.StatSystem
{
    public interface IStatLinkable
    {
        float StatLinkerValue { get; }

        void AddLinker(StatLinker linker);
        void ClearLinkers();
        void UpdateLinkers();
    }
}