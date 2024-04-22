using CameraViewer.Config.SystemConfig;
using CameraViewer.Config.RecipeConfig;
using BaslerVision;
using CameraViewer.Utile.Define;
using ImageWatch;
using ImageProcessor;

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

        ConfigFileManager _configManager;
        public ConfigFileManager ConfigManager
        {
            get { return _configManager; }
        }

        RecipeFileManager _recipeManager;
        public RecipeFileManager RecipeManager
        {
            get { return _recipeManager; }
        }

        ImageProcessor.ImageProcessor _imageProcessor;

        void InitIntegratedClass()
        {
            _hardWareState = new HardWareState();
            _mainSystem = App.MainSystem;

            CreateImageProcessor();

            CreateSystemConfigData();

            CreateRecipeDate();

            CreateImageWatch();

            CreateBaslerCamera();
        }

        public void CloseIntegratedClass()
        {
            _baslerCamera.CloseCamera();
            _imageProcessor.DisposeImageProcessor();

            foreach (var imageWatch in _imageWatch) 
            {
                imageWatch.Close();
            }
        }

        void CreateImageProcessor() 
        {
            _imageProcessor = new ImageProcessor.ImageProcessor(CommonDefine.ImageSizeWidth, CommonDefine.ImageSizeHeiget, 1, CBInspDone);
        }

        void CreateSystemConfigData() 
        {
            _configManager = new ConfigFileManager();

            if(_configManager != null)
                _configManager.LoadFile();
        }

        void CreateRecipeDate() 
        {
            _recipeManager = new RecipeFileManager();

            if (_recipeManager != null)
                _recipeManager.LoadFile();
        }

        void CreateImageWatch() 
        {
            _imageWatch = new ImageWatchAPI[(int)CommonDefine.Views.ViewsCount];

            for (int i = 0; i < _imageWatch.Length; ++i)
                _imageWatch[i] = new ImageWatchAPI();

            _imageWatch[(int)CommonDefine.Views.eMainViews].InitImageView(CommonDefine.ImageSizeWidth, CommonDefine.ImageSizeHeiget, true, true, true);

            _imageWatch[(int)CommonDefine.Views.eRecipeViews].InitImageView(CommonDefine.ImageSizeWidth, CommonDefine.ImageSizeHeiget,true, true, true);
            _imageWatch[(int)CommonDefine.Views.eRecipeViews].MouseRightButtomEvent(_mainSystem.RightMouseButtomClickEvent);

            _imageWatch[(int)CommonDefine.Views.eResipeSubViews].InitImageView(CommonDefine.ImageSizeWidth, CommonDefine.ImageSizeHeiget, true, true, true);
            
        }

        void CreateBaslerCamera() 
        {
            _baslerCamera = new BaslerCamera(OnImageGrabbed);

            int ExposureTime = _configManager.SystemData.ExposureTime;
            int TimeOut = _configManager.SystemData.TimeOut;

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

        public void CBInspDone() 
        {
            //검사 완료 시그널.
        }
    }
}
