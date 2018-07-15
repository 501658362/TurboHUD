using Turbo.Plugins.Default;
namespace Turbo.Plugins.glq
{
    using System.Collections.Generic;

    public static class LegendaryPowerInfoExtensions
    {
        public static IEnumerable<IBuff> EquippedLegendaryPowers(this ILegendaryPowerInfo powerInfo)
        {
            foreach (var buff in powerInfo.EquippedLegendaryItemsBuffs())
            {
                yield return buff;
            }
        }
		
        public static IEnumerable<IBuff> EquippedLegendaryPowers(this ILegendaryGemInfo GemInfo)
        {
            foreach (var buff in GemInfo.EquippedLegendaryGemsPrimaryBuffs())
            {
                yield return buff;
            }
            foreach (var buff in GemInfo.EquippedLegendaryGemsSecondaryBuffs())
            {
                yield return buff;
            }

        }

        public static IEnumerable<IBuff> EquippedLegendaryGemsPrimaryBuffs(this ILegendaryGemInfo GemInfo)
        {
            if (GemInfo.BaneOfThePowerfulPrimary != null) yield return GemInfo.BaneOfThePowerfulPrimary;
            if (GemInfo.BaneOfTheStrickenPrimary != null) yield return GemInfo.BaneOfTheStrickenPrimary;
            if (GemInfo.BaneOfTheTrappedPrimary != null) yield return GemInfo.BaneOfTheTrappedPrimary;
            if (GemInfo.BoonOfTheHoarderPrimary != null) yield return GemInfo.BoonOfTheHoarderPrimary;
            if (GemInfo.BoyarskysChipPrimary != null) yield return GemInfo.BoyarskysChipPrimary;
            if (GemInfo.EnforcerPrimary != null) yield return GemInfo.EnforcerPrimary;
            if (GemInfo.EsotericAlterationPrimary != null) yield return GemInfo.EsotericAlterationPrimary;
            if (GemInfo.GemOfEasePrimary != null) yield return GemInfo.GemOfEasePrimary;
            if (GemInfo.GemOfEfficaciousToxinPrimary != null) yield return GemInfo.GemOfEfficaciousToxinPrimary;
            if (GemInfo.GogokOfSwiftnessPrimary != null) yield return GemInfo.GogokOfSwiftnessPrimary;
            if (GemInfo.IceblinkPrimary != null) yield return GemInfo.IceblinkPrimary;
            if (GemInfo.InvigoratingGemstonePrimary != null) yield return GemInfo.InvigoratingGemstonePrimary;
            if (GemInfo.MirinaeTeardropOfTheStarweaverPrimary != null) yield return GemInfo.MirinaeTeardropOfTheStarweaverPrimary;
            if (GemInfo.MoltenWildebeestsGizzardPrimary != null) yield return GemInfo.MoltenWildebeestsGizzardPrimary;
            if (GemInfo.MoratoriumPrimary != null) yield return GemInfo.MoratoriumPrimary;
            if (GemInfo.MutilationGuardPrimary != null) yield return GemInfo.MutilationGuardPrimary;
            if (GemInfo.PainEnhancerPrimary != null) yield return GemInfo.PainEnhancerPrimary;
            if (GemInfo.RedSoulShardPrimary != null) yield return GemInfo.RedSoulShardPrimary;
            if (GemInfo.SimplicitysStrengthPrimary != null) yield return GemInfo.SimplicitysStrengthPrimary;
            if (GemInfo.TaegukPrimary != null) yield return GemInfo.TaegukPrimary;
            if (GemInfo.WreathOfLightningPrimary != null) yield return GemInfo.WreathOfLightningPrimary;
            if (GemInfo.ZeisStoneOfVengeancePrimary != null) yield return GemInfo.ZeisStoneOfVengeancePrimary;
        }

                public static IEnumerable<IBuff> EquippedLegendaryGemsSecondaryBuffs(this ILegendaryGemInfo GemInfo)
        {
            if (GemInfo.BaneOfThePowerfulSecondary != null) yield return GemInfo.BaneOfThePowerfulSecondary;
            if (GemInfo.BaneOfTheStrickenSecondary != null) yield return GemInfo.BaneOfTheStrickenSecondary;
            if (GemInfo.BaneOfTheTrappedSecondary != null) yield return GemInfo.BaneOfTheTrappedSecondary;
            if (GemInfo.BoonOfTheHoarderSecondary != null) yield return GemInfo.BoonOfTheHoarderSecondary;
            if (GemInfo.BoyarskysChipSecondary != null) yield return GemInfo.BoyarskysChipSecondary;
            if (GemInfo.EnforcerSecondary != null) yield return GemInfo.EnforcerSecondary;
            if (GemInfo.EsotericAlterationSecondary != null) yield return GemInfo.EsotericAlterationSecondary;
            if (GemInfo.GemOfEaseSecondary != null) yield return GemInfo.GemOfEaseSecondary;
            if (GemInfo.GemOfEfficaciousToxinSecondary != null) yield return GemInfo.GemOfEfficaciousToxinSecondary;
            if (GemInfo.GogokOfSwiftnessSecondary != null) yield return GemInfo.GogokOfSwiftnessSecondary;
            if (GemInfo.IceblinkSecondary != null) yield return GemInfo.IceblinkSecondary;
            if (GemInfo.InvigoratingGemstoneSecondary != null) yield return GemInfo.InvigoratingGemstoneSecondary;
            if (GemInfo.MirinaeTeardropOfTheStarweaverSecondary != null) yield return GemInfo.MirinaeTeardropOfTheStarweaverSecondary;
            if (GemInfo.MoltenWildebeestsGizzardSecondary != null) yield return GemInfo.MoltenWildebeestsGizzardSecondary;
            if (GemInfo.MoratoriumSecondary != null) yield return GemInfo.MoratoriumSecondary;
            if (GemInfo.MutilationGuardSecondary != null) yield return GemInfo.MutilationGuardSecondary;
            if (GemInfo.PainEnhancerSecondary != null) yield return GemInfo.PainEnhancerSecondary;
            if (GemInfo.RedSoulShardSecondary != null) yield return GemInfo.RedSoulShardSecondary;
            if (GemInfo.SimplicitysStrengthSecondary != null) yield return GemInfo.SimplicitysStrengthSecondary;
            if (GemInfo.TaegukSecondary != null) yield return GemInfo.TaegukSecondary;
            if (GemInfo.WreathOfLightningSecondary != null) yield return GemInfo.WreathOfLightningSecondary;
            if (GemInfo.ZeisStoneOfVengeanceSecondary != null) yield return GemInfo.ZeisStoneOfVengeanceSecondary;
        }

        public static IEnumerable<IBuff> EquippedLegendaryItemsBuffs(this ILegendaryPowerInfo powerInfo)
        {
            if (powerInfo.AetherWalker != null) yield return powerInfo.AetherWalker;
            if (powerInfo.AhavarionSpearOfLycander != null) yield return powerInfo.AhavarionSpearOfLycander;
            if (powerInfo.AkkhansAddendum != null) yield return powerInfo.AkkhansAddendum;
            if (powerInfo.AkkhansLeniency != null) yield return powerInfo.AkkhansLeniency;
            if (powerInfo.AkkhansManacles != null) yield return powerInfo.AkkhansManacles;
            if (powerInfo.AncestorsGrace != null) yield return powerInfo.AncestorsGrace;
            if (powerInfo.AncientParthanDefenders != null) yield return powerInfo.AncientParthanDefenders;
            if (powerInfo.AnessaziEdge != null) yield return powerInfo.AnessaziEdge;
            if (powerInfo.AquilaCuirass != null) yield return powerInfo.AquilaCuirass;
            if (powerInfo.ArchmagesVicalyke != null) yield return powerInfo.ArchmagesVicalyke;
            if (powerInfo.Arcstone != null) yield return powerInfo.Arcstone;
            if (powerInfo.ArmorOfTheKindRegent != null) yield return powerInfo.ArmorOfTheKindRegent;
            if (powerInfo.ArreatsLaw != null) yield return powerInfo.ArreatsLaw;
            if (powerInfo.ArthefsSparkOfLife != null) yield return powerInfo.ArthefsSparkOfLife;
            if (powerInfo.AshnagarrsBloodBracer != null) yield return powerInfo.AshnagarrsBloodBracer;
            if (powerInfo.BakuliJungleWraps != null) yield return powerInfo.BakuliJungleWraps;
            if (powerInfo.Balance != null) yield return powerInfo.Balance;
            if (powerInfo.BalefulRemnant != null) yield return powerInfo.BalefulRemnant;
            if (powerInfo.BandOfHollowWhispers != null) yield return powerInfo.BandOfHollowWhispers;
            if (powerInfo.BandOfMight != null) yield return powerInfo.BandOfMight;
            if (powerInfo.BandOfTheRueChambers != null) yield return powerInfo.BandOfTheRueChambers;
            if (powerInfo.BastionsRevered != null) yield return powerInfo.BastionsRevered;
            if (powerInfo.BeckonSail != null) yield return powerInfo.BeckonSail;
            if (powerInfo.BeltOfTheTrove != null) yield return powerInfo.BeltOfTheTrove;
            if (powerInfo.BeltOfTranscendence != null) yield return powerInfo.BeltOfTranscendence;
            if (powerInfo.BindingOfTheLost != null) yield return powerInfo.BindingOfTheLost;
            if (powerInfo.BindingsOfTheLesserGods != null) yield return powerInfo.BindingsOfTheLesserGods;
            if (powerInfo.Blackfeather != null) yield return powerInfo.Blackfeather;
            if (powerInfo.BladeOfProphecy != null) yield return powerInfo.BladeOfProphecy;
            if (powerInfo.BladeOfTheTribes != null) yield return powerInfo.BladeOfTheTribes;
            if (powerInfo.BladeOfTheWarlord != null) yield return powerInfo.BladeOfTheWarlord;
            if (powerInfo.BlessedOfHaull != null) yield return powerInfo.BlessedOfHaull;
            if (powerInfo.BloodBrother != null) yield return powerInfo.BloodBrother;
            if (powerInfo.BovineBardiche != null) yield return powerInfo.BovineBardiche;
            if (powerInfo.BracerOfFury != null) yield return powerInfo.BracerOfFury;
            if (powerInfo.BracersOfDestruction != null) yield return powerInfo.BracersOfDestruction;
            if (powerInfo.BracersOfTheFirstMen != null) yield return powerInfo.BracersOfTheFirstMen;
            if (powerInfo.BrokenCrown != null) yield return powerInfo.BrokenCrown;
            if (powerInfo.BrokenPromises != null) yield return powerInfo.BrokenPromises;
            if (powerInfo.BulKathossWeddingBand != null) yield return powerInfo.BulKathossWeddingBand;
            if (powerInfo.ButchersCarver != null) yield return powerInfo.ButchersCarver;
            if (powerInfo.CamsRebuttal != null) yield return powerInfo.CamsRebuttal;
            if (powerInfo.CapeOfTheDarkNight != null) yield return powerInfo.CapeOfTheDarkNight;
            if (powerInfo.Carnevil != null) yield return powerInfo.Carnevil;
            if (powerInfo.CesarsMemento != null) yield return powerInfo.CesarsMemento;
            if (powerInfo.Chaingmail != null) yield return powerInfo.Chaingmail;
            if (powerInfo.ChainOfShadows != null) yield return powerInfo.ChainOfShadows;
            if (powerInfo.ChanonBolter != null) yield return powerInfo.ChanonBolter;
            if (powerInfo.ChilaniksChain != null) yield return powerInfo.ChilaniksChain;
            if (powerInfo.Cindercoat != null) yield return powerInfo.Cindercoat;
            if (powerInfo.CoilsOfTheFirstSpider != null) yield return powerInfo.CoilsOfTheFirstSpider;
            if (powerInfo.ConventionOfElements != null) yield return powerInfo.ConventionOfElements;
            if (powerInfo.CordOfTheSherma != null) yield return powerInfo.CordOfTheSherma;
            if (powerInfo.CorruptedAshbringer != null) yield return powerInfo.CorruptedAshbringer;
            if (powerInfo.CountessJuliasCameo != null) yield return powerInfo.CountessJuliasCameo;
            if (powerInfo.CrashingRain != null) yield return powerInfo.CrashingRain;
            if (powerInfo.CrownOfThePrimus != null) yield return powerInfo.CrownOfThePrimus;
            if (powerInfo.CrystalFist != null) yield return powerInfo.CrystalFist;
            if (powerInfo.CusterianWristguards != null) yield return powerInfo.CusterianWristguards;
            if (powerInfo.Darklight != null) yield return powerInfo.Darklight;
            if (powerInfo.DarkMagesShade != null) yield return powerInfo.DarkMagesShade;
            if (powerInfo.DeadlyRebirth != null) yield return powerInfo.DeadlyRebirth;
            if (powerInfo.DeathseersCowl != null) yield return powerInfo.DeathseersCowl;
            if (powerInfo.DeathWatchMantle != null) yield return powerInfo.DeathWatchMantle;
            if (powerInfo.Deathwish != null) yield return powerInfo.Deathwish;
            if (powerInfo.DepthDiggers != null) yield return powerInfo.DepthDiggers;
            if (powerInfo.DishonoredLegacy != null) yield return powerInfo.DishonoredLegacy;
            if (powerInfo.DovuEnergyTrap != null) yield return powerInfo.DovuEnergyTrap;
            if (powerInfo.DrakonsLesson != null) yield return powerInfo.DrakonsLesson;
            if (powerInfo.DreadIron != null) yield return powerInfo.DreadIron;
            if (powerInfo.ElusiveRing != null) yield return powerInfo.ElusiveRing;
            if (powerInfo.EnchantingFavor != null) yield return powerInfo.EnchantingFavor;
            if (powerInfo.EternalUnion != null) yield return powerInfo.EternalUnion;
            if (powerInfo.Eunjangdo != null) yield return powerInfo.Eunjangdo;
            if (powerInfo.EyeOfPeshkov != null) yield return powerInfo.EyeOfPeshkov;
            if (powerInfo.FaithfulMemory != null) yield return powerInfo.FaithfulMemory;
            if (powerInfo.FateOfTheFell != null) yield return powerInfo.FateOfTheFell;
            if (powerInfo.FazulasImprobableChain != null) yield return powerInfo.FazulasImprobableChain;
            if (powerInfo.FireWalkers != null) yield return powerInfo.FireWalkers;
            if (powerInfo.FlailOfTheAscended != null) yield return powerInfo.FlailOfTheAscended;
            if (powerInfo.Fleshrake != null) yield return powerInfo.Fleshrake;
            if (powerInfo.FlyingDragon != null) yield return powerInfo.FlyingDragon;
            if (powerInfo.FortressBallista != null) yield return powerInfo.FortressBallista;
            if (powerInfo.FragmentOfDestiny != null) yield return powerInfo.FragmentOfDestiny;
            if (powerInfo.Frostburn != null) yield return powerInfo.Frostburn;
            if (powerInfo.Fulminator != null) yield return powerInfo.Fulminator;
            if (powerInfo.FuryOfTheAncients != null) yield return powerInfo.FuryOfTheAncients;
            if (powerInfo.GabrielsVambraces != null) yield return powerInfo.GabrielsVambraces;
            if (powerInfo.Genzaniku != null) yield return powerInfo.Genzaniku;
            if (powerInfo.GestureOfOrpheus != null) yield return powerInfo.GestureOfOrpheus;
            if (powerInfo.GirdleOfGiants != null) yield return powerInfo.GirdleOfGiants;
            if (powerInfo.GladiatorGauntlets != null) yield return powerInfo.GladiatorGauntlets;
            if (powerInfo.GoldenFlense != null) yield return powerInfo.GoldenFlense;
            if (powerInfo.Goldwrap != null) yield return powerInfo.Goldwrap;
            if (powerInfo.GungdoGear != null) yield return powerInfo.GungdoGear;
            if (powerInfo.GyanaNaKashu != null) yield return powerInfo.GyanaNaKashu;
            if (powerInfo.GyrfalconsFoote != null) yield return powerInfo.GyrfalconsFoote;
            if (powerInfo.Hack != null) yield return powerInfo.Hack;
            if (powerInfo.HaloOfArlyse != null) yield return powerInfo.HaloOfArlyse;
            if (powerInfo.HaloOfKarini != null) yield return powerInfo.HaloOfKarini;
            if (powerInfo.HammerJammers != null) yield return powerInfo.HammerJammers;
            if (powerInfo.HandOfTheProphet != null) yield return powerInfo.HandOfTheProphet;
            if (powerInfo.HarringtonWaistguard != null) yield return powerInfo.HarringtonWaistguard;
            if (powerInfo.HauntingGirdle != null) yield return powerInfo.HauntingGirdle;
            if (powerInfo.HauntOfVaxo != null) yield return powerInfo.HauntOfVaxo;
            if (powerInfo.HeartOfIron != null) yield return powerInfo.HeartOfIron;
            //if (powerInfo.HellcatWaistguard != null) yield return powerInfo.HellcatWaistguard;
            if (powerInfo.HergbrashsBinding != null) yield return powerInfo.HergbrashsBinding;
            if (powerInfo.HexingPantsOfMrYan != null) yield return powerInfo.HexingPantsOfMrYan;
            if (powerInfo.HillenbrandsTrainingSword != null) yield return powerInfo.HillenbrandsTrainingSword;
            if (powerInfo.HomingPads != null) yield return powerInfo.HomingPads;
            if (powerInfo.HuntersWrath != null) yield return powerInfo.HuntersWrath;
            if (powerInfo.HwojWrap != null) yield return powerInfo.HwojWrap;
            if (powerInfo.IncenseTorchOfTheGrandTemple != null) yield return powerInfo.IncenseTorchOfTheGrandTemple;
            if (powerInfo.Ingeom != null) yield return powerInfo.Ingeom;
            if (powerInfo.InviolableFaith != null) yield return powerInfo.InviolableFaith;
            if (powerInfo.IrontoeMudsputters != null) yield return powerInfo.IrontoeMudsputters;
            if (powerInfo.JacesHammerOfVigilance != null) yield return powerInfo.JacesHammerOfVigilance;
            if (powerInfo.JangsEnvelopment != null) yield return powerInfo.JangsEnvelopment;
            if (powerInfo.Jawbreaker != null) yield return powerInfo.Jawbreaker;
            if (powerInfo.JeramsBracers != null) yield return powerInfo.JeramsBracers;
            if (powerInfo.JohannasArgument != null) yield return powerInfo.JohannasArgument;
            if (powerInfo.JustiniansMercy != null) yield return powerInfo.JustiniansMercy;
            if (powerInfo.KarleisPoint != null) yield return powerInfo.KarleisPoint;
            if (powerInfo.KassarsRetribution != null) yield return powerInfo.KassarsRetribution;
            if (powerInfo.KekegisUnbreakableSpirit != null) yield return powerInfo.KekegisUnbreakableSpirit;
            if (powerInfo.KhassettsCordOfRighteousness != null) yield return powerInfo.KhassettsCordOfRighteousness;
            if (powerInfo.KmarTenclip != null) yield return powerInfo.KmarTenclip;
            if (powerInfo.KredesFlame != null) yield return powerInfo.KredesFlame;
            if (powerInfo.KrelmsBuffBelt != null) yield return powerInfo.KrelmsBuffBelt;
            if (powerInfo.KrelmsBuffBracers != null) yield return powerInfo.KrelmsBuffBracers;
            if (powerInfo.Kridershot != null) yield return powerInfo.Kridershot;
            if (powerInfo.KyoshirosBlade != null) yield return powerInfo.KyoshirosBlade;
            if (powerInfo.KyoshirosSoul != null) yield return powerInfo.KyoshirosSoul;
            if (powerInfo.LakumbasOrnament != null) yield return powerInfo.LakumbasOrnament;
            if (powerInfo.Lamentation != null) yield return powerInfo.Lamentation;
            if (powerInfo.LastBreath != null) yield return powerInfo.LastBreath;
            if (powerInfo.LefebvresSoliloquy != null) yield return powerInfo.LefebvresSoliloquy;
            if (powerInfo.LeonineBowOfHashir != null) yield return powerInfo.LeonineBowOfHashir;
            if (powerInfo.LiannasWings != null) yield return powerInfo.LiannasWings;
            if (powerInfo.LionsClaw != null) yield return powerInfo.LionsClaw;
            if (powerInfo.LordGreenstonesFan != null) yield return powerInfo.LordGreenstonesFan;
            if (powerInfo.LutSocks != null) yield return powerInfo.LutSocks;
            if (powerInfo.MadawcsSorrow != null) yield return powerInfo.MadawcsSorrow;
            if (powerInfo.Madstone != null) yield return powerInfo.Madstone;
            if (powerInfo.Magefist != null) yield return powerInfo.Magefist;
            if (powerInfo.MalothsFocus != null) yield return powerInfo.MalothsFocus;
            if (powerInfo.ManaldHeal != null) yield return powerInfo.ManaldHeal;
            if (powerInfo.MantleOfChanneling != null) yield return powerInfo.MantleOfChanneling;
            if (powerInfo.MarasKaleidoscope != null) yield return powerInfo.MarasKaleidoscope;
            if (powerInfo.MaskOfJeram != null) yield return powerInfo.MaskOfJeram;
            if (powerInfo.MoonlightWard != null) yield return powerInfo.MoonlightWard;
            if (powerInfo.MordullusPromise != null) yield return powerInfo.MordullusPromise;
            if (powerInfo.NemesisBracers != null) yield return powerInfo.NemesisBracers;
            if (powerInfo.NilfursBoast != null) yield return powerInfo.NilfursBoast;
            if (powerInfo.Oathkeeper != null) yield return powerInfo.Oathkeeper;
            if (powerInfo.OculusRing != null) yield return powerInfo.OculusRing;
            if (powerInfo.OdynSon != null) yield return powerInfo.OdynSon;
            if (powerInfo.OdysseysEnd != null) yield return powerInfo.OdysseysEnd;
            if (powerInfo.Omnislash != null) yield return powerInfo.Omnislash;
            if (powerInfo.OmrynsChain != null) yield return powerInfo.OmrynsChain;
            if (powerInfo.PintosPride != null) yield return powerInfo.PintosPride;
            if (powerInfo.PoxFaulds != null) yield return powerInfo.PoxFaulds;
            if (powerInfo.PrideOfCassius != null) yield return powerInfo.PrideOfCassius;
            if (powerInfo.PromiseOfGlory != null) yield return powerInfo.PromiseOfGlory;
            if (powerInfo.PuzzleRing != null) yield return powerInfo.PuzzleRing;
            if (powerInfo.Quetzalcoatl != null) yield return powerInfo.Quetzalcoatl;
            if (powerInfo.RabidStrike != null) yield return powerInfo.RabidStrike;
            if (powerInfo.RakoffsGlassOfLife != null) yield return powerInfo.RakoffsGlassOfLife;
            if (powerInfo.RanslorsFolly != null) yield return powerInfo.RanslorsFolly;
            if (powerInfo.RazorStrop != null) yield return powerInfo.RazorStrop;
            if (powerInfo.RechelsRingOfLarceny != null) yield return powerInfo.RechelsRingOfLarceny;
            if (powerInfo.RelicOfAkarat != null) yield return powerInfo.RelicOfAkarat;
            if (powerInfo.Remorseless != null) yield return powerInfo.Remorseless;
            if (powerInfo.RhenhoFlayer != null) yield return powerInfo.RhenhoFlayer;
            if (powerInfo.RibaldEtchings != null) yield return powerInfo.RibaldEtchings;
            if (powerInfo.Rimeheart != null) yield return powerInfo.Rimeheart;
            if (powerInfo.RingOfEmptiness != null) yield return powerInfo.RingOfEmptiness;
            if (powerInfo.RiveraDancers != null) yield return powerInfo.RiveraDancers;
            if (powerInfo.RogarsHugeStone != null) yield return powerInfo.RogarsHugeStone;
            if (powerInfo.SacredHarness != null) yield return powerInfo.SacredHarness;
            if (powerInfo.SacredHarvester != null) yield return powerInfo.SacredHarvester;
            if (powerInfo.SaffronWrap != null) yield return powerInfo.SaffronWrap;
            if (powerInfo.SashOfKnives != null) yield return powerInfo.SashOfKnives;
            if (powerInfo.Scarbringer != null) yield return powerInfo.Scarbringer;
            if (powerInfo.Scourge != null) yield return powerInfo.Scourge;
            if (powerInfo.Scrimshaw != null) yield return powerInfo.Scrimshaw;
            if (powerInfo.SeborsNightmare != null) yield return powerInfo.SeborsNightmare;
            if (powerInfo.SerpentsSparker != null) yield return powerInfo.SerpentsSparker;
            if (powerInfo.ShardOfHate != null) yield return powerInfo.ShardOfHate;
            if (powerInfo.ShiMizusHaori != null) yield return powerInfo.ShiMizusHaori;
            if (powerInfo.SkeletonKey != null) yield return powerInfo.SkeletonKey;
            if (powerInfo.SkularsSalvation != null) yield return powerInfo.SkularsSalvation;
            if (powerInfo.SkullGrasp != null) yield return powerInfo.SkullGrasp;
            if (powerInfo.SkullOfResonance != null) yield return powerInfo.SkullOfResonance;
            if (powerInfo.SkySplitter != null) yield return powerInfo.SkySplitter;
            if (powerInfo.Skywarden != null) yield return powerInfo.Skywarden;
            if (powerInfo.SlipkasLetterOpener != null) yield return powerInfo.SlipkasLetterOpener;
            if (powerInfo.SloraksMadness != null) yield return powerInfo.SloraksMadness;
            if (powerInfo.SmokingThurible != null) yield return powerInfo.SmokingThurible;
            if (powerInfo.Solanium != null) yield return powerInfo.Solanium;
            if (powerInfo.SpauldersOfZakara != null) yield return powerInfo.SpauldersOfZakara;
            if (powerInfo.SpiritGuards != null) yield return powerInfo.SpiritGuards;
            if (powerInfo.StaffOfChiroptera != null) yield return powerInfo.StaffOfChiroptera;
            if (powerInfo.StalgardsDecimator != null) yield return powerInfo.StalgardsDecimator;
            if (powerInfo.Standoff != null) yield return powerInfo.Standoff;
            if (powerInfo.StArchewsGage != null) yield return powerInfo.StArchewsGage;
            if (powerInfo.Starfire != null) yield return powerInfo.Starfire;
            if (powerInfo.StarmetalKukri != null) yield return powerInfo.StarmetalKukri;
            if (powerInfo.StormCrow != null) yield return powerInfo.StormCrow;
            if (powerInfo.StringOfEars != null) yield return powerInfo.StringOfEars;
            if (powerInfo.StrongarmBracers != null) yield return powerInfo.StrongarmBracers;
            if (powerInfo.SuWongDiviner != null) yield return powerInfo.SuWongDiviner;
            if (powerInfo.SwampLandWaders != null) yield return powerInfo.SwampLandWaders;
            if (powerInfo.Swiftmount != null) yield return powerInfo.Swiftmount;
            if (powerInfo.SwordOfIllWill != null) yield return powerInfo.SwordOfIllWill;
            if (powerInfo.TalismanOfAranoch != null) yield return powerInfo.TalismanOfAranoch;
            if (powerInfo.TaskerandTheo != null) yield return powerInfo.TaskerandTheo;
            if (powerInfo.TheBarber != null) yield return powerInfo.TheBarber;
            if (powerInfo.TheBurningAxeOfSankis != null) yield return powerInfo.TheBurningAxeOfSankis;
            if (powerInfo.TheButchersSickle != null) yield return powerInfo.TheButchersSickle;
            if (powerInfo.TheCloakOfTheGarwulf != null) yield return powerInfo.TheCloakOfTheGarwulf;
            if (powerInfo.TheCrudestBoots != null) yield return powerInfo.TheCrudestBoots;
            if (powerInfo.TheDaggerOfDarts != null) yield return powerInfo.TheDaggerOfDarts;
            if (powerInfo.TheDemonsDemise != null) yield return powerInfo.TheDemonsDemise;
            if (powerInfo.TheEssOfJohan != null) yield return powerInfo.TheEssOfJohan;
            if (powerInfo.TheFistOfAzTurrasq != null) yield return powerInfo.TheFistOfAzTurrasq;
            if (powerInfo.TheFlowOfEternity != null) yield return powerInfo.TheFlowOfEternity;
            if (powerInfo.TheFurnace != null) yield return powerInfo.TheFurnace;
            if (powerInfo.TheGavelOfJudgment != null) yield return powerInfo.TheGavelOfJudgment;
            if (powerInfo.TheGidbinn != null) yield return powerInfo.TheGidbinn;
            if (powerInfo.TheGrandVizier != null) yield return powerInfo.TheGrandVizier;
            if (powerInfo.TheGrinReaper != null) yield return powerInfo.TheGrinReaper;
            if (powerInfo.TheLawsOfSeph != null) yield return powerInfo.TheLawsOfSeph;
            if (powerInfo.TheMagistrate != null) yield return powerInfo.TheMagistrate;
            if (powerInfo.TheMindsEye != null) yield return powerInfo.TheMindsEye;
            if (powerInfo.TheMortalDrama != null) yield return powerInfo.TheMortalDrama;
            if (powerInfo.ThePaddle != null) yield return powerInfo.ThePaddle;
            if (powerInfo.TheShameOfDelsere != null) yield return powerInfo.TheShameOfDelsere;
            if (powerInfo.TheShortMansFinger != null) yield return powerInfo.TheShortMansFinger;
            if (powerInfo.TheSmolderingCore != null) yield return powerInfo.TheSmolderingCore;
            if (powerInfo.TheSpiderQueensGrasp != null) yield return powerInfo.TheSpiderQueensGrasp;
            if (powerInfo.TheStarOfAzkaranth != null) yield return powerInfo.TheStarOfAzkaranth;
            if (powerInfo.TheSwami != null) yield return powerInfo.TheSwami;
            if (powerInfo.TheTallMansFinger != null) yield return powerInfo.TheTallMansFinger;
            if (powerInfo.TheThreeHundredthSpear != null) yield return powerInfo.TheThreeHundredthSpear;
            if (powerInfo.TheTormentor != null) yield return powerInfo.TheTormentor;
            if (powerInfo.TheTwistedSword != null) yield return powerInfo.TheTwistedSword;
            if (powerInfo.TheUndisputedChampion != null) yield return powerInfo.TheUndisputedChampion;
            if (powerInfo.ThunderfuryBlessedBladeOfTheWindseeker != null) yield return powerInfo.ThunderfuryBlessedBladeOfTheWindseeker;
            if (powerInfo.TiklandianVisage != null) yield return powerInfo.TiklandianVisage;
            if (powerInfo.TragOulCoils != null) yield return powerInfo.TragOulCoils;
            if (powerInfo.TzoKrinsGaze != null) yield return powerInfo.TzoKrinsGaze;
            if (powerInfo.UnstableScepter != null) yield return powerInfo.UnstableScepter;
            if (powerInfo.VadimsSurge != null) yield return powerInfo.VadimsSurge;
            if (powerInfo.ValtheksRebuke != null) yield return powerInfo.ValtheksRebuke;
            if (powerInfo.VambracesOfSescheron != null) yield return powerInfo.VambracesOfSescheron;
            if (powerInfo.VelvetCamaral != null) yield return powerInfo.VelvetCamaral;
            if (powerInfo.VengefulWind != null) yield return powerInfo.VengefulWind;
            if (powerInfo.Vigilance != null) yield return powerInfo.Vigilance;
            if (powerInfo.VileWard != null) yield return powerInfo.VileWard;
            if (powerInfo.VisageOfGiyua != null) yield return powerInfo.VisageOfGiyua;
            if (powerInfo.VisageOfGunes != null) yield return powerInfo.VisageOfGunes;
            if (powerInfo.VoosJuicer != null) yield return powerInfo.VoosJuicer;
            if (powerInfo.WandOfWoh != null) yield return powerInfo.WandOfWoh;
            if (powerInfo.WarhelmOfKassar != null) yield return powerInfo.WarhelmOfKassar;
            if (powerInfo.WarstaffOfGeneralQuang != null) yield return powerInfo.WarstaffOfGeneralQuang;
            if (powerInfo.WarzechianArmguards != null) yield return powerInfo.WarzechianArmguards;
            if (powerInfo.Wizardspike != null) yield return powerInfo.Wizardspike;
            if (powerInfo.WojahnniAssaulter != null) yield return powerInfo.WojahnniAssaulter;
            if (powerInfo.WrapsOfClarity != null) yield return powerInfo.WrapsOfClarity;
            if (powerInfo.Wyrdward != null) yield return powerInfo.Wyrdward;
            if (powerInfo.XephirianAmulet != null) yield return powerInfo.XephirianAmulet;
            if (powerInfo.ZoeysSecret != null) yield return powerInfo.ZoeysSecret;
        }
    }
}
