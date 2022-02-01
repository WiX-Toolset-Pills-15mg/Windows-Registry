:: ====================================================================================================
:: Step 3 (Create): Uninstall
:: ====================================================================================================
:: 
:: Uninstall the msi and look into the "uninstall.log" file to see the uninstallation is successful.
:: Start regedit.exe and see that the "GitHub" value is gone:
::		- \Software\Dust in the Wind\Windows Registry\GitHub
:: 
:: END

msiexec /x WindowsRegistry.Create.msi /l*vx uninstall.log