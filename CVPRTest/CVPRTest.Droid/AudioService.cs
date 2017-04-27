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
        int _clicks = 0;
        MediaPlayer _player;

        public void Play_Pause(string url)
        {
            if (_clicks == 0)
            {
                _player = new MediaPlayer();
                _player.SetDataSource(url);
                _player.SetAudioStreamType(Stream.Music);
                _player.PrepareAsync();
                _player.Start();
                _clicks++;
            }
            else if (_clicks % 2 != 0)
            {
                _player.Pause();
                _clicks++;

            }
            else
            {
                _player.Start();
                _clicks++;
            }
        }

        public void Stop(bool val)
        {
            _player.Stop();
            _clicks = 0;
        }
    }
}