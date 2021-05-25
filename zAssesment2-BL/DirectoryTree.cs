using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assesment2_BL
{
    /// <summary>
    /// Static class which expose a GetStructure method to print the Directory Structure Tree
    /// </summary>
    public static class DirectoryTree
    {

        //String builder object to store Directory tree structure
        private static StringBuilder _structure = new StringBuilder("");

        /// <summary>
        /// Print the Structure of the given directory
        /// </summary>
        /// <exception cref="ArgumentException">When Arguments is not valid </exception>
        /// <exception cref="DirectoryNotFoundException">When the directory Path given is not Exist</exception>
        /// <exception cref="PathTooLongException">When Path is Too Long </exception>
        /// <exception cref="UnauthorizedAccessException">When access a unauthorised directory </exception>
        /// <param name="path">Contains the path of the Directory</param>
        /// <return>string contain the structure tree information</return>
        public static string GetStructure(string path)
        {
            PrintTree(path,"");
            return _structure.ToString();
        }

        


        // Recursive function To Print the structure of the Tree 
        private static void PrintTree(string path, string spaces="")
        {

            DirectoryInfo root = null;
            try
            {
                root = new DirectoryInfo(path);

            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (PathTooLongException)
            {
                throw;
            }

            FileInfo[] files = null;
            try
            {
                files = root.GetFiles();

            }
            catch (DirectoryNotFoundException)
            {
                throw;
            }
            catch (UnauthorizedAccessException)
            {
                throw;
            }
            

            foreach (FileInfo file in files)
            {
                
                _structure.AppendLine($"{spaces + "-"}{file.Name}");

            }

            DirectoryInfo[] folders = root.GetDirectories();
            foreach (DirectoryInfo folder in folders)
            {
                
                _structure.AppendLine( $"{spaces + "--"}{folder.Name}");
                // Calling recursion on subfolder (depth first approach) with added spaces
                PrintTree(path + $@"\{folder.Name}", spaces + "  ");
                
            }
        }
    }

   


}
