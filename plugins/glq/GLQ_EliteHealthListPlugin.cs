using System;
using System.Collections.Generic;
using System.Linq;
using Turbo.Plugins.Default;
namespace Turbo.Plugins.glq
{
    public class GLQ_EliteHealthListPlugin : BasePlugin, IInGameWorldPainter
    {
        //作者：我想静静 修改：小米
        public IFont TextFont { get; set; }
        public IBrush BorderBrush { get; set; }
        public IBrush BackgroundBrush { get; set; }
        public IBrush RareBrush { get; set; }
        public IBrush ChampionBrush { get; set; }

        public GLQ_EliteHealthListPlugin()
        {
            Enabled = false;
        }
        public override void Load(IController hud)
        {
            base.Load(hud);
            TextFont = Hud.Render.CreateFont("tahoma", 6, 180, 255, 255, 255, false, false, true);
            BorderBrush = Hud.Render.CreateBrush(255, 150, 180, 150, 2);
            BackgroundBrush = Hud.Render.CreateBrush(120, 0, 0, 0, 0);
            RareBrush = Hud.Render.CreateBrush(120, 255, 128, 0, 0);
            ChampionBrush = Hud.Render.CreateBrush(120, 0, 128, 255, 0);
        }
        public void PaintWorld(WorldLayer layer)
        {
            var monsters = Hud.Game.AliveMonsters;
            Dictionary<IMonster, string> eliteGroup = new Dictionary<IMonster, string>();
            foreach (var monster in monsters)
            {
                if (monster.Rarity == ActorRarity.Champion || monster.Rarity == ActorRarity.Rare)
                {
                    if(eliteGroup.ContainsKey(monster))
                    {
                        eliteGroup[monster]= monster.SnoMonster.Priority.ToString() + monster.SnoMonster.Sno + monster.SnoMonster.NameEnglish + String.Join(", ", monster.AffixSnoList);
                    }
                    else
                    {
                        eliteGroup.Add(monster, monster.SnoMonster.Priority.ToString() + monster.SnoMonster.Sno + monster.SnoMonster.NameEnglish + String.Join(", ", monster.AffixSnoList));
                    }
                }
            }
            Dictionary<IMonster, string> eliteGroup1 = eliteGroup.OrderBy(p => p.Value).ToDictionary(p => p.Key, o => o.Value);
            var px = Hud.Window.Size.Width * 0.00125f;
            var py = Hud.Window.Size.Height * 0.001667f;
            var h = py * 5;
            var w2 = py * 50;
            var count = 0;
            string preStr = null;
            //remove clone
            foreach (var elite in eliteGroup1)
            {
                if (elite.Key.Illusion) continue;
                if (elite.Key.Rarity == ActorRarity.Champion)
                {
                    var x = Hud.Window.Size.Width * 0.125f;
                    var w = elite.Key.CurHealth * w2 / elite.Key.MaxHealth;
                    var affixlist = "";
                    foreach (var Affix in elite.Key.AffixSnoList)
                    {
                        affixlist = affixlist + " " + Affix.NameLocalized;
                    }
                    var text = (elite.Key.CurHealth * 100 / elite.Key.MaxHealth).ToString("f1") + "%" + affixlist;
                    var layout = TextFont.GetTextLayout(text);
                    if (preStr != elite.Value || preStr == null) count++;
                    var y = py * 8 * count;
                    if (elite.Key.Invulnerable) BorderBrush.DrawRectangle(x, y, w2, h);
                    BackgroundBrush.DrawRectangle(x, y, w2, h);
                    TextFont.DrawText(layout, x + px + w2, y - py);
                    ChampionBrush.DrawRectangle(x, y, (float)w, h);
                    preStr = elite.Value;
                    count++;
                }
                if (elite.Key.Rarity == ActorRarity.Rare)
                {
                    var x = Hud.Window.Size.Width * 0.125f;
                    var w = elite.Key.CurHealth * w2 / elite.Key.MaxHealth;
                    var affixlist = "";
                    foreach (var Affix in elite.Key.AffixSnoList)
                    {
                        affixlist = affixlist + " " + Affix.NameLocalized;
                    }
                    var text = (elite.Key.CurHealth * 100 / elite.Key.MaxHealth).ToString("f1") + "%" + affixlist;
                    var layout = TextFont.GetTextLayout(text);
                    if (preStr != elite.Value || preStr == null) count++;
                    var y = py * 8 * count;
                    if (elite.Key.Invulnerable) BorderBrush.DrawRectangle(x, y, w2, h);
                    BackgroundBrush.DrawRectangle(x, y, w2, h);
                    TextFont.DrawText(layout, x + px + w2, y - py);
                    RareBrush.DrawRectangle(x, y, (float)w, h);
                    preStr = elite.Value;
                    count++;
                }
            }
            eliteGroup.Clear();
            eliteGroup1.Clear();
        }
    }
}