# Registry Entry

## Overview

Sometimes, the installer may need to read or write data from/to the Windows Registry. This can be done from C# using a custom action, but there is also a simpler way.

## I) Create a registry entry

### Hypothetical scenario

The product being installed requires to have specific data in Windows Registry. At install time, the necessary registry keys and values will be created and, at uninstall time, they will be removed.

### Step 1 - Create Component

This is done using the `<RegistryKey>` and `<RegistryValue>` tags placed inside a `<Component>`:

```xml
<Component>
    <RegistryKey
        Root="HKLM"
        Key="Software\Dust in the Wind\Registry Entry"
        Action="createAndRemoveOnUninstall">

        <RegistryValue
            Type="string"
            Name="GitHub"
            Value="https://github.com/WiX-Toolset-Pills-15mg/Registry-Entry"
            KeyPath="yes" />

    </RegistryKey>
</Component>
```

**Note**: Remember that the component must be added to a feature so that it is actually installed.

I think that the code is pretty much self explanatory:

- The  `<RegistryKey>` tag will create a registry key. In this example it is `Software\Dust in the Wind\Registry Entry`.
- The `<RegistryValue>` tag specifies the registry value with name and actually value to be created inside the previously specified key. We choose to create the registry value `GitHub` to store the GitHub URL of this tutorial.

The `Action` attribute from the `<RegistryKey>` element can have two important values:

- `create` - creates the registry key at install time but it is not removed at uninstall time.
- `createAndRemoveOnUninstall` - creates the registry key at install time and removes it at uninstall time.

Please refer to the official documentation for more details regarding the attributes and what values they can have:

- `<RegistryKey>`:  https://wixtoolset.org/documentation/manual/v3/xsd/wix/registrykey.html
- `<RegistryValue>`: https://wixtoolset.org/documentation/manual/v3/xsd/wix/registryvalue.html

### Step 2 - Build and install

**Note**: Every installer must have at least one file deployed, so, make sure to add a dummy file to the installer. See the example from the `sources` directory (`ProductComponents.wxs` and `Directories.wxs`) in order to be able to build the project.

After build, run the installer by double clicking it.

**Note**: To also generate a log file, use the following command:

```
msiexec /i RegistryEntry.Create.msi /l*vx install.log
```

Then, open the Registry Editor (`regedit.exe`) and look for the `\Software\Dust in the Wind\Registry Entry\GitHub` value.

![image-20211130101423752](C:\Users\alexandru.iuga\AppData\Roaming\Typora\typora-user-images\image-20211130101423752.png)

### Step 4 - uninstall

Uninstall the product, either from Control Panel or from command line:

```
msiexec /x RegistryEntry.Create.msi /l*vx uninstall.log
```

Check again the Registry Editor do see that the `GitHub` value is gone.

## II) Read a registry entry

### Step 1 - Create property

A value read from Windows Registry must be stored in a public property. So, the first step is to create a public property. The `<RegistrySearch>` element is providing the value read from the Windows Registry. In this example we choose to read the windows version.

```xml
<Property Id="WINDOWS_VERSION">
    <RegistrySearch
        Id="InstallCountRegistrySearch"
        Root="HKLM"
        Key="Software\Microsoft\Windows NT\CurrentVersion"
        Name="ProductName"
        Type="raw" />
</Property>
```

### Step 2 - Build and run

**Note**: Every installer must have at least one file deployed, so, make sure to add a dummy file to the installer. See the example from the `sources` directory (`ProductComponents.wxs` and `Directories.wxs`) in order to be able to build the project.

After build, run the installer with the following command to generate a log file:

```
msiexec /i RegistryEntry.Read.msi /l*vx install.log
```

Open the log file and search for the `WINDOWS_VERSION` property.

![image-20211130103950413](C:\Users\alexandru.iuga\AppData\Roaming\Typora\typora-user-images\image-20211130103950413.png)

