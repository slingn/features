using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace SlingN.Features.Framework
{
    public class AppSettingsBasedFeatureSetFactory : IFeatureSetFactory
    {
        private const string AppSettingFeaturePrefix = "Feature.";

        public IEnumerable<IFeature> Create()
        {
            var output = new List<IFeature>();

            ConfigurationManager.AppSettings.AllKeys.ToList().ForEach(key =>
            {
                if (!key.Contains(AppSettingFeaturePrefix)) return;
                var name = key.Replace(AppSettingFeaturePrefix, string.Empty);
                var rawValue = ConfigurationManager.AppSettings[key];
                var value = !string.IsNullOrEmpty(rawValue) && rawValue.Trim().ToLower() == "true";
                var feature = new StandardFeature(name, value);
                output.Add(feature);
            });

            return output;
        }
    }
}