
using System.Windows.Controls;


namespace CameraViewer.UI.SetUpPage
{
    /// <summary>
    /// SetUpPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SetUpPage : UserControl
    {
        SetUpPageViewModel _setUpPageViewModel;

        public SetUpPage()
        {
            //_setUpPageViewModel = new SetUpPageViewModel();
            InitializeComponent();
            //DataContext = _setUpPageViewModel;
        }
    }
}
