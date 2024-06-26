﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Media;
using CameraViewer.ManagementSystem;
using CameraViewer.Utile.Define;
using System.Windows;
using CameraViewer.Config.SystemConfig;
using CameraViewer.UI.RecipePage;

namespace CameraViewer.UI.MainFrame
{
    public class MainFrameViewModel : ObservableObject
    {
        MainSystem _mainSystem;
        HardWareState _hardWareState;

        public MainFrameViewModel(MainSystem mainSystem)
        {
            _mainSystem = mainSystem;
            _mainSystem.MainFrame = this;

            _hardWareState = IntegratedClass.Instance.HardWareState;

            CameraState = Brushes.Red;
            LightState = Brushes.Red;
            MotionState = Brushes.Red;

            if (_hardWareState.IsCameraOpen) CameraState = Brushes.Green;
            if (_hardWareState.IsLightOpen) LightState = Brushes.Green;
            if (_hardWareState.IsMotionOpen) MotionState = Brushes.Green;


            _mainPage = new CameraViewer.UI.MainPage.MainPage();
            _setUpPage = new CameraViewer.UI.SetUpPage.SetUpPage();
            _recipePage = new CameraViewer.UI.RecipePage.RecipePage();

            CurrentPage = _mainPage;
            _viewName = CommonDefine.SetUpViewName;
            _recipeUIContent = CommonDefine.RecipeViewName;

            CreateCommand();
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

        
        object _mainPage;
        object _setUpPage;
        object _recipePage;

        object _currentPage;
        public object CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                OnPropertyChanged(nameof(CurrentPage));   
            }
        }

        string _viewName;
        public string ViewName
        {
            get { return _viewName; }
            set 
            {
                if (value != _viewName) 
                {
                    _viewName = value;
                    OnPropertyChanged(nameof(ViewName));
                }
            }
        }



        string _recipeUIContent;
        public string RecipeUIContent
        {
            get { return _recipeUIContent; }
            set
            {
                if (value != _recipeUIContent)
                {
                    _recipeUIContent = value;
                    OnPropertyChanged(nameof(RecipeUIContent));
                }
            }
        }

        private RelayCommand _recipeUI;
        public RelayCommand RecipeUI
        {
            get { return _recipeUI; }
            set
            {
                if (_recipeUI != value)
                {
                    _recipeUI = value;
                    OnPropertyChanged(nameof(RecipeUI));
                }
            }
        }

        

        private RelayCommand _viewChageCommand;
        public RelayCommand ViewChageCommand 
        {
            get { return _viewChageCommand;  }
            set 
            {
                if (_viewChageCommand != value) 
                {
                    _viewChageCommand = value;
                    OnPropertyChanged(nameof(ViewChageCommand));
                }
            }
        }
        bool RecipeChageFlag = false;
        void RecipeChageChage()
        {
            if (RecipeChageFlag)
            {
                CurrentPage = _mainPage;
                RecipeUIContent = CommonDefine.RecipeViewName;
                RecipeChageFlag = false;
            }
            else
            {
                CurrentPage = _recipePage;
                RecipeUIContent = CommonDefine.MainViewName;
                RecipeChageFlag = true;
            }
        }

        bool viewChageFlag = false;
        void ViewChage() 
        {
            if (viewChageFlag)
            {
                CurrentPage = _mainPage;
                ViewName = CommonDefine.SetUpViewName;
                viewChageFlag = false;
            }
            else
            {
                CurrentPage = _setUpPage;
                ViewName = CommonDefine.MainViewName;
                viewChageFlag = true;
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
            ProgramExit = new RelayCommand(Close);
            ViewChageCommand = new RelayCommand(ViewChage);
            RecipeUI = new RelayCommand(RecipeChageChage);
        }

        public void HardWareCameraState(bool cameraState) 
        {
            if (cameraState) CameraState = Brushes.Green;
            else CameraState = Brushes.Red;
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

        public void Close() 
        {
            MessageBoxResult result = MessageBox.Show("프로그램을 종료하시겠습니까?", "Confirmation", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.No) return;

            App.Current.Shutdown();
        }
    }
}
