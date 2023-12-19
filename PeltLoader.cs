using BepInEx;
using DiskCardGame;
using HarmonyLib;
using InscryptionAPI.Card;
using InscryptionAPI.Helpers;
using InscryptionAPI.Pelts;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Tribal_Pelts
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    [BepInDependency("cyantist.inscryption.api", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency(JGUID, BepInDependency.DependencyFlags.SoftDependency)]
    [BepInDependency(LGUID, BepInDependency.DependencyFlags.SoftDependency)]
    [BepInDependency(TGUID, BepInDependency.DependencyFlags.SoftDependency)]
    [BepInDependency(NGUID, BepInDependency.DependencyFlags.SoftDependency)]
    [BepInDependency(ZGUID, BepInDependency.DependencyFlags.SoftDependency)]
    [BepInDependency(VGUID, BepInDependency.DependencyFlags.SoftDependency)]
    [BepInDependency(WGUID, BepInDependency.DependencyFlags.SoftDependency)]
    // [BepInDependency("cyantist.inscryption.api", BepInDependency.DependencyFlags.SoftDependency)] ADD MK Tribes

    public class PeltLoader : BaseUnityPlugin
    {
        // --------------------------------------------------------------------------------------------------------------------------------------------------

        // Declare Harmony here for future Harmony patches. You'll use Harmony to patch the game's code outside of the scope of the API.
        Harmony harmony = new Harmony(PluginGuid);

        // These are variables that exist everywhere in the entire class.
        private const string PluginGuid = "creator.TribalPelts";
        private const string PluginName = "TribalPelts";
        private const string PluginVersion = "1.0.0";
        private const string PluginPrefix = "TribalPelts";
        public const string TGUID = "tribes.libary";
        public const string NGUID = "nevernamed.inscryption.sigils";
        public const string ZGUID = "zepht.inscryption.ZephtPvZ";
        public const string VGUID = "extraVoid.inscryption.VerminTribe";
        public const string JGUID = "MADH.inscryption.JSONLoader";
        public const string WGUID = "whistlewind.inscryption.abnormalsigils";
        public const string LGUID = "Lily.BOT";


        // For some things, like challenge icons, we need to add the art now instead of later.
        // We initialize the list here, in Awake() we'll add the sprites themselves.
        public static List<Sprite> art_sprites;
        // This is where you would run all of your other methods.
        private void Awake()
        {
            // Apply our harmony patches.
            int i = 0;
            harmony.PatchAll(typeof(PeltLoader));
            AvianPelt();
            CaninePelt();
            HoovedPelt();
            TurtlePelt();
            InsectPelt();

            static CardInfo CreateCard(string displayName, string imagePath, int attack, int health, Tribe tribe)
            {
                CardInfo info = CardManager.New(PluginGuid, displayName, displayName, attack, health);
                info.SetPortrait(TextureHelper.GetImageAsTexture(Path.Combine(imagePath)));
                info.cardComplexity = CardComplexity.Simple;
                info.AddTraits(Trait.Pelt);
                if (tribe != Tribe.None) info.AddTribes(tribe);
                info.temple = CardTemple.Nature;
                info.AddSpecialAbilities(SpecialTriggeredAbility.SpawnLice);
                info.AddAppearances(CardAppearanceBehaviour.Appearance.TerrainBackground, CardAppearanceBehaviour.Appearance.TerrainLayout);

                return info;
            }
            static CardInfo CreateRareCard(string displayName, string imagePath, int attack, int health, Tribe tribe)
            {
                CardInfo info = CreateCard(displayName, imagePath, attack, health, Tribe.None);
                info.AddAppearances(CardAppearanceBehaviour.Appearance.GoldEmission);

                return info;
            }

            static void AvianPelt()
            {
                CardInfo info = CreateCard("Raven Epidermis", "Avian_Pelt.png", 0, 2, Tribe.Bird);

                PeltManager.New(PluginGuid, info, 5, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.IsOfTribe(Tribe.Bird) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            i++;
            static void CaninePelt()
            {
                CardInfo info = CreateCard("Coyote Pelt", "Canine_Pelt.png", 0, 2, Tribe.Canine);

                PeltManager.New(PluginGuid, info, 5, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.IsOfTribe(Tribe.Canine) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            i++;
            static void InsectPelt()
            {
                CardInfo info = CreateCard("Moth Molt", "Insect_Pelt.png", 0, 2, Tribe.Insect);

                PeltManager.New(PluginGuid, info, 5, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.IsOfTribe(Tribe.Insect) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            i++;
            static void HoovedPelt()
            {
                CardInfo info = CreateCard("Deer Pelt", "Deer_Pelt.png", 0, 2, Tribe.Hooved);

                PeltManager.New(PluginGuid, info, 5, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.IsOfTribe(Tribe.Hooved) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            i++;
            static void TurtlePelt()
            {
                CardInfo info = CreateCard("Crocodile Hide", "Reptile_Pelt.png", 0, 2, Tribe.Reptile);

                PeltManager.New(PluginGuid, info, 5, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.IsOfTribe(Tribe.Reptile) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            i++;

            if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(TGUID))
            {
                Logger.LogMessage("Do I see The other DLL? I do, I do see the other DLL! (Tribal Libary)");
            }
            else if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(JGUID))
            {
                Logger.LogMessage("Do I see The other DLL? I do, I do see the other DLL! (JSON Loader [Likely for Prof. Eggnogs LFTD Tribes])");
            }
            else if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(NGUID))
            {
                Logger.LogMessage("Do I see The other DLL? I do, I do see the other DLL! (Nevernameds Sigilarium)");
            }
            else if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(ZGUID))
            {
                Logger.LogMessage("Do I see The other DLL? I do, I do see the other DLL! (Plants Vs Zombies)");
            }
            else if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(VGUID))
            {
                Logger.LogMessage("Do I see The other DLL? I do, I do see the other DLL! (Vermin Tribe)");
            }
            else if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(WGUID))
            {
                Logger.LogMessage("Do I see The other DLL? I do, I do see the other DLL! (Abnormal Sigils)");
            }
            else if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(LGUID))
            {
                Logger.LogMessage("Do I see The other DLL? I do, I do see the other DLL! (Bundle O' Totems)");
            }
            else
            {
                Logger.LogMessage("I See no extension DLL's applying Zero Expansions.");
            }
            Logger.LogInfo($"Sucsessfully Loaded {i} Pelt(s)!");
        }
    }
}