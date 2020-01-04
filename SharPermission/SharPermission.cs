using System;
using System.IO;
using System.Text;
using System.Security.AccessControl;


namespace SharPermission
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Test if input arguments were supplied.
            if (args.Length == 0)
            {
                Console.WriteLine("Please enter a file path");
                return;
            }

            // Get File Path from Command-line Argument assign to 'path' variable
            string path = args[0];
            Console.WriteLine("Permissions for: {0}\n", path);

            // Get File's ACL & Access Rules
            // https://www.developer.com/net/article.php/10916_3701811_2/The-Basics-of-Manipulating-File-Access-Control-Lists-with-C.htm
            FileSecurity fSecurity = File.GetAccessControl(path);
            AuthorizationRuleCollection acl = fSecurity.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount));

            // Iterate through ACEs and print properties
            foreach (FileSystemAccessRule ace in acl)
            {
                StringBuilder info = new StringBuilder();
                info.Append(string.Format("\t{0,-15} {1}\n", "Account: ", ace.IdentityReference.Value));
                info.Append(string.Format("\t{0,-15} {1}\n", "Type: ", ace.AccessControlType));
                info.Append(string.Format("\t{0,-15} {1}\n", "Rights: ", ace.FileSystemRights));
                info.Append(string.Format("\t{0,-15} {1}\n", "Inherited ACE: ", ace.IsInherited));
                Console.WriteLine(info);
            }
        }

    }
}
