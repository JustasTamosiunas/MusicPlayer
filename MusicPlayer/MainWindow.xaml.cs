using System.Linq;
using System.Windows;
using System.Windows.Forms;

namespace MusicPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() {
            InitializeComponent();
        }
        private MusicPlayerClass player = new MusicPlayerClass(); // Initialize the MusicPlayer object

        Playlist current;

        private void SelectButton_Click(object sender, RoutedEventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog(); //Opens the dialog to choose a file
            openFileDialog.Filter = "All files|*.*"; 
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                player.ChangeMusic(openFileDialog.FileName); //If everything is ok, we initialize the player with the chosen file.
            }
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e) {
            player.PlayMusic();
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e) {
            player.PauseMusic();
        }

        private void SelectMultipleButton_Click(object sender, RoutedEventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog(); //Opens the dialog to choose a file
            openFileDialog.Filter = "All files|*.*";
            openFileDialog.Multiselect = true;
            Playlist temp = new Playlist();
            temp.Name = "test";
            temp.Position = 0;
            temp.SongList = openFileDialog.FileNames.ToList();
            current = temp;
            player.ChangeMusic(current.ReadSong(current.Position));
        }

        private void NextSongButton_Click(object sender, RoutedEventArgs e) {
            current.NextSong();
            player.ChangeMusic(current.ReadSong(current.Position));
        }

        private void PrevSongButton_Click(object sender, RoutedEventArgs e) {
            current.PrevSong();
            player.ChangeMusic(current.ReadSong(current.Position));
        }
    }
}
