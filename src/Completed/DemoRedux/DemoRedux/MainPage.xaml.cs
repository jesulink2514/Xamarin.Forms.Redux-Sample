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

            App.TodosStore.Subscribe(t =>
            {
                TodoList.ItemsSource = t.Todos
                .Where(x => t.ShowCompleted ? x.Completed : !x.Completed);

                BtnToogleCompleted.Text = t.ShowCompleted ? 
                "Show pendent tasks" : "Show completed tasks";
            });
        }

        private void Toogle_ViewCompleted(object sender, EventArgs e)
        {
            App.TodosStore.Dispatch(new ToogleCompletedViewAction());
        }

        private void NewTodo_Clicked(object sender, EventArgs e)
        {
            App.TodosStore.Dispatch(new NewTodoAction(TxtTodo.Text));
            TxtTodo.Text = string.Empty;
        }

        private void Todo_CheckedChanged(object sender, XLabs.EventArgs<bool> e)
        {
            if (!(sender is CheckBox toogle)) return;
            if (!(toogle.BindingContext is TodoItem todoItem)) return;

            App.TodosStore.Dispatch(new CompleteTodoAction(todoItem.Id));
        }
    }
}
