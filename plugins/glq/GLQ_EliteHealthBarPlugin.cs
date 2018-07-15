using System.Collections.Generic;
using System.Linq;
using System;
using Turbo.Plugins.Default;
namespace Turbo.Plugins.glq
{
    public class GLQ_EliteHealthBarPlugin : BasePlugin, IInGameWorldPainter
    {
        //作者：我想静静 修改：小米
        public IFont TextFont { get; set; }
        public IBrush BorderBrush { get; set; }
        public IBrush BackgroundBrush { get; set; }
        public IBrush RareBrush { get; set; }
        public IBrush ChampionBrush { get; set; }
        public IFont TextFontHaunt { get; set; }
        public IFont TextFontLocust { get; set; }
        public int b { get; set; }


        public GLQ_EliteHealthBarPlugin()
        {
            Enabled = false;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
            TextFont = Hud.Render.CreateFont("tahoma", 8, 180, 255, 255, 255, true, false, true);
            BorderBrush = Hud.Render.CreateBrush(255, 150, 180, 150, -4);
            BackgroundBrush = Hud.Render.CreateBrush(255, 0, 0, 0, 0);
            RareBrush = Hud.Render.CreateBrush(200, 255, 128, 0, 0);
            ChampionBrush = Hud.Render.CreateBrush(200, 0, 128, 255, 0);
            TextFontLocust = Hud.Render.CreateFont("tahoma", 8, 120, 128, 255, 128, true, false, true);
            TextFontHaunt = Hud.Render.CreateFont("tahoma", 8, 120, 150, 200, 255, true, false, true);
            TextFontLocust.SetShadowBrush(255, 0, 64, 64, true);
            TextFontHaunt.SetShadowBrush(255, 0, 0, 64, true);
            b = 35;

        }

        public void PaintWorld(WorldLayer layer)
        {
            var w1 = Hud.Window.Size.Width * 0.00333f * b;
            var textLocust = "虫群";//"L"
            var layoutLocust = TextFontLocust.GetTextLayout(textLocust);
            var textHaunt = "蚀魂";//"H"
            var layoutHaunt = TextFontHaunt.GetTextLayout(textHaunt);
            var h2 = Hud.Window.Size.Height * 0.017f;
            var x2 = Hud.Window.Size.Width * 0.001667f * b;
            var x3 = Hud.Window.Size.Width * 0.02f;


            var monsters = Hud.Game.AliveMonsters;
            foreach (var monster in monsters)
            {
				bool illusionist = false;
				if(monster.SummonerAcdDynamicId == 0)
				{
					illusionist = false;
				}
				else
				{
					illusionist = true;
				}
                if (monster.Rarity == ActorRarity.Champion)
                {
					if (illusionist == false)
                    {
					    var hptext = (monster.CurHealth * 100 / monster.MaxHealth).ToString("f1")+"%";
                        var layout = TextFont.GetTextLayout(hptext);
                        var h = Hud.Window.Size.Height * 0.00034f * 35;
                        var w = monster.CurHealth * w1 / monster.MaxHealth;
                        var monsterX = monster.FloorCoordinate.ToScreenCoordinate().X;// - w1 / 2;
                        var monsterY = monster.FloorCoordinate.ToScreenCoordinate().Y;// + py * 14;
                        var locustX = monsterX + x3 * 0.1f;
                        var hauntX = monsterX - x3;
                        var buffY = monsterY - h2 * 2f;
                        var hpX = monsterX-1.5f;
                        if(monster.Invulnerable)BorderBrush.DrawRectangle(monsterX-x2, monsterY+h2, w1, h);
                        BackgroundBrush.DrawRectangle(monsterX - x2, monsterY + h2, w1, h);
                        if (monster.Rarity == ActorRarity.Champion) ChampionBrush.DrawRectangle(monsterX - x2, monsterY + h2, (float)w, h);
                        if (monster.Locust) TextFontLocust.DrawText(layoutLocust, locustX, buffY);
                        if (monster.Haunted) TextFontHaunt.DrawText(layoutHaunt, hauntX, buffY);
                        TextFont.DrawText(layout, hpX, monsterY + h2/1.2f);
                    }
                }
                if (monster.Rarity == ActorRarity.Rare)
                {
					if (illusionist == false)
                    {
					    var hptext = (monster.CurHealth * 100 / monster.MaxHealth).ToString("f1")+"%";
                        var layout = TextFont.GetTextLayout(hptext);
                        var h = Hud.Window.Size.Height * 0.00034f * 35;
                        var w = monster.CurHealth * w1 / monster.MaxHealth;
                        var monsterX = monster.FloorCoordinate.ToScreenCoordinate().X;// - w1 / 2;
                        var monsterY = monster.FloorCoordinate.ToScreenCoordinate().Y;// + py * 14;
                        var locustX = monsterX + x3 * 0.1f;
                        var hauntX = monsterX - x3;
                        var buffY = monsterY - h2 * 2f;
                        var hpX = monsterX-1.5f;
						if(monster.Invulnerable)BorderBrush.DrawRectangle(monsterX-x2, monsterY+h2, w1, h);
                        BackgroundBrush.DrawRectangle(monsterX - x2, monsterY + h2, w1, h);
                        if (monster.Rarity == ActorRarity.Rare) RareBrush.DrawRectangle(monsterX - x2, monsterY + h2, (float)w, h);
                        if (monster.Locust) TextFontLocust.DrawText(layoutLocust, locustX, buffY);
                        if (monster.Haunted) TextFontHaunt.DrawText(layoutHaunt, hauntX, buffY);
                        TextFont.DrawText(layout, hpX, monsterY + h2/1.2f);
                    }
                }
            }
        }
    }
}