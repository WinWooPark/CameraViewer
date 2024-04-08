using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Media;

namespace CameraViewer.UI.MainFrame
{
    public class MainFrameViewModel : ObservableObject
    {
        public MainFrameViewModel()
        {
            CameraState = Brushes.Red;
            LightState = Brushes.Red;
            MotionState = Brushes.Red;

            RunMode = "Manual";
        }

        private SolidColorBrush _cameraState;
        public SolidColorBrush CameraState
        {
            get { return _cameraState; }
            set
            {
                _cameraState = value;
                OnPropertyChanged(nameof(_cameraState));
            }
        }

        private SolidColorBrush _lightState;
        public SolidColorBrush LightState
        {
            get { return _lightState; }
            set
            {
                _lightState = value;
                OnPropertyChanged(nameof(_lightState));
            }
        }

        private SolidColorBrush _motionState;
        public SolidColorBrush MotionState
        {
            get { return _motionState; }
            set
            {
                _motionState = value;
                OnPropertyChanged(nameof(_motionState));
            }
        }

        private RelayCommand _programExit;
        public RelayCommand ProgramExit 
        {
            get { return _programExit; }
            set 
            { 
                _programExit = value;
                OnPropertyChanged(nameof(_lightState));
            }
        }

        string _runMode;
        public string RunMode 
        {
            get { return _runMode; }
            set 
            {
                _runMode = value;
                OnPropertyChanged(nameof(_runMode));
            }
        }

        public void CreateCommand() 
        {
            //ProgramExit = new RelayCommand();
        }

        public void HardWareState(bool cameraState, bool lightState, bool motionState) 
        {
            if (cameraState) CameraState = Brushes.Green;
            else CameraState = Brushes.Red;

            if (lightState) LightState = Brushes.Green;
            else LightState = Brushes.Red;

            if (motionState) MotionState = Brushes.Green;
            else MotionState = Brushes.Red;
        }
    }
}
