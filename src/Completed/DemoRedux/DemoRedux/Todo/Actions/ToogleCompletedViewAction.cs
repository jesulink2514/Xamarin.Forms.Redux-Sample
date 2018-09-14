using Redux;

namespace DemoRedux.Todo.Actions
{
    public class ToogleCompletedViewAction : IAction { }
    public class CompleteTodoAction: IAction
    {
        public CompleteTodoAction(int todoId)
        {
            Id = todoId;
        }
        public int Id { get; }
    }
    public class NewTodoAction : IAction
    {
        public NewTodoAction(string todo)
        {
            Todo = todo;
        }

        public string Todo { get; }
    }
}
