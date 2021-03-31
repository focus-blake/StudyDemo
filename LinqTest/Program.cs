using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // 全部学生成绩
            List<int> allScores = new List<int> { 60, 59, 12, 100, 99, 1000 };
            Console.WriteLine("全部学生成绩：");
            foreach (int num in allScores)
            {
                Console.Write(num + "\t");
            }

            // 不及格学生成绩
            IEnumerable<int> failScores = from score in allScores
                                          where score < 60
                                          orderby score descending
                                          select score;
            Console.WriteLine("\n不及格学生成绩：");
            foreach (int num in failScores)
            {
                Console.Write(num + "\t");
            }
        }
    }
}
