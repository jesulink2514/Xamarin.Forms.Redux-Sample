using Redux;

namespace DemoRedux.Todo.Actions
{
    public class CompleteTodoAction: IAction
    {
        public CompleteTodoAction(int todoId)
        {
            Id = todoId;
        }
        public int Id { get; }
    }
}
