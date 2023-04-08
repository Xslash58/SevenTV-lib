[![NuGet](https://img.shields.io/nuget/v/SevenTV-lib.svg?label=NuGet)](https://nuget.org/packages/SevenTV-lib)
# SevenTV-lib
SevenTV-lib implements 7TV V3 API into easy to use C# library. I'll try to update this library as frequently as possible with new implementations from 7TV side.

# Example usage
```csharp
var sevenTv = new SevenTV.SevenTV();

SevenTV.Types.User user = await sevenTv.GetUser("60b67e8f561dfc1d80f217c5");
Console.WriteLine(user.username);
```
More on [wiki](https://github.com/Xslash58/SevenTV-lib/wiki)<br>
You can see examples in [EmoteGuesser](https://github.com/Xslash58/emoteguesser)

# Dependencies
SevenTV-lib is using [Newtonsoft.JSON](https://www.newtonsoft.com/json) to deserialize data from 7TV API.

# I want to use it in Unity!
As SevenTV-lib is written in .NET Standard 2.1 you have to change 'Api Compatibility Level' to .NET 4.x.
[How to do it](https://learn.microsoft.com/en-us/visualstudio/gamedev/unity/unity-scripting-upgrade)
