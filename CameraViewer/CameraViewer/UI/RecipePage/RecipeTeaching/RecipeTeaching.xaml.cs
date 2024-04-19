using CameraViewer.ManagementSystem;
using CameraViewer.Utile.Define;
using ImageWatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CameraViewer.UI.RecipePage.RecipeTeaching
{
    /// <summary>
    /// RecipeTeaching.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class RecipeTeaching : UserControl
    {
        RecipeTeachingViewModel _recipeTeachingViewModel;


        public RecipeTeaching()
        {
            _recipeTeachingViewModel = new RecipeTeachingViewModel(App.MainSystem);
            InitializeComponent();
            DataContext = _recipeTeachingViewModel;

            ImageWatchAPI API = IntegratedClass.Instance.ImageWatch[(int)CommonDefine.Views.eResipeSubViews];
            RecipeSubImage.Children.Add(API.ImageWatch);
        }
    }
}
