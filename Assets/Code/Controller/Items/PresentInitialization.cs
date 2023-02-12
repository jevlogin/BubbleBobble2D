namespace WORLDGAMEDEVELOPMENT
{
    public sealed class PresentInitialization
    {
        private PresentFactory _presentFactory;
        public PresentModel PresentModel;

        public PresentInitialization(PresentFactory presentFactory)
        {
            _presentFactory = presentFactory;
            PresentModel = _presentFactory.GetOrCreatePresentModels();
        }
    }
}