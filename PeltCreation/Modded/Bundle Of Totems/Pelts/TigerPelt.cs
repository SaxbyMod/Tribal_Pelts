using DiskCardGame;
using InscryptionAPI.Pelts;
using Tribal_Pelts.Util;
using InscryptionAPI.Card;
using InscryptionAPI.Pelts.Extensions;
using System.Collections.Generic;

namespace Tribal_Pelts.PeltCreation.Modded.Bundle_Of_Totems.Pelts
{
	public class TigerPelt
	{
		public static void CreateTigerPelt()
		{
			List<Tribe> tribestoPass = new List<Tribe>() {GetCustomTribeUtil.GetCustomTribe(TribalPelts.BundleOfTotemsGuid, "feline")};
			CardInfo info = CreateCardUtil.CreateCard("Bundle_Of_Totems_Feline_Pelt", "Tiger Pelt", "Tiger Pelt.png", "None.png", 0, 2, tribestoPass);
			PeltManager.New(TribalPelts.PluginGuid, info, 6, 0, 4,
				() =>
				{
					return CardManager.AllCardsCopy.FindAll((a) =>
						a.IsOfTribe(GetCustomTribeUtil.GetCustomTribe(TribalPelts.BundleOfTotemsGuid, "feline")) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
				}
			).SetTierName("Tiger Pelts");
		}
	}
}