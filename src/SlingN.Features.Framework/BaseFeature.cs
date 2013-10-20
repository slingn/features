namespace SlingN.Features.Framework
{
    public abstract class BaseFeature : IFeature
    {
        public string Name { get; protected set; }
        public abstract bool IsEnabled();
    }
}