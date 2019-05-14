using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using MVPTest.Presenters;
using MVPTest.Models;
using MVPTest.Views;

namespace MVPTest
{
    static class Program
    {
        public static readonly ApplicationContext Context = new ApplicationContext();
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainPresenter presenter = new MainPresenter(new MainView(), new DBModel());
            presenter.Run();
        }
    }
}
