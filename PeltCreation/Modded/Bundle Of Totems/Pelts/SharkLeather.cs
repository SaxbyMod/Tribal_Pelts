using DiskCardGame;
using InscryptionAPI.Pelts;
using Tribal_Pelts.Util;
using InscryptionAPI.Card;
using InscryptionAPI.Pelts.Extensions;
using System.Collections.Generic;

namespace Tribal_Pelts.PeltCreation.Modded.Bundle_Of_Totems.Pelts
{
	public class SharkLeather
	{
		public static void CreateSharkLeather()
		{
			List<Tribe> tribestoPass = new List<Tribe>() {GetCustomTribeUtil.GetCustomTribe(TribalPelts.BundleOfTotemsGuid, "aquatic")};
			CardInfo info = CreateCardUtil.CreateCard("Bundle_Of_Totems_Aquatic_Pelt", "Shark Leather", "Shark Leather.png", "None.png", 0, 2, tribestoPass);
			PeltManager.New(TribalPelts.PluginGuid, info, 6, 0, 4,
				() =>
				{
					return CardManager.AllCardsCopy.FindAll((a) =>
						a.IsOfTribe(GetCustomTribeUtil.GetCustomTribe(TribalPelts.BundleOfTotemsGuid, "aquatic")) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
				}
			).SetTierName("Shark Leather");
		}
	}
}