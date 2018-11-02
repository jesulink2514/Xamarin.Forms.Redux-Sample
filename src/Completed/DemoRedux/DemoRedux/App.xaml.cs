using DemoRedux.Todo.Reducers;
using DemoRedux.Todo.States;
using Redux;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DemoRedux
{
    public partial class App : Application
    {
        public static Store<TodoState> TodosStore { get; private set; }

        public App()
        {
            InitializeComponent();

            TodosStore = new Store<TodoState>(TodoReducer.Execute, TodoState.InitialState);

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
