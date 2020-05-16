using System;
using System.Collections.Generic;
using IronPython.Hosting;

namespace TestIronPython
{
    class Program
    {
        static void Main(string[] args)
        {
            var script = $@"
print(""This is a simple example of executing an addition"")
x + y            
";


var authScript = $@"
from TestIronPython import AuthorizationStatus, PolicyCheckResult

print(""This is an example of something how our authorization stuff would work"")
class AuthScript(Result):
    def get_result(self):
        return PolicyCheckResult.Authorize(reason)

AuthScript().get_result()
";


var listScript = $@"
print(""This is an example of adding numbers from a CLR list passed as a param"")
sum = 0
for num in numbers:
    sum += num

sum
";

            var results = (int)ScriptExecutor.RunScript(script, new Dictionary<string, object>{ {"x", 1}, {"y", 2}});
            Console.WriteLine(results);

            var authResults = (PolicyCheckResult)ScriptExecutor.RunScript(authScript, new Dictionary<string, object>{ {"reason", "I have my reasons"} } );
            Console.WriteLine(authResults);


            var listExample = (int)ScriptExecutor.RunScript(listScript, new Dictionary<string, object>{ {"numbers", new List<int> { 
                1, 2, 3
            } } } );
            Console.WriteLine(listExample);
        }
    }
}
