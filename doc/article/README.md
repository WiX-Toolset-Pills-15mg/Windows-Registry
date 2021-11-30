# Registry Entry

## Overview

Sometimes, the installer may need to read or write data from/to the Windows Registry. This can be done from C# using a custom action, but there is also a simpler way.

## How to create a registry entry

### Hypothetical scenario

The product being installed requires to have specific data in Windows Registry. At install time, the necessary registry keys and values will be created and, at uninstall time, they will be removed.

### Implementation

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

I think that the code is pretty much self explanatory: the  `<RegistryKey>` tag specifies the key that needs to be created and the `<RegistryValue>` tag specifies the value. Please refer to the official documentation for more details regarding the attributes and what values they can have:

- `<RegistryKey>`:  https://wixtoolset.org/documentation/manual/v3/xsd/wix/registrykey.html
- `<RegistryValue>`: https://wixtoolset.org/documentation/manual/v3/xsd/wix/registryvalue.html

One attribute, though, is worth mentioning here: the `Action` from the `<RegistryKey>` element. It can have two important values:

- `create` - creates the registry key at install time but it is not removed at uninstall time.
- `createAndRemoveOnUninstall` - creates the registry key at install time and removes it at uninstall time.

## How to read a registry entry

TBD
