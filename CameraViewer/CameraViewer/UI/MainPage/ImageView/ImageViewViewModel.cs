using CameraViewer.ManagementSystem;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CameraViewer.UI.MainPage.ImageView
{
    public class ImageViewViewModel : ObservableObject
    {
        MainSystem _mainSystem;
        
        public RelayCommand ImageFit { get; set; }
        public RelayCommand ImageLoad { get; set; }
        public RelayCommand ImageSave { get; set; }

        public RelayCommand CameraLive { get; set; }
        public RelayCommand CameraStop { get; set; }
        public RelayCommand CameraGrab { get; set; }


        public ImageViewViewModel(MainSystem mainSystem)
        {
            _mainSystem = mainSystem;
            _mainSystem.ImageView = this;

            CreateCommand();
        }

        void CreateCommand() 
        {
            ImageFit = new RelayCommand(_mainSystem.MainViewImageFit);
            ImageLoad = new RelayCommand(_mainSystem.MainViewImageLoad);
            ImageSave = new RelayCommand(_mainSystem.MainViewImageSave);

            CameraLive = new RelayCommand(_mainSystem.MainViewImageLive);
            CameraStop = new RelayCommand(_mainSystem.MainViewImageStop);
            CameraGrab = new RelayCommand(_mainSystem.MainViewImageGrab);

        }
    }
}
