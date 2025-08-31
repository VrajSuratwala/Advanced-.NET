# 🌍 Setting Multiple Environments in .NET (Development, Staging, Production)

## **1. Default Environment**

By default, .NET uses:

```bash
ASPNETCORE_ENVIRONMENT = Production
```

---

## **2. Create Configuration Files**

Create the following files in your project root:

* `appsettings.json` → Common settings
* `appsettings.Development.json` → Development environment settings
* `appsettings.Staging.json` → Staging environment settings
* `appsettings.Production.json` → Production environment settings

---

## **3. Configure in Program.cs**

Update your **Program.cs** to load environment-specific files:

```csharp
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true);
```

---

## **4. Set Environment Variable**

### 🔹 Windows (PowerShell)

```powershell
$env:ASPNETCORE_ENVIRONMENT = "Development"
```

### 🔹 Linux / macOS

```bash
export ASPNETCORE_ENVIRONMENT=Development
```

---

## **5. Check Active Environment**

Inside your app, you can check the current environment:

```csharp
var env = builder.Environment.EnvironmentName;
Console.WriteLine($"Running in: {env}");
```
