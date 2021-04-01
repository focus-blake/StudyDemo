using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace LiveChartsTest
{
    class Bootstrapper: BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            // LiveChartsTest是要启动的第一个界面
            DisplayRootViewFor<LiveChartsTest.ViewModels.ChartsViewModel>();
        }
    }
}
