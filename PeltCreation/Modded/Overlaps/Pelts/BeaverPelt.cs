using DiskCardGame;
using InscryptionAPI.Pelts;
using Tribal_Pelts.Util;
using InscryptionAPI.Card;
using InscryptionAPI.Pelts.Extensions;
using System.Collections.Generic;

namespace Tribal_Pelts.PeltCreation.Modded.Overlaps.Pelts
{
	public class BeaverPelt
	{
		public static void CreateBeaverPelt(List<Tribe> tribesToPass)
		{
			CardInfo info = CreateCardUtil.CreateCard("Overlaps_Rodent_Pelt", "Beaver Pelt", "Beaver Pelt.png", "None.png", 0, 2, tribesToPass);

			PeltManager.New(TribalPelts.PluginGuid, info, 6, 0, 4,
				() =>
				{
					return CardManager.AllCardsCopy.FindAll((a) =>
						a.IsOfTribe(GetCustomTribeUtil.GetCustomTribe(TribalPelts.NevernamedsSigilariumGuid, "Rodent")) || a.IsOfTribe(GetCustomTribeUtil.GetCustomTribe(TribalPelts.BundleOfTotemsGuid, "rodent")) || a.IsOfTribe(Tribe.Squirrel) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
				}
			).SetTierName("Beaver Pelts");
		}
	}
}