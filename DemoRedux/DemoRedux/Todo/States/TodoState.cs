using System.Collections.Generic;

namespace DemoRedux.Todo.States
{
    public class TodoState
    {
        public bool ShowCompleted { get; set; }
        public string Text { get; set; }
        public List<TodoItem> Todos { get; set; } = new List<TodoItem>();

        public static TodoState InitialState => new TodoState()
        {
            Text = "",
            Todos = new List<TodoItem>()
            {
                new TodoItem()
                {
                    Id=1,
                    Todo = "Todo 1"
                },
                new TodoItem()
                {
                    Id=2,
                    Todo = "Todo 2"
                },
                new TodoItem()
                {
                    Id=3,
                    Todo = "Todo 3"
                }
            }
        };
    }
}
