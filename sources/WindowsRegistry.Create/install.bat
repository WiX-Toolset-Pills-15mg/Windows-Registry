:: ====================================================================================================
:: Step 2 (Create): Build and Install
:: ====================================================================================================
:: 
:: Build the project.
:: 
:: Run the installer and look into the "install.log" file to see the installation is successful.
:: Start regedit.exe and find the key and the value added by the installer.
:: 
:: uninstall.bat

msiexec /i WindowsRegistry.Create.msi /l*vx install.log