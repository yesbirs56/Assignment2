using System;
using System.IO;

namespace DirectoryStructure
{
    internal class DirectoryStructure
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Enter the Directory path");
            string path = Console.ReadLine();
            path = $@"{path}";
            GetStructure(path, "");
        }

        //A recursive function accepts the path of directory and spaces
        // which signifies the spaces required in x depth of folder and print the structure of directory
        private static void GetStructure(string path, string spaces)
        {
            DirectoryInfo root = null;
            try
            {
                root = new DirectoryInfo(path);
            }
            catch (ArgumentException)
            {
                Console.Write("Path is not given  ");
                return;
            }
            catch (PathTooLongException)
            {
                Console.Write("Path is too Long  ");
                return;
            }

            FileInfo[] files = null;
            try
            {
                files = root.GetFiles();
            }
            catch (DirectoryNotFoundException)
            {
                Console.Write("Path Does not Exist ");
                return;
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine($"{spaces} ( UnAuthorized access in {root.Name} directory )");
                return;
            }

            foreach (FileInfo file in files)
            {
                Console.WriteLine($"{spaces + " -"}{file.Name}");
            }

            DirectoryInfo[] folders = root.GetDirectories();
            foreach (DirectoryInfo folder in folders)
            {
                Console.WriteLine($"{spaces + "--"}{folder.Name}");
                // Calling recursion on subfolder (depth first approach) with added spaces
                GetStructure(path + $@"\{folder.Name}", spaces + "  ");
            }
        }
    }
}