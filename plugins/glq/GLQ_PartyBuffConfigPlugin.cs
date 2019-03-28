using Turbo.Plugins.Default;
namespace Turbo.Plugins.glq
{
    public class GLQ_PartyBuffConfigPlugin : BasePlugin, ICustomizer
	{
        public GLQ_PartyBuffConfigPlugin()
		{
            Enabled = true;
		}
        public void Customize()
        {
 
Hud.RunOnPlugin<GLQ_PartyBuffPlugin>(plugin => 
{ 
    uint[] onWiz = {
		//onWiz
        

	}; 
    uint[] onMonk = {
		//onMonk

	}; 
    uint[] onWD = {
		//onWD
        
	}; 
    uint[] onBarb = {
		//onBarb
		
	}; 
    uint[] onCrus = {
		//onCrus
        
	}; 
    uint[] onDH = {
		//onDH
        
	}; 
    uint[] onAll = {
		//onAll
		208474,
		134872,
		30725,
		317076,
		96215,
		156484,
		79528,
		79607,
		217819,
		117402,
		67616,
		106237,
		208594,
		218501,
		269032,
		291804,
		309830,
		129216,
		365311,
		129217,
		130695,
		324770,
		402462,
		246562,
		440336,
		429855,
		450294,
		359580,
		445814,
		429673,
		437711,
		439308,
		436426,
		445829,
		445639,
		409428,
		434964,
		423244,
		445266,
		403404,
		266258,
		266254,
		262935,
		266271,
		402461,
		465839,
		472910,
		465952,

		334883,
		278269,
		030477,
		278271,
		030479,
		278270,
		030478,
		278268,
		030476,
		260349,
		260348,
		462089,
		465350,
	}; 
    uint[] onMe = {
		//onMe
		440569,
		359583,
		476583,
		475248,
		476580,
		476689,
		441517,
		476587,
		430289,
		445274,
		449236,
		402458,
		318817,
		318875,
		318821,
		440598,
		30631,
		430228,

		30668,
	};  
    //pass buffs to plugin -> apply them 
    uint[] onNec = {
		//onNec
		
	};
    plugin.DisplayOnAll(onAll); 
    plugin.DisplayOnMe(onMe); 
    plugin.DisplayOnClassExceptMe(HeroClass.Wizard, onWiz); 
    plugin.DisplayOnClassExceptMe(HeroClass.Necromancer, onNec); 
    plugin.DisplayOnClassExceptMe(HeroClass.Monk, onMonk); 
    plugin.DisplayOnClassExceptMe(HeroClass.Barbarian, onBarb); 
    plugin.DisplayOnClassExceptMe(HeroClass.WitchDoctor, onWD); 
    plugin.DisplayOnClassExceptMe(HeroClass.DemonHunter, onDH); 
    plugin.DisplayOnClassExceptMe(HeroClass.Crusader, onCrus); 
            }); 
        }
    }
}