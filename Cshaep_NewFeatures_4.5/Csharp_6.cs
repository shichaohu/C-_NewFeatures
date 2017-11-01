using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//三、导入静态类
using static System.Math;//注意这里不是命名空间哦

namespace Cshaep_NewFeatures_4._5
{
    public class Csharp_6
    {
        public void Init()
        {
            //一、字符串插值
            Person person = new Person { FirstName = "Jack", LastName = "Wang", Age = 100 };
            var results = $@"First Name: {person.FirstName} 
                            LastName: {person.LastName} Age: {person.Age}"; // 如果想写"{" 或"}"符号,写两个即可,如$"{{".

            Console.WriteLine($"之前的使用方式: {Math.Pow(4, 2)}");
            Console.WriteLine($"三、导入静态类: {Pow(4, 2)}");


            //四、空值运算符
            string age = person?.FirstName;//如果person不为空，那么返回person.FirstName
            Person age_ = person ?? new Person();//如果person为空，那么new 一个person


            //五、对象初始化器
            IDictionary<int, string> dict = new Dictionary<int, string>()
            {
                [1] = "first",
                [2] = "second"
            };

            //六、异常过滤器
            try
            {
                Int32.Parse("s");
            }
            catch (Exception e) when (e.Equals(new ArgumentNullException("")))//当when()里面返回的值不为true,将持续抛出异常,不会执行catch里面的方法.
            {
                Console.WriteLine("catch");
                return;
            }

            //七、nameof表达式  //待验证
            //nameof(person);

            //八、在cath和finally语句块里使用await
            Person res = null;
            try
            {
                //res = await Resource.OpenAsync(…);       // You could do this.

            }
            catch (Exception e)
            {
                //await Resource.LogAsync(res, e);         // Now you can do this …
            }
            finally
            {
                //if (res != null) await res.CloseAsync(); // … and this.
            }

        }

        //九、在属性里使用Lambda表达式
        public string Name => string.Format("姓名: {0}", "summit");

        //十、在方法成员上使用Lambda表达式
        public void Print() => Console.WriteLine(Name);
        static int LambdaFunc(int x, int y) => x * y;

    }

    class Person
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
