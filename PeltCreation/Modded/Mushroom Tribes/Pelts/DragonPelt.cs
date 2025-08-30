using DiskCardGame;
using InscryptionAPI.Pelts;
using Tribal_Pelts.Util;
using InscryptionAPI.Card;
using InscryptionAPI.Pelts.Extensions;
using System.Collections.Generic;

namespace Tribal_Pelts.PeltCreation.Modded.Mushroom_Tribes.Pelts
{
	public class DragonPelt
	{
		public static void CreateDragonPelt()
		{
			List<Tribe> tribestoPass = new List<Tribe>() {};
			CardInfo info = CreateCardUtil.CreateCard("Mushroom_Dragon_Pelt", "Dragon Pelt", "Dragon Pelt.png", "Dragon Pelt_e.png", 0, 2, tribestoPass);
			PeltManager.New(TribalPelts.PluginGuid, info, 6, 0, 4,
				() =>
				{
					return CardManager.AllCardsCopy.FindAll((a) =>
						a.IsOfTribe(GetCustomTribeUtil.GetCustomTribe(TribalPelts.MushroomTribesGuid, "dinosaur")) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
				}
			).SetTierName("Dragon Pelts");
		}
	}
}