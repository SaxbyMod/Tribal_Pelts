using DiskCardGame;
using InscryptionAPI.Pelts;
using Tribal_Pelts.Util;
using InscryptionAPI.Card;
using InscryptionAPI.Pelts.Extensions;
using System.Collections.Generic;

namespace Tribal_Pelts.PeltCreation.BaseGame.Pelts
{
	public class ReptilePelt
	{
		public static void CreateReptilePelt()
		{
			List<Tribe> tribestoPass = new List<Tribe>() {Tribe.Reptile};
			CardInfo info = CreateCardUtil.CreateCard("Vanilla_Reptile_Pelt", "Crocodile Hide", "Reptile_Pelt.png", "none.png", 0, 2, tribestoPass);
			PeltManager.New(TribalPelts.PluginGuid, info, 6, 0, 4,
				() =>
				{
					return CardManager.AllCardsCopy.FindAll((a) => a.IsOfTribe(Tribe.Reptile) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
				}).SetTierName("Crocodile Hides");
		}
	}
}