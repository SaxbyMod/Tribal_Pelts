using DiskCardGame;
using InscryptionAPI.Card;
using InscryptionAPI.Helpers;
using System.IO;
using System.Collections.Generic;

namespace Tribal_Pelts.Util
{
	public class CreateCardUtil
	{
		// Code from JamesGames
		public static CardInfo CreateCard(string name, string displayName, string imagePath, string imagePathEmisive, int attack, int health, List<Tribe> tribe)
		{
			CardInfo info = CardManager.New(TribalPelts.PluginGuid, name, displayName, attack, health);
			info.SetPortrait(TextureHelper.GetImageAsTexture(Path.Combine(imagePath)));
			info.SetEmissivePortrait(TextureHelper.GetImageAsTexture(Path.Combine(imagePathEmisive)));
			info.cardComplexity = CardComplexity.Simple;
			info.AddTraits(Trait.Pelt);
			foreach (Tribe currentTribe in tribe)
			{
				if (currentTribe != Tribe.None)
				{
					info.AddTribes(currentTribe);
				}
			}
			info.temple = CardTemple.Nature;
			info.AddSpecialAbilities(SpecialTriggeredAbility.SpawnLice);
			info.AddAppearances(CardAppearanceBehaviour.Appearance.TerrainBackground, CardAppearanceBehaviour.Appearance.TerrainLayout);

			return info;
		}
	}
}