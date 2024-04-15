using System.Windows.Controls;


namespace CameraViewer.UI.SetUpPage.CameraSetUp
{
    /// <summary>
    /// CameraSetting.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CameraSetUp : UserControl
    {
        CameraSetUpViewModel _cameraSetUpViewModel;
        public CameraSetUp()
        {
            _cameraSetUpViewModel = new CameraSetUpViewModel(App.MainSystem);
            InitializeComponent();
            DataContext = _cameraSetUpViewModel;
        }
    }
}
