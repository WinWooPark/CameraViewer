using CameraViewer.ManagementSystem;
using CameraViewer.Utile.Define;
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

            ImageWatchAPI API = IntegratedClass.Instance.ImageWatch[(int)CommonDefine.Views.eMainViews];

            MaingImageView.Children.Add(API.ImageWatch);
        }
    }
}
