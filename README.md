## .NET core IronPython

Examples on how to use .NET core in conjunction with IronPython. Quite useful for dynamic things in your code.

### Using the code

To run the project examples, just use:

```
dotnet run
```

The API is quite simple, you just need to use the `ScriptExecutor` class to run your scripts. Whatever you add to `BaseScript.py` also gets included.

Example of adding 2 numbers passed from .NET:

```csharp
var results = (int)ScriptExecutor.RunScript(script, new Dictionary<string, object>{ {"x", 1}, {"y", 2}});
```
