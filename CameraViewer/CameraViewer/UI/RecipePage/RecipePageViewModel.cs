using CameraViewer.ManagementSystem;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CameraViewer.UI.RecipePage
{
    public class RecipePageViewModel : ObservableObject
    {
        MainSystem _mainSystem;

        public RecipePageViewModel(MainSystem mainSystem)
        {
            _mainSystem = mainSystem;
        }

    }
}
