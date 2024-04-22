using CommunityToolkit.Mvvm.ComponentModel;
using CameraViewer.ManagementSystem;
using CameraViewer.Config.SystemConfig;

namespace CameraViewer.UI.SetUpPage.CameraSetUp
{
    public class CameraSetUpViewModel : ObservableObject
    {
        MainSystem _mainSystem;
        IntegratedClass _integrationClass;
        ConfigFileManager _configManager;

        public CameraSetUpViewModel(MainSystem mainSystem)
        {
            _mainSystem = mainSystem;
            _integrationClass = IntegratedClass.Instance;
            _configManager = _integrationClass.ConfigManager;
        }

        public int ExposureTime 
        {
            get { return _configManager.SystemData.ExposureTime; }
            set 
            {
                _configManager.SystemData.ExposureTime = value; 
                OnPropertyChanged(nameof(ExposureTime));
            }
        }

        public int TimeOut
        {
            get { return _configManager.SystemData.TimeOut; }
            set 
            {
                _configManager.SystemData.TimeOut = value;
                OnPropertyChanged(nameof(TimeOut));
            }
        }
    }
}
