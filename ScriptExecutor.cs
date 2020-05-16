using System.Collections.Generic;
using System.IO;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace TestIronPython
{

    /// <summary>
    /// Wrapper class to execute Python scipts.
    /// </summary>
    public class ScriptExecutor
    {

        /// <summary>
        /// Runs a Powershell script and injects the variables that are passed in
        /// </summary>
        /// <param name="script">The script itself</param>
        /// <param name="variables">A <see cref="Dictionary{K,V}"/> containing all the parameters to inject into the script</param>
        /// <param name="logger">The logger to use in order to log exception that occur</param>
        /// <returns>A <see cref="IEnumerable{T}" /> with strings containing the output of the script</returns>
        public static dynamic RunScript(string script, Dictionary<string, object> variables)
        {
            var python = Python.CreateEngine();
            ScriptScope scope = python.CreateScope();
            foreach (var variable in variables)
            {
                scope.SetVariable(variable.Key, variable.Value);
            }
            var baseScript = File.ReadAllText("./BaseScript.py");
            return python.Execute(baseScript + script, scope);
        }
    }
}