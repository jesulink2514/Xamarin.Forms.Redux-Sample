using Redux;
using System.Threading.Tasks;

namespace DemoRedux.Todo
{
    public static class StoreExtensions
    {
        public static Task DispatchAsync<TState>(
            this IStore<TState> store, AsyncActionsCreator<TState> asyncAction)
        {
            return asyncAction(store.Dispatch,store.GetState);
        }
    }
}
