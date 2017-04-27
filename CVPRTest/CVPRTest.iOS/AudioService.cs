using System;
using AVFoundation;
using CVPRTest.Helpers;
using CVPRTest.iOS;
using Foundation;

using Xamarin.Forms;

[assembly: Dependency(typeof(AudioService))]
namespace CVPRTest.iOS
{
    public class AudioService : IAudio
    {
        private int _clicks = 0;
        private AVPlayer _avPlayer;

        public void Play_Pause(string url)
        {
            if (_clicks == 0)
            {
                _avPlayer = new AVPlayer();
                _avPlayer = AVPlayer.FromUrl(NSUrl.FromString(url));
                _avPlayer.Play();
                _clicks++;
            }
            else if (_clicks % 2 != 0)
            {
                _avPlayer.Pause();
                _clicks++;
            }
            else
            {
                _avPlayer.Play();
                _clicks++;
            }
        }
        public void Stop(bool val)
        {
            if (_avPlayer == null) return;
            _avPlayer.Dispose();
            _clicks = 0;
        }
    }
}
