using Tribal_Pelts.PeltCreation.BaseGame;
using Tribal_Pelts.PeltCreation.Modded.Bundle_Of_Totems;
using Tribal_Pelts.PeltCreation.Modded.Mushroom_Tribes;
using Tribal_Pelts.PeltCreation.Modded.Nevernameds_Sigilarium;
using Tribal_Pelts.PeltCreation.Modded.Overlaps;

namespace Tribal_Pelts.PeltCreation
{
	public class InitializePelts
	{
		public static int Init(int Count)
		{
			Count = BaseGamePelts.CreateBaseGamesPelts(Count);

			// Handles the Beaver Overlap
			if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(TribalPelts.NevernamedsSigilariumGuid) || BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(TribalPelts.BundleOfTotemsGuid) || BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(TribalPelts.VerminTribeGuid))
			{
				BeaverPeltHandler.InitializeBeaverPelt();
				Count++; // For the Beaver
			}
			if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(TribalPelts.NevernamedsSigilariumGuid))
			{
				TribalPelts.Log.LogMessage("Do I see The other DLL? I do, I do see the other DLL! (Nevernameds Sigilarium)");
				NevernamedsSigilariumPelts.Init(Count);
			}
			if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(TribalPelts.BundleOfTotemsGuid))
			{
				TribalPelts.Log.LogMessage("Do I see The other DLL? I do, I do see the other DLL! (Bundle O' Totems)");
				BundleOfTotemsPelts.Init(Count);
			}
			if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(TribalPelts.MushroomTribesGuid))
			{
				TribalPelts.Log.LogMessage("Do I see The other DLL? I do, I do see the other DLL! (Mushroom Tribes)");
				MushroomTribesPelts.Init(Count);
			}
			else
			{
				TribalPelts.Log.LogMessage("Do I see the Other DLL(s)? I dont, I dont see any other DLLs!");
			}
			return Count;
		}
	}
}