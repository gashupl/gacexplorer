using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GacExplorer.Services.Tests
{
    [TestClass]
    public class Test
    {
        private class A
        {
            private C c;

            public A(ref C c)
            {
                this.c = c; 
            }

            public void SetValue()
            {
                //c = new C("Set from A"); 
                c.Value = "Set from A"; 
            }
            public void ShowValue()
            {
                Console.WriteLine(c.Value); 
            }
        }

        private class B
        {
            private C c;

            public B(ref C c)
            {
                this.c = c;
            }

            public void ShowValue()
            {
                Console.WriteLine(c.Value);
            }
        }

        private class C
        {
            public C(string value)
            {
                Value = value; 
            }
            public string Value { get; set; }
        }

        [TestMethod] 
        public void RunTest()
        {
            C c = new C("Initial value"); 
            var a = new A(ref c);
            var b = new B(ref c);
            a.SetValue();
            a.ShowValue();
            b.ShowValue(); 

        }
    }
}
