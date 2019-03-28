using System.Linq;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.glq
{
    public class GLQ_OtherPlayersPlusPlugin : BasePlugin, IInGameWorldPainter
	{
        public TopLabelDecorator TagDecorator { get; set; }
        public bool Tag { get; set; }
        public bool HPbar { get; set; }
        public bool Resbar { get; set; }
        public IFont TextFont { get; set; }
        public IBrush BorderBrush { get; set; }
        public IBrush BackgroundBrush { get; set; }
        public IBrush HPbarBrush { get; set; }
        public IBrush ShieldbarBrush { get; set; }
        public IBrush ArcaneBrush { get; set; }//法师奥能
        public IBrush ManaBrush { get; set; }//巫医法力
        public IBrush SpiritBrush { get; set; }//武僧精力
        public IBrush FuryBrush { get; set; }//蛮子怒气
        public IBrush HatreBrush { get; set; }//猎魔人憎恨
        public IBrush DisciplineBrush { get; set; }//猎魔人戒律
        public IBrush WrathBrush { get; set; }//圣教军愤怒
        public IBrush EssenceBrush { get; set; }//死灵法师精魂

        public GLQ_OtherPlayersPlusPlugin()
		{
            Enabled = true;
            Tag = true;
            HPbar = true;
            Resbar = false;
        }
        public override void Load(IController hud)
        {
            base.Load(hud);
            TagDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 8, 200, 255, 255, 255, true, false, false),
            };
            TextFont = Hud.Render.CreateFont("tahoma", 8, 180, 255, 255, 255, true, false, true);
            BorderBrush = Hud.Render.CreateBrush(255, 0, 0, 0, 1);
            BackgroundBrush = Hud.Render.CreateBrush(255, 0, 0, 0, 0);
            HPbarBrush = Hud.Render.CreateBrush(200, 255, 0, 0, 0);
            ShieldbarBrush = Hud.Render.CreateBrush(200, 0, 2220, 220, 0);
            ArcaneBrush = Hud.Render.CreateBrush(200, 255, 0, 255, 0);
            ManaBrush = Hud.Render.CreateBrush(200, 0, 100, 255, 0);
            SpiritBrush = Hud.Render.CreateBrush(200, 255, 255, 200, 0);
            FuryBrush = Hud.Render.CreateBrush(200, 255, 128, 0, 0);
            HatreBrush = Hud.Render.CreateBrush(200, 160, 0, 0, 0);
            DisciplineBrush = Hud.Render.CreateBrush(200, 40, 70, 250, 0);
            WrathBrush = Hud.Render.CreateBrush(200, 255, 255, 230, 0);
            EssenceBrush = Hud.Render.CreateBrush(200, 80, 170, 170, 0);
        }

        public void PaintWorld(WorldLayer layer)
        {
            if ((Hud.Game.MapMode == MapMode.WaypointMap) || (Hud.Game.MapMode == MapMode.ActMap) || (Hud.Game.MapMode == MapMode.Map)) return;
            var players = Hud.Game.Players.Where(player => !player.IsMe && player.CoordinateKnown && (player.HeadStone == null));
            foreach (var player in players)
            {
                if (player == null) continue;
                var ScreenWidth = Hud.Window.Size.Width;
                var ScreenHeight = Hud.Window.Size.Height;
                var HeroTexture = Hud.Texture.GetTexture(890155253);
                var HPbarWidth = (float)(ScreenWidth / 13);
                var HPbarHeight = (float)(ScreenHeight / 130);
                var ResbarWidth = (float)(ScreenWidth / 13);
                var ResbarHeight = (float)(ScreenHeight / 200);
                var CurRes = 0f;
                var CurRes2 = 0f;
                var ScreenCoordinate = player.FloorCoordinate.ToScreenCoordinate();
                var PlayerX = ScreenCoordinate.X;
                var PlayerY = ScreenCoordinate.Y;
                if (HPbar == true)
                {
                    var CurHealth = player.Defense.HealthCur / player.Defense.HealthMax;
                    BorderBrush.DrawRectangle(PlayerX - (float)HPbarWidth / 2, PlayerY - (float)(ScreenHeight / 16) / 2, HPbarWidth, HPbarHeight);
                    BackgroundBrush.DrawRectangle(PlayerX - (float)HPbarWidth / 2, PlayerY - (float)(ScreenHeight / 16) / 2, HPbarWidth, HPbarHeight);
                    HPbarBrush.DrawRectangle(PlayerX - (float)HPbarWidth / 2, PlayerY - (float)(ScreenHeight / 16) / 2, HPbarWidth * CurHealth, HPbarHeight);
                    var Shieldpct = Hud.Game.Me.Defense.CurShield / Hud.Game.Me.Defense.HealthMax;
                    if (Shieldpct > 1) Shieldpct = 1;
                    ShieldbarBrush.DrawRectangle(PlayerX - (float)HPbarWidth / 2, PlayerY - (float)(ScreenHeight / 16) / 2, HPbarWidth * Shieldpct, HPbarHeight);

                }

                if (player.HeroClassDefinition.HeroClass.ToString() == "Barbarian")
                {
                    if(Resbar == true)
                    {
                        CurRes = player.Stats.ResourceCurFury / player.Stats.ResourceMaxFury;
                        BackgroundBrush.DrawRectangle(PlayerX - (float)ResbarWidth / 2, PlayerY - (float)(ScreenHeight / 28)/1.6f, ResbarWidth, ResbarHeight);
                        FuryBrush.DrawRectangle(PlayerX - (float)ResbarWidth / 2, PlayerY - (float)(ScreenHeight / 28)/1.6f, ResbarWidth * CurRes, ResbarHeight);
                    }
                    
                    if (player.SnoActor?.Sno == player.HeroClassDefinition.MaleActorSno) HeroTexture = Hud.Texture.GetTexture(3921484788); // male/female can't be determined, let's keep it for later...
                    else HeroTexture = Hud.Texture.GetTexture(1030273087);
                }
                else if (player.HeroClassDefinition.HeroClass.ToString() == "Crusader")
                {
                    if (Resbar == true)
                    {
                        CurRes = player.Stats.ResourceCurWrath / player.Stats.ResourceMaxWrath;
                        BackgroundBrush.DrawRectangle(PlayerX - (float)ResbarWidth / 2, PlayerY - (float)(ScreenHeight / 28) / 1.6f, ResbarWidth, ResbarHeight);
                        WrathBrush.DrawRectangle(PlayerX - (float)ResbarWidth / 2, PlayerY - (float)(ScreenHeight / 28) / 1.6f, ResbarWidth * CurRes, ResbarHeight);
                    }
                    if (player.SnoActor?.Sno == player.HeroClassDefinition.MaleActorSno) HeroTexture = Hud.Texture.GetTexture(3742271755);
                    else HeroTexture = Hud.Texture.GetTexture(3435775766);
                }
                else if (player.HeroClassDefinition.HeroClass.ToString() == "DemonHunter")
                {
                    if (Resbar == true)
                    {
                        CurRes = player.Stats.ResourceCurHatred / player.Stats.ResourceMaxHatred;
                        CurRes2 = player.Stats.ResourceCurDiscipline / player.Stats.ResourceMaxDiscipline;
                        BackgroundBrush.DrawRectangle(PlayerX - (float)ResbarWidth / 2, PlayerY - (float)(ScreenHeight / 28) / 1.6f, ResbarWidth, ResbarHeight);
                        HatreBrush.DrawRectangle(PlayerX - (float)ResbarWidth / 2, PlayerY - (float)(ScreenHeight / 28) / 1.6f, ResbarWidth * CurRes, ResbarHeight);
                        BackgroundBrush.DrawRectangle(PlayerX - (float)ResbarWidth / 2, PlayerY - (float)(ScreenHeight / 40) / 1.45f, ResbarWidth, ResbarHeight);
                        DisciplineBrush.DrawRectangle(PlayerX - (float)ResbarWidth / 2, PlayerY - (float)(ScreenHeight / 40) / 1.45f, ResbarWidth * CurRes2, ResbarHeight);
                    }
                    if (player.SnoActor?.Sno == player.HeroClassDefinition.MaleActorSno) HeroTexture = Hud.Texture.GetTexture(3785199803);
                    else HeroTexture = Hud.Texture.GetTexture(2939779782);
                }
                else if (player.HeroClassDefinition.HeroClass.ToString() == "Monk")
                {
                    if (Resbar == true)
                    {
                        CurRes = player.Stats.ResourceCurSpirit / player.Stats.ResourceMaxSpirit;
                        BackgroundBrush.DrawRectangle(PlayerX - (float)ResbarWidth / 2, PlayerY - (float)(ScreenHeight / 28) / 1.6f, ResbarWidth, ResbarHeight);
                        SpiritBrush.DrawRectangle(PlayerX - (float)ResbarWidth / 2, PlayerY - (float)(ScreenHeight / 28) / 1.6f, ResbarWidth * CurRes, ResbarHeight);
                    }
                    if (player.SnoActor?.Sno == player.HeroClassDefinition.MaleActorSno) HeroTexture = Hud.Texture.GetTexture(2227317895);
                    else HeroTexture = Hud.Texture.GetTexture(2918463890);
                }
                else if (player.HeroClassDefinition.HeroClass.ToString() == "Necromancer")
                {
                    if (Resbar == true)
                    {
                        CurRes = player.Stats.ResourceCurEssence / player.Stats.ResourceMaxEssence;
                        BackgroundBrush.DrawRectangle(PlayerX - (float)ResbarWidth / 2, PlayerY - (float)(ScreenHeight / 28) / 1.6f, ResbarWidth, ResbarHeight);
                        EssenceBrush.DrawRectangle(PlayerX - (float)ResbarWidth / 2, PlayerY - (float)(ScreenHeight / 28) / 1.6f, ResbarWidth * CurRes, ResbarHeight);
                    }
                    if (player.SnoActor?.Sno == player.HeroClassDefinition.MaleActorSno) HeroTexture = Hud.Texture.GetTexture(3285997023);
                    else HeroTexture = Hud.Texture.GetTexture(473831658);
                }
                else if (player.HeroClassDefinition.HeroClass.ToString() == "WitchDoctor")
                {
                    if (Resbar == true)
                    {
                        CurRes = player.Stats.ResourceCurMana / player.Stats.ResourceMaxMana;
                        BackgroundBrush.DrawRectangle(PlayerX - (float)ResbarWidth / 2, PlayerY - (float)(ScreenHeight / 28) / 1.6f, ResbarWidth, ResbarHeight);
                        ManaBrush.DrawRectangle(PlayerX - (float)ResbarWidth / 2, PlayerY - (float)(ScreenHeight / 28) / 1.6f, ResbarWidth * CurRes, ResbarHeight);
                    }
                    if (player.SnoActor?.Sno == player.HeroClassDefinition.MaleActorSno) HeroTexture = Hud.Texture.GetTexture(3925954876);
                    else HeroTexture = Hud.Texture.GetTexture(1603231623);
                }
                else if (player.HeroClassDefinition.HeroClass.ToString() == "Wizard")
                {
                    if (Resbar == true)
                    {
                        CurRes = player.Stats.ResourceCurArcane / player.Stats.ResourceMaxArcane;
                        BackgroundBrush.DrawRectangle(PlayerX - (float)ResbarWidth / 2, PlayerY - (float)(ScreenHeight / 28) / 1.6f, ResbarWidth, ResbarHeight);
                        ArcaneBrush.DrawRectangle(PlayerX - (float)ResbarWidth / 2, PlayerY - (float)(ScreenHeight / 28) / 1.6f, ResbarWidth * CurRes, ResbarHeight);
                    }
                    if (player.SnoActor?.Sno == player.HeroClassDefinition.MaleActorSno) HeroTexture = Hud.Texture.GetTexture(44435619);
                    else HeroTexture = Hud.Texture.GetTexture(876580014);
                }

                if(Tag == true)
                {
                    string battleTag = player.BattleTagAbovePortrait;
                    if (battleTag == null) continue;
                    TagDecorator.TextFunc = () => battleTag.ToString();
                    var BattleTagTexture = Hud.Texture.GetTexture(3098562643);
                    BattleTagTexture.Draw(PlayerX - (float)(ScreenWidth / 10) / 2, PlayerY - (float)(ScreenHeight / 7.8f) / 2, (float)(ScreenWidth / 10), (float)(ScreenHeight / 28), 0.7843f);
                    HeroTexture.Draw(PlayerX - (float)(Hud.Window.Size.Height / 31) / 2, PlayerY - (float)(ScreenHeight / 6.1f) / 2, (float)(ScreenHeight / 31), (float)(Hud.Window.Size.Height / 31), 1f);
                    TagDecorator.Paint(PlayerX - (float)(ScreenWidth / 11.5) / 2, PlayerY - (float)(ScreenHeight / 9.23f) / 2, (float)(ScreenWidth / 11.5), (float)(ScreenHeight / 45), HorizontalAlign.Center);
                }
                
            }
        }

    }

}