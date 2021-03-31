using System;
using System.Linq;
using System.Xml.Linq;

namespace XmlTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            p.Id = Guid.NewGuid().ToString();
            p.Name = "诸葛亮";
            p.Age = 40;
            p.Hometown = "隆中";

            SavePerson(p,@"D:/Person.xml");
            Console.WriteLine("end!");
        }

        /// <summary>
        /// 将person对象保存为xml文件
        /// </summary>
        /// <param name="p"></param>
        static void SavePerson(Person p,string outPath)
        {
            XDocument doc = new XDocument
            (
                new XDeclaration("1.0", "utf-8", "yes"),
                // 根节点
                new XElement
                // 根节点名称
                ("PersonGroup",
                     // 子节点
                     new XElement
                     ("Person",
                     // 子节点的属性
                     new XAttribute("Id", "1"),
                     new XElement("Name", p.Name),
                     new XElement("Age", p.Age),
                     new XElement("Hometown", p.Hometown)
                     ),
                     // 子节点
                     new XElement
                     ("Person",
                     new XAttribute("Id", "2"),
                     new XElement("Name", p.Name),
                     new XElement("Age", p.Age),
                     new XElement("Hometown", p.Hometown)
                     )
                )
            );
            doc.Save(outPath);
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
