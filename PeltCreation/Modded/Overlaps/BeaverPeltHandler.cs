using DiskCardGame;
using System.Collections.Generic;
using Tribal_Pelts.PeltCreation.Modded.Overlaps.Pelts;
using Tribal_Pelts.Util;

namespace Tribal_Pelts.PeltCreation.Modded.Overlaps
{
	public class BeaverPeltHandler
	{
		public static List<Tribe> tribesToPass = new List<Tribe>();

		public static void InitializeBeaverPelt()
		{
			if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(TribalPelts.NevernamedsSigilariumGuid))
			{
				tribesToPass.Add(GetCustomTribeUtil.GetCustomTribe(TribalPelts.NevernamedsSigilariumGuid, "Rodent"));
			}
			if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(TribalPelts.VerminTribeGuid))
			{
				tribesToPass.Add(GetCustomTribeUtil.GetCustomTribe(TribalPelts.BundleOfTotemsGuid, "rodent"));
			}
			if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(TribalPelts.BundleOfTotemsGuid))
			{
				tribesToPass.Add(Tribe.Squirrel);
			}
			BeaverPelt.CreateBeaverPelt(tribesToPass);
		}
	}
}