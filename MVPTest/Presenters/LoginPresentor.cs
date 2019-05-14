using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVPTest.Views;
using MVPTest.Models;
using System.Windows.Forms;

namespace MVPTest.Presenters
{
    public class LoginPresentor : IPresenter
    {
        private readonly ILoginView _view;
        private readonly IDBModel _model;

        public LoginPresentor(ILoginView view, IDBModel model)
        {
            _view = view;
            _model = model;
            _view.LogIn += new EventHandler(LogIn);
            _view.Exit += new EventHandler(Exit);
        }

        public void Run()
        {
            _view.Show();
        }

        public void LogIn(object sender, EventArgs e)
        {
            if(_view.GetLogin().Replace(" ", "").Length == 0 || _view.GetPassword().Replace(" ","").Length == 0)
            {
                _view.ShowEmpty();
                return;
            }

            if (_model.Authorization(_view.GetLogin(), _view.GetPassword()))
            {
                Global.Login = _view.GetLogin();
                _view.Close();
            }
            else
            {
                _view.ShowError();
            }    
        }

        public void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
