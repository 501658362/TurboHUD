using System.Media;

namespace Turbo.Plugins
{
    public interface ISoundController
    {
        bool IsSpeakEnabled { get; set; }
        IWatch LastSpeak { get; }
        void Speak(string text);
        void StopSpeak();

        bool IsIngameSoundEnabled { get; }
        int IngameMasterVolume { get; }
        int IngameEffectsVolume { get; }

        // Final volume is calculated by this: (IngameMasterVolume / 100) * (IngameEffectsVolume / 100) * HudVolumeMultiplier
        double VolumeMultiplier { get; set; } // default 1.0

        SoundPlayer LoadSoundPlayer(string fileName); // filename is relative to the \sounds folder
    }
}