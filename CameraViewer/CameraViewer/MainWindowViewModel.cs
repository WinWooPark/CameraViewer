using CameraViewer.ManagementSystem;

namespace CameraViewer
{
    public class MainWindowViewModel
    {
        MainSystem _mainSystem;

        public MainWindowViewModel(MainSystem mainSystem)
        {
            _mainSystem = mainSystem;
        }
    }
}
