using System.Collections.Generic;

namespace Turbo.Plugins.Default
{

    // this is not a plugin, just a helper class to display labels on the ground
    public class GroundShapeDecorator: IWorldDecoratorWithRadius
    {

        public bool Enabled { get; set; }
        public WorldLayer Layer { get; private set; }
        public IController Hud { get; set; }

        public IBrush Brush { get; set; }
        public IBrush ShadowBrush { get; set; }
        public IWorldShapePainter ShapePainter { get; set; }

        public float Radius { get; set; }
        public float Rotation { get; set; }

        public IRadiusTransformator RadiusTransformator { get; set; }
        public IRotationTransformator RotationTransformator { get; set; }

        public GroundShapeDecorator(IController hud)
        {
            Enabled = true;
            Layer = WorldLayer.Ground;
            Hud = hud;
            Radius = 1.0f;
            Rotation = 0.0f;
        }

        public void Paint(IActor actor, IWorldCoordinate coord, string text)
        {
            if (!Enabled) return;
            if (Brush == null) return;
            if (Radius <= 0) return;
            if (ShapePainter == null) return;

            var radius = RadiusTransformator != null ? RadiusTransformator.TransformRadius(Radius) : Radius;
            var rotation = RotationTransformator != null ? RotationTransformator.TransformRotation(Rotation) : Rotation;

            ShapePainter.Paint(coord.X, coord.Y, coord.Z, radius, rotation, Brush, ShadowBrush);
        }

        public IEnumerable<ITransparent> GetTransparents()
        {
            yield return Brush;
            yield return ShadowBrush;
        }

    }

}