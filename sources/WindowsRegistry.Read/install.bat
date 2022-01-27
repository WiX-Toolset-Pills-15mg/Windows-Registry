:: ====================================================================================================
:: Step 2 (Read): Install
:: ====================================================================================================
::
:: Run the installer and look into the "install.log" file. At the end of the log file there is a dump
:: of all the properties. Among them, there should be the "WINDOWS_VERSION" private property containing
:: the version of the operating system.
:: 
:: END

msiexec /i WindowsRegistry.Read.msi /l*vx install.log