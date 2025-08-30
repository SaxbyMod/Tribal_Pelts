using DiskCardGame;
using InscryptionAPI.Pelts;
using Tribal_Pelts.Util;
using InscryptionAPI.Card;
using InscryptionAPI.Pelts.Extensions;
using System.Collections.Generic;

namespace Tribal_Pelts.PeltCreation.BaseGame.Pelts
{
	public class CaninePelt
	{
		public static void CreateCaninePelt()
		{
			List<Tribe> tribestoPass = new List<Tribe>() {Tribe.Canine};
			CardInfo info = CreateCardUtil.CreateCard("Vanilla_Canine_Pelt", "Coyote Pelt", "Canine_Pelt.png", "none.png", 0, 2, tribestoPass);
			PeltManager.New(TribalPelts.PluginGuid, info, 6, 0, 4,
				() =>
				{
					return CardManager.AllCardsCopy.FindAll((a) => a.IsOfTribe(Tribe.Canine) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
				}).SetTierName("Coyote Pelts");
		}
	}
}