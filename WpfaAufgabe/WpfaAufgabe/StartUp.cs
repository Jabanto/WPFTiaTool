using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfaAufgabe.IoC;
using WpfaAufgabe.ViewModel;
using WpfaAufgabe.Views;

namespace WpfaAufgabe
{
    public class StartUp
    {
        private DIContainer mainContainer = new DIContainer(); 
       
        public StartUp()
        {
            registerTypes();
            initialize();
        }

        private void registerTypes()
        {
            //mainContainer.Register<MainViewModel>();
        }

        void initialize()
        {
            var mainView = mainContainer.Resolve<MainView>();
            mainView.Show();
        }

    }
}
