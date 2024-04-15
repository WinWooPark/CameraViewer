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
            SaveConfig = new RelayCommand(IntegratedClass.Instance.ConfigData.SaveConfigData);
            ApplyConfig = new RelayCommand(IntegratedClass.Instance.ConfigData.ApplyConfigData);
        }
    }
}
