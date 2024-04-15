using CameraViewer.Config;
using BaslerVision;
using CameraViewer.Utile.Define;
using ImageWatch;

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

        ImageWatchAPI _imageWatchAPI;
        public ImageWatchAPI ImageWatchAPI 
        {
            get { return _imageWatchAPI; }
        }

        BaslerCamera _baslerCamera;

        ConfigData _configData;
        public ConfigData ConfigData 
        {
            get { return _configData; }
        }

        void InitIntegratedClass()
        {
            CreateConfigData();

            CreateImageWatch();

            CreateBaslerCamera();
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
            _imageWatchAPI.InitImageView(CommonDefine.ImageSizeWidth, CommonDefine.ImageSizeHeiget);
        }

        void CreateBaslerCamera() 
        {
            _baslerCamera = new BaslerCamera();

            int ExposureTime = _configData.SystemData.ExposureTime;
            int TimeOut = _configData.SystemData.TimeOut;

            bool bRet = _baslerCamera.CameraOpen(ExposureTime, TimeOut);
        }

        public void ExecuteSoftwareTrigger() 
        {
            _baslerCamera.ExecuteSoftwareTrigger();
        }

    }
}
