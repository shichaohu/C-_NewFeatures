using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_NewFeatures
{
    public class Csharp_6
    {
        public void Init()
        {
            //一、字符串插值
            Person p = new Person { FirstName = "Jack", LastName = "Wang", Age = 100 };
            var results = $"First Name: {p.FirstName} LastName: {p.LastName} Age: {p.Age}";
        }

    }

    class Person
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public int Age { set; get; }
    }
}
