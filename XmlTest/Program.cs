using System;
using System.Linq;
using System.Xml.Linq;

namespace XmlTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Person p = new Person();
            //p.Id = Guid.NewGuid().ToString();
            //p.Name = "诸葛亮";
            //p.Age = 40;
            //p.Hometown = "隆中";

            //SavePerson(p,@"D:/Person.xml");
            DelPersonById("2");
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
        static void ReadPerson()
        {
            XDocument doc = XDocument.Load(@"D:/Person.xml");
            var result = from d in doc.Descendants("Person")
                         select new
                         {
                             id = d.Attribute("Id").Value,
                             name = d.Element("Name").Value,
                             age = d.Element("Age").Value,
                             hometown = d.Element("Hometown").Value
                         };

            foreach (var p in result)
            {
                Console.WriteLine(p.id);
                Console.WriteLine(p.name);
                Console.WriteLine(p.age);
                Console.WriteLine(p.hometown);
            }
        }

        /// <summary>
        /// 在xml文件子节点下增加属性和数据
        /// </summary>
        static void AddXmlAttribute()
        {
            XDocument doc = XDocument.Load(@"D:/Person.xml");
            // 在Person节点添加属性和数据
            doc.Root.Element("Person").Add(new XElement("Sister","Amy"));
            doc.Save(@"D:/Person.xml");
        }

        /// <summary>
        /// 根据Id删除Person节点
        /// </summary>
        /// <param name="id"></param>
        static void DelPersonById(string id)
        {
            XDocument doc = XDocument.Load(@"D:/Person.xml");
            try
            {
                // 获取目标节点
                XElement target = doc.Root.Elements("Person").Where(t => t.Attribute("Id").Value.Equals(id)).Single();
                // 删除节点
                if (target != null)
                {
                    target.Remove();
                    doc.Save(@"D:/Person.xml");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("存在多个符合条件的xml节点或节点不存在" + e.Message);
            } 
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
