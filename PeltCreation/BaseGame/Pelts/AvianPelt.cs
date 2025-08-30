using DiskCardGame;
using InscryptionAPI.Pelts;
using Tribal_Pelts.Util;
using InscryptionAPI.Card;
using InscryptionAPI.Pelts.Extensions;
using System.Collections.Generic;

namespace Tribal_Pelts.PeltCreation.BaseGame.Pelts
{
	public class AvianPelt
	{
		public static void CreateAvianPelt()
		{
			List<Tribe> tribestoPass = new List<Tribe>() {Tribe.Bird};
			CardInfo info = CreateCardUtil.CreateCard("Vanilla_Bird_Pelt", "Raven Epidermis", "Avian_Pelt.png", "none.png", 0, 2, tribestoPass);
			PeltManager.New(TribalPelts.PluginGuid, info, 6, 0, 4,
				() =>
				{
					return CardManager.AllCardsCopy.FindAll((a) => a.IsOfTribe(Tribe.Bird) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
				}).SetTierName("Raven Epidermises");
		}
	}
}