using System.Collections.Generic;

namespace SlingN.Features.Framework
{
    public interface IFeatureSetFactory
    {
        IEnumerable<IFeature> Create();
    }
}