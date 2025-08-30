using DiskCardGame;
using InscryptionAPI.Pelts;
using Tribal_Pelts.Util;
using InscryptionAPI.Card;
using InscryptionAPI.Pelts.Extensions;
using System.Collections.Generic;

namespace Tribal_Pelts.PeltCreation.Modded.Mushroom_Tribes.Pelts
{
	public class WaddlewingPelt
	{
		public static void CreateWaddlewingPelt()
		{
			List<Tribe> tribestoPass = new List<Tribe>() {GetCustomTribeUtil.GetCustomTribe(TribalPelts.MushroomTribesGuid, "waddlewing")};
			CardInfo info = CreateCardUtil.CreateCard("Mushroom_Waddlewing_Pelt", "Waddlewing Pelt", "Waddlewing Pelt.png", "Waddlewing Pelt_e.png", 0, 2, tribestoPass);
			PeltManager.New(TribalPelts.PluginGuid, info, 6, 0, 4,
				() =>
				{
					return CardManager.AllCardsCopy.FindAll((a) =>
						a.IsOfTribe(GetCustomTribeUtil.GetCustomTribe(TribalPelts.MushroomTribesGuid, "waddlewing")) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
				}
			).SetTierName("Waddlewing Pelts");
		}
	}
}