namespace SlingN.Features.Framework
{
    public class StandardFeature : BaseFeature
    {
        private readonly bool _isEnabled;

        public StandardFeature(string name, bool isEnabled)
        {
            Name = name;
            _isEnabled = isEnabled;
        }

        public override bool IsEnabled()
        {
            return _isEnabled;
        }
    }
}