using System.Collections.Generic;

namespace DemoRedux.Todo.States
{
    public class TodoState
    {
        public bool ShowCompleted { get; set; }
        public bool IsLoading { get;set;}
        public List<TodoItem> Todos { get; set; } = new List<TodoItem>();

        public static TodoState InitialState => new TodoState()
        {
            IsLoading = false,
            Todos = new List<TodoItem>()
        };
    }
}
