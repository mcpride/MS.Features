namespace MS.Features
{
    public abstract class FeatureBase
    {
        public bool CanModify { get; private set; }

        public bool IsProperlyConfigured { get; private set; }

        public string Name { get; internal set; }

        internal void ChangeIsProperlyConfiguredState(bool state)
        {
            IsProperlyConfigured = state;
        }

        internal void ChangeModifiableState(bool modifiable)
        {
            CanModify = modifiable;
        }
    }
}
