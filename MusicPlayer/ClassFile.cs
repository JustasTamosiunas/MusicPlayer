using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using NAudio.Wave;

namespace MusicPlayer {
    class MusicPlayerClass 
    {
        public MusicPlayerClass() {

        }
        private IWavePlayer waveOutDevice = new WaveOut(); //We're using the NAudio library (included with the project), we create the player, and the file reader.
        private MediaFoundationReader mediaFoundationReader;
        public void changeMusic(string location) {
            mediaFoundationReader = new MediaFoundationReader(location); //We insert the file into the Audio reader
            waveOutDevice.Init(mediaFoundationReader);
            waveOutDevice.Play(); //Automatically start playing upon selecting file.
        }
        public void pauseMusic() {
            waveOutDevice.Pause();
        }
        public void playMusic() {
            waveOutDevice.Play();
        }
    }
}
