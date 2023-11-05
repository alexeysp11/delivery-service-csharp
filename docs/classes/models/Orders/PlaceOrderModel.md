# PlaceOrderModel Class 

Namespace: [DeliveryService.Models.Orders](DeliveryService.Models.Orders.md)

Model for placing order, that is used to send request from frontend to the controller.

## Constructors 

### PlaceOrderModel()

Default constructor.

```C#
public PlaceOrderModel();
```

## Properties 

### UserUid

User GUID.

```C#
public string? UserUid { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

User GUID.

### Login

Login of the user.

```C#
public string? Login { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Login of the user.

### PhoneNumber

Phone number of the user.

```C#
public string? PhoneNumber { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Phone number of the user.

### City

City of the delivery.

```C#
public string? City { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

City of the delivery.

### Address

Address of the delivery.

```C#
public string? Address { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Address of the delivery.

### ProductIds

List of the product IDs, that user has placed into the order.

```C#
public List<int> ProductIds { get; set; }
```

#### Property Value

[List](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<[Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32)>

List of the product IDs, that user has placed into the order.

### Products

List of the products, that user has placed into the order.

```C#
public List<Product> Products { get; set; }
```

#### Property Value

[List](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<[Product](https://github.com/alexeysp11/workflow-lib/blob/main/src/Models/Business/Products/Product.cs)>

List of the products, that user has placed into the order.
