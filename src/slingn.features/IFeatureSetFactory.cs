using System.Collections.Generic;

namespace slingn.features
{
    public interface IFeatureSetFactory
    {
        IEnumerable<IFeature> Create();
    }
}