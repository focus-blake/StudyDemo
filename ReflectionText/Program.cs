using System;
using System.Reflection;
using LiveCharts.Wpf;
using PluginTest;

namespace ReflectionText
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowPublicMembers();
        }

        /// <summary>
        /// 利用Assembly获取自己封装类库中的一些属性和方法
        /// </summary>
        static void GetCaliburn()
        {
            // 获取自己封装的dll
            Assembly ass = Assembly.LoadFrom("PluginTest.dll");
            // 获取类的类型
            Type t = ass.GetType("PluginTest.FirstPlugin");
            // 获取类的实例
            object o = ass.CreateInstance(t.ToString());
            // 设置属性调用方法FirstPlugin.Name的值
            PropertyInfo p = t.GetProperty("Name");
            p.SetValue(o, "孙中山");
            // 调用方法FirstPlugin.Show()
            MethodInfo m = t.GetMethod("Show");
            ((FirstPlugin)o).Show();
            // 打印属性的名字
            Console.WriteLine(p.Name);

            /*
             * 输出：
             * 调用方法FirstPlugin
             * 孙中山
             * Name
             * */
        }

        /// <summary>
        /// 用反射生成对象，并调用属性、方法和字段进行操作 
        /// </summary>
        static void ShowOthers()
        {
            ReflectionClass rc = new ReflectionClass();
            Type t = rc.GetType();
            object obj = Activator.CreateInstance(t);
            //取得ID字段
            FieldInfo fi = t.GetField("id");
            //给ID字段赋值
            fi.SetValue(obj, 1);
            //取得Name属性
            PropertyInfo piName = t.GetProperty("Name");
            //给Name属性赋值
            piName.SetValue(obj, "刘邦");
            PropertyInfo piAge = t.GetProperty("Age");
            piAge.SetValue(obj, "46");
            PropertyInfo piSex = t.GetProperty("Sex");
            piSex.SetValue(obj, "男");
            //取得Show方法
            MethodInfo mi = t.GetMethod("Show");
            //调用Show方法
            mi.Invoke(obj, null);
            Console.WriteLine("ID为：" + ((ReflectionClass)obj).id);
        }

        /// <summary>
        /// 返回成员的类型
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        static string ShowType(MemberTypes t)
        {
            switch (t)
            {
                case MemberTypes.Field:
                    {
                        return "字段";
                    }
                case MemberTypes.Method:
                    {
                        return "方法";
                    }
                case MemberTypes.Property:
                    {
                        return "属性";
                    }
                default:
                    {
                        return "未知";
                    }
            }
        }

        /// <summary>
        /// 获取私有实例静态成员
        /// </summary>
        static void ShowPrivateStaticFieId()
        {
            FieldInfo f = new ReflectionClass().GetType().GetField("place", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
            if(f != null)
                Console.WriteLine(f.Name);
        }

        /// <summary>
        /// 获取私有实例成员（不包括父类）
        /// BindingFlags.DeclaredOnly 不包括父类
        /// </summary>
        static void ShowPrivateMembers()
        {
            MethodInfo[] mArr = new ReflectionClass().GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (MethodInfo m in mArr)
            {
                Console.WriteLine(m.Name);
            }
        }

        /// <summary>
        /// 获取所有公共成员
        /// </summary>
        static void ShowPublicMembers()
        {
            MemberInfo[] mArr = new ReflectionClass().GetType().GetMembers();
            foreach (MemberInfo m in mArr)
            {
                Console.WriteLine("类型:" + ShowType(m.MemberType) + "---" + m.Name);
            }
        }

        /// <summary>
        /// 查看类中的公共字段
        /// </summary>
        static void ShowFieIds()
        {
            FieldInfo[] piArray = new ReflectionClass().GetType().GetFields();
            foreach (FieldInfo pi in piArray)
            {
                Console.WriteLine(pi.Name);
            }
        }

        /// <summary>
        /// 查看类中的公共方法
        /// </summary>
        static void ShowMethods()
        {
            MethodInfo[] piArray = new ReflectionClass().GetType().GetMethods();
            foreach (MethodInfo pi in piArray)
            {
                Console.WriteLine(pi.Name);
            }
        }

        /// <summary>
        /// 查看类中的属性
        /// </summary>
        static void ShowPropertys()
        {
            PropertyInfo[] piArray = new ReflectionClass().GetType().GetProperties();
            foreach (PropertyInfo pi in piArray)
            {
                Console.WriteLine(pi.Name);
            }
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

        private static string place = "BeiJing";
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

        private void ShowPrivate()
        {
            Console.WriteLine("我是私有方法");
        }
    }
}
