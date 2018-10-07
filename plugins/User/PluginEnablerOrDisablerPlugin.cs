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
        Hud.GetPlugin<TopExperienceStatistics>().Enabled = true;
        Hud.GetPlugin<DangerousMonsterPlugin>().Enabled = true;
        Hud.GetPlugin<EliteMonsterAffixPlugin>().Enabled = true;
        Hud.GetPlugin<GoblinPlugin>().EnableSpeak = true;
        Hud.GetPlugin<TopMonsterHealthBarPlugin>().Enabled = false;
        Hud.GetPlugin<DamageBonusPlugin>().Enabled = true;
        Hud.GetPlugin<ExperienceOverBarPlugin>().Enabled = false;
        Hud.GetPlugin<NetworkLatencyPlugin>().Enabled = true;
        // 截图插件
        Hud.GetPlugin<ParagonCapturePlugin>().Enabled = false;

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
        Hud.GetPlugin<GLQ_GreaterRiftPylonMarkerPlugin>().Enabled = true;
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
                    plugin.OtherScreenPaint = false; // ？？
                    plugin.OtherPortraitPaint = true; // 队友头像处
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
        Hud.GetPlugin<OtherPlayersPlusPlugin>().Enabled = true;
        // 队友名字
        Hud.GetPlugin<OtherPlayersPlusPlugin>().Tag = true;
        // 队友血量
        Hud.GetPlugin<OtherPlayersPlusPlugin>().HPbar = true;
        // 队友能量
        Hud.GetPlugin<OtherPlayersPlusPlugin>().Resbar = false;


        // 这个插件显示队友的名字 很小但是很烦
        Hud.GetPlugin<OtherPlayersPlugin>().Enabled = false;


        // 精英各种词缀 看着会很烦
        Hud.GetPlugin<GLQ_EliteHealthBarPlugin>().Enabled = false;
        Hud.GetPlugin<GLQ_EliteHealthListPlugin>().Enabled = false;




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
        }

    }

}