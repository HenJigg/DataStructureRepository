using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureSlns
{
    class Program
    {
        static void Main(string[] args)
        {
            MyArrayListTest();

            Console.ReadKey();
        }

        static void MyArrayListTest()
        {
            Console.WriteLine("-----测试MyArrayList----");
            MyArrayList array = new MyArrayList();

            array.Add(9527);
            array.Add("Google");
            array.Add("Facebook");
            array.Add("Youtube");
            Console.WriteLine($"数组长度:{array.Capacity}");

            array.Insert(1, "Microsoft");
            Console.WriteLine("插入元素:Microsoft\r\n");

            Console.WriteLine($"数组长度:{array.Capacity}\r\n");

            array.RemoveAt(4);
            Console.WriteLine("移除索引位置4元素\r\n");

            array.TrimToSize();
            Console.WriteLine("裁剪数组空间\r\n");
            Console.WriteLine($"数组长度:{array.Capacity}\r\n");

            for (int i = 0; i < array.Count; i++)
            {
                Console.WriteLine("遍历元素:"+array[i].ToString());
            }

            Console.WriteLine("------------------------");
        }
    }
}
