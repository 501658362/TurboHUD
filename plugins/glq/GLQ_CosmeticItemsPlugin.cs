using System.Collections.Generic;
using System.Linq;
using Turbo.Plugins.Default;
namespace Turbo.Plugins.glq
{
    // original idea from http://turbohud.freeforums.net/user/6766 and http://turbohud.freeforums.net/user/1694
    public class GLQ_CosmeticItemsPlugin : BasePlugin, IInGameWorldPainter
    {

        public WorldDecoratorCollection Decorator { get; set; }
        public string DisplayTextOnActors { get; set; }
        public string DisplayTextOnActors_StaffofHerding { get; set; }
        public string DisplayTextOnMonsters { get; set; }
        public string DisplayTextOnMonsters_StaffofHerding { get; set; }
        public string DisplayTextOnItems { get; set; }
        public string DisplayTextOnItems_Cosmetic { get; set; }
        public string DisplayTextOnItems_StaffofHerding { get; set; }
        public bool EnableSpeak { get; set; }
		
        private HashSet<uint> _monsterSnoList = new HashSet<uint>();
        private HashSet<uint> _monsterSnoList_StaffofHerding = new HashSet<uint>();
        private HashSet<uint> _actorSnoList = new HashSet<uint>();
        private HashSet<uint> _actorSnoList_StaffofHerding = new HashSet<uint>();
        private HashSet<uint> _itemSnoList_Cosmetic = new HashSet<uint>();
        private HashSet<uint> _itemSnoList_StaffofHerding = new HashSet<uint>();

        public GLQ_CosmeticItemsPlugin()
        {
            Enabled = true;
            EnableSpeak = true;
            DisplayTextOnActors = "装饰品掉落处";
            DisplayTextOnActors_StaffofHerding = "牧牛杖材料掉落处";
            DisplayTextOnMonsters = "装饰品掉落者";
            DisplayTextOnMonsters_StaffofHerding = "牧牛杖材料掉落者";
            DisplayTextOnItems = "装饰品";
            DisplayTextOnItems_Cosmetic = "幻化品";
            DisplayTextOnItems_StaffofHerding = "牧牛杖材料";
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            Decorator = new WorldDecoratorCollection(
                new MapShapeDecorator(Hud)
                {
                    ShapePainter = new RotatingTriangleShapePainter(Hud),
                    Brush = Hud.Render.CreateBrush(160, 255, 102, 255, 10),
                    ShadowBrush = Hud.Render.CreateBrush(96, 0, 0, 0, 1),
                    Radius = 2,
                },
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(150, 255, 128, 0, 0),
                    Radius = 1.125f,
                },
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(90, 0, 0, 0, 0),
                    TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 255, 102, 255, true, false, 88, 0, 0, 0, true),
                }
                );
            //虹光
            _monsterSnoList.Add(214948); // 星塵公主
            _monsterSnoList.Add(201679); // 夢夢瑞薾媞
            _monsterSnoList.Add(209506); // 夜光閃閃
            _monsterSnoList.Add(218802); // 莫琳索莉
            _monsterSnoList.Add(218806); // 地獄小姐
            _monsterSnoList.Add(218807); // 奇麗兒
            _monsterSnoList.Add(218808); // 拉萊耶
            _monsterSnoList.Add(218804); // 奶油泡芙
            _monsterSnoList.Add(373833); // 超厲害閃亮亮蛋糕

            //幻化物品或装饰品掉落者
            _monsterSnoList.Add(225114); // Jay Wilson 墓园彩蛋，开发者地狱BOSS，掉落五年之剑
            _monsterSnoList.Add(316439); // Josh Mosqueira 小秘境随机出现的开发组墓地，掉落第二把五年之剑
            _monsterSnoList.Add(444994); // The Succulent 肥汁 A5 灰洞岛-潮汐洞穴一层 掉落 甲壳颅盔 
            _monsterSnoList.Add(450997); // Regreb the Slayer A2 烈风之地 屠戮者雷格雷布 掉落 造王者
            _monsterSnoList.Add(450999); // Princess Lilian  彩虹哥布林开的门 奇想郡 莉莉安公主 掉落 宇宙之翼
            _monsterSnoList.Add(451002); // Sir William 奇想郡 威廉爵士 掉落 彩虹头像框
            _monsterSnoList.Add(451004); // Graw the Herald 烈风之地-失落的车队 魔使葛洛 掉落吸魂器
            _monsterSnoList.Add(451011); // Nevaz 内瓦兹 A1 苦痛大厅三层 掉落 魁黑刚的意志
            _monsterSnoList.Add(451121); // Ravi Lilywhite 拉维·百合 掉落宠物 丽芙摩尔
            _monsterSnoList.Add(450993); // Menagerist Goblin 园长哥布林 野外刷新 掉落 宠物

            _monsterSnoList.Add(217744); // Nine Toads 九蟾恶尸 A2凄凉沙漠 掉落 飞剪
            _monsterSnoList.Add(156738); // Moontooth Dreadshark A2卡尔蒂姆下水道 月牙恐鲨 掉落 鱼人坠匣
            _monsterSnoList.Add(178619); // Urzel Mordreg A1 乌泽尔·莫德雷格 掉落 碎裂船桨

            _actorSnoList.Add(225782); // Bishibosh's Remains 毕希波什的尸骸 掉落 怀特原来的腿
            _actorSnoList.Add(173325); // Anvil of Fury 铁砧 掉落格里斯沃尔德的破损之锋
            _actorSnoList.Add(113845); // Fallen Shrine A1 沉没的神庙（沉沒神殿，内部偏左） 掉落 盛宰之怒


            _actorSnoList.Add(451035); // Mysterious Chest 神秘的箱子 A1 大教堂二层 掉落 圣殿骑士之链    
            _actorSnoList.Add(451028); // Mysterious Chest 神秘的箱子 A3 亚瑞特巨坑一层（亞瑞特巨坑第一層） 掉落 史迪冯的重枪
            _actorSnoList.Add(451030); // Mysterious Chest 神秘的箱子 A4希望花园一层 掉落鹰隼之翼
            _actorSnoList.Add(451047); // Mysterious Chest 神秘的箱子 A4希望花园二层 掉落 食尸鬼王之刃
            _actorSnoList.Add(451029); // Mysterious Chest 神秘的箱子 A3 永恒森林（永恆之林，A3 赛斯雪隆废墟传送平台右侧） 掉落 豹爪
            _actorSnoList.Add(451038); // Mysterious Chest 神秘的箱子 A3 赛斯雪隆废墟-不朽王座 （仅能在3月份最后一周获得，需完成卡奈的红门奶牛关任务）掉落 卡奈的斯科恩
            _actorSnoList.Add(451034); // Mysterious Chest 
            _actorSnoList.Add(451033); // Mysterious Chest 神秘的箱子 A5 鲜血沼泽 科乌斯之弩
            _actorSnoList.Add(451027); // Mysterious Chest 神秘的箱子 A5 萨卡兰姆大教堂 掉落 弑神者
            _actorSnoList.Add(451039); // Mysterious Barrel 神秘的木桶 A3 战场-营房二层 掉落 乌鸦之锤 
            _actorSnoList.Add(211861); // Pinata 奇想郡 Q版大菠萝挂件 掉落赫拉蒂姆汉堡
            _actorSnoList.Add(457175); // Pinata_goblin 彩虹哥布林开的门 奇想郡 Q版大菠萝挂件 掉落赫拉蒂姆汉堡

            _actorSnoList.Add(457828); // Wirt's Stash 怀特的箱子

            //_actorSnoList.Add(6131); //trOut_Griswold_Sign	格里斯沃尔德的精良武器 

            //幻化物品
            _itemSnoList_Cosmetic.Add(1345846543);//艾丹的复仇
            _itemSnoList_Cosmetic.Add(1345846544);//造王者
            _itemSnoList_Cosmetic.Add(1345846545);//卡奈的斯科恩
            _itemSnoList_Cosmetic.Add(1345846546);//盛宰之怒
            _itemSnoList_Cosmetic.Add(868864647);//绝望之手
            _itemSnoList_Cosmetic.Add(868864648);//豹爪
            _itemSnoList_Cosmetic.Add(2393753657);//魁黑刚的意志
            _itemSnoList_Cosmetic.Add(2393753658);//屠戮连枷
            _itemSnoList_Cosmetic.Add(2393753659);//萨卡兰姆之魂
            _itemSnoList_Cosmetic.Add(2393753660);//圣殿骑士之链
            _itemSnoList_Cosmetic.Add(2379311681);//星际战盔
            _itemSnoList_Cosmetic.Add(2379311682);//甲壳颅盔
            _itemSnoList_Cosmetic.Add(1268253959);//乌鸦之锤
            _itemSnoList_Cosmetic.Add(2876618433);//串肉叉
            _itemSnoList_Cosmetic.Add(3601985652);//星际肩铠
            _itemSnoList_Cosmetic.Add(173517644);//史迪冯的重枪
            _itemSnoList_Cosmetic.Add(1460786533);//夺魂者之吻
            _itemSnoList_Cosmetic.Add(2089009824);//弑神者
            _itemSnoList_Cosmetic.Add(2089009825);//琥珀之翼
            _itemSnoList_Cosmetic.Add(2089009826);//食尸鬼王之刃
            _itemSnoList_Cosmetic.Add(2089009827);//五年之剑
            _itemSnoList_Cosmetic.Add(2089009828);//第二把五年之剑
            _itemSnoList_Cosmetic.Add(1286110481);//科乌斯之弩
            _itemSnoList_Cosmetic.Add(974107120);//神圣之盔
            _itemSnoList_Cosmetic.Add(974143057);//死神面罩
            _itemSnoList_Cosmetic.Add(595814643);//仪祭匕首
            _itemSnoList_Cosmetic.Add(2032005920);//死亡之触
            _itemSnoList_Cosmetic.Add(1226090826);//夺命环枷
            _itemSnoList_Cosmetic.Add(4250043973);//奎伊图斯
            _itemSnoList_Cosmetic.Add(4198109141);//狰狞夺魂者
            _itemSnoList_Cosmetic.Add(2360826509);//黑暗之心
            _itemSnoList_Cosmetic.Add(229247441);//噬生
            _itemSnoList_Cosmetic.Add(3655641016);//禁地之争
            _itemSnoList_Cosmetic.Add(1821181577);//泰坦之心
            _itemSnoList_Cosmetic.Add(204261921);//凶险飞升之握
            _itemSnoList_Cosmetic.Add(1571690839);//守护者之面
            _itemSnoList_Cosmetic.Add(3989208951);//封印之谷腿甲
            _itemSnoList_Cosmetic.Add(2112365407);//顽强幸存者的重负
            _itemSnoList_Cosmetic.Add(1239902833);//征服者军帽
            _itemSnoList_Cosmetic.Add(1902294393);//征服者肩铠
            _itemSnoList_Cosmetic.Add(1290781938);//征服者钢靴
            _itemSnoList_Cosmetic.Add(883162595);//征服者胸甲
            _itemSnoList_Cosmetic.Add(3359388795);//征服者护手
            _itemSnoList_Cosmetic.Add(3708589201);//征服者腿铠
            _itemSnoList_Cosmetic.Add(1142135055);//失落的兽人督军弓
            _itemSnoList_Cosmetic.Add(537275943);//碎手的拳套武器
            _itemSnoList_Cosmetic.Add(2821956861);//死眼之锤
            _itemSnoList_Cosmetic.Add(3905524508);//黑石摧毁者
            _itemSnoList_Cosmetic.Add(2028438506);//古尔丹的秘密
            _itemSnoList_Cosmetic.Add(2885600891);//影月之耐奥祖法杖
            _itemSnoList_Cosmetic.Add(4258211819);//主教的头盔
            _itemSnoList_Cosmetic.Add(2845225459);//主教的护肩
            _itemSnoList_Cosmetic.Add(1159896909);//背叛者的仪容
            _itemSnoList_Cosmetic.Add(3342927994);//拉齐达南的风暴之盾

            _itemSnoList_Cosmetic.Add(4211285172);//吸魂器
            _itemSnoList_Cosmetic.Add(1742926680);//吸魂器
            _itemSnoList_Cosmetic.Add(3321154079);//飞剪
            _itemSnoList_Cosmetic.Add(2223827351);//飞剪
            
            _itemSnoList_Cosmetic.Add(3456694308);//赫拉迪姆汉堡
            _itemSnoList_Cosmetic.Add(2401687612);//赫拉迪姆汉堡
            
            _itemSnoList_Cosmetic.Add(1311084213);//格里斯沃尔德的破损之锋
            _itemSnoList_Cosmetic.Add(316031213);//格里斯沃尔德的破损之锋
            
            _itemSnoList_Cosmetic.Add(1312234197);//拉卡尼休之刃
            _itemSnoList_Cosmetic.Add(353980685);//拉卡尼休之刃
            
            _itemSnoList_Cosmetic.Add(1313456055);//虹光
            _itemSnoList_Cosmetic.Add(394301999);//虹光
            
            _itemSnoList_Cosmetic.Add(3266690394);//碎裂船桨
            _itemSnoList_Cosmetic.Add(426525746);//碎裂船桨
            
            _itemSnoList_Cosmetic.Add(2400841116);//怀特原来的腿
            _itemSnoList_Cosmetic.Add(1918270644);//怀特原来的腿
            
            _itemSnoList_Cosmetic.Add(1528346871);//鱼人坠匣
            _itemSnoList_Cosmetic.Add(3190731631);//鱼人坠匣
            
            _itemSnoList_Cosmetic.Add(1918956665);//急速君王剑
            _itemSnoList_Cosmetic.Add(863594611);//巨鲸之神圣铠甲
            _itemSnoList_Cosmetic.Add(2334824326);//大天使的天启之杖
            _itemSnoList_Cosmetic.Add(2627338352);//屠夫的剁肉刀
            _itemSnoList_Cosmetic.Add(2709069634);//格里斯沃尔德的锐利
            _itemSnoList_Cosmetic.Add(863594612);//阿凯尼的荣耀
            _itemSnoList_Cosmetic.Add(8361880);//谐角之冠
            _itemSnoList_Cosmetic.Add(8361881);//不死王冠
            _itemSnoList_Cosmetic.Add(8361882);//钢铁面纱
            _itemSnoList_Cosmetic.Add(3130714842);//明眼护符
            _itemSnoList_Cosmetic.Add(1933089186);//碧空之戒
            _itemSnoList_Cosmetic.Add(1933089187);//实相之戒
            _itemSnoList_Cosmetic.Add(2492975421);//怀特的腿

            //牧牛杖材料
            _itemSnoList_StaffofHerding.Add(2301417192);//黑蘑菇
            _itemSnoList_StaffofHerding.Add(3665447244);//李奥瑞克的胫骨
            _itemSnoList_StaffofHerding.Add(3494992897);//饶舌宝石
            _itemSnoList_StaffofHerding.Add(725082635);//彩虹魔药
            _itemSnoList_StaffofHerding.Add(3495098760);//怀特的铃铛
            _itemSnoList_StaffofHerding.Add(2831772274);//图纸：牧牛杖
            _itemSnoList_StaffofHerding.Add(1806898802);//图纸：牧牛杖

            //掉落牧牛杖材料处
            _actorSnoList_StaffofHerding.Add(172948);//黑蘑菇
            _actorSnoList_StaffofHerding.Add(213905);//烧焦的原木 李奥瑞克的胫骨
            _actorSnoList_StaffofHerding.Add(207706);//彩虹魔药的神秘的箱子

            //掉落牧牛杖材料的怪
            _monsterSnoList_StaffofHerding.Add(212750);//琪塔拉
            _monsterSnoList_StaffofHerding.Add(148449);//衣卒尔
            


        }

        private bool IsCosmetic(IItem item)
        {
            return item.SnoItem.HasGroupCode("cosmetic") || item.SnoItem.HasGroupCode("cosmetic_pet") || item.SnoItem.HasGroupCode("cosmetic_portrait_frame") || item.SnoItem.HasGroupCode("cosmetic_wing") || item.SnoItem.HasGroupCode("cosmetic_pennant");
        }

        public void PaintWorld(WorldLayer layer)
        {
            var actors = Hud.Game.Actors.Where(actor => actor.DisplayOnOverlay && (_actorSnoList.Contains(actor.SnoActor.Sno) || _actorSnoList_StaffofHerding.Contains(actor.SnoActor.Sno)));
            foreach (var actor in actors)
            {
                if(_actorSnoList.Contains(actor.SnoActor.Sno))
                {
                    Decorator.Paint(layer, actor, actor.FloorCoordinate, DisplayTextOnActors + "：" + actor.SnoActor.NameLocalized);
                    if (EnableSpeak && (actor.LastSpeak == null) && Hud.Sound.LastSpeak.TimerTest(2000))
                    {
                        Hud.Sound.Speak(DisplayTextOnActors + "：" + actor.SnoActor.NameLocalized);
                        actor.LastSpeak = Hud.Time.CreateAndStartWatch();
                    }
                    continue;
                }
                if (_actorSnoList_StaffofHerding.Contains(actor.SnoActor.Sno))
                {
                    Decorator.Paint(layer, actor, actor.FloorCoordinate, DisplayTextOnActors_StaffofHerding + "：" + actor.SnoActor.NameLocalized);
                    if (EnableSpeak && (actor.LastSpeak == null) && Hud.Sound.LastSpeak.TimerTest(2000))
                    {
                        Hud.Sound.Speak(DisplayTextOnActors_StaffofHerding + "：" + actor.SnoActor.NameLocalized);
                        actor.LastSpeak = Hud.Time.CreateAndStartWatch();
                    }
                    continue;
                }
            }

            var monsters = Hud.Game.AliveMonsters.Where(monster => (_monsterSnoList.Contains(monster.SnoActor.Sno) || _monsterSnoList_StaffofHerding.Contains(monster.SnoActor.Sno)));
            foreach (var monster in monsters)
            {
                if(_monsterSnoList.Contains(monster.SnoActor.Sno))
                {
                    Decorator.Paint(layer, monster, monster.FloorCoordinate, DisplayTextOnMonsters + "：" + monster.SnoMonster.NameLocalized);
                    if (EnableSpeak && (monster.LastSpeak == null) && Hud.Sound.LastSpeak.TimerTest(2000))
                    {
                        Hud.Sound.Speak(DisplayTextOnMonsters + "：" + monster.SnoMonster.NameLocalized);
                        monster.LastSpeak = Hud.Time.CreateAndStartWatch();
                    }
                    continue;
                }
                if (_monsterSnoList_StaffofHerding.Contains(monster.SnoActor.Sno))
                {
                    Decorator.Paint(layer, monster, monster.FloorCoordinate, DisplayTextOnMonsters_StaffofHerding + "：" + monster.SnoMonster.NameLocalized);
                    if (EnableSpeak && (monster.LastSpeak == null) && Hud.Sound.LastSpeak.TimerTest(2000))
                    {
                        Hud.Sound.Speak(DisplayTextOnMonsters_StaffofHerding + "：" + monster.SnoMonster.NameLocalized);
                        monster.LastSpeak = Hud.Time.CreateAndStartWatch();
                    }
                    continue;
                }

            }
            var items = Hud.Game.Items.Where(item => item.Location == ItemLocation.Floor && (IsCosmetic(item) || _itemSnoList_Cosmetic.Contains(item.SnoItem.Sno) || _itemSnoList_StaffofHerding.Contains(item.SnoItem.Sno)));
            foreach (var item in items)
            {
                if(IsCosmetic(item))
                {
                    Decorator.Paint(layer, item, item.FloorCoordinate, DisplayTextOnItems + "：" + item.SnoItem.NameLocalized);
                    if (EnableSpeak && (item.LastSpeak == null) && Hud.Sound.LastSpeak.TimerTest(2000))
                    {
                        Hud.Sound.Speak(DisplayTextOnItems + "：" + item.SnoItem.NameLocalized);
                        item.LastSpeak = Hud.Time.CreateAndStartWatch();
                    }
                    continue;
                }
                if (_itemSnoList_Cosmetic.Contains(item.SnoItem.Sno))
                {
                    Decorator.Paint(layer, item, item.FloorCoordinate, DisplayTextOnItems_Cosmetic + "：" + item.SnoItem.NameLocalized);
                    if (EnableSpeak && (item.LastSpeak == null) && Hud.Sound.LastSpeak.TimerTest(2000))
                    {
                        Hud.Sound.Speak(DisplayTextOnItems_Cosmetic + "：" + item.SnoItem.NameLocalized);
                        item.LastSpeak = Hud.Time.CreateAndStartWatch();
                    }
                    continue;
                }
                if (_itemSnoList_StaffofHerding.Contains(item.SnoItem.Sno))
                {
                    Decorator.Paint(layer, item, item.FloorCoordinate, DisplayTextOnItems_StaffofHerding + "：" + item.SnoItem.NameLocalized);
                    if (EnableSpeak && (item.LastSpeak == null) && Hud.Sound.LastSpeak.TimerTest(2000))
                    {
                        Hud.Sound.Speak(DisplayTextOnItems_StaffofHerding + "：" + item.SnoItem.NameLocalized);
                        item.LastSpeak = Hud.Time.CreateAndStartWatch();
                    }
                    continue;
                }
            }
        }
    }

}