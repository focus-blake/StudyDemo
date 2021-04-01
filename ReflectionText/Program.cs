using System;
using System.Reflection;

namespace ReflectionText
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateObjForActivator();
        }

        /// <summary>
        /// 用Activator生成对象
        /// </summary>
        static void CreateObjForActivator()
        {
            // 获取类型
            Type reType = typeof(ReflectionClass);
            // 构造函数的参数
            object[] paraArr = { "拜登", "60" };
            // 利用Activator创建实例
            object result = Activator.CreateInstance(reType, paraArr);
            // 调用动态生成对象的方法
            ((ReflectionClass)result).Show();
        }

        /// <summary>
        /// 用构造函数动态生成对象
        /// </summary>
        static void CreateObjForConstructor()
        {
            // 获取指定的构造函数
            Type reType = typeof(ReflectionClass);
            Type[] typeArr = { typeof(string), typeof(string) };
            ConstructorInfo consInfo = reType.GetConstructor(typeArr);

            // 构造函数的参数
            object[] paraArr = { "拜登", "60"};

            // 利用获取的构造函数实例化对象
            object result = consInfo.Invoke(paraArr);

            // 调用动态生成对象的方法
            ((ReflectionClass)result).Show();
        }

        /// <summary>
        /// 获得所有构造函数的参数类型和参数名称
        /// </summary>
        static void GetConstructorsPara()
        {
            // 创建ReflectionClass的实例
            ReflectionClass re = new ReflectionClass();
            // 获得re的类型
            Type t = re.GetType();
            //获取类的所有构造函数
            ConstructorInfo[] ciArray = t.GetConstructors();
            foreach (ConstructorInfo ci in ciArray)
            {
                // 获取当前构造函数的所有参数
                ParameterInfo[] piArray = ci.GetParameters();
                foreach (ParameterInfo pi in piArray)
                {
                    // 打印当前构造函数的所有参数
                    Console.Write(pi.ParameterType.ToString() + "\t" + pi.Name + "\t");
                }
                Console.WriteLine();
            }
        }
    }

    /// <summary>
    /// 实例类
    /// </summary>
    class ReflectionClass
    {
        public int id;

        private string name;
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string age;
        /// <summary>
        /// 年龄
        /// </summary>
        public string Age
        {
            get { return age; }
            set { age = value; }
        }
        private string sex;
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        public ReflectionClass(string name, string age)
        {
            this.name = name;
            this.age = age;
        }
        public ReflectionClass(string sex)
        {
            this.sex = sex;
        }
        public ReflectionClass()
        { }

        public void Show()
        {
            Console.WriteLine("姓名：" + name + "\n" + "年龄：" + age + "\n" + "性别：" + sex);
        }
    }
}
