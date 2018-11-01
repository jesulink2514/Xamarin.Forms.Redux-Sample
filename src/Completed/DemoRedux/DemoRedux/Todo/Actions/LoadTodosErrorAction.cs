using Redux;

namespace DemoRedux.Todo.Actions
{
    public class LoadTodosErrorAction : IAction
    {
        public string Error { get;}
        public LoadTodosErrorAction(string error)
        {
            Error = error;
        }
    }
}
