using System;
using Xamarin.Forms;
using CVPRTest.Droid;
using Android.Media;
using CVPRTest.Helpers;

[assembly: Dependency(typeof(AudioService))]

namespace CVPRTest.Droid
{
    public class AudioService : IAudio
    {
        MediaPlayer _player;

        public void Play(string url)
        {
                _player = new MediaPlayer();
                _player.SetDataSource(url);
                _player.SetAudioStreamType(Stream.Music);
                _player.PrepareAsync();
                _player.Start(); 
        }

        public void Stop(bool val)
        {
            _player.Stop();
        }
    }
}