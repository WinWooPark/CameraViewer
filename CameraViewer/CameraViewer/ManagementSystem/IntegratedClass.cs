using CameraViewer.Config;
using BaslerVision;
using CameraViewer.Utile.Define;
using ImageWatch;
using System.Windows.Media.Imaging;
using ImageWatch.ManagementSystem;
using OpenCvSharp;

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

        
        ImageWatchAPI[] _imageWatch;
        public ImageWatchAPI[] ImageWatch 
        {
            get { return _imageWatch; }
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

        RecipeData _recipeData;
        public RecipeData RecipeData 
        {
            get { return _recipeData; }
            set { _recipeData = value; }
        }

        void InitIntegratedClass()
        {
            _hardWareState = new HardWareState();
            _mainSystem = App.MainSystem;
            _recipeData = new RecipeData();

            CreateConfigData();

            CreateImageWatch();

            CreateBaslerCamera();
        }

        public void CloseIntegratedClass()
        {
            _baslerCamera.CloseCamera();

            foreach (var imageWatch in _imageWatch) 
            {
                imageWatch.Close();
            }
        }

        void CreateConfigData() 
        {
            _configData = new ConfigData();

            if(_configData != null)
                _configData.LoadConfigData();
        }

        void CreateImageWatch() 
        {
            _imageWatch = new ImageWatchAPI[(int)CommonDefine.Views.ViewsCount];

            for (int i = 0; i < _imageWatch.Length; ++i)
                _imageWatch[i] = new ImageWatchAPI();

            _imageWatch[(int)CommonDefine.Views.eMainViews].InitImageView(CommonDefine.ImageSizeWidth, CommonDefine.ImageSizeHeiget, true, true, true);
            //_imageWatch[(int)CommonDefine.Views.eMainViews].MouseRightButtomEvent(_mainSystem.RightMouseButtomClickEvent);

            _imageWatch[(int)CommonDefine.Views.eRecipeViews].InitImageView(CommonDefine.ImageSizeWidth, CommonDefine.ImageSizeHeiget,true, true, true);
            _imageWatch[(int)CommonDefine.Views.eRecipeViews].MouseRightButtomEvent(_mainSystem.RightMouseButtomClickEvent);

            _imageWatch[(int)CommonDefine.Views.eResipeSubViews].InitImageView(CommonDefine.ImageSizeWidth, CommonDefine.ImageSizeHeiget, true, true, true);
            
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

            ImageWatch[(int)CommonDefine.Views.eMainViews].UpdateUIImage(buffer, Width, Height, 1);

            if (_liveMode) ExecuteSoftwareTrigger();
        }
    }
}
