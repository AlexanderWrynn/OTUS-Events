using System.Windows.Input;

namespace OTUS_Events
{
    class MainViewModel : ViewModel
    {
        public MainViewModel()
        {
            imageDownloader = new ImageDownloader();
        }

        public ICommand AddDownloadCommand { get { return new Command(DownloadCommand); } }
        public ICommand AddDownloadStatusCommand { get { return new Command(DownloadStatus); } }

        public ImageDownloader imageDownloader { get; private set; }
        public string StartMessage { get; set; }
        public string FinishMessage { get; set; }
        public string StatusMessage { get; set; }

        private async void DownloadCommand()
        {
            StartMessage = "Скачивание файла началось";
            RaisePropertyChanged(() => StartMessage);

            await imageDownloader.Download("https://effigis.com/wp-content/uploads/2015/02/Iunctus_SPOT5_5m_8bit_RGB_DRA_torngat_mountains_national_park_8bits_1.jpg", "bigimage.jpg");

            FinishMessage = "Скачивание файла закончилось";
            RaisePropertyChanged(() => FinishMessage);
        }

        private void DownloadStatus()
        {
            if (FinishMessage == "Скачивание файла закончилось")
            {
                StatusMessage = "true";
                RaisePropertyChanged(() => StatusMessage);
            }

            else
            {
                StatusMessage = "false";
                RaisePropertyChanged(() => StatusMessage);
            }
        }

    }
}
