using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using NAudio.Wave;
using System.IO;

namespace MusicPlayer {
    class MusicPlayerClass 
    {
        public MusicPlayerClass() {}
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

    class Playlist
    {
        string name;
        List<string> songList = new List<string>(); //strings with all song Paths
        int position;
        public string nextSong() {
            if (!(position == songList.Count-1)) { //if it's not the last song, return the next one. If it is, loop around.
                position++; 
                return songList[position];
            } else {
                position = 0;
                return songList[position];
            }
        }
        public void initialize() {
            using (StreamReader sr = new StreamReader("playlists.dat")) {
                name = sr.ReadToEnd();
                position = int.Parse(sr.ReadToEnd());
                while(true) {
                    string line = sr.ReadToEnd();
                    if (line == "&&&")
                        break;
                    songList.Add(line);
                }
            }
        }
    }
}
