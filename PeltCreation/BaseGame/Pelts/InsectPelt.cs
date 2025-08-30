using DiskCardGame;
using InscryptionAPI.Pelts;
using Tribal_Pelts.Util;
using InscryptionAPI.Card;
using InscryptionAPI.Pelts.Extensions;
using System.Collections.Generic;

namespace Tribal_Pelts.PeltCreation.BaseGame.Pelts
{
	public class InsectPelt
	{
		public static void CreateInsectPelt()
		{
			List<Tribe> tribestoPass = new List<Tribe>() {Tribe.Insect};
			CardInfo info = CreateCardUtil.CreateCard("Vanilla_Insect_Pelt", "Moth Molt", "Insect_Pelt.png", "none.png", 0, 2, tribestoPass);
			PeltManager.New(TribalPelts.PluginGuid, info, 6, 0, 4,
				() =>
				{
					return CardManager.AllCardsCopy.FindAll((a) => a.IsOfTribe(Tribe.Insect) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
				}).SetTierName("Moth Molts");
		}
	}
}