namespace SlingN.Features.Framework
{
    public interface IFeature
    {
        string Name { get; }
        bool IsEnabled();
    }
}