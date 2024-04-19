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

        public RecipeTeachingViewModel(MainSystem mainSystem)
        {
            _mainSystem = mainSystem;
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
