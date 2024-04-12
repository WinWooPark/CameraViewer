using ImageWatch;
using System.Windows.Controls;


namespace CameraViewer.UI.MainPage
{
    /// <summary>
    /// MainPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainPage : UserControl
    {
        MainPageViewModel _mainPageViewModel;
        ImageWatchAPI _imageWatchAPI1;
        ImageWatchAPI _imageWatchAPI2;
        public MainPage()
        {
            _mainPageViewModel = new MainPageViewModel();
            InitializeComponent();

            DataContext = _mainPageViewModel;
        }
    }
}
