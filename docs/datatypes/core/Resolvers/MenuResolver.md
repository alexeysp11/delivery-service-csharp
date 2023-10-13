# MenuResolver Class 

Namespace: [DeliveryService.Core.Resolvers](DeliveryService.Core.Resolvers.md)

## Constructors 

### MenuResolver()

```C#
public MenuResolver();
```

## Methods 

### GetMenu()

Method for allowing a user to sign in.

```C#
public MenuItem GetMenu();
```

#### Parameters 

- `serverAddress`: [String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Server address.

- `signInModel`: [SignInModel](../../models/Authentication/SignInModel.md)

Sign in model.

#### Returns

[MenuItem](../../models/Menu/MenuItem.md)

The result of verification of user credintials.

#### Examples

Example of using `GetMenu()` method:
