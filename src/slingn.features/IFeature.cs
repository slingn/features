namespace slingn.features
{
    public interface IFeature
    {
        string Name { get; }
        bool IsEnabled();
    }
}