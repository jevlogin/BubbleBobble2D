namespace WORLDGAMEDEVELOPMENT
{
    public sealed class CoinsModels
    {
        public CoinsComponents CoinsComponents;
        public CoinsSettingsData CoinsSettings;

        public CoinsModels(CoinsComponents coinsComponents, CoinsSettingsData coinsSettings)
        {
            CoinsComponents = coinsComponents;
            CoinsSettings = coinsSettings;
        }
    }
}