using CameraViewer.ManagementSystem;
using ImageWatch;
using CameraViewer.Utile.Define;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CameraViewer.UI.MainPage
{
    public class MainPageViewModel : ObservableObject
    {
        MainSystem _mainSystem;
        IntegratedClass _integratedClass;
       

        public MainPageViewModel(MainSystem mainSystem)
        {
            _mainSystem = mainSystem;
            _mainSystem.MainPage = this;

            _integratedClass = IntegratedClass.Instance;
        }
    }
}
