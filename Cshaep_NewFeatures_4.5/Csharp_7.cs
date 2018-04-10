using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cshaep_NewFeatures_4._5
{
    public class Csharp_7
    {
        public void Init()
        {
            Stopwatch sw = new Stopwatch();
            

            //1. out-variables(Out变量)
            //以前,我们使用out变量的时候,需要在外部先申明,然后才能传入方法,类似如下:

            string aaa; //先申明变量
            Test01(out aaa);
            Console.WriteLine(aaa);

            //在C#7.0中我们可以不必申明,直接在参数传递的同时申明它,如下:

            Test01(out string bbb); //传递的同时申明
            Console.WriteLine(bbb);
            Console.ReadLine();



            //2.Tuples(元组) 注意:需要通过nuget引用System.ValueTuple
            var data = Test02_1();
            Console.WriteLine($"返回1：{data.Item1},返回2：{data.Item2},返回3：{data.Item3},");

            var data2 = Test02_2(("a", "b", "c"));
            Console.WriteLine($"返回1：{data2.a},返回2：{data2.b},返回3：{data2.c},");

            (string a2, string b2, string c2) = Test02_2(("d", "e", "f"));
            Console.WriteLine($"返回1：{a2},返回2：{b2},返回3：{c2},");


            //3. Pattern Matching(匹配模式)
            object a3 = 1;
            if (a3 is int c3) //这里,判断为int后就直接赋值给c
            {
                int d3 = c3 + 10;
                Console.WriteLine(d3);
            }

            //4.ref locals and returns(局部变量和引用返回)
            int a4 = 3;
            ref int a4_1 = ref a4;  //注意这里,我们通过ref关键字 把x赋给了x1
            a4_1 = 2;
            Console.WriteLine($"改变后的变量 {nameof(a4_1)} 值为: {a4}"); //这段代码最终输出 "2"

            int[] a4_arr = { 1, 2, 3, 4, 5 };
            ref int a4_x = ref GetByIndex(a4_arr, 2);
            a4_x = 99;
            Console.WriteLine($"数组arr[2]的值为: {a4_arr[2]}");//输出"99"


            //5.Local Functions (局部函数)
            //注:局部函数定义在方法的任何位置,都可以在方法内被调用,不用遵循逐行解析的方式
            Init5(1, 2);
            //定义局部函数,Dosmeing2.
            int Init5(int a5, int b5)
            {
                return a5 + b5;
            }
            Init5(3, 4);

            //9.Numeric literal syntax improvements(数值文字语法改进)
            int a9 = 123_456;
            int b9 = 0xAB_CD_EF;
            int c9 = 123456;
            int d9 = 0xABCDEF;
            Console.WriteLine(a9 == c9);
            Console.WriteLine(b9 == d9);
            //如上代码会显示两个true,在数字中用"_"分隔符不会影响结果,只是为了提高可读性

        }
        //6.More expression-bodied members(更多的函数成员的表达式体)
        public void CreatePerson7() => new Person7();
        //等价于下面的代码
        //public void CreatePerson7()
        //{
        //    new Person7();
        //}
        //但是,并不支持用于构造函数,析构函数,和属性访问器,那么C#7.0就支持了..代码如下:

        // 构造函数的表达式写法
        public Csharp_7(string label) => this.Label = label;

        // 析构函数的表达式写法
        ~Csharp_7() => Console.Error.WriteLine("Finalized!");

        private string label;
        // Get/Set属性访问器的表达式写法
        public string Label
        {
            get => label;
            set => this.label = value ?? "Default label";
        }


        //7.throw Expressions (异常表达式)
        public string IsNull()
        {
            string a = null;
            return a ?? throw new Exception("异常了!");
        }



        private string Test01(out string a)
        {
            a = "test01";
            return a;
        }

        private Tuple<string, string, string> Test02_1()
        {
            return new Tuple<string, string, string>("a", "b", "c");
        }
        private static (string a, string b, string c) Test02_2((string a, string b, string c) tupleIn)
        {
            return (tupleIn.a + "a", tupleIn.b + "b", tupleIn.c + "c");
        }

        private dynamic Test03(object a)
        {
            dynamic data;
            switch (a)
            {
                case int b when b < 0://筛选：判断为int并且小于0后就直接赋值给b
                    data = b + 100;
                    break;
                case int b:
                    data = b++;
                    break;
                case string c:
                    data = c + "aaa";
                    break;
                default:
                    data = null;
                    break;
            }
            return data;
        }

        private ref int GetByIndex(int[] arr, int ix) => ref arr[ix];  //获取指定数组的指定下标

    }

    class Person7
    {
        //二、自动属性初始化
        public string FirstName { set; get; } = "summit";
        public string LastName { set; get; }
        public int Age { set; get; }
        public IList<int> AgeList
        {
            get;
            set;
        } = new List<int> { 10, 20, 30, 40, 50 };
    }
}
