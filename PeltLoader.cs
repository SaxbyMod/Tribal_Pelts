using BepInEx;
using DiskCardGame;
using HarmonyLib;
using InscryptionAPI.Card;
using InscryptionAPI.Guid;
using InscryptionAPI.Helpers;
using InscryptionAPI.Pelts;
using System.IO;

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
    [BepInDependency(MGUID, BepInDependency.DependencyFlags.SoftDependency)]
    // [BepInDependency("cyantist.inscryption.api", BepInDependency.DependencyFlags.SoftDependency)] ADD MK Tribes

    public class PeltLoader : BaseUnityPlugin
    {
        // --------------------------------------------------------------------------------------------------------------------------------------------------

        // Declare Harmony here for future Harmony patches. You'll use Harmony to patch the game's code outside of the scope of the API.
        readonly Harmony harmony = new(PluginGuid);

        // These are variables that exist everywhere in the entire class.
        private const string PluginGuid = "creator.TribalPelts";
        private const string PluginName = "TribalPelts";
        private const string PluginVersion = "2.2.0";
        private const string PluginPrefix = "TribalPelts";
        public const string TGUID = "tribes.libary";
        public const string NGUID = "nevernamed.inscryption.sigils";
        public const string ZGUID = "zepht.inscryption.ZephtPvZ";
        public const string VGUID = "extraVoid.inscryption.VerminTribe";
        public const string JGUID = "MADH.inscryption.JSONLoader";
        public const string WGUID = "whistlewind.inscryption.abnormalsigils";
        public const string LGUID = "Lily.BOT";
        public const string MGUID = "mushroom.pelts";
        public int Count = 0;

        public static CardInfo CreateCard(string name, string displayName, string imagePath, string imagePathEmisive, int attack, int health, Tribe tribe)
        {
            CardInfo info = CardManager.New(PeltLoader.PluginGuid, name, displayName, attack, health);
            info.SetPortrait(TextureHelper.GetImageAsTexture(Path.Combine(imagePath)));
            info.SetEmissivePortrait(TextureHelper.GetImageAsTexture(Path.Combine(imagePathEmisive)));
            info.cardComplexity = CardComplexity.Simple;
            info.AddTraits(Trait.Pelt);
            if (tribe != Tribe.None) info.AddTribes(tribe);
            info.temple = CardTemple.Nature;
            info.AddSpecialAbilities(SpecialTriggeredAbility.SpawnLice);
            info.AddAppearances(CardAppearanceBehaviour.Appearance.TerrainBackground, CardAppearanceBehaviour.Appearance.TerrainLayout);

            return info;
        }
        public static CardInfo CreateRareCard(string name, string displayName, string imagePath, string imagePathEmisive, int attack, int health, Tribe tribe)
        {
            CardInfo info = CreateCard(name, displayName, imagePath, imagePathEmisive, attack, health, Tribe.None);
            info.AddAppearances(CardAppearanceBehaviour.Appearance.GoldEmission);

            return info;
        }

        public static Tribe GetCustomTribe(string GUID, string name)
        {
            return GuidManager.GetEnumValue<Tribe>(GUID, name);
        }

        // Code for Everything:
        public void Awake()
        {
            AvianPelt();
            CaninePelt();
            HoovedPelt();
            TurtlePelt();
            InsectPelt();

            static void AvianPelt()
            {
                CardInfo info = CreateCard("Vanila_Bird_Pelt", "Raven Epidermis", "Avian_Pelt.png", "none.png", 0, 2, Tribe.Bird);

                PeltManager.New(PluginGuid, info, 6, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.IsOfTribe(Tribe.Bird) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            Count++;
            static void CaninePelt()
            {
                CardInfo info = CreateCard("Vanila_Canine_Pelt", "Coyote Pelt", "Canine_Pelt.png", "none.png", 0, 2, Tribe.Canine);

                PeltManager.New(PluginGuid, info, 6, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.IsOfTribe(Tribe.Canine) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            Count++;
            static void InsectPelt()
            {
                CardInfo info = CreateCard("Vanila_Insect_Pelt", "Moth Molt", "Insect_Pelt.png", "none.png", 0, 2, Tribe.Insect);

                PeltManager.New(PluginGuid, info, 6, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.IsOfTribe(Tribe.Insect) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            Count++;
            static void HoovedPelt()
            {
                CardInfo info = CreateCard("Vanila_Hooved_Pelt", "Deer Pelt", "Deer_Pelt.png", "none.png", 0, 2, Tribe.Hooved);

                PeltManager.New(PluginGuid, info, 6, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.IsOfTribe(Tribe.Hooved) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            Count++;
            static void TurtlePelt()
            {
                CardInfo info = CreateCard("Vanila_Reptile_Pelt", "Crocodile Hide", "Reptile_Pelt.png", "none.png", 0, 2, Tribe.Reptile);

                PeltManager.New(PluginGuid, info, 6, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.IsOfTribe(Tribe.Reptile) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            Count++;

            if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(TGUID))
            {
                Logger.LogMessage("Do I see The other DLL? I do, I do see the other DLL! (Tribal Libary)");
            }
            /*
            if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(JGUID))
            {
                Logger.LogMessage("Do I see The other DLL? I do, I do see the other DLL! (JSON Loader)");
                if (GetCustomTribe("LFTD.tribe", "Feline") != null)
                {
                    Logger.LogMessage("Do I See LFTD Tribes? I do, I do see LFTD Tribes! (LFTD Tribes)");
                    LFTDTribes();
                }
            }
            */
            if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(NGUID))
            {
                Logger.LogMessage("Do I see The other DLL? I do, I do see the other DLL! (Nevernameds Sigilarium)");
                NeverNamedsSigilarium();
            }
            if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(ZGUID))
            {
                Logger.LogMessage("Do I see The other DLL? I do, I do see the other DLL! (Plants Vs Zombies)");
            }
            if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(VGUID))
            {
                Logger.LogMessage("Do I see The other DLL? I do, I do see the other DLL! (Vermin Tribe)");
                VerminTribe();
            }
            if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(WGUID))
            {
                Logger.LogMessage("Do I see The other DLL? I do, I do see the other DLL! (Abnormal Sigils)");
            }
            if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(LGUID))
            {
                Logger.LogMessage("Do I see The other DLL? I do, I do see the other DLL! (Bundle O' Totems)");
                BundleOTotems();
            }
            if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(MGUID))
            {
                Logger.LogMessage("Do I see The other DLL? I do, I do see the other DLL! (Mushroom Tribes)");
                MushroomTribesPelts();
            }
            else
            {
                Logger.LogMessage("Do I see the Other DLL? I dont, I dont see any other DLLs!");
            }
            Logger.LogMessage($"Successfully Loaded {Count} Pelt(s)!");
        }

        public void BundleOTotems()
        {
            HumanRemains();
            SharkLeather();
            TigerPelt();
            BeaverPelt();

            static void HumanRemains()
            {
                CardInfo info = CreateCard("Bundle_Of_Totems_Undead_Pelt", "Human Remains", "Human Remains.png", "None.png", 0, 2, GetCustomTribe(LGUID, "undead"));

                PeltManager.New(PeltLoader.PluginGuid, info, 6, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.IsOfTribe(GetCustomTribe(LGUID, "undead")) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            Count++;
            static void SharkLeather()
            {
                CardInfo info = CreateCard("Bundle_Of_Totems_Aquatic_Pelt", "Shark Leather", "Shark Leather.png", "None.png", 0, 2, GetCustomTribe(LGUID, "aquatic"));

                PeltManager.New(PeltLoader.PluginGuid, info, 6, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.IsOfTribe(GetCustomTribe(LGUID, "aquatic")) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            Count++;
            static void TigerPelt()
            {
                CardInfo info = CreateCard("Bundle_Of_Totems_Feline_Pelt", "Tiger Pelt", "Tiger Pelt.png", "None.png", 0, 2, GetCustomTribe(LGUID, "feline"));

                PeltManager.New(PeltLoader.PluginGuid, info, 6, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.IsOfTribe(GetCustomTribe(LGUID, "feline")) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            Count++;
            static void BeaverPelt()
            {
                CardInfo info = CreateCard("Bundle_Of_Totems_Rodent_Pelt", "Beaver Pelt", "Beaver Pelt.png", "None.png", 0, 2, GetCustomTribe(LGUID, "rodent"));

                PeltManager.New(PeltLoader.PluginGuid, info, 6, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.IsOfTribe(GetCustomTribe(LGUID, "rodent")) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            Count++;
        }
        /*
        public void LFTDTribes()
        {
            HumanRemainsLFTD();
            SharkLeatherLFTD();
            TigerPeltLFTD();

            static void HumanRemainsLFTD()
            {
                CardInfo info = CreateCard("LFTD_Undead_Pelt", "Human Remains [LFTD]", "Human Remains.png", "None.png", 0, 2, GetCustomTribe("LFTD.tribe", "Undead"));

                PeltManager.New(PeltLoader.PluginGuid, info, 6, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.IsOfTribe(GetCustomTribe("LFTD.tribe", "Undead")) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            Count++;
            static void SharkLeatherLFTD()
            {
                CardInfo info = CreateCard("LFTD_Shark_Pelt", "Shark Leather [LFTD]", "Shark Leather.png", "None.png", 0, 2, GetCustomTribe("LFTD.tribe", "Shark"));

                PeltManager.New(PeltLoader.PluginGuid, info, 6, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.IsOfTribe(GetCustomTribe("LFTD.tribe", "Shark")) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            Count++;
            static void TigerPeltLFTD()
            {
                CardInfo info = CreateCard("LFTD_Feline_Pelt", "Tiger Pelt [LFTD]", "Tiger Pelt.png", "None.png", 0, 2, GetCustomTribe("LFTD.tribe", "Feline"));

                PeltManager.New(PeltLoader.PluginGuid, info, 6, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.IsOfTribe(GetCustomTribe("LFTD.tribe", "Feline")) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            Count++;
        }
        */
        public void MushroomTribesPelts()
        {
            BlasterPelt();
            BlockPelt();
            BlooperPelt();
            BobOmbPelt();
            BooPelt();
            BronzePortrait();
            ChainChompPelt();
            CheepCheepPelt();
            ConkdorPelt();
            DragonPelt();
            DryBonesPelt();
            GoldPortrait();
            GoombaPelt();
            KoopaPelt();
            PiranhaPelt();
            PokeyPelt();
            PowerUpPelt();
            RamPelt();
            ShroobPelt();
            ShyGuyPelt();
            SilverPortrait();
            StarPelt();
            SpikePelt();
            TanukiPelt();
            ThwompPelt();
            WaddlewingPelt();
            WigglerPelt();
            PowerMoon();
            StarBits();
            ShineSprite();

            static void BlasterPelt()
            {
                CardInfo info = CreateCard("Mushroom_Blaster_Pelt", "Blaster Pelt", "Blaster Pelt.png", "Blaster Pelt_e.png", 0, 2, MushroomTribes.MushroomTribes.blasterTribe);

                PeltManager.New(PeltLoader.PluginGuid, info, 6, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.IsOfTribe(MushroomTribes.MushroomTribes.blasterTribe) && (a.ModPrefixIs("Mushroom") || a.ModPrefixIs("Gallery")) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            Count++;
            static void BlockPelt()
            {
                CardInfo info = CreateCard("Mushroom_Block_Pelt", "Block Pelt", "Block Pelt.png", "Block Pelt_e.png", 0, 2, MushroomTribes.MushroomTribes.blockTribe);

                PeltManager.New(PeltLoader.PluginGuid, info, 6, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.IsOfTribe(MushroomTribes.MushroomTribes.blockTribe) && (a.ModPrefixIs("Mushroom") || a.ModPrefixIs("Gallery")) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            Count++;
            static void BlooperPelt()
            {
                CardInfo info = CreateCard("Mushroom_Blooper_Pelt", "Blooper Pelt", "Blooper Pelt.png", "Blooper Pelt_e.png", 0, 2, MushroomTribes.MushroomTribes.blooperTribe);

                PeltManager.New(PeltLoader.PluginGuid, info, 6, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.IsOfTribe(MushroomTribes.MushroomTribes.blooperTribe) && (a.ModPrefixIs("Mushroom") || a.ModPrefixIs("Gallery")) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            Count++;
            static void BobOmbPelt()
            {
                CardInfo info = CreateCard("Mushroom_Bob_Omb_Pelt", "Bob-Omb Pelt", "Bob-Omb Pelt.png", "Bob-Omb Pelt_e.png", 0, 2, MushroomTribes.MushroomTribes.bombombTribe);

                PeltManager.New(PeltLoader.PluginGuid, info, 6, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.IsOfTribe(MushroomTribes.MushroomTribes.bombombTribe) && (a.ModPrefixIs("Mushroom") || a.ModPrefixIs("Gallery")) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            Count++;
            static void BooPelt()
            {
                CardInfo info = CreateCard("Mushroom_Boo_Pelt", "Boo Pelt", "Boo Pelt.png", "Boo Pelt_e.png", 0, 2, MushroomTribes.MushroomTribes.booTribe);

                PeltManager.New(PeltLoader.PluginGuid, info, 6, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.IsOfTribe(MushroomTribes.MushroomTribes.booTribe) && (a.ModPrefixIs("Mushroom") || a.ModPrefixIs("Gallery")) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            Count++;
            static void BronzePortrait()
            {
                CardInfo info = CreateCard("Mushroom_Bronze_Portrait", "Bronze Portrait", "Bronze Portrait.png", "Bronze Portrait_e.png", 0, 2, Tribe.None);

                PeltManager.New(PeltLoader.PluginGuid, info, 3, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.ModPrefixIs("Gallery") && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            Count++;
            static void ChainChompPelt()
            {
                CardInfo info = CreateCard("Mushroom_Chain_Chomp_Pelt", "Chain Chomp Pelt", "Chain Chomp Pelt.png", "Chain Chomp Pelt_e.png", 0, 2, MushroomTribes.MushroomTribes.chompTribe);

                PeltManager.New(PeltLoader.PluginGuid, info, 6, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.IsOfTribe(MushroomTribes.MushroomTribes.chompTribe) && (a.ModPrefixIs("Mushroom") || a.ModPrefixIs("Gallery")) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            Count++;
            static void CheepCheepPelt()
            {
                CardInfo info = CreateCard("Mushroom_Cheep_Cheep_Pelt", "Cheep-Cheep Pelt", "Cheep-Cheep Pelt.png", "Cheep-Cheep Pelt_e.png", 0, 2, MushroomTribes.MushroomTribes.cheepCheepTribe);

                PeltManager.New(PeltLoader.PluginGuid, info, 6, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.IsOfTribe(MushroomTribes.MushroomTribes.cheepCheepTribe) && (a.ModPrefixIs("Mushroom") || a.ModPrefixIs("Gallery")) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            Count++;
            static void ConkdorPelt()
            {
                CardInfo info = CreateCard("Mushroom_Conkdor_Pelt", "Conkdor Pelt", "Conkdor Pelt.png", "Conkdor Pelt_e.png", 0, 2, MushroomTribes.MushroomTribes.conkdorTribe);

                PeltManager.New(PeltLoader.PluginGuid, info, 6, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.IsOfTribe(MushroomTribes.MushroomTribes.conkdorTribe) && (a.ModPrefixIs("Mushroom") || a.ModPrefixIs("Gallery")) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            Count++;
            static void DragonPelt()
            {
                CardInfo info = CreateCard("Mushroom_Dragon_Pelt", "Dragon Pelt", "Dragon Pelt.png", "Dragon Pelt_e.png", 0, 2, MushroomTribes.MushroomTribes.dinosaurTribe);

                PeltManager.New(PeltLoader.PluginGuid, info, 6, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.IsOfTribe(MushroomTribes.MushroomTribes.dinosaurTribe) && (a.ModPrefixIs("Mushroom") || a.ModPrefixIs("Gallery")) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            Count++;
            static void DryBonesPelt()
            {
                CardInfo info = CreateCard("Mushroom_Dry_Bones_Pelt", "Dry Bones Pelt", "Dry Bones Pelt.png", "Dry Bones Pelt_e.png", 0, 2, MushroomTribes.MushroomTribes.skeletonTribe);

                PeltManager.New(PeltLoader.PluginGuid, info, 6, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.IsOfTribe(MushroomTribes.MushroomTribes.skeletonTribe) && (a.ModPrefixIs("Mushroom") || a.ModPrefixIs("Gallery")) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            Count++;
            static void GoldPortrait()
            {
                CardInfo info = CreateRareCard("Mushroom_Gold_Portrait", "Gold Portrait", "Gold Portrait.png", "Gold Portrait_e.png", 0, 2, Tribe.None);

                PeltManager.New(PeltLoader.PluginGuid, info, 11, 0, 2,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.ModPrefixIs("Gallery") && a.HasAnyOfCardMetaCategories(CardMetaCategory.Rare));
                    }
                );
            }
            Count++;
            static void GoombaPelt()
            {
                CardInfo info = CreateCard("Mushroom_Goomba_Pelt", "Goomba Pelt", "Goomba Pelt.png", "Goomba Pelt_e.png", 0, 2, MushroomTribes.MushroomTribes.goombaTribe);

                PeltManager.New(PeltLoader.PluginGuid, info, 6, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.IsOfTribe(MushroomTribes.MushroomTribes.goombaTribe) && (a.ModPrefixIs("Mushroom") || a.ModPrefixIs("Gallery")) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            Count++;
            static void KoopaPelt()
            {
                CardInfo info = CreateCard("Mushroom_Koopa_Pelt", "Koopa Pelt", "Koopa Pelt.png", "Koopa Pelt_e.png", 0, 2, MushroomTribes.MushroomTribes.koopaTribe);

                PeltManager.New(PeltLoader.PluginGuid, info, 6, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.IsOfTribe(MushroomTribes.MushroomTribes.koopaTribe) && (a.ModPrefixIs("Mushroom") || a.ModPrefixIs("Gallery")) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            Count++;
            static void PiranhaPelt()
            {
                CardInfo info = CreateCard("Mushroom_Piranha_Plant_Pelt", "Piranha Plant Pelt", "Piranha Pelt.png", "Piranha Pelt_e.png", 0, 2, MushroomTribes.MushroomTribes.piranhaPlantTribe);

                PeltManager.New(PeltLoader.PluginGuid, info, 6, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.IsOfTribe(MushroomTribes.MushroomTribes.piranhaPlantTribe) && (a.ModPrefixIs("Mushroom") || a.ModPrefixIs("Gallery")) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            Count++;
            static void PokeyPelt()
            {
                CardInfo info = CreateCard("Mushroom_Pokey_Pelt", "Pokey Pelt", "Pokey Pelt.png", "Pokey Pelt_e.png", 0, 2, MushroomTribes.MushroomTribes.pokeyTribe);

                PeltManager.New(PeltLoader.PluginGuid, info, 6, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.IsOfTribe(MushroomTribes.MushroomTribes.pokeyTribe) && (a.ModPrefixIs("Mushroom") || a.ModPrefixIs("Gallery")) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            Count++;
            static void PowerUpPelt()
            {
                CardInfo info = CreateCard("Mushroom_Power_Up_Pelt", "Power-Up Pelt", "Power-Up Pelt.png", "Power-Up Pelt_e.png", 0, 2, MushroomTribes.MushroomTribes.powerUpTribe);

                PeltManager.New(PeltLoader.PluginGuid, info, 6, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.IsOfTribe(MushroomTribes.MushroomTribes.powerUpTribe) && (a.ModPrefixIs("Mushroom") || a.ModPrefixIs("Gallery")) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            Count++;
            static void RamPelt()
            {
                CardInfo info = CreateCard("Mushroom_Ram_Pelt", "Ram Pelt", "Ram Pelt.png", "Ram Pelt_e.png", 0, 2, MushroomTribes.MushroomTribes.ramTribe);

                PeltManager.New(PeltLoader.PluginGuid, info, 6, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.IsOfTribe(MushroomTribes.MushroomTribes.ramTribe) && (a.ModPrefixIs("Mushroom") || a.ModPrefixIs("Gallery")) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            Count++;
            static void ShroobPelt()
            {
                CardInfo info = CreateCard("Mushroom_Shroob_Pelt", "Shroob Pelt", "Shroob Pelt.png", "Shroob Pelt_e.png", 0, 2, MushroomTribes.MushroomTribes.shroobTribe);

                PeltManager.New(PeltLoader.PluginGuid, info, 6, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.IsOfTribe(MushroomTribes.MushroomTribes.shroobTribe) && (a.ModPrefixIs("Mushroom") || a.ModPrefixIs("Gallery")) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            Count++;
            static void ShyGuyPelt()
            {
                CardInfo info = CreateCard("Mushroom_Shy_Guy_Pelt", "Shy Guy Pelt", "Shy Guy Pelt.png", "Shy Guy Pelt_e.png", 0, 2, MushroomTribes.MushroomTribes.shyGuyTribe);

                PeltManager.New(PeltLoader.PluginGuid, info, 6, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.IsOfTribe(MushroomTribes.MushroomTribes.shyGuyTribe) && (a.ModPrefixIs("Mushroom") || a.ModPrefixIs("Gallery")) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            Count++;
            static void SilverPortrait()
            {
                CardInfo info = CreateCard("Mushroom_Silver_Portrait", "Silver Portrait", "Silver Portrait.png", "Silver Portrait_e.png", 0, 2, Tribe.None);

                PeltManager.New(PeltLoader.PluginGuid, info, 7, 1, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.ModPrefixIs("Gallery") && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            Count++;
            static void SpikePelt()
            {
                CardInfo info = CreateCard("Mushroom_Spike_Pelt", "Spike Pelt", "Spike Pelt.png", "Spike Pelt_e.png", 0, 2, MushroomTribes.MushroomTribes.spikeTribe);

                PeltManager.New(PeltLoader.PluginGuid, info, 6, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.IsOfTribe(MushroomTribes.MushroomTribes.spikeTribe) && (a.ModPrefixIs("Mushroom") || a.ModPrefixIs("Gallery")) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            Count++;
            static void StarPelt()
            {
                CardInfo info = CreateCard("Mushroom_Star_Pelt", "Star Pelt", "Star Pelt.png", "Star Pelt_e.png", 0, 2, MushroomTribes.MushroomTribes.starTribe);

                PeltManager.New(PeltLoader.PluginGuid, info, 6, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.IsOfTribe(MushroomTribes.MushroomTribes.starTribe) && (a.ModPrefixIs("Mushroom") || a.ModPrefixIs("Gallery")) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            Count++;
            static void TanukiPelt()
            {
                CardInfo info = CreateCard("Mushroom_Tanuki_Pelt", "Tanuki Pelt", "Tanuki Pelt.png", "Tanuki Pelt_e.png", 0, 2, MushroomTribes.MushroomTribes.tanukiTribe);

                PeltManager.New(PeltLoader.PluginGuid, info, 6, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.IsOfTribe(MushroomTribes.MushroomTribes.tanukiTribe) && (a.ModPrefixIs("Mushroom") || a.ModPrefixIs("Gallery")) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            Count++;
            static void ThwompPelt()
            {
                CardInfo info = CreateCard("Mushroom_Thwomp_Pelt", "Thwomp Pelt", "Thwomp Pelt.png", "Thwomp Pelt_e.png", 0, 2, MushroomTribes.MushroomTribes.crusherTribe);

                PeltManager.New(PeltLoader.PluginGuid, info, 6, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.IsOfTribe(MushroomTribes.MushroomTribes.crusherTribe) && (a.ModPrefixIs("Mushroom") || a.ModPrefixIs("Gallery")) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            Count++;
            static void WaddlewingPelt()
            {
                CardInfo info = CreateCard("Mushroom_Waddlewing_Pelt", "Waddlewing Pelt", "Waddlewing Pelt.png", "Waddlewing Pelt_e.png", 0, 2, MushroomTribes.MushroomTribes.waddlewingTribe);

                PeltManager.New(PeltLoader.PluginGuid, info, 6, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.IsOfTribe(MushroomTribes.MushroomTribes.waddlewingTribe) && (a.ModPrefixIs("Mushroom") || a.ModPrefixIs("Gallery")) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            Count++;
            static void WigglerPelt()
            {
                CardInfo info = CreateCard("Mushroom_Wiggler_Pelt", "Wiggler Pelt", "Wiggler Pelt.png", "Wiggler Pelt_e.png", 0, 2, MushroomTribes.MushroomTribes.wrigglerTribe);

                PeltManager.New(PeltLoader.PluginGuid, info, 6, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.IsOfTribe(MushroomTribes.MushroomTribes.wrigglerTribe) && (a.ModPrefixIs("Mushroom") || a.ModPrefixIs("Gallery")) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            Count++;
            static void PowerMoon()
            {
                CardInfo info = CreateCard("Mushroom_Power_Moon", "Power Moon", "Power Moon.png", "Power Moon_e.png", 0, 2, Tribe.None);

                PeltManager.New(PeltLoader.PluginGuid, info, 7, 1, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.ModPrefixIs("Mushroom") && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            Count++;
            static void StarBits()
            {
                CardInfo info = CreateCard("Mushroom_Star_Bits", "Star Bits", "Star Bits.png", "Star Bits_e.png", 0, 2, Tribe.None);

                PeltManager.New(PeltLoader.PluginGuid, info, 3, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.ModPrefixIs("Mushroom") && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            Count++;
            static void ShineSprite()
            {
                CardInfo info = CreateCard("Mushroom_Shine_Sprite", "Shine Sprite", "Shine Sprite.png", "Shine Sprite_e.png", 0, 2, Tribe.None);

                PeltManager.New(PeltLoader.PluginGuid, info, 11, 0, 2,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.ModPrefixIs("Mushroom") && a.HasAnyOfCardMetaCategories(CardMetaCategory.Rare));
                    }
                );
            }
            Count++;
        }

        public void NeverNamedsSigilarium()
        {
            BeaverPeltSigilarium();
            LobsterShell();
            SpiderSkin();

            static void BeaverPeltSigilarium()
            {
                CardInfo info = CreateCard("Nevernameds_Sigilarium_Rodent_Pelt", "Beaver Pelt", "Beaver Pelt.png", "None.png", 0, 2, GetCustomTribe(NGUID, "Rodent"));

                PeltManager.New(PeltLoader.PluginGuid, info, 6, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.IsOfTribe(GetCustomTribe(LGUID, "Rodent")) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            Count++;
            static void LobsterShell()
            {
                CardInfo info = CreateCard("Nevernameds_Sigilarium_Crustacean_Pelt", "Lobster Shell", "Lobster Shell.png", "None.png", 0, 2, GetCustomTribe(NGUID, "Crustacean"));

                PeltManager.New(PeltLoader.PluginGuid, info, 6, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.IsOfTribe(GetCustomTribe(NGUID, "Crustacean")) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            Count++;
            static void SpiderSkin()
            {
                CardInfo info = CreateCard("Nevernameds_Sigilarium_Arachnid_Pelt", "Spider Skin", "Spider Skin.png", "None.png", 0, 2, GetCustomTribe(NGUID, "Arachnid"));

                PeltManager.New(PeltLoader.PluginGuid, info, 6, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.IsOfTribe(GetCustomTribe(NGUID, "Arachnid")) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            Count++;
        }

        public void VerminTribe()
        {
            BeaverPeltVermin();
            static void BeaverPeltVermin()
            {
                CardInfo info = CreateCard("Vermin_Vermin_Pelt", "Beaver Pelt", "Beaver Pelt.png", "None.png", 0, 2, Tribe.Squirrel);

                PeltManager.New(PeltLoader.PluginGuid, info, 6, 0, 4,
                    () =>
                    {
                        return CardManager.AllCardsCopy.FindAll((a) =>
                        a.IsOfTribe(Tribe.Squirrel) && a.HasAnyOfCardMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer));
                    }
                );
            }
            Count++;
        }
    }
}