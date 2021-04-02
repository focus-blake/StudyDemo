using System;
using System.Collections.Generic;
using System.Text;

namespace PluginTest
{
    public class FirstPlugin
    {
        public FirstPlugin(string name)
        {
            this.Name = name;
        }

        public FirstPlugin()
        {
            Console.WriteLine("FirstPlugin无参构造函数");
        }

        public int id = 0;
        
        public string Name { get; set; }
        
        public void Show()
        {
            Console.WriteLine(Name);
        }
    }
}
