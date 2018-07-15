using System.Media;

namespace Turbo.Plugins
{
    public interface ISoundController
    {
        bool IsSpeakEnabled { get; set; }
        IWatch LastSpeak { get; }
        void Speak(string text);
        void StopSpeak();

        SoundPlayer LoadSoundPlayer(string fileName); // filename is relative to the \sounds folder
    }
}