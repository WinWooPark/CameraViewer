using CommunityToolkit.Mvvm.ComponentModel;
using CameraViewer.ManagementSystem;
using CameraViewer.Config;

namespace CameraViewer.UI.SetUpPage.CameraSetUp
{
    public class CameraSetUpViewModel : ObservableObject
    {
        MainSystem _mainSystem;
        IntegratedClass _integrationClass;
        ConfigData _configData;

        public CameraSetUpViewModel(MainSystem mainSystem)
        {
            _mainSystem = mainSystem;
            _integrationClass = IntegratedClass.Instance;
            _configData = _integrationClass.ConfigData;
        }

        public int ExposureTime 
        {
            get { return _configData.SystemData.ExposureTime; }
            set 
            {
                _configData.SystemData.ExposureTime = value; 
                OnPropertyChanged(nameof(ExposureTime));
            }
        }

        public int TimeOut
        {
            get { return _configData.SystemData.TimeOut; }
            set 
            {
                _configData.SystemData.TimeOut = value;
                OnPropertyChanged(nameof(TimeOut));
            }
        }
    }
}
