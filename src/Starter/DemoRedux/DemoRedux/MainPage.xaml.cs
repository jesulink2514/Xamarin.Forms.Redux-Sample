using DemoRedux.Todo.Actions;
using DemoRedux.Todo.States;
using System;
using System.Linq;
using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace DemoRedux
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Toogle_ViewCompleted(object sender, EventArgs e)
        {
        }

        private void NewTodo_Clicked(object sender, EventArgs e)
        {
        }

        private void Todo_CheckedChanged(object sender, XLabs.EventArgs<bool> e)
        {
        }
    }
}
