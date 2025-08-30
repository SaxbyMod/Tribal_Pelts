using DiskCardGame;
using InscryptionAPI.Pelts;
using Tribal_Pelts.Util;
using InscryptionAPI.Card;
using InscryptionAPI.Pelts.Extensions;
using System.Collections.Generic;

namespace Tribal_Pelts.PeltCreation.Modded.Mushroom_Tribes.Pelts
{
	public class PowerUpPelt
	{
		public static void CreatePowerUpPelt()
		{
			List<Tribe> tribestoPass = new List<Tribe>() {GetCustomTribeUtil.GetCustomTribe(TribalPelts.MushroomTribesGuid, "power_up")};
			CardInfo info = CreateCardUtil.CreateCard("Mushroom_Power_Up_Pelt", "Power-Up Pelt", "Power-Up Pelt.png", "Power-Up Pelt_e.png", 0, 2, tribestoPass);
			PeltManager.New(TribalPelts.PluginGuid, info, 6, 0, 4,
				() =>
				{
					return CardManager.AllCardsCopy.FindAll((a) =>
						a.IsOfTribe(GetCustomTribeUtil.GetCustomTribe(TribalPelts.MushroomTribesGuid, "power_up")) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
				}
			).SetTierName("Power Up Pelts");
		}
	}
}