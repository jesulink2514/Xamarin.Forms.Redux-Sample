using DemoRedux.Todo.Actions;
using DemoRedux.Todo.States;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Redux;
using Xamarin.Forms;

namespace DemoRedux.Tests.Pages
{
    [TestClass]
    public class MainPageTests
    {
        [TestMethod]
        public void Given_ShowCompleted_clicked_then_action_dispatched()
        {
            //Arrange
            var store = A.Fake<IStore<TodoState>>();
            MockForms.Init();
            var page = new MainPage(store);

            //Act
            page.BtnToogleCompleted.SendClicked();

            //Assert
            A.CallTo(() => store.Dispatch(A<ToogleCompletedViewAction>.Ignored))
                .MustHaveHappenedOnceExactly();
        }
    }
}
