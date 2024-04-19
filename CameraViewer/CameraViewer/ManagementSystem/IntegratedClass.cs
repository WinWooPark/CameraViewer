using CameraViewer.Config;
using BaslerVision;
using CameraViewer.Utile.Define;
using ImageWatch;
using System.Windows.Media.Imaging;
using ImageWatch.ManagementSystem;

namespace CameraViewer.ManagementSystem
{
    public class IntegratedClass
    {
        static object obj = new object();

        static IntegratedClass _instance;

        public static IntegratedClass Instance 
        {
            get 
            {
                lock (obj) 
                {
                    if (_instance == null) 
                    {
                        _instance = new IntegratedClass();
                    }

                    return _instance;
                }
            }
        }

        private IntegratedClass()
        {
            InitIntegratedClass();
        }

        MainSystem _mainSystem;
        public MainSystem MainSystem 
        {
            get { return _mainSystem; }
            set { _mainSystem = value; }
        }

        HardWareState _hardWareState;
        public HardWareState HardWareState 
        {
            get { return _hardWareState; }
        }

        ImageWatchAPI _imageWatchAPI;
        public ImageWatchAPI ImageWatchAPI 
        {
            get { return _imageWatchAPI; }
        }

        bool _liveMode = false;
        public bool liveMode 
        {
            get { return _liveMode; }
            set { _liveMode = value; }
        }
        BaslerCamera _baslerCamera;

        ConfigData _configData;
        public ConfigData ConfigData 
        {
            get { return _configData; }
        }

        void InitIntegratedClass()
        {
            _hardWareState = new HardWareState();
            _mainSystem = App.MainSystem;

            CreateConfigData();

            CreateImageWatch();

            CreateBaslerCamera();
        }

        public void CloseIntegratedClass()
        {
            _baslerCamera.CloseCamera();

            ImageWatchAPI.Close();
        }

        void CreateConfigData() 
        {
            _configData = new ConfigData();

            if(_configData != null)
                _configData.LoadConfigData();
        }

        void CreateImageWatch() 
        {
            _imageWatchAPI = new ImageWatchAPI();
            _imageWatchAPI.InitImageView(CommonDefine.ImageSizeWidth, CommonDefine.ImageSizeHeiget,true, true, true);
            _imageWatchAPI.SetRightMouseButtomEvent(_mainSystem.RightMouseButtomClickEvent);
        }

        void CreateBaslerCamera() 
        {
            _baslerCamera = new BaslerCamera(OnImageGrabbed);

            int ExposureTime = _configData.SystemData.ExposureTime;
            int TimeOut = _configData.SystemData.TimeOut;

            bool IsOpen = _baslerCamera.CameraOpen(ExposureTime, TimeOut);

            _hardWareState.IsCameraOpen = IsOpen;
        }

        public void ExecuteSoftwareTrigger() 
        {
            _baslerCamera.ExecuteSoftwareTrigger();
        }

        public void OnImageGrabbed(byte[] buffer, int Width, int Height) 
        {
            if (buffer == null || buffer.Length <= 0 || Height < 0 || Width < 0) return;

            _imageWatchAPI.UpdateUIImage(buffer, Width, Height, 1);

            if (_liveMode) ExecuteSoftwareTrigger();
        }
    }
}
