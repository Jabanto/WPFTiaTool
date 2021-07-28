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
            initialize();
        }

        void initialize()
        {
            //Container with inject the mainviewModel into the Context
            var mainView = mainContainer.Resolve<MainView>();
            mainView.Show();
        }

    }
}
