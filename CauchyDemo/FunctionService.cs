using System;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.CodeAnalysis.CSharp.Scripting;

namespace CauchyDemo
{
    internal class FunctionService
    {
        /// <summary>
        /// Creates Func instance, using given string as function definition
        /// </summary>
        /// <param name="fSrc"> string to use as definition </param>
        /// <returns> Function instance </returns>
        public static Func<double, double, double> CreateFunctionFromString(string fSrc)
        {
            var str = "(x, y) => " + fSrc;
            var options = ScriptOptions.Default.AddImports(new string[] { "System" });
            return CSharpScript.EvaluateAsync<Func<double, double, double>>(str, options).Result;
        }
    }
}
