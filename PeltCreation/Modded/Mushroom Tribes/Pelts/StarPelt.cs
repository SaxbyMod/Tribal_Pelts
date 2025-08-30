using DiskCardGame;
using InscryptionAPI.Pelts;
using Tribal_Pelts.Util;
using InscryptionAPI.Card;
using InscryptionAPI.Pelts.Extensions;
using System.Collections.Generic;

namespace Tribal_Pelts.PeltCreation.Modded.Mushroom_Tribes.Pelts
{
	public class StarPelt
	{
		public static void CreateStarPelt()
		{
			List<Tribe> tribestoPass = new List<Tribe>() {GetCustomTribeUtil.GetCustomTribe(TribalPelts.MushroomTribesGuid, "star")};
			CardInfo info = CreateCardUtil.CreateCard("Mushroom_Star_Pelt", "Star Pelt", "Star Pelt.png", "Star Pelt_e.png", 0, 2, tribestoPass);
			PeltManager.New(TribalPelts.PluginGuid, info, 6, 0, 4,
				() =>
				{
					return CardManager.AllCardsCopy.FindAll((a) =>
						a.IsOfTribe(GetCustomTribeUtil.GetCustomTribe(TribalPelts.MushroomTribesGuid, "star")) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
				}
			).SetTierName("Star Pelts");
		}
	}
}