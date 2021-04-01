using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Caliburn.Micro;

namespace LiveChartsDemo
{
    class Bootstrapper:BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<LiveChartsDemo.ViewModels.ChartsViewModel>();
        }
    }
}
