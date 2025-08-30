using BepInEx;
using HarmonyLib;
using Tribal_Pelts.PeltCreation;
using BepInEx.Logging;

namespace Tribal_Pelts
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    [BepInDependency("cyantist.inscryption.api")]
    [BepInDependency(BundleOfTotemsGuid, BepInDependency.DependencyFlags.SoftDependency)]
    [BepInDependency(NevernamedsSigilariumGuid, BepInDependency.DependencyFlags.SoftDependency)]
    [BepInDependency(VerminTribeGuid, BepInDependency.DependencyFlags.SoftDependency)]
    [BepInDependency(MushroomTribesGuid, BepInDependency.DependencyFlags.SoftDependency)]

    public class TribalPelts : BaseUnityPlugin
    {
        public const string PluginGuid = "creator.TribalPelts";
        public const string PluginName = "TribalPelts";
        public const string PluginVersion = "3.0.0";
        public const string PluginPrefix = "TribalPelts";
        
        // Extension GUIDS
        public const string NevernamedsSigilariumGuid = "nevernamed.inscryption.sigils";
        public const string VerminTribeGuid = "extraVoid.inscryption.VerminTribe";
        public const string BundleOfTotemsGuid = "Lily.BOT";
        public const string MushroomTribesGuid = "mushroom.pelts";
        
        // Define a Manual Log Source
        public static ManualLogSource Log = new ManualLogSource(PluginName);

        // Declare Harmony here for future Harmony patches. You'll use Harmony to patch the game's code outside of the scope of the API.
        public static Harmony Harmony = new(PluginGuid);

        public int PeltIterator;

        // Code for Everything:
        public void Awake()
        {
            PeltIterator = InitializePelts.Init(PeltIterator);
            Log.LogMessage($"Successfully Loaded {PeltIterator} Pelt(s)!");
        }
    }
}