using System;

namespace slingn.features
{
    public class LambdaFeature : BaseFeature
    {
        private readonly Func<bool> _isEnabled;

        public LambdaFeature(string name, Func<bool> isEnabled)
        {
            _isEnabled = isEnabled;
            Name = name;
        }

        public override bool IsEnabled()
        {
            try
            {
                return _isEnabled();
            }
            catch
            {
                return false;
            }
        }
    }
}