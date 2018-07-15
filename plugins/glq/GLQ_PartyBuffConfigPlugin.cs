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
		430674,
		208474,
		134872,
		30725,
		226348,
		312307,
		317076,
		96215,
		97110,
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
		130831,
		130830,
		130695,
		324770,
		449064,
		318821,
		402462,
		246562,
		318817,
		402458,
		449236,
		246113,
		440336,
		446195,
		318771,
		441517,
		322977,
		359583,
		440569,
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
		428348,
		403471,
		428030,
		403464,
		383014,

		445266,
		403404,
		266258,
		266254,
		262935,
		266271,
		402461,
		476689,
		476580,
		476583,
		475248,
		465839,
		472910,
		465952,
		466857,
	}; 
    uint[] onMe = {
		//onMe

		403460,
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