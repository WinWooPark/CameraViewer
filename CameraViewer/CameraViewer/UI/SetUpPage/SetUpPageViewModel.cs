using CameraViewer.ManagementSystem;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CameraViewer.UI.SetUpPage
{
    public class SetUpPageViewModel : ObservableObject
    {
        public SetUpPageViewModel()
        {
            CreateCommand();
        }

        public RelayCommand SaveConfig { get; set; }
        public RelayCommand ApplyConfig { get; set; }


        void CreateCommand() 
        {
            SaveConfig = new RelayCommand(IntegratedClass.Instance.ConfigManager.SaveFile);
            ApplyConfig = new RelayCommand(IntegratedClass.Instance.ConfigManager.ApplyConfigData);
        }
    }
}
