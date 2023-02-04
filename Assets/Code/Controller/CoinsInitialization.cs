namespace WORLDGAMEDEVELOPMENT
{
    internal class CoinsInitialization
    {
        private CoinsFactory _coinsFactory;
        public CoinsModels CoinsModels;

        public CoinsInitialization(CoinsFactory coinsFactory)
        {
            _coinsFactory = coinsFactory;
            CoinsModels = _coinsFactory.CreateCoinsModel();
        }
    }
}