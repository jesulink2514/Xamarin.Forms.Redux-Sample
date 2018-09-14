using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DemoRedux
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
            MainPage = new MainPage();
        }
    }
}
