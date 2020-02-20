# Carton Builder

## Warehouse Database ERD

![Warehouse Database ERD](./documentation/warehouse-data.jpg)

## Troubleshooting

### File Not Found Exception Encountered

Running the application yields the following exception:

```Exception Details: System.IO.FileNotFoundException: Could not find file 'C:\carton-builder\bin\roslyn\csc.exe'.```

Open the Package Manager Console in Visual Studio and execute the following command:

```Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r```

This will install or upgrade the .NET compiler.
