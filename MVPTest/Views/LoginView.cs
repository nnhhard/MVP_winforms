using System;
using System.Windows.Forms;

namespace MVPTest.Views
{
    public interface ILoginView: IView
    {
        event EventHandler Exit;
        event EventHandler LogIn;
        String GetPassword();
        String GetLogin();
        void ShowError();
        void ShowEmpty();
    }

    public partial class LoginView : Form, ILoginView
    {
        public LoginView()
        {
            InitializeComponent();
        }

        public event EventHandler Exit;
        public event EventHandler LogIn;

        public string GetLogin()
        {
            return txtLogin.Text;
        }

        public void ShowEmpty()
        {
            lblMessageEmpty.Visible = true;
            lblMessageError.Visible = false;
        }

        public void ShowError()
        {
            lblMessageEmpty.Visible = false;
            lblMessageError.Visible = true;
        }

        public string GetPassword()
        {
            return txtPassword.Text;
        }

        public new void Show()
        {
            this.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Exit?.Invoke(this, EventArgs.Empty);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LogIn?.Invoke(this, EventArgs.Empty);
        }
    }
}
