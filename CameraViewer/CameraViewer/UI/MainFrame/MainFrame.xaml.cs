using CameraViewer.UI.SetUpPage;
using System.Windows.Controls;

namespace CameraViewer.UI.MainFrame
{
    /// <summary>
    /// MainFrame.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainFrame : UserControl
    {
        MainFrameViewModel _mainFrameViewModel;

        public MainFrame()
        {
            _mainFrameViewModel = new MainFrameViewModel(App.MainSystem);
            InitializeComponent();
            DataContext = _mainFrameViewModel;
        }
    }
}
