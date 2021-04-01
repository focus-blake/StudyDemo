using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
// 引用MvvmLight
using GalaSoft.MvvmLight;

namespace LiveChartsTest.ViewModels
{
    class ChartsViewModel:ViewModelBase
    {
        // 继承MvvmLight的ViewModelBase利用RaisePropertyChanged做数据绑定
        public string BtnContent { get { return _BtnContent; } set { _BtnContent = value; RaisePropertyChanged("BtnContent"); } }
        private string _BtnContent = "Test";
       
        // 利用Caliburn行为绑定
        public void BtnTestClick()
        {
            MessageBox.Show("调用成功");
        }
    }
}
