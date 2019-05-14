using System;
using System.Windows.Forms;


namespace MVPTest.Views
{
    public interface IView
    {
        void Show();
        void Close();
    }

    public interface IMainView : IView
    {
        String FirstName { get; }
        String LastName { get; }
        void ShowError(String errorMessage);
        event EventHandler Exit;
        void SetLogin(String login);
    }

    public partial class MainView : Form, IMainView
    {
        private string firstName;
        public String FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }
        public string lastName;
        public String LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        public MainView()
        {
            InitializeComponent();
        }

        public void SetLogin(String login)
        {
            lblLogin.Text = login;
        }

        public new void Show()
        {
            Application.Run(this);
        }

        public void ShowError(String errorMessage)
        {
            MessageBox.Show(errorMessage);
        }

        public event EventHandler Exit;

        private void btnExit_Click(object sender, EventArgs e)
        {
            Exit?.Invoke(this, EventArgs.Empty);
        }
    }
}
