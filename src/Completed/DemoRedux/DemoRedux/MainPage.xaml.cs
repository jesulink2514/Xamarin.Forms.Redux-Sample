using DemoRedux.Todo.Actions;
using DemoRedux.Todo.States;
using Redux;
using System;
using System.Linq;
using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace DemoRedux
{
    public partial class MainPage : ContentPage
    {
        private readonly IStore<TodoState> _store;

        public MainPage():this(App.TodosStore)
        {
            InitializeComponent();
        }

        public MainPage(IStore<TodoState> store)
        {
            InitializeComponent();

            _store = store;

            store.Subscribe(t =>
            {
                TodoList.ItemsSource = t.Todos
                .Where(x => t.ShowCompleted ? x.Completed : !x.Completed);

                BtnToogleCompleted.Text = t.ShowCompleted ? 
                "Show pendent tasks" : "Show completed tasks";
            });
        }

        public void Toogle_ViewCompleted(object sender, EventArgs e)
        {
            _store.Dispatch(new ToogleCompletedViewAction());
        }

        public void NewTodo_Clicked(object sender, EventArgs e)
        {
            _store.Dispatch(new NewTodoAction(TxtTodo.Text));
            TxtTodo.Text = string.Empty;
        }

        public void Todo_CheckedChanged(object sender, XLabs.EventArgs<bool> e)
        {
            if (!(sender is CheckBox toogle)) return;
            if (!(toogle.BindingContext is TodoItem todoItem)) return;

            _store.Dispatch(new CompleteTodoAction(todoItem.Id));
        }
    }
}
