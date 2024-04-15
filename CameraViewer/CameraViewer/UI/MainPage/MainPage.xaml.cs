using CameraViewer.ManagementSystem;
using ImageWatch;
using System.Windows.Controls;


namespace CameraViewer.UI.MainPage
{
    public partial class MainPage : UserControl
    {
        MainPageViewModel _mainPageViewModel;

        public MainPage()
        {
            _mainPageViewModel = new MainPageViewModel(App.MainSystem);
            InitializeComponent();

            DataContext = _mainPageViewModel;

            MaingImageView.Children.Add(IntegratedClass.Instance.ImageWatchAPI.ImageWatch);
        }
    }
}
