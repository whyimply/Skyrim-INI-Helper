namespace SIH
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = new Window(new MainPage()) { Title = "SIH - Skyrim INI Helper" };
#if WINDOWS
            window.MinimumWidth = 800;
            window.MinimumHeight = 600;
#endif
            return window;
        }
    }
}
