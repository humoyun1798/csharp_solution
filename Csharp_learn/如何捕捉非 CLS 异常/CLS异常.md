https://learn.microsoft.com/zh-cn/dotnet/csharp/how-to/how-to-catch-a-non-cls-exception

C++/CLI 在内的某些 .NET 语言允许对象引发并非派生自 Exception 的异常

在 catch(RuntimeWrappedException e) 块中通过 RuntimeWrappedException.WrappedException 属性访问原始异常。