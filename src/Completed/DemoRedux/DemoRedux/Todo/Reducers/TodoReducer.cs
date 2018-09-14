using DemoRedux.Todo.Actions;
using DemoRedux.Todo.States;
using Redux;
using System.Linq;

namespace DemoRedux.Todo.Reducers
{
    public static class TodoReducer
    {
        public static TodoState Execute(TodoState previousState, IAction action)
        {
            if (action is ShowCompletedAction)
            {
                previousState.ShowCompleted = true;
            }

            if (action is ShowPendentAction)
            {
                previousState.ShowCompleted = false;
            }

            if(action is ToogleCompletedViewAction)
            {
                previousState.ShowCompleted=!previousState.ShowCompleted;
            }

            if(action is CompleteTodoAction c)
            {
                var todo = previousState.Todos.First(t=>t.Id == c.Id);
                todo.Completed = true;
            }

            if(action is NewTodoAction newTodo)
            {
                var todo = new TodoItem()
                {
                    Id = previousState.Todos.Max(x=>x.Id) + 1,
                    Todo = newTodo.Todo
                };

                previousState.Todos.Add(todo);
            }

            return previousState;
        }
    }
}
