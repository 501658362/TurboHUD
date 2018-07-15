// ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
// *.txt files are not loaded automatically by TurboHUD
// you have to change this file's extension to .cs to enable it
// ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

using Turbo.Plugins.Default;
using Turbo.Plugins.glq;
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
            // basic examples
            // 玩家技能配置
        Hud.GetPlugin<GLQ_PartyInspector>().ToggleKeyEvent = Hud.Input.CreateKeyEvent(true, Key.F12, false, false, false);
        //  悬赏表格
        Hud.GetPlugin<BountyTablePlugin>().Enabled = true;
        // 计算怪物数量
        Hud.GetPlugin<GLQ_MonstersCountPlugin>().yard = 40;

        // 进度条提醒 秘境百分比通知
        Hud.GetPlugin<NotifyAtRiftPercentagePlugin>().Enabled = false;
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








        // 宝石技能范围
        Hud.GetPlugin<GLQ_LegendGemCirclePlugin>().Enabled = false;


        Hud.GetPlugin<OtherPlayersPlusPlugin>().Enabled = false;
        Hud.GetPlugin<OtherPlayersPlusPlugin>().Tag = false;
        Hud.GetPlugin<OtherPlayersPlusPlugin>().HPbar = false;
        Hud.GetPlugin<OtherPlayersPlusPlugin>().Resbar = false;


        // 精英各种词缀 看着会很烦
        Hud.GetPlugin<GLQ_EliteHealthBarPlugin>().Enabled = false;
        Hud.GetPlugin<GLQ_EliteHealthListPlugin>().Enabled = false;

        // 这个插件显示队友的名字
        Hud.GetPlugin<OtherPlayersPlugin>().Enabled = false;
        // buff显示在人身上
        Hud.GetPlugin<GLQ_PartyBuffPlugin>().Enabled = false;


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