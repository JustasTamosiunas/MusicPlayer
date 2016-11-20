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
    }
}
