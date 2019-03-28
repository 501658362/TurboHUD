using Turbo.Plugins.Default;
using System.Linq;
namespace Turbo.Plugins.glq
{

    public class GLQ_TopMonsterHealthBarPlugin : BasePlugin, IInGameTopPainter
	{

        public IFont MonsterHitpointsFont { get; set; }
        public IFont MonsterEffectsFont { get; set; }
        public IBrush LineBrush { get; set; }
        public IBrush BorderBrush { get; set; }

        public GLQ_TopMonsterHealthBarPlugin()
		{
            Enabled = true;
		}

        public override void Load(IController hud)
        {
            base.Load(hud);

            MonsterHitpointsFont = Hud.Render.CreateFont("tahoma", 6, 255, 255, 255, 255, true, false, true);
            MonsterEffectsFont = Hud.Render.CreateFont("tahoma", 6, 255, 40, 200, 40, true, false, 128, 0, 0, 0, true);
            LineBrush = Hud.Render.CreateBrush(255, 255, 255, 255, 2f);
            BorderBrush = Hud.Render.CreateBrush(255, 150, 180, 150, -2);
        }
        private bool isKrysbin(IMonster Mob)
        {
            var Players = Hud.Game.Players.Where(player => player.HeroClassDefinition.HeroClass == HeroClass.Necromancer);
            bool EKrysbin = false;
            foreach (var player in Players)
            {
                if (player.Powers.BuffIsActive(475241))
                {
                    EKrysbin = true;
                    break;
                }
            }
            if (!EKrysbin) return false;
            if (Mob.Slow || Mob.Chilled)
            {
                if (Mob.Frozen || Mob.Stunned || Mob.Blind)
                    return true;
            }

            return false;
        }
        public void PaintTopInGame(ClipState clipState)
        {
            if (clipState != ClipState.BeforeClip) return;

            var uiBar = Hud.Render.MonsterHpBarUiElement;

            var monster = Hud.Game.SelectedMonster2 ?? Hud.Game.SelectedMonster1;
            if ((monster == null) || (uiBar == null)) return;
            var hpText = GLQ_BasePluginCN.ValueToString(monster.CurHealth, ValueFormat.LongNumber) + " / " + GLQ_BasePluginCN.ValueToString(monster.MaxHealth, ValueFormat.LongNumber);
            hpText += " - " + GLQ_BasePluginCN.ValueToString(monster.CurHealth / (monster.MaxHealth / 100.0f), ValueFormat.LongNumber) + "%";

            var textLayout = MonsterHitpointsFont.GetTextLayout(hpText);
            MonsterHitpointsFont.DrawText(textLayout, uiBar.Rectangle.Left + (uiBar.Rectangle.Width - textLayout.Metrics.Width) / 2, uiBar.Rectangle.Top + (uiBar.Rectangle.Height - textLayout.Metrics.Height) / 2);

            string textCC = null;
            if (monster.Frozen) textCC += (textCC == null ? "" : ", ") + "冰冻";
            if (monster.Chilled) textCC += (textCC == null ? "" : ", ") + "寒冷";
            if (monster.Slow) textCC += (textCC == null ? "" : ", ") + "减速";
            if (monster.Stunned) textCC += (textCC == null ? "" : ", ") + "昏迷";
            if (monster.Invulnerable)
            {
                BorderBrush.DrawRectangle(uiBar.Rectangle.Left, uiBar.Rectangle.Top, uiBar.Rectangle.Width, uiBar.Rectangle.Height);
                textCC += (textCC == null ? "" : ", ") + "无敌";
            }
                
            if (monster.Blind) textCC += (textCC == null ? "" : ", ") + "致盲";

            string textDebuff = null;
            if (monster.Locust) textDebuff += (textDebuff == null ? "" : ", ") + "虫群";
            if (monster.Palmed) textDebuff += (textDebuff == null ? "" : ", ") + "爆裂掌";
            if (monster.Haunted) textDebuff += (textDebuff == null ? "" : ", ") + "蚀魂";
            if (monster.MarkedForDeath) textDebuff += (textDebuff == null ? "" : ", ") + "标记";
            if (monster.Strongarmed) textDebuff += (textDebuff == null ? "" : ", ") + "力士";
            if (monster.Phoenixed) textDebuff += (textDebuff == null ? "" : ", ") + "火鸟";
            if(isKrysbin(monster)) textDebuff += (textDebuff == null ? "" : ", ") + "克利斯宾";
            var text = textCC + (textCC != null && textDebuff != null ? " | " : "") + textDebuff;
            if (monster.DotDpsApplied > 0) text += (string.IsNullOrEmpty(text) ? "" : " | ") + "DOT: " + GLQ_BasePluginCN.ValueToString(monster.DotDpsApplied, ValueFormat.LongNumber);
            if (text != null)
            {
                textLayout = MonsterEffectsFont.GetTextLayout(text);
                MonsterEffectsFont.DrawText(textLayout, uiBar.Rectangle.Left + (uiBar.Rectangle.Width - textLayout.Metrics.Width) / 2, uiBar.Rectangle.Top - (uiBar.Rectangle.Height * 0.38f) - textLayout.Metrics.Height);
            }
            if (monster.SummonerAcdDynamicId != 0 && monster.IsElite)
            {
                LineBrush.DrawLine(uiBar.Rectangle.Left, uiBar.Rectangle.Top - uiBar.Rectangle.Height * 1.5f, uiBar.Rectangle.Right, uiBar.Rectangle.Top + uiBar.Rectangle.Height + uiBar.Rectangle.Height * 1.5f, 0);
                LineBrush.DrawLine(uiBar.Rectangle.Left, uiBar.Rectangle.Top + uiBar.Rectangle.Height + uiBar.Rectangle.Height * 1.5f, uiBar.Rectangle.Right, uiBar.Rectangle.Top - uiBar.Rectangle.Height * 1.5f, 0);
            }
        }
    }

}