# getAddress.io SDK

## Install

```
Install from Nuget:

PM> Install-Package getAddress.Sdk
```
## Usage

### Dependency Injection
```
services.AddSingleton(s => new GetAddress.ApiKeys("<YOUR ADDRESS LOOKUP KEY>", "<YOUR ADMINISTRATION KEY>"));

services.AddHttpClient<GetAddress.Api>();
```
### Autocomplete and lookup addresses
```
public async Task Autocomplete(GetAddress.Api api)
{
  var autocompleteResult = await api.Autocomplete("High St");

  if (autocompleteResult.IsSuccess)
  {
      foreach(var suggestion in autocompleteResult.Success.Suggestions)
      {
          var getResult = await api.Get(suggestion);

          if (getResult.IsSuccess)
          {
              var address = getResult.Success;
              var line1 = address.Line1;
              var line2 = address.Line2;
              var line3 = address.Line3;
              var line4 = address.Line4;
              var buildName = address.BuildingName;
              //....
          }
      }
  }
  else
  {
      var errorMessage = autocompleteResult.Failed.Message;
  }
}
```
