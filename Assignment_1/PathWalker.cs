using System;
using System.IO;

namespace Assignment_1
{
    public class PathWalker
    {
        public static void StartWalking(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    // This path is a file
                    FileProcessor.CSVParser(path);
                }
                else if (Directory.Exists(path))
                {
                    // This path is a directory
                    DirectoryProcessor.DirectoryWalker(path);
                }
                else
                {
                    Console.WriteLine("{0} is not a valid file or directory.", path);
                }
            }
            catch (DriveNotFoundException)
            {
                Console.WriteLine("The drive specified in 'path' is invalid.");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("'path' exceeds the maxium supported path length.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("You do not have permission to create this file.");
            }
            catch (IOException e) when ((e.HResult & 0x0000FFFF) == 32)
            {
                Console.WriteLine("There is a sharing violation.");
            }
            catch (IOException e) when ((e.HResult & 0x0000FFFF) == 80)
            {
                Console.WriteLine("The file already exists.");
            }
            catch (IOException e)
            {
                Console.WriteLine($"An exception occurred:\nError code: " +
                                  $"{e.HResult & 0x0000FFFF}\nMessage: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unhandled Exceptin : [{e}]");
            }
        }
    }
}
