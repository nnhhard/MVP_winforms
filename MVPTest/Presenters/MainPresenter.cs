using System;
using MVPTest.Views;
using MVPTest.Models;

namespace MVPTest.Presenters
{
    public interface IPresenter
    {
        void Run();
    }

    public class MainPresenter: IPresenter
    {
        private readonly IMainView _view;
        private readonly IDBModel _model;

        public MainPresenter(IMainView view, IDBModel model)
        {
            _view = view;
            _model = model;
            _view.Exit += new EventHandler(Exit);
        }

        public void Run()
        {
            LoginPresentor loginPresentor = new LoginPresentor(new LoginView(), new DBModel());
            loginPresentor.Run();
            _view.SetLogin(Global.Login);
            _view.Show();
        }

        public void Exit(object sender, EventArgs e)
        {
            _view.Close();
        }
    }
}
