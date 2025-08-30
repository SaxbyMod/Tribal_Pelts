using Tribal_Pelts.PeltCreation.Modded.Bundle_Of_Totems.Pelts;

namespace Tribal_Pelts.PeltCreation.Modded.Bundle_Of_Totems
{
	public class BundleOfTotemsPelts
	{
		public static int Init(int Count)
        {
            HumanRemains.CreateHumanRemains();
            Count++;
            SharkLeather.CreateSharkLeather();
            Count++;
            TigerPelt.CreateTigerPelt();
            Count++;
            
            return Count;
        }
	}
}