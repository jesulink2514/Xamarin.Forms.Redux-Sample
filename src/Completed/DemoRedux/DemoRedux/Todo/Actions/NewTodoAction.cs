using Redux;

namespace DemoRedux.Todo.Actions
{
    public class NewTodoAction : IAction
    {
        public NewTodoAction(string todo)
        {
            Todo = todo;
        }

        public string Todo { get; }
    }
}
