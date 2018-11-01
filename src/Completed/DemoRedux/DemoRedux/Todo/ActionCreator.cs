using DemoRedux.Todo.Actions;
using DemoRedux.Todo.States;
using Newtonsoft.Json;
using Redux;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DemoRedux.Todo
{
    public delegate Task AsyncActionsCreator<TState>
        (Dispatcher dispatcher, Func<TState> getState);

    public static class ActionCreator
    {
        public static AsyncActionsCreator<TodoState> LoadTodosAsync()
        {
            return async (dispatch, getState) =>
            {
                dispatch(new LoadTodosAction());

                try
                {
                    var httpclient = new HttpClient();
                    var json = await httpclient
                    .GetStringAsync("http://localhost:3000/todos");

                    var items = JsonConvert
                    .DeserializeObject<TodoItem[]>(json);

                    dispatch(new LoadTodosSuccessAction(items));
                }
                catch (Exception ex)
                {
                    dispatch(new LoadTodosErrorAction(ex.ToString()));
                }
            };
        }
    }
}
