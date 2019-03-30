// ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
// *.txt files are not loaded automatically by TurboHUD
// you have to change this file's extension to .cs to enable it
// ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

using Turbo.Plugins.Default;
using Turbo.Plugins.glq;
using Turbo.Plugins.wq;
using Turbo.Plugins.Resu;
using Turbo.Plugins.Stone;
using Turbo.Plugins.gjuz;
using SharpDX.DirectInput;

namespace Turbo.Plugins.User
{

    public class PluginEnablerOrDisablerPlugin : BasePlugin, ICustomizer
    {

        public PluginEnablerOrDisablerPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
        }

        // "Customize" methods are automatically executed after every plugin is loaded.
        // So these methods can use Hud.GetPlugin<class> to access the plugin instances' public properties (like decorators, Enabled flag, parameters, etc)
        // Make sure you test the return value against null!
        public void Customize()
        {
        // default disable
        Hud.GetPlugin<ItemsPlugin>().Enabled = false;
        Hud.GetPlugin<TopExperienceStatistics>().Enabled = false;
        Hud.GetPlugin<DangerousMonsterPlugin>().Enabled = true;
        Hud.GetPlugin<EliteMonsterAffixPlugin>().Enabled = true;
        Hud.GetPlugin<GoblinPlugin>().EnableSpeak = true;
        Hud.GetPlugin<TopMonsterHealthBarPlugin>().Enabled = false;
        Hud.GetPlugin<DamageBonusPlugin>().Enabled = false;
        Hud.GetPlugin<ExperienceOverBarPlugin>().Enabled = false;
        Hud.GetPlugin<NetworkLatencyPlugin>().Enabled = true;
        // 截图插件
        Hud.GetPlugin<ParagonCapturePlugin>().Enabled = false;

        // 管理器相关的
        Hud.GetPlugin<GLQ_VersioninformationPlugin>().Enabled = false;
	    // Inventory 文件夹 物品栏、储存箱相关插件
		Hud.TogglePlugin<InventoryAndStashPlugin>(false);			//物品装备多功能辅助显示，请在子功能上选择true、false
		Hud.TogglePlugin<GLQ_InventoryAndStashPlugin>(true);			//物品装备多功能辅助显示，请在子功能上选择true、false
		Hud.GetPlugin<GLQ_InventoryAndStashPlugin>().LooksGoodDisplayEnabled = false;			//属性是否比较满，比较好会显示一个绿色角标
		Hud.GetPlugin<GLQ_InventoryAndStashPlugin>().DefinitelyBadDisplayEnabled = true;		//属性是否都很差，很差的会显示一个红色角标
		Hud.GetPlugin<GLQ_InventoryAndStashPlugin>().NotGoodDisplayEnabled = true;				//不是很好的东西，用灰色标注出来
		Hud.GetPlugin<GLQ_InventoryAndStashPlugin>().AncientRankEnabled = true;					//远古、太古显示(无须鉴定)
		Hud.GetPlugin<GLQ_InventoryAndStashPlugin>().SocketedLegendaryGemRankEnabled = true;	//显示首饰位置上传奇宝石等级
		Hud.GetPlugin<GLQ_InventoryAndStashPlugin>().CaldesannRankEnabled = true;				//卡德山的等级显示在装备上
		Hud.GetPlugin<GLQ_InventoryAndStashPlugin>().HoradricCacheEnabled = true;				//标注是否是悬赏专属物品
		Hud.GetPlugin<GLQ_InventoryAndStashPlugin>().CanCubedEnabled = true;					//显示是否可以萃取到魔盒里
        // 仓库中 显示装备在军械库的装备
        Hud.GetPlugin<GLQ_ArmorySetInfo>().Enabled = true;
        // 技能栏上方
        Hud.GetPlugin<AttributeLabelListPlugin>().Enabled = false;
        Hud.GetPlugin<CcpAttributeLabelListPlugin>().Enabled = false;
        Hud.GetPlugin<GLQ_AttributeLabelListPlugin>().Enabled = true;
        //BOSS血条右边显示所有人受罚者叠层
        Hud.GetPlugin<GLQ_BaneOfTheStrickenPlugin>().Enabled = true;
        //显示其他人放的战旗的位置
        Hud.GetPlugin<BannerPlugin>().Enabled = false;
        Hud.GetPlugin<GLQ_BannerPlugin>().Enabled = true;
        // 显示鼠标与角色的距离 鼠标范围内怪物数量
        Hud.GetPlugin<GLQ_MonsterDensityAroundCursorPlugin>().Enabled = false;
        // 自己脚下的红圈
        Hud.GetPlugin<GLQ_PlayersCirclePlugin>().Enabled = false;
          // 自己脚下的红圈
        Hud.GetPlugin<GLQ_MeCirclePlugin>().Enabled = false;
        // 全能戒子 buff 计时
        Hud.GetPlugin<GLQ_ConventionOfElementsBuffListPlugin>().Enabled = false;
        Hud.GetPlugin<GLQ_FollowerPlugin>().Enabled = false;

        //显示组队“人多势众”Buff范围
        Hud.GetPlugin<MultiplayerExperienceRangePlugin>().Enabled = true;

            // basic examples
            // 玩家技能配置
        Hud.GetPlugin<GLQ_PartyInspector>().ToggleKeyEvent = Hud.Input.CreateKeyEvent(true, Key.F12, false, false, false);
        //  悬赏表格
        Hud.GetPlugin<BountyTablePlugin>().Enabled = true;

        // 计算怪物数量
        Hud.GetPlugin<GLQ_MonstersCountPlugin>().yard = 40;

        // 进度条提醒 秘境百分比通知
        Hud.GetPlugin<NotifyAtRiftPercentagePlugin>().Enabled = true;
        // 进度条提醒 秘境百分比通知
        Hud.GetPlugin<GLQ_NotifyAtRiftPercentagePlugin>().Enabled = true;
        // 秘境圣坛标记
        Hud.GetPlugin<GLQ_GreaterRiftPylonMarkerPlugin>().Enabled = false;
        // 大秘境 进度条
        Hud.GetPlugin<GLQ_GRiftProgressBarRuler>().Enabled = true;
        // 宝石计算
        Hud.GetPlugin<GLQ_GemsInventoryCountPlugin>().Enabled = true;
        // 血球
        Hud.GetPlugin<GLQ_HealthGlobePlugin>().Enabled = true;
        // 进度球和奈非天球
        Hud.GetPlugin<GlobePlugin>().Enabled = true;
        Hud.GetPlugin<GLQ_GlobePlugin>().Enabled = true;

        // 哥布林插件
        Hud.GetPlugin<GoblinPlugin>().Enabled = false;
        Hud.GetPlugin<GLQ_GoblinPlugin>().Enabled = true;


        // 装备掉落提示
        Hud.GetPlugin<GLQ_ItemDropSoundAlertPlugin>().Enabled = true;
        // 装备主属性显示
        Hud.GetPlugin<GLQ_InventoryMainStatPlugin>().Enabled = true;
        // 古帕特效提醒
        Hud.GetPlugin<GLQ_AncientParthanCount>().Enabled = true;

        // 诅咒事件  也不知道干嘛的
        Hud.GetPlugin<GLQ_CursedEventPlugin>().Enabled = true;


        // 显示远古 地面的传奇
        Hud.GetPlugin<GLQ_ItemsPlugin>().Enabled = true;

        // 全能戒子 buff 计时
        Hud.GetPlugin<ConventionOfElementsBuffListPlugin>().Enabled = false;
        // 全能戒子 buff 计时 只显示一种
        Hud.GetPlugin<ConventionOfElementsAndBrokenPromissesBuffOnCenterPlugin>().Enabled = true;
        // 所有buff显示在人身上 和头像上
        Hud.RunOnPlugin<GLQ_PartyBuffPlugin>(plugin =>
            {
                    plugin.MeScreenPaint = false; // 人物下方
                    plugin.MePortraitPaint = true; // 自己的头像处
                    plugin.OtherScreenPaint = true; // ？？
                    plugin.OtherPortraitPaint = false; // 队友头像处
                    plugin.Tooltips = false;

            });


        // Resu  https://github.com/User5981/Resu/blob/master/README.md
        // 贼神宝石 指示器
        Hud.RunOnPlugin<HuntersVengeancePlugin>(plugin =>
            {
                plugin.permanentCircle = true;
                plugin.ElitesOnlyNumbers = true;
            });

        // 宝石升级几率
        Hud.RunOnPlugin<UrshisGiftPlugin>(plugin =>
            {
                plugin.ChanceWantedPercentage = 100;  // % chance wanted : 100; 90; 80; 70; 60; 30; 15; 8; 4; 2; 1;
                plugin.NumberOfAttempts = 5;        // 此％的连续尝试次数：1; 2; 3; （默认）4; （授予GRift或无死亡奖金）5; （赋予GRift +无死亡奖​​金）
                plugin.InventoryNumbers = true;    //显示GRift级别建议库存中的gem，stash，设置为true; 或者是假的;
                plugin.HoveredNumbers = true;     // 显示项目悬停时的升级提示，设置为true; 或者是假的;

            });


        // 怪物统计用  具体没明白 是干嘛的
        Hud.RunOnPlugin<SummonerMonsterBarCountPlugin>(plugin =>
            {
               plugin.ShowMeScreenBaseYard = false;    // 1. MeScreenBaseYard on, off
               plugin.ShowMeScreenMaxYard = false;     // 2. MeScreenMaxYard on, off
               plugin.ShowSummonerCount = true;       // 3. SummonerCount on, off
               plugin.ShowSummonerEliteBar = true;    // 4. EliteSummonerBar on, off
               plugin.ShowSummonerNormalMonsterBar = true; //5.NormalSummonerBar on, off
               plugin.showdifLabel = true;            // 6. different Label Color on, off

            });
         // 统计玩家在城里的时间  悬赏看混子的
        Hud.RunOnPlugin<PlayerInTown>(plugin =>
            {
                plugin.AlwaysStopTime = false;
                plugin.OnlyShowOnBountyTable = false;

            });




        // 大秘境组队推荐层级  垃圾东西。。。
        Hud.GetPlugin<GroupGRLevelAdviserPlugin>().Enabled = false;

        // 宝石技能范围
        Hud.GetPlugin<GLQ_LegendGemCirclePlugin>().Enabled = false;

        // 队友插件
        Hud.GetPlugin<OtherPlayersPlusPlugin>().Enabled = false;
        // 队友名字
        Hud.GetPlugin<OtherPlayersPlusPlugin>().Tag = false;
        // 队友血量
        Hud.GetPlugin<OtherPlayersPlusPlugin>().HPbar = false;
        // 队友能量
        Hud.GetPlugin<OtherPlayersPlusPlugin>().Resbar = false;


        // 这个插件显示队友的名字 很小但是很烦
        Hud.GetPlugin<OtherPlayersPlugin>().Enabled = false;


        // 精英各种词缀 看着会很烦
        Hud.GetPlugin<GLQ_EliteHealthBarPlugin>().Enabled = true;
        Hud.GetPlugin<GLQ_EliteHealthListPlugin>().Enabled = true;


		Hud.TogglePlugin<BloodShardPlugin>(true);					//血岩碎片容量状态显示在成就按钮下面
		Hud.TogglePlugin<InventoryFreeSpacePlugin>(true);			//物品栏空位数量显示在背包按钮下面
		Hud.TogglePlugin<InventoryKanaiCubedItemsPlugin>(true);		//魔盒萃取的三件在物品栏最上面显示
		Hud.TogglePlugin<InventoryMaterialCountPlugin>(true);		//材料数量在物品栏下面显示

		Hud.TogglePlugin<StashPreviewPlugin>(false);				//储存箱内容预览，鼠标停在箱子页标，会显示该页内容
		Hud.TogglePlugin<StashUsedSpacePlugin>(false);				//储存箱已用的格数显示在箱子页标上


		// Items 文件夹 游戏界面内物品辅助显示插件
		Hud.TogglePlugin<CosmeticItemsPlugin>(true);				//各种可能出现幻化与特殊收藏品的地方都会提示你
		Hud.TogglePlugin<HoveredItemInfoPlugin>(true);				//未鉴定装备探测，鼠标停在装备上会在装备名字处显示信息
//            // turn on MultiplayerExperienceRangePlugin
//            Hud.TogglePlugin<MultiplayerExperienceRangePlugin>(true);
//
//            // turn off sell darkening
//            Hud.GetPlugin<InventoryAndStashPlugin>().NotGoodDisplayEnabled = false;
//
//            // disable arcane affix label
//            Hud.GetPlugin<EliteMonsterAffixPlugin>().AffixDecorators.Remove(MonsterAffix.Arcane);
//
//            // override an elite affix's text
//            Hud.GetPlugin<EliteMonsterAffixPlugin>().CustomAffixNames.Add(MonsterAffix.Desecrator, "DES");

            // Minimap 文件夹 小地图辅助功能插件
			Hud.TogglePlugin<MarkerPlugin>(true);						//对任务点、特殊事件等地方会在小地图里打圈
			Hud.TogglePlugin<SceneHintPlugin>(true);					//场景预览插件，就是开图
			// tab地图、小地图
			Hud.SceneReveal.MapEnabled = true;				//tab地图开图功能
			Hud.SceneReveal.MapOpacity = 60;				//大地图的预览区透明度(0-255)
			Hud.SceneReveal.MinimapEnabled = true;			//小地图开图功能
			Hud.SceneReveal.MinimapOpacity = 80;			//小地图预览区域透明度(0-255)
			Hud.SceneReveal.DisplaySceneBorder = false;		//是否显示不同的地形区块的边界
			// 小地图是否限制在框界限内(不加限制，小地图将出界展现为全屏的大地图)
			Hud.SceneReveal.MinimapClip = true;
			// 别动下一句
			Hud.SceneReveal.BrushKnown = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(64, 180, 180, 250));
        }

    }

}