using System;
using System.IO;
using System.Text;
using System.Configuration;

namespace IOTest
{
    class Program
    {
        static void Main(string[] args)
        {
            GetConfig("username");
            GetConfig("password");
            SetConfig("password", "123456");
            GetConfig("username");
            GetConfig("password");
            Console.WriteLine("end");
        }

        /// <summary>
        /// 读取文本文件
        /// </summary>
        /// <param name="filePath"></param>
        static void ReadTxt(string filePath)
        {
            if (!File.Exists(filePath))
                return;
            FileStream fs = null;
            StreamReader m_streamReader = null;
            try
            {
                // 访问模式为打开， 权限为读取
                fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                // 编码为默认编码
                m_streamReader = new StreamReader(fs, Encoding.UTF8);
                // 设置指针位置为文件开头
                m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
                // 从数据流中读取每一行，直到文件的最后一行
                string strLine = "";
                while ((strLine = m_streamReader.ReadLine()) != null)
                {
                    Console.WriteLine(strLine);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("读取失败" + e.Message + e.StackTrace);
            }
            finally
            {
                if(fs != null)
                    fs.Close();
            }
        }

        /// <summary>
        /// 将内容写入文本文件，如果文件不存在将会创建。写入的内容会把从指针开始位置到写入文本长度的内容覆盖
        /// </summary>
        /// <param name="filePath"></param>
        static void WriteTxt(string filePath, string content)
        {
            FileStream fs = null;
            StreamWriter sw = null;
            try
            {
                fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
                sw = new StreamWriter(fs, Encoding.UTF8);
                sw.BaseStream.Seek(0, SeekOrigin.Begin);
                sw.Write(content);
                sw.Flush();
            }
            catch (IOException e)
            {
                Console.WriteLine("写入失败" + e.Message + e.StackTrace + e.Source);
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }
        }

        /// <summary>
        /// 在文本文件末尾新增内容，如果指针开始处已经有内容，会报异常
        /// </summary>
        /// <param name="filePath"></param>
        static void AppendTxt(string filePath, string content)
        {
            FileStream fs = null;
            StreamWriter sw = null;
            try
            {
                fs = new FileStream(filePath, FileMode.Append, FileAccess.Write);
                sw = new StreamWriter(fs, Encoding.UTF8);
                sw.BaseStream.Seek(0, SeekOrigin.End);
                sw.Write(Environment.NewLine);
                sw.Write(content);
                sw.Flush();
            }
            catch (IOException e)
            {
                Console.WriteLine("写入失败" + e.Message + e.StackTrace + e.Source);
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }
        }

        /// <summary>
        /// 读取app.config的属性的值
        /// </summary>
        /// <param name="attributeKey"></param>
        static void GetConfig(string attributeKey)
        {
            string str = ConfigurationManager.AppSettings[attributeKey];
            Console.WriteLine(str);
        }

        /// <summary>
        /// 修改app.config的属性的值
        /// </summary>
        /// <param name="attributeKey"></param>
        /// <param name="newValue"></param>
        static void SetConfig(string attributeKey, string newValue)
        {
            // 创建配置文件对象
            Configuration conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            // 修改对应的属性的值
            conf.AppSettings.Settings[attributeKey].Value = newValue;
            // 保存修改
            conf.Save();
            // 刷新内存，否则数据会放在内存，不会真正写入文件
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
