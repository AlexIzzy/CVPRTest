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
        private AVPlayer _avPlayer;

        public void Play(string url)
        {
                _avPlayer = new AVPlayer(new NSUrl(url));
                _avPlayer.Play();
        }
        public void Stop(bool val)
        {
            _avPlayer?.Dispose();
        }
    }
}
