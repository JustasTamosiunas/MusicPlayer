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

        public void ChangeMusic(string location) {
            mediaFoundationReader = new MediaFoundationReader(location); //We insert the file into the Audio reader
            waveOutDevice.Init(mediaFoundationReader);
            waveOutDevice.Play(); //Automatically start playing upon selecting file.
        }

        public void PauseMusic() {
            waveOutDevice.Pause();
        }

        public void PlayMusic() {
            waveOutDevice.Play();
        }

        public List<Playlist> InitializePlaylists() {
            List<Playlist> temp = new List<Playlist>();
            int numPlaylists;
            using (StreamReader sr = new StreamReader("playlists.dat")) {
                numPlaylists = int.Parse(sr.ReadLine());
                for (int i = 0; i < numPlaylists; i++) {
                    Playlist tempPlaylist = new Playlist();
                    tempPlaylist.Name = sr.ReadLine();
                    tempPlaylist.Position = int.Parse(sr.ReadLine());
                    while (true) {
                        string line = sr.ReadLine();
                        if (line == "&&&")
                            break;
                        tempPlaylist.AddSong(line);
                    }
                    temp.Add(tempPlaylist);
                }
            }
            return temp;
        }

        public void SavePlaylists(List<Playlist> playlists) {
            using (StreamWriter sw = new StreamWriter("playlists.dat")) {
                sw.WriteLine(playlists.Count);
                for (int i = 0; i < playlists.Count; i++) {
                    sw.WriteLine(playlists[i].Name);
                    sw.WriteLine(playlists[i].Position);
                    for (int j = 0; j < playlists[i].SongList.Count; j++) {
                        sw.WriteLine(playlists[i].ReadSong(j));
                    }
                    sw.WriteLine("&&&");
                }
            }
        }
    }

    class Playlist
    {
        string name;
        List<string> songList = new List<string>(); //strings with all song Paths
        int position;
        public string NextSong() {
            if (!(position == songList.Count-1)) { //if it's not the last song, return the next one. If it is, loop around.
                position++; 
                return songList[position];
            } else {
                position = 0;
                return songList[position];
            }
        }

        public string Name { get; set; }

        public int Position { get; set; }

        public List<string> SongList { get; set; }

        public string ReadSong(int index) {
            return songList[index];
        }

        public void AddSong(string path) {
            songList.Add(path);
        }

        public void Save() {
            using (StreamWriter sw = new StreamWriter("playlists.dat")) {
                sw.WriteLine(name);
                sw.WriteLine(position);
                for (int i = 0; i < songList.Count; i++) {
                    sw.WriteLine(songList[i]);
                }
                sw.WriteLine("&&&");
            }
        }
    }
}
