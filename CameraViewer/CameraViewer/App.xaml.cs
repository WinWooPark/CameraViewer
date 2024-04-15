using CameraViewer.ManagementSystem;
using System.Windows;

namespace CameraViewer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static MainSystem? _mainSystem = null;
        public static MainSystem MainSystem 
        {
            get { return _mainSystem; }
        }

        MainWindowViewModel _mainWindowViewModel;
        IntegratedClass _integratedClass;
        public App()
        {
            _mainSystem = new MainSystem();
            _integratedClass = IntegratedClass.Instance;
            _mainSystem.InitMainSystem();
            _mainWindowViewModel = new MainWindowViewModel(_mainSystem);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow = new MainWindow()
            {
                DataContext = _mainWindowViewModel
            };

            MainWindow.Show();
        }
    }

}
