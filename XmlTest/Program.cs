using System;

namespace XmlTest
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");
        }

        /// <summary>
        /// 将person对象保存为xml文件
        /// </summary>
        /// <param name="p"></param>
        static void SavePerson(Person p)
        { 
        }

        /// <summary>
        /// 从指定的xml文件读取person对象
        /// </summary>
        /// <param name="xmlPath"></param>
        static void ReadPerson(string xmlPath)
        {
            
        }
    }

    class Person
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Hometown { get; set; }
    }
}
