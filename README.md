[![NuGet](https://img.shields.io/nuget/v/SevenTV-lib.svg?label=NuGet)](https://nuget.org/packages/SevenTV-lib)
# SevenTV-lib
SevenTV-lib implements 7TV V3 API into easy to use C# library. I'll try to update this library as frequently as possible with new implementations from 7TV side.

# Example usage
```csharp
var client = new SevenTV.SevenTVClient();

SevenTV.Types.Rest.User user = await client.rest.GetUser("01F74DWQMR0005C7FW3P0F45Y5");
Console.WriteLine(user.username);

var addResponse = await client.graphql.AddEmote("01F6WP22CR0004YCK11WAVZHEW", "01F74DWQMR0005C7FW3P0F45Y5");

```
More on [wiki](https://github.com/Xslash58/SevenTV-lib/wiki)<br>
You can see examples in [EmoteGuesser](https://github.com/Xslash58/emoteguesser) (pre-gql version)

# Dependencies
SevenTV-lib is using [Newtonsoft.JSON](https://www.newtonsoft.com/json) to deserialize data from 7TV API.

# I want to use it in Unity!
As SevenTV-lib is written in .NET Standard 2.1 you have to change 'Api Compatibility Level' to .NET 4.x.
[How to do it](https://learn.microsoft.com/en-us/visualstudio/gamedev/unity/unity-scripting-upgrade)
