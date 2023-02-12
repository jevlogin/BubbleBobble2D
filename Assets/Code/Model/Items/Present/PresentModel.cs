namespace WORLDGAMEDEVELOPMENT
{
    public class PresentModel
    {
        private PresentStruct presentStruct;
        private PresentComponents presentComponents;

        public PresentModel(PresentStruct presentStruct, PresentComponents presentComponents)
        {
            this.presentStruct = presentStruct;
            this.presentComponents = presentComponents;
        }
    }
}