using System;
using System.Collections.Generic;
using System.Linq;
using SlingN.Features.Framework;

namespace slingn.features
{
    public class Feature
    {
        private static readonly Dictionary<string, IFeature> FeaturesList = new Dictionary<string, IFeature>();
        
        public static bool IsEnabled(string name)
        {
            return FeaturesList.ContainsKey(name) && FeaturesList[name].IsEnabled();
        }

        public static void Add(string name, Func<bool> isEnabled)
        {
            var feature = new LambdaFeature(name, isEnabled);
            FeaturesList[name] = feature;
        }
        
        public static void Add(string name, bool isEnabled)
        {
            var feature = new StandardFeature(name, isEnabled);
            FeaturesList[name] = feature;
        }

        public static void InitializeFromAppSettings()
        {
            var factory = new AppSettingsBasedFeatureSetFactory();
            var features = factory.Create();
            features.ToList().ForEach(feature => FeaturesList[feature.Name] = feature);
        }
    }
}