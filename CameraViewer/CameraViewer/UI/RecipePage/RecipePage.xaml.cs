using CameraViewer.ManagementSystem;
using CameraViewer.Utile.Define;
using ImageWatch;
using System.Windows.Controls;



namespace CameraViewer.UI.RecipePage
{
    /// <summary>
    /// RecipePage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class RecipePage : UserControl
    {
        RecipePageViewModel _recipePageViewModel;
        public RecipePage()
        {
            _recipePageViewModel = new RecipePageViewModel(App.MainSystem);
            InitializeComponent();
            DataContext = _recipePageViewModel;

            ImageWatchAPI API = IntegratedClass.Instance.ImageWatch[(int)CommonDefine.Views.eRecipeViews];
            RecipeView.Children.Add(API.ImageWatch);
        }
    }
}
