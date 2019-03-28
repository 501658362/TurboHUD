//using SharpDX.DirectInput;
//using Turbo.Plugins.Default;
//
//namespace Turbo.Plugins.glq
//{
//
//    public class GLQ_PluginEnablerOrDisablerPlugin : BasePlugin, ICustomizer
//    {
//
//        public GLQ_PluginEnablerOrDisablerPlugin()
//        {
//            Enabled = true;
//        }
//
//        public override void Load(IController hud)
//        {
//            base.Load(hud);
//        }
//        public void Customize()
//        {
////CustomizeStart
//Hud.GetPlugin<BountyTablePlugin>().ToggleKeyEvent = Hud.Input.CreateKeyEvent(true, Key.F10, false, false, false);
//Hud.GetPlugin<RiftPlugin>().NephalemRiftPercentEnabled = true;
//Hud.GetPlugin<GLQ_MonstersCountPlugin>().yard = 40;
//Hud.GetPlugin<GLQ_EliteHealthBarPlugin>().b = 35;
//Hud.GetPlugin<GLQ_BannerPlugin>().Enabled = true;
//Hud.GetPlugin<StashPreviewPlugin>().Enabled = true;
//Hud.GetPlugin<StashUsedSpacePlugin>().Enabled = true;
//Hud.GetPlugin<HoveredItemInfoPlugin>().Enabled = true;
//Hud.GetPlugin<InventoryKanaiCubedItemsPlugin>().Enabled = true;
//Hud.GetPlugin<InventoryMaterialCountPlugin>().Enabled = true;
//Hud.GetPlugin<GLQ_AttributeLabelListPlugin>().Enabled = true;
//Hud.GetPlugin<GameInfoPlugin>().Enabled = true;
//Hud.GetPlugin<MultiplayerExperienceRangePlugin>().Enabled = false;
//Hud.GetPlugin<GLQ_DamageBonusPlugin>().Enabled = true;
//Hud.GetPlugin<GLQ_NetworkLatencyPlugin>().Enabled = true;
//Hud.GetPlugin<GLQ_NotifyAtRiftPercentagePlugin>().Enabled = true;
//Hud.GetPlugin<GLQ_BloodShardPlugin>().Enabled = true;
//Hud.GetPlugin<GLQ_InventoryFreeSpacePlugin>().Enabled = true;
//Hud.GetPlugin<SkillRangeHelperPlugin>().Enabled = true;
//Hud.GetPlugin<GLQ_PortraitBottomStatsPlugin>().Enabled = true;
//Hud.GetPlugin<GLQ_ResourceOverGlobePlugin>().Enabled = true;
//Hud.GetPlugin<GLQ_TopMonsterHealthBarPlugin>().Enabled = true;
//Hud.GetPlugin<OriginalSkillBarPlugin>().Enabled = true;
//Hud.GetPlugin<OriginalSkillBarPlugin>().SkillPainter.EnableSkillDpsBar = true;
//Hud.GetPlugin<GLQ_CosmeticItemsPlugin>().Enabled = true;
//Hud.GetPlugin<GLQ_OtherPlayersPlugin>().Enabled = true;
//Hud.GetPlugin<GLQ_HeadStonePlugin>().Enabled = true;
//Hud.GetPlugin<GLQ_PlayerSkillPlugin>().Enabled = true;
//Hud.GetPlugin<GLQ_PlayersCirclePlugin>().Enabled = true;
//Hud.GetPlugin<PickupRangePlugin>().Enabled = false;
//Hud.GetPlugin<CheatDeathBuffFeederPlugin>().Enabled = false;
//Hud.GetPlugin<GLQ_FollowerPlugin>().Enabled = true;
//Hud.GetPlugin<GLQ_PortalPlugin>().Enabled = true;
//Hud.GetPlugin<ClickableChestGizmoPlugin>().Enabled = true;
//Hud.GetPlugin<GLQ_CursedEventPlugin>().Enabled = true;
//Hud.GetPlugin<GLQ_SceneHintPlugin>().Enabled = true;
//Hud.GetPlugin<DeadBodyPlugin>().Enabled = true;
//Hud.GetPlugin<RackPlugin>().Enabled = true;
//Hud.GetPlugin<ChestPlugin>().Enabled = true;
//Hud.GetPlugin<GLQ_ShrineNamePlugin>().Enabled = true;
//Hud.GetPlugin<GLQ_DoorsPlugin>().Enabled = true;
//Hud.GetPlugin<GLQ_GlobePlugin>().Enabled = true;
//Hud.GetPlugin<GLQ_HealthGlobePlugin>().Enabled = true;
//Hud.GetPlugin<MarkerPlugin>().Enabled = true;
//Hud.GetPlugin<GLQ_InventoryAndStashPlugin>().AncientRankEnabled = false;
//Hud.GetPlugin<GLQ_InventoryAndStashPlugin>().CanCubedEnabled = true;
//Hud.GetPlugin<GLQ_InventoryAndStashPlugin>().HoradricCacheEnabled = true;
//Hud.GetPlugin<GLQ_InventoryAndStashPlugin>().SocketedLegendaryGemRankEnabled = true;
//Hud.GetPlugin<GLQ_ItemsPlugin>().Enabled = true;
//Hud.GetPlugin<DangerousMonsterPlugin>().Enabled = true;
//Hud.GetPlugin<DangerousMonsterPlugin>().AddNames("炽炎卫士","堕落癫狂者");
//Hud.GetPlugin<GLQ_StandardMonsterPlugin>().Enabled = true;
//Hud.GetPlugin<MonsterRiftProgressionColoringPlugin>().Enabled = false;
//Hud.GetPlugin<GLQ_GoblinPlugin>().Enabled = true;
//Hud.GetPlugin<GLQ_MonstersCountPlugin>().Enabled = true;
//Hud.GetPlugin<GLQ_EliteHealthBarPlugin>().Enabled = true;
//Hud.GetPlugin<GLQ_EliteHealthListPlugin>().Enabled = true;
//Hud.GetPlugin<EliteMonsterSkillPlugin>().Enabled = true;
//Hud.GetPlugin<ExplosiveMonsterPlugin>().Enabled = true;
//Hud.GetPlugin<GLQ_EliteJuggernautOverridePlugin>().Enabled = false;
//Hud.GetPlugin<GLQ_MonsterPackPlugin>().Enabled = false;
//Hud.GetPlugin<GLQ_MonsterCirclePlugin>().TrashDecorator.Enabled = false;
//Hud.GetPlugin<GLQ_MonsterCirclePlugin>().ChampionDecorator.Enabled = true;
//Hud.GetPlugin<GLQ_MonsterCirclePlugin>().RareDecorator.Enabled = true;
//Hud.GetPlugin<GLQ_MonsterCirclePlugin>().RareMinionDecorator.Enabled = true;
//Hud.GetPlugin<GLQ_MonsterCirclePlugin>().UniqueDecorator.Enabled = true;
//Hud.GetPlugin<GLQ_MonsterCirclePlugin>().BossDecorator.Enabled = true;
//Hud.GetPlugin<EliteMonsterSkillPlugin>().ArcaneDecorator.Enabled = true;
//Hud.GetPlugin<EliteMonsterSkillPlugin>().ArcaneSpawnDecorator.Enabled = true;
//Hud.GetPlugin<EliteMonsterSkillPlugin>().DesecratorDecorator.Enabled = true;
//Hud.GetPlugin<EliteMonsterSkillPlugin>().FrozenBallDecorator.Enabled = true;
//Hud.GetPlugin<EliteMonsterSkillPlugin>().FrozenPulseDecorator.Enabled = true;
//Hud.GetPlugin<EliteMonsterSkillPlugin>().MoltenExplosionDecorator.Enabled = true;
//Hud.GetPlugin<EliteMonsterSkillPlugin>().MoltenDecorator.Enabled = false;
//Hud.GetPlugin<EliteMonsterSkillPlugin>().PlaguedDecorator.Enabled = true;
//Hud.GetPlugin<EliteMonsterSkillPlugin>().ThunderstormDecorator.Enabled = true;
//Hud.GetPlugin<EliteMonsterSkillPlugin>().GhomDecorator.Enabled = true;
//Hud.GetPlugin<GLQ_ShockTowerPlugin>().Enabled = true;
//Hud.GetPlugin<GLQ_PlayerSkillPlugin>().HydraDecorator.Enabled = true;
//Hud.GetPlugin<GLQ_PlayerSkillPlugin>().BlackHoleDecorator.Enabled = true;
//Hud.GetPlugin<GLQ_PlayerSkillPlugin>().SentryDecorator.Enabled = true;
//Hud.GetPlugin<GLQ_PlayerSkillPlugin>().SentryWithCustomEngineeringDecorator.Enabled = true;
//Hud.GetPlugin<GLQ_PlayerSkillPlugin>().PiranhadoDecorator.Enabled = true;
//Hud.GetPlugin<GLQ_PlayerSkillPlugin>().SpiritWalkDecorator.Enabled = true;
//Hud.GetPlugin<GLQ_PlayerSkillPlugin>().SpiritWalkWithJauntDecorator.Enabled = true;
//Hud.GetPlugin<GLQ_PlayerSkillPlugin>().BigBadVoodooDecorator.Enabled = true;
//Hud.GetPlugin<GLQ_PlayerSkillPlugin>().BigBadVoodooWithJungleDrumsDecorator.Enabled = true;
//Hud.GetPlugin<GLQ_PlayerSkillPlugin>().InnerSanctuaryDecorator.Enabled = true;
//Hud.GetPlugin<MiniMapLeftBuffListPlugin>().Enabled = true;
//Hud.GetPlugin<MiniMapRightBuffListPlugin>().Enabled = true;
//Hud.GetPlugin<PlayerBottomBuffListPlugin>().Enabled = true;
//Hud.GetPlugin<ConventionOfElementsBuffListPlugin>().Enabled = false;
//Hud.GetPlugin<GLQ_EliteMonsterAffixPlugin>().Enabled = true;
//Hud.GetPlugin<GLQ_PlayerSkillCirclesPlugin>().SkillRadius.Add(Hud.Render.CreateBrush(255, 255, 0, 0, 3), 15f, 105963, 4);
//Hud.GetPlugin<GLQ_PlayerSkillCirclesPlugin>().SkillRadius.Add(Hud.Render.CreateBrush(255, 255,255,255, 3), 50f, 79528, 2);
//Hud.GetPlugin<GLQ_TalRashaPlugin>().ShowRashaElements = true;
//Hud.GetPlugin<OriginalHealthPotionSkillPlugin>().Enabled = true;
//Hud.GetPlugin<RiftPlugin>().GreaterRiftPercentEnabled = true;
//Hud.GetPlugin<RiftPlugin>().GreaterRiftTimerEnabled = true;
//Hud.GetPlugin<GLQ_MonsterRiftProgressionPlugin>().Enabled = true;
//Hud.GetPlugin<GLQ_NotifyAtRiftPercentagePlugin>().DisplayLimit = 90;
//Hud.GetPlugin<GLQ_RiftInfoPlugin>().Enabled = true;//CustomizeEnd
//        }
//
//    }
//
//}