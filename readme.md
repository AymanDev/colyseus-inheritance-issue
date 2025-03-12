# Colyseus Inheritance Issue

### Steps

* `cd server && npm i && npm run start`
* Open Project in Unity(I used Unity 6000.0.36f1)
* Just launch game


You will see in console debug prints of received field names and schema-codegen error about mismatch.
Also, some errors about keys not present in dictionary, probably errors and connected


### Debug

I tried debugging by adding in `SchemaSerializer.cs` from Colyseus C# SDK to CompareTypes method this lines of code

```csharp
string fieldNames = "";
for (int i = 0; i < reflectionFields.Count; i++)
{
    fieldNames += reflectionFields[i].name + ", ";
}

Debug.Log($"Received fields {fieldNames}");
```

After starting game in console will output received field names and in my case it was repeated same fields like:
* position, position, 

and etc

Basically any inherited types with more than 1 level of deep inheritance