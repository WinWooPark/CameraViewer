using CameraViewer.ManagementSystem;
using CameraViewer.Utile.Define;
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

        void FitImage() { _mainSystem.ViewerFit(CommonDefine.Views.eMainViews);}
        void LoadImage() { _mainSystem.ViewerImageLoad(CommonDefine.Views.eMainViews); }
        void SaveImage() { _mainSystem.ViewerImageSave(CommonDefine.Views.eMainViews); }

        void CreateCommand() 
        {
            ImageFit = new RelayCommand(FitImage);
            ImageLoad = new RelayCommand(LoadImage);
            ImageSave = new RelayCommand(SaveImage);

            CameraLive = new RelayCommand(_mainSystem.MainViewImageLive);
            CameraStop = new RelayCommand(_mainSystem.MainViewImageStop);
            CameraGrab = new RelayCommand(_mainSystem.MainViewImageGrab);
        }
    }
}
