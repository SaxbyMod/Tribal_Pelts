using DiskCardGame;
using InscryptionAPI.Pelts;
using Tribal_Pelts.Util;
using InscryptionAPI.Card;
using InscryptionAPI.Pelts.Extensions;
using System.Collections.Generic;

namespace Tribal_Pelts.PeltCreation.BaseGame.Pelts
{
	public class HoovedPelt
	{
		public static void CreateHoovedPelt()
		{
			List<Tribe> tribestoPass = new List<Tribe>() {Tribe.Hooved};
			CardInfo info = CreateCardUtil.CreateCard("Vanilla_Hooved_Pelt", "Deer Pelt", "Deer_Pelt.png", "none.png", 0, 2, tribestoPass);
			PeltManager.New(TribalPelts.PluginGuid, info, 6, 0, 4,
				() =>
				{
					return CardManager.AllCardsCopy.FindAll((a) => a.IsOfTribe(Tribe.Hooved) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
				}).SetTierName("Deer Pelts");
		}
	}
}