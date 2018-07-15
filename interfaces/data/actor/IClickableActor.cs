namespace Turbo.Plugins
{
    public interface IClickableActor: IActor
    {
        IWatch FirstClicked { get; }
        IWatch LastClicked { get; }

        bool Disabled { get; set; }
        bool Operated { get; set; }
        bool? ShouldBeClicked { get; set; }

        void RegisterClick();
    }
}