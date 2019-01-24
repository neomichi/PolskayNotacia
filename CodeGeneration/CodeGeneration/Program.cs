using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGeneration
{
    class Program
    {
        static void Main(string[] args)
        {
            var row = Console.ReadLine();
            var response = "";
            using (Microsoft.CSharp.CSharpCodeProvider test = new Microsoft.CSharp.CSharpCodeProvider())
            {
                var res = test.CompileAssemblyFromSource(
                    new System.CodeDom.Compiler.CompilerParameters()
                    {
                        GenerateInMemory = true
                    },
                    "public class TestClass { public int Calc() { return "+ row + ";}}"
                );

                var type = res.CompiledAssembly.GetType("TestClass");
                var obj = Activator.CreateInstance(type);
                var output = type.GetMethod("Calc").Invoke(obj, new object[] { });
                response = output.ToString();
            }       
            Console.WriteLine(response);           
            Console.ReadKey();

        }

        /// зачем нам обратная польская нотация,это то же С#///


    }
}
