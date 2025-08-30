using DiskCardGame;
using InscryptionAPI.Pelts;
using Tribal_Pelts.Util;
using InscryptionAPI.Card;
using InscryptionAPI.Pelts.Extensions;
using Tribal_Pelts.PeltCreation.BaseGame.Pelts;

namespace Tribal_Pelts.PeltCreation.BaseGame
{
	public class BaseGamePelts
	{
        public static int CreateBaseGamesPelts(int Count)
        {
            AvianPelt.CreateAvianPelt();
            Count++;
            CaninePelt.CreateCaninePelt();
            Count++;
            InsectPelt.CreateInsectPelt();
            Count++;
            HoovedPelt.CreateHoovedPelt();
            Count++;
            ReptilePelt.CreateReptilePelt();
            Count++;
            return Count;
        }
    }
}