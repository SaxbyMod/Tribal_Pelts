using DiskCardGame;
using InscryptionAPI.Pelts;
using Tribal_Pelts.Util;
using InscryptionAPI.Card;
using InscryptionAPI.Pelts.Extensions;
using System.Collections.Generic;

namespace Tribal_Pelts.PeltCreation.Modded.Mushroom_Tribes.Pelts
{
	public class TanukiPelt
	{
		public static void CreateTanukiPelt()
		{
			List<Tribe> tribestoPass = new List<Tribe>() {GetCustomTribeUtil.GetCustomTribe(TribalPelts.MushroomTribesGuid, "tanuki")};
			CardInfo info = CreateCardUtil.CreateCard("Mushroom_Tanuki_Pelt", "Tanuki Pelt", "Tanuki Pelt.png", "Tanuki Pelt_e.png", 0, 2, tribestoPass);
			PeltManager.New(TribalPelts.PluginGuid, info, 6, 0, 4,
				() =>
				{
					return CardManager.AllCardsCopy.FindAll((a) =>
						a.IsOfTribe(GetCustomTribeUtil.GetCustomTribe(TribalPelts.MushroomTribesGuid, "tanuki")) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
				}
			).SetTierName("Takuni Pelts");
		}
	}
}