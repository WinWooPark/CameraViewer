using CameraViewer.Config.RecipeConfig;
using CameraViewer.ManagementSystem;
using CameraViewer.Utile.Define;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace CameraViewer.UI.RecipePage.RecipeTeaching
{
    public class RecipeTeachingViewModel : ObservableObject
    {
        MainSystem _mainSystem;
        IntegratedClass _integrationClass;
        RecipeFileManager _recipeFileManager;

        public RecipeTeachingViewModel(MainSystem mainSystem)
        {
            _mainSystem = mainSystem;

            _integrationClass = IntegratedClass.Instance;
            _recipeFileManager = _integrationClass.RecipeManager;

            CreateCommand();
        }

        public double Resolution
        {
            get { return _recipeFileManager.RecipeData.Resolution; }
            set { _recipeFileManager.RecipeData.Resolution = value; }
        }

        
        public double Threshold
        {
            get { return _recipeFileManager.RecipeData.Threshold; }
            set { _recipeFileManager.RecipeData.Threshold = value; }
        }

        
        public double LimitShiftX
        {
            get { return _recipeFileManager.RecipeData.LimitShiftX; }
            set { _recipeFileManager.RecipeData.LimitShiftX = value; }
        }

        
        public double LimitShiftY
        {
            get { return _recipeFileManager.RecipeData.LimitShiftY; }
            set { _recipeFileManager.RecipeData.LimitShiftY = value; }
        }

        
        public double LimitTheta
        {
            get { return _recipeFileManager.RecipeData.LimitTheta; }
            set { _recipeFileManager.RecipeData.LimitTheta = value; }
        }

        ICommand _showRef;
        public ICommand ShowRef 
        {
            get { return _showRef; }
            set 
            {
                if (value != _showRef) 
                {
                    _showRef = value;
                    OnPropertyChanged(nameof(ShowRef));
                }
            }
        }

        ICommand _saveRef;
        public ICommand SaveRef
        {
            get { return _saveRef; }
            set
            {
                if (value != _saveRef)
                {
                    _saveRef = value;
                    OnPropertyChanged(nameof(SaveRef));
                }
            }
        }

        ICommand _imageLoad;
        public ICommand ImageLoad
        {
            get { return _imageLoad; }
            set
            {
                if (value != _imageLoad)
                {
                    _imageLoad = value;
                    OnPropertyChanged(nameof(ImageLoad));
                }
            }
        }

        ICommand _recipeFit;
        public ICommand RecipeFit
        {
            get { return _recipeFit; }
            set
            {
                if (value != _recipeFit)
                {
                    _recipeFit = value;
                    OnPropertyChanged(nameof(RecipeFit));
                }
            }
        }
        
        ICommand _subFit;
        public ICommand SubFit 
        {
            get { return _subFit; }
            set 
            {
                if (value != _subFit)
                {
                    _subFit = value;
                    OnPropertyChanged(nameof(SubFit));
                }
            }
        }

        ICommand _saveRecipe;
        public ICommand SaveRecipe
        {
            get { return _saveRecipe; }
            set
            {
                if (value != _saveRecipe)
                {
                    _saveRecipe = value;
                    OnPropertyChanged(nameof(SaveRecipe));
                }
            }
        }

        ICommand _applyRecipe;
         public ICommand ApplyRecipe
        {
            get { return _applyRecipe; }
            set 
            {
                if (value != _applyRecipe)
                {
                    _applyRecipe = value;
                    OnPropertyChanged(nameof(ApplyRecipe));
                }
            }
        }

        void LoadRecipeImage() { _mainSystem.ViewerImageLoad(CommonDefine.Views.eRecipeViews); }
        void ShowSubImage() { _mainSystem.ShowSubImage(); }
        void FitRecipe() { _mainSystem.ViewerFit(CommonDefine.Views.eRecipeViews); }
        void FitSub() { _mainSystem.ViewerFit(CommonDefine.Views.eResipeSubViews); }
        void SaveRefImage() { _mainSystem.ViewerImageSave(CommonDefine.Views.eResipeSubViews); }

        void CreateCommand() 
        {
            ShowRef = new RelayCommand(ShowSubImage);
            SaveRef = new RelayCommand(SaveRefImage);
            ImageLoad = new RelayCommand(LoadRecipeImage);
            RecipeFit = new RelayCommand(FitRecipe);
            SubFit = new RelayCommand(FitSub);
            //SaveRecipe = new RelayCommand(SaveRefImage);
            //ApplyRecipe = new RelayCommand();
        }

    }
}
