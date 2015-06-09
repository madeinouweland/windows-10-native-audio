using System;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace AudioDemo {
    public sealed partial class MainPage : Page {
        public MainPage() {
            this.InitializeComponent();
        }

        private AudioPlayer _player = new AudioPlayer();

        protected async override void OnNavigatedTo(NavigationEventArgs e) {
            base.OnNavigatedTo(e);
            var wav = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/Audio/washburn.wav"));
            var wma = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/Audio/closure.wma"));
            var mp3 = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/Audio/oldbones.mp3"));

            await _player.LoadFileAsync(wav);
            await _player.LoadFileAsync(wma);
            await _player.LoadFileAsync(mp3);

        }

        private void ButtonWAV_Click(object sender, RoutedEventArgs e) {
            _player.Play("washburn.wav", SliderWAV.Value / 100);
        }

        private void ButtonWMA_Click(object sender, RoutedEventArgs e) {
            _player.Play("closure.wma", SliderWMA.Value / 100);
        }

        private void ButtonMP3_Click(object sender, RoutedEventArgs e) {
            _player.Play("oldbones.mp3", SliderMP3.Value / 100);
        }
    }
}
