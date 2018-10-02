using DemoRedux.Todo.Reducers;
using DemoRedux.Todo.States;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace DemoRedux.Tests
{
    [TestClass]
    public class TodoReducerTests
    {
        [TestMethod]
        [DataRow(true,false)]
        [DataRow(false,true)]
        public void ToogleStatus_Change_ShowPendent_On_and_Off(bool initialValue,bool expectedValue)
        {
            //Arrange
            var action = new Todo.Actions.ToogleCompletedViewAction();
            var initialState = new TodoState()
            {
                ShowCompleted = initialValue
            };

            //Act
            var finalState = Todo.Reducers.TodoReducer.Execute(initialState,action);

            //Assert
            Assert.AreEqual(expectedValue,finalState.ShowCompleted);
        }

        [TestMethod]
        public void AddTodo_UpdateTodoLists()
        {
            //Arrange
            var action = new Todo.Actions.NewTodoAction("Todo-1");
            var initialState = new TodoState()
            {
                Todos = new List<TodoItem>()
            };
            //Act
            var newState = TodoReducer.Execute(initialState,action);

            //Assert
            Assert.AreEqual(newState.Todos.Count,1);
            Assert.AreEqual(newState.Todos.First().Todo,"Todo-1");
        }

        [TestMethod]
        public void CompleteTodo_UpadteTodo_as_completed()
        {
            //Arrange
            const int todoId = 1;
            var action = new Todo.Actions.CompleteTodoAction(todoId);
            var initialState = new TodoState()
            {
                Todos = new List<TodoItem>()
                {
                    new TodoItem(){Id=todoId,Todo="T1",Completed=false}
                }
            };
            //Act
            var newState = TodoReducer.Execute(initialState, action);

            //Assert
            var todo = newState.Todos.FirstOrDefault(x=>x.Id == todoId);
            Assert.IsNotNull(todo);
            Assert.AreEqual(newState.Todos.Count, 1);
            Assert.IsTrue(todo.Completed);
        }
    }
}
