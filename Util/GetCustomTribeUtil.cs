using DiskCardGame;
using InscryptionAPI.Guid;

namespace Tribal_Pelts.Util
{
	public class GetCustomTribeUtil
	{
		// Code from Lily
		public static Tribe GetCustomTribe(string GUID, string name)
		{
			return GuidManager.GetEnumValue<Tribe>(GUID, name);
		}
	}
}