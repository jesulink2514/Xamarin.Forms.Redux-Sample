using DemoRedux.Todo.States;
using Redux;

namespace DemoRedux.Todo.Actions
{
    public class LoadTodosSuccessAction: IAction
    {
        public TodoItem[] Todos { get;}
        public LoadTodosSuccessAction(TodoItem[] todos)
        {
            Todos = todos;
        }
    }
}
