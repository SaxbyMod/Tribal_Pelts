using Tribal_Pelts.PeltCreation.Modded.Nevernameds_Sigilarium.Pelts;

namespace Tribal_Pelts.PeltCreation.Modded.Nevernameds_Sigilarium
{
	public class NevernamedsSigilariumPelts
	{
		public static int Init(int Count)
        {
            LobsterShell.CreateLobsterShell();
            Count++;
            SpiderSkin.CreateSpiderSkin();
            Count++;

            return Count;
        }
	}
}