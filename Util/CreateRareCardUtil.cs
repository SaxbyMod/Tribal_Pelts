using DiskCardGame;
using InscryptionAPI.Card;
using System.Collections.Generic;

namespace Tribal_Pelts.Util
{
	public class CreateRareCardUtil
	{
		// Code from JamesGames
		public static CardInfo CreateRareCard(string name, string displayName, string imagePath, string imagePathEmisive, int attack, int health, List<Tribe> tribe)
		{
			CardInfo info = CreateCardUtil.CreateCard(name, displayName, imagePath, imagePathEmisive, attack, health, tribe);
			info.AddAppearances(CardAppearanceBehaviour.Appearance.GoldEmission);

			return info;
		}
	}
}