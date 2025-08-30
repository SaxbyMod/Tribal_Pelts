using DiskCardGame;
using InscryptionAPI.Pelts;
using Tribal_Pelts.Util;
using InscryptionAPI.Card;
using InscryptionAPI.Pelts.Extensions;
using System.Collections.Generic;

namespace Tribal_Pelts.PeltCreation.Modded.Nevernameds_Sigilarium.Pelts
{
	public class SpiderSkin
	{
		public static void CreateSpiderSkin()
		{
			List<Tribe> tribestoPass = new List<Tribe>() {GetCustomTribeUtil.GetCustomTribe(TribalPelts.NevernamedsSigilariumGuid, "Arachnid")};
			CardInfo info = CreateCardUtil.CreateCard("Nevernameds_Sigilarium_Arachnid_Pelt", "Spider Skin", "Spider Skin.png", "None.png", 0, 2, tribestoPass);
			PeltManager.New(TribalPelts.PluginGuid, info, 6, 0, 4,
				() =>
				{
					return CardManager.AllCardsCopy.FindAll((a) =>
						a.IsOfTribe(GetCustomTribeUtil.GetCustomTribe(TribalPelts.NevernamedsSigilariumGuid, "Arachnid")) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
				}
			).SetTierName("Spider Skins");
		}
	}
}