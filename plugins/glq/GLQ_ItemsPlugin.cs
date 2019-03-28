using System.Linq;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.glq
{

    public class GLQ_ItemsPlugin : BasePlugin, IInGameWorldPainter
	{

        public WorldDecoratorCollection LegendaryDecorator { get; set; }
        public WorldDecoratorCollection AncientDecorator { get; set; }
        public WorldDecoratorCollection PrimalDecorator { get; set; }
        public WorldDecoratorCollection SetDecorator { get; set; }
        public WorldDecoratorCollection AncientSetDecorator { get; set; }
        public WorldDecoratorCollection PrimalSetDecorator { get; set; }
        public WorldDecoratorCollection UtilityDecorator { get; set; }
        public WorldDecoratorCollection NormalKeepDecorator { get; set; }
        public WorldDecoratorCollection MagicKeepDecorator { get; set; }
        public WorldDecoratorCollection RareKeepDecorator { get; set; }
        public WorldDecoratorCollection LegendaryKeepDecorator { get; set; }
        public WorldDecoratorCollection BookDecorator { get; set; }
        public WorldDecoratorCollection DeathsBreathDecorator { get; set; }
        public WorldDecoratorCollection BountyCacheDecorator { get; set; }
        public WorldDecoratorCollection AddSocketsDecorator { get; set; }
        public WorldDecoratorCollection InArmorySetDecorator { get; set; }
        private float OffsetY;
        public GLQ_ItemsPlugin()
		{
            Enabled = true;
            

        }

        public override void Load(IController hud)
        {
            base.Load(hud);
            OffsetY = - Hud.Window.Size.Height * 0.021f;
            LegendaryDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(160, 0, 0, 0, 0),
                    BorderBrush = Hud.Render.CreateBrush(0, 0, 0, 0, 0),
                    TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 235, 120, 0, true, false, false),
                    OffsetY = OffsetY,
                },
                new MapShapeDecorator(Hud)
                {
                    ShapePainter = new RotatingTriangleShapePainter(Hud),
                    Brush = Hud.Render.CreateBrush(255, 255, 160, 0, 3),
                    ShadowBrush = Hud.Render.CreateBrush(96, 0, 0, 0, 1),
                    Radius = 8,
                    RadiusTransformator = new StandardPingRadiusTransformator(Hud, 333),
                }
                );

            AncientDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(192, 255, 140, 0, -3),
                    Radius = 2.2f,
                    RadiusTransformator = new StandardPingRadiusTransformator(Hud, 500),
                },
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 255, 140, 0, 0),
                    BorderBrush = Hud.Render.CreateBrush(160, 0, 0, 0, 2),
                    TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 0, 0, 0, true, false, false),
                    OffsetY = OffsetY,
                },
                new MapShapeDecorator(Hud)
                {
                    ShapePainter = new RotatingTriangleShapePainter(Hud),
                    Brush = Hud.Render.CreateBrush(255, 255, 120, 0, 3),
                    ShadowBrush = Hud.Render.CreateBrush(96, 0, 0, 0, 1),
                    Radius = 11,
                    RadiusTransformator = new StandardPingRadiusTransformator(Hud, 333),
                }
                );

            PrimalDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(192, 255, 140, 0, -3),
                    Radius = 2.2f,
                    RadiusTransformator = new StandardPingRadiusTransformator(Hud, 500),
                },
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 255, 140, 0, 0),
                    BorderBrush = Hud.Render.CreateBrush(242, 255, 0, 0, 3),
                    TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 0, 0, 0, true, false, false),
                    OffsetY = OffsetY,
                },
                new MapShapeDecorator(Hud)
                {
                    ShapePainter = new RotatingTriangleShapePainter(Hud),
                    Brush = Hud.Render.CreateBrush(255, 255, 120, 0, 3),
                    ShadowBrush = Hud.Render.CreateBrush(96, 0, 0, 0, 1),
                    Radius = 11,
                    RadiusTransformator = new StandardPingRadiusTransformator(Hud, 333),
                }
                );

            SetDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(160, 0, 0, 0, 0),
                    BorderBrush = Hud.Render.CreateBrush(0, 0, 0, 0, 0),
                    TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 50, 220, 50, true, false, false),
                    OffsetY = OffsetY,
                },
                new MapShapeDecorator(Hud)
                {
                    ShapePainter = new RotatingTriangleShapePainter(Hud),
                    Brush = Hud.Render.CreateBrush(255, 160, 255, 0, 3),
                    ShadowBrush = Hud.Render.CreateBrush(96, 0, 0, 0, 1),
                    Radius = 8,
                    RadiusTransformator = new StandardPingRadiusTransformator(Hud, 333),
                }
                );

            AncientSetDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(192, 85, 255, 85, -3),
                    Radius = 2.2f,
                    RadiusTransformator = new StandardPingRadiusTransformator(Hud, 500),
                },
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 50, 220, 50, 0),
                    BorderBrush = Hud.Render.CreateBrush(160, 0, 0, 0, 2),
                    TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 0, 0, 0, true, false, false),
                    OffsetY = OffsetY,
                },
                new MapShapeDecorator(Hud)
                {
                    ShapePainter = new RotatingTriangleShapePainter(Hud),
                    Brush = Hud.Render.CreateBrush(255, 120, 255, 0, 3),
                    ShadowBrush = Hud.Render.CreateBrush(96, 0, 0, 0, 1),
                    Radius = 11,
                    RadiusTransformator = new StandardPingRadiusTransformator(Hud, 333),
                }
                );

            PrimalSetDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(192, 85, 255, 85, -3),
                    Radius = 2.2f,
                    RadiusTransformator = new StandardPingRadiusTransformator(Hud, 500),
                },
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 50, 220, 50, 0),
                    BorderBrush = Hud.Render.CreateBrush(242, 255, 0, 0, 3),
                    TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 0, 0, 0, true, false, false),
                    OffsetY= OffsetY,
                },
                new MapShapeDecorator(Hud)
                {
                    ShapePainter = new RotatingTriangleShapePainter(Hud),
                    Brush = Hud.Render.CreateBrush(255, 120, 255, 0, 3),
                    ShadowBrush = Hud.Render.CreateBrush(96, 0, 0, 0, 1),
                    Radius = 11,
                    RadiusTransformator = new StandardPingRadiusTransformator(Hud, 333),
        }
                );

            UtilityDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(192, 255, 160, 0, -3),
                    Radius = 1.5f,
                },
                new MapShapeDecorator(Hud)
                {
                    ShapePainter = new RotatingTriangleShapePainter(Hud),
                    Brush = Hud.Render.CreateBrush(255, 255, 160, 0, 3),
                    ShadowBrush = Hud.Render.CreateBrush(96, 0, 0, 0, 1),
                    Radius = 8,
                    RadiusTransformator = new StandardPingRadiusTransformator(Hud, 333),
                }
                );

            NormalKeepDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(192, 200, 200, 200, -2),
                    Radius = 1.25f,
                }
                );
            // disabled by default
            NormalKeepDecorator.Enabled = false;

            MagicKeepDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(192, 60, 60, 255, -2),
                    Radius = 1.25f,
                }
                );
            // disabled by default
            MagicKeepDecorator.Enabled = false;

            RareKeepDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(192, 255, 255, 0, -2),
                    Radius = 1.25f,
                    RadiusTransformator = new StandardPingRadiusTransformator(Hud, 333),
                },
                new MapShapeDecorator(Hud)
                {
                    ShapePainter = new CircleShapePainter(Hud),
                    Brush = Hud.Render.CreateBrush(255, 255, 255, 0, 0),
                    ShadowBrush = Hud.Render.CreateBrush(96, 0, 0, 0, 1),
                    Radius = 6,
                    RadiusTransformator = new StandardPingRadiusTransformator(Hud, 333),
                }
                );
            // disabled by default
            RareKeepDecorator.Enabled = false;

            LegendaryKeepDecorator = new WorldDecoratorCollection(

                new MapShapeDecorator(Hud)
                {
                    ShapePainter = new CircleShapePainter(Hud),
                    Brush = Hud.Render.CreateBrush(255, 255, 160, 0, 0),
                    ShadowBrush = Hud.Render.CreateBrush(96, 0, 0, 0, 1),
                    Radius = 6,
                    RadiusTransformator = new StandardPingRadiusTransformator(Hud, 333),
                }
                );

            BookDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 0, 255, 0, -2),
                    Radius = 1.0f,
                }
                );

            DeathsBreathDecorator = new WorldDecoratorCollection(
                new MapTextureDecorator(Hud)
                {
                    SnoItem = Hud.Inventory.GetSnoItem(2087837753),
                    Radius = 0.3f,
                    RadiusTransformator = new StandardPingRadiusTransformator(Hud, 500)
                    {
                         RadiusMinimumMultiplier = 0.8f,
                    },
                }
                );

            BountyCacheDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 255, 255, 0, 0),
                    TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 0, 0, 0, true, false, false)
                },
                new MapTextureDecorator(Hud)
                {
                    SnoItem = Hud.Inventory.GetSnoItem(1749838250),
                    Radius = 0.3f,
                    RadiusTransformator = new StandardPingRadiusTransformator(Hud, 250)
                    {
                        RadiusMinimumMultiplier = 0.8f,
                    },
                }
                );
            AddSocketsDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(160, 0, 0, 0, 0),
                    BorderBrush = Hud.Render.CreateBrush(255, 0, 128, 128, 2),
                    TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 235, 120, 0, true, false, false)
                },
                new MapTextureDecorator(Hud)
                {
                    SnoItem = Hud.Inventory.GetSnoItem(1844495708),
                    Radius = 0.3f,
                    RadiusTransformator = new StandardPingRadiusTransformator(Hud, 250)
                    {
                        RadiusMinimumMultiplier = 0.8f,
                    },
                }
                );


            InArmorySetDecorator = new WorldDecoratorCollection(
                new GroundShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(192, 255, 64, 64, -3),
                    ShadowBrush = Hud.Render.CreateBrush(96, 0, 0, 0, 1),
                    ShapePainter = WorldStarShapePainter.NewCross(Hud),
                    Radius = 4.5f,
                    RadiusTransformator = new StandardPingRadiusTransformator(Hud, 400, 0.8f, 1.0f),
                    RotationTransformator = new CircularRotationTransformator(Hud, 30),
                },
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(192, 255, 64, 64, -3),
                    Radius = 4.5f,
                    RadiusTransformator = new StandardPingRadiusTransformator(Hud, 200, 0.8f, 1.0f),
                },
                new MapShapeDecorator(Hud)
                {
                    ShapePainter = new CircleShapePainter(Hud),
                    Brush = Hud.Render.CreateBrush(255, 255, 64, 64, -1),
                    ShadowBrush = Hud.Render.CreateBrush(96, 0, 0, 0, 1),
                    Radius = 14,
                    RadiusTransformator = new StandardPingRadiusTransformator(Hud, 200, 0.8f, 1.0f),
                },
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 255, 0, 0, 0),
                    BorderBrush = Hud.Render.CreateBrush(255, 0, 0, 0, -1),
                    TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 255, 255, 255, true, false, false)
                }
                );
        }
		
        private string GetItemName(IItem item)
        {
            var name = item.FullNameLocalized;
            if (item.AncientRank >=1)
            {
                name = item.FullNameLocalized;
            }
            if (item.KeepDecision == ItemKeepDecision.LooksGood)
            {
                name += "[!]";
            }
            return name;
        }
		public void PaintWorld(WorldLayer layer)
		{
			var items = Hud.Game.Items.Where(item => item.Location == ItemLocation.Floor);
            foreach (var item in items)
			{
                var inSet = Hud.Game.Me.ArmorySets.Any(set => set.ContainsItem(item));
                if (inSet)
                {
                    InArmorySetDecorator.Paint(layer, item, item.FloorCoordinate, Hud.Game.Me.ArmorySets.First(set => set.ContainsItem(item)).Name);
                    continue;
                }

                var legendaryDisplayed = false;
                if (item.IsLegendary && item.Unidentified && (item.SnoItem.Kind != ItemKind.craft))
                {
                    legendaryDisplayed = true;
                    if (item.SetSno != uint.MaxValue)
                    {
                        switch (item.AncientRank)
                        {
                            case 1:
                                AncientSetDecorator.Paint(layer, item, item.FloorCoordinate, GetItemName(item));
                                break;
                            case 2:
                                PrimalSetDecorator.Paint(layer, item, item.FloorCoordinate, GetItemName(item));
                                break;
                            default:
                                SetDecorator.Paint(layer, item, item.FloorCoordinate, GetItemName(item));
                                break;
                        }
                    }
                    else
                    {
                        switch (item.AncientRank)
                        {
                            case 1:
                                AncientDecorator.Paint(layer, item, item.FloorCoordinate, GetItemName(item));
                                break;
                            case 2:
                                PrimalDecorator.Paint(layer, item, item.FloorCoordinate, GetItemName(item));
                                break;
                            default:
                                LegendaryDecorator.Paint(layer, item, item.FloorCoordinate, GetItemName(item));
                                break;
                        }
                    }
                }

                if (item.SnoItem.HasGroupCode("uber") || item.SnoItem.HasGroupCode("riftkeystone"))
                {
                    UtilityDecorator.Paint(layer, item, item.FloorCoordinate, GetItemName(item));
                }

                if (item.SnoItem.Sno == 2087837753)
                {
                    DeathsBreathDecorator.Paint(layer, item, item.FloorCoordinate, GetItemName(item));
                    continue;
                }
                if (item.SnoActor.Sno == ActorSnoEnum._greaterhoradriccache)
                {
                    BountyCacheDecorator.Paint(layer, item, item.FloorCoordinate, GetItemName(item));
                    continue;
                }
                if (item.SnoItem.Sno == 1844495708)
                {
                    AddSocketsDecorator.Paint(layer, item, item.FloorCoordinate, GetItemName(item));
                    continue;
                }
                if (item.IsNormal && (item.KeepDecision == ItemKeepDecision.LooksGood))
                {
                    NormalKeepDecorator.Paint(layer, item, item.FloorCoordinate, GetItemName(item));
                }
                else if (item.IsMagic && (item.KeepDecision == ItemKeepDecision.LooksGood))
                {
                    MagicKeepDecorator.Paint(layer, item, item.FloorCoordinate, GetItemName(item));
                }
                else if (item.IsRare && (item.KeepDecision == ItemKeepDecision.LooksGood))
                {
                    RareKeepDecorator.Paint(layer, item, item.FloorCoordinate, GetItemName(item));
                }
                else if (item.IsLegendary && (item.KeepDecision == ItemKeepDecision.LooksGood) && !legendaryDisplayed)
                {
                    LegendaryKeepDecorator.Paint(layer, item, item.FloorCoordinate, GetItemName(item));
                }

                if (!Hud.Game.IsInTown)
                {
                    if (item.SnoItem.Kind == ItemKind.book)
                    {
                        BookDecorator.Paint(layer, item, item.FloorCoordinate, GetItemName(item));
                    }
                }
			}
		}

    }

}