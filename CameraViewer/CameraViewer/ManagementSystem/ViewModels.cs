using CameraViewer.UI.MainFrame;
using CameraViewer.UI.MainPage;
using CameraViewer.UI.MainPage.ImageView;
using CameraViewer.UI.SetUpPage;
using CameraViewer.UI.SetUpPage.CameraSetUp;


namespace CameraViewer.ManagementSystem
{
    public class ViewModels
    {
        MainFrameViewModel _mainFrame;
        public MainFrameViewModel MainFrame
        {
            get { return _mainFrame; }
            set { _mainFrame = value; }
        }

        MainPageViewModel _mainPage;
        public MainPageViewModel MainPage 
        {
            get { return _mainPage; }
            set { _mainPage = value; }
        }

        ImageViewViewModel _imageView;
        public ImageViewViewModel ImageView 
        {
            get { return _imageView; }
            set { _imageView = value; }
        }

        SetUpPageViewModel _setUpPage;
        public SetUpPageViewModel SetUpPage
        {
            get { return SetUpPage; }
            set { SetUpPage = value; }
        }

        CameraSetUpViewModel _cameraSetUp;
        public CameraSetUpViewModel CameraSetUp
        {
            get { return _cameraSetUp; }
            set { _cameraSetUp = value; }
        }
    }
}
