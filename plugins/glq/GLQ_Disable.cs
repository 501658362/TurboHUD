using Turbo.Plugins.Default;

namespace Turbo.Plugins.glq
{

    public class GLQ_DisablePlugin : BasePlugin, ICustomizer
	{

        public GLQ_DisablePlugin()
		{
            Enabled = true;
		}

        public void Customize()
        {
            Hud.RunOnPlugin<DangerousMonsterPlugin>(plugin => 
            { 
                foreach (var name in new string[] { "Wood Wraith", "Highland Walker", "The Old Man", "Fallen Lunatic", "Deranged Fallen", "Fallen Maniac", "Frenzied Lunatic", "Herald of Pestilence", "Terror Demon", "Demented Fallen", "Savage Beast", "Tusked Bogan", "Punisher", "Anarch", "Corrupted Angel", "Winged Assassin", "Exarch" }) 
                { 
                    plugin.RemoveName(name); 
                } 
            });  
            Hud.GetPlugin<AttributeLabelListPlugin>().Enabled = false;
            Hud.GetPlugin<BannerPlugin>().Enabled = false;
            Hud.GetPlugin<BloodShardPlugin>().Enabled = false; 
            Hud.GetPlugin<CosmeticItemsPlugin>().Enabled = false;
            Hud.GetPlugin<CursedEventPlugin>().Enabled = false; 
            Hud.GetPlugin<DamageBonusPlugin>().Enabled = false; 
            Hud.GetPlugin<ExperienceOverBarPlugin>().Enabled = false; 
            Hud.GetPlugin<EliteMonsterAffixPlugin>().Enabled = false; 
            Hud.GetPlugin<GoblinPlugin>().Enabled = false; 
            Hud.GetPlugin<GlobePlugin>().Enabled = false; 
            Hud.GetPlugin<HeadStonePlugin>().Enabled = false; 
            Hud.GetPlugin<InventoryAndStashPlugin>().Enabled = false;
            Hud.GetPlugin<InventoryFreeSpacePlugin>().Enabled = false;
            Hud.GetPlugin<ItemsPlugin>().Enabled = false;
            Hud.GetPlugin<MonsterPackPlugin>().Enabled = false; 
            Hud.GetPlugin<NetworkLatencyPlugin>().Enabled = false; 
            Hud.GetPlugin<NotifyAtRiftPercentagePlugin>().Enabled = false; 
            Hud.GetPlugin<OtherPlayersPlugin>().Enabled = false;
            Hud.GetPlugin<PlayerSkillPlugin>().Enabled = false; 
            Hud.GetPlugin<GLQ_PlayerSkillPlugin>().HydraDecorator.Enabled = false;
            Hud.GetPlugin<PortalPlugin>().Enabled = false; 
            Hud.GetPlugin<PortraitBottomStatsPlugin>().Enabled = false; 
            Hud.GetPlugin<SceneHintPlugin>().Enabled = false;
            Hud.GetPlugin<ShrinePlugin>().Enabled = false; 
            Hud.GetPlugin<StandardMonsterPlugin>().Enabled = false; 
            Hud.GetPlugin<TopMonsterHealthBarPlugin>().Enabled = false; 
            Hud.GetPlugin<ResourceOverGlobePlugin>().Enabled = false; 
            Hud.GetPlugin<RiftPlugin>().NearMonsterProgressionEnabled = false;
            Hud.GetPlugin<OriginalSkillBarPlugin>().Enabled = false; 
            Hud.GetPlugin<ConventionOfElementsBuffListPlugin>().Enabled = false; 
            Hud.GetPlugin<TopExperienceStatistics>().Enabled = false; 
            Hud.GetPlugin<GLQ_OtherPlayersPlugin>().Enabled = true; 
            Hud.RunOnPlugin<PlayerBottomBuffListPlugin>(plugin => {
                plugin.RuleCalculator.Rules.Clear();
                plugin.Enabled = false;
            })
            ;

        }

    }

}