using DiskCardGame;
using InscryptionAPI.Pelts;
using Tribal_Pelts.Util;
using InscryptionAPI.Card;
using InscryptionAPI.Pelts.Extensions;
using System.Collections.Generic;

namespace Tribal_Pelts.PeltCreation.Modded.Mushroom_Tribes.Pelts
{
	public class DryBonesPelt
	{
		public static void CreateDryBonesPelt()
		{
			List<Tribe> tribestoPass = new List<Tribe>() {GetCustomTribeUtil.GetCustomTribe(TribalPelts.MushroomTribesGuid, "mskeleton")};
			CardInfo info = CreateCardUtil.CreateCard("Mushroom_Dry_Bones_Pelt", "Dry Bones Pelt", "Dry Bones Pelt.png", "Dry Bones Pelt_e.png", 0, 2, tribestoPass);
			PeltManager.New(TribalPelts.PluginGuid, info, 6, 0, 4,
				() =>
				{
					return CardManager.AllCardsCopy.FindAll((a) =>
						a.IsOfTribe(GetCustomTribeUtil.GetCustomTribe(TribalPelts.MushroomTribesGuid, "mskeleton")) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
				}
			).SetTierName("Dry Bones Pelts");
		}
	}
}