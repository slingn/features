using SlingN.Features.Framework;

namespace slingn.features
{
    public abstract class BaseFeature : IFeature
    {
        public string Name { get; protected set; }
        public abstract bool IsEnabled();
    }
}