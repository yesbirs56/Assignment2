using System;
using System.IO;
using Assesment2_BL;

namespace DirectoryStructure
{
    internal class DirectoryStructure
    {
        private static void Main(string[] args)
        {
            string structure = "";
            bool isValid = false;
            do
            {
                Console.WriteLine("Enter the Directory path");
                string path = Console.ReadLine();
                path = $@"{path}";

                try
                {
                    structure = DirectoryTree.GetStructure(path);
                    isValid = true;
                }
                catch (ArgumentException exc)
                {
                    Console.WriteLine(exc.Message);
                }
                catch (DirectoryNotFoundException exc)
                {
                    Console.WriteLine("Directory does not exist " + exc.Message);
                }
                catch (UnauthorizedAccessException exc)
                {
                    Console.WriteLine(exc.Message);
                }
                catch (PathTooLongException exc)
                {
                    Console.WriteLine(exc.Message);
                }
                catch (Exception exc)
                {
                    Console.WriteLine($"{exc.Message}");
                }
            } while (!isValid);

            Console.WriteLine(structure);
        }

        
       
    }
}