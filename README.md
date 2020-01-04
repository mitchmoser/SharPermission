# SharPermission
C# .NET Assembly for interacting with File Object DACLs

An opsec alternative to running `shell icacls` in Cobalt Strike using `execute-assembly`.

Retrieves File Object DACLs via [File.GetAccessControl Method](https://docs.microsoft.com/en-us/dotnet/api/system.io.file.getaccesscontrol?view=netframework-4.8)

#### TODO
Add option to apply an ACE to a File Object using [File.SetAccessControl Method](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileinfo.setaccesscontrol?view=netframework-4.8)

## Example Usage:
```
execute-assembly /opt/SharpTools/SharPermission.exe \\HOSTNAME\share\
```
### Output
```
[*] Tasked beacon to run .NET program: SharPermission.exe \\HOSTNAME\share\
[+] host called home, sent: 111705 bytes
[+] received output:
Permissions for: \\HOSTNAME\share\

	Account:        Everyone
	Type:           Allow
	Rights:         FullControl
	Inherited ACE: 	False

	Account:        NT AUTHORITY\SYSTEM
	Type:           Allow
	Rights:         FullControl
	Inherited ACE:  False

	Account:        BUILTIN\Administrators
	Type:           Allow
	Rights:         FullControl
	Inherited ACE:  False
```
