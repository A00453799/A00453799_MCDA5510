using System.IO;

namespace Assignment_1
{
    public class DirectoryProcessor
    {
        public static void DirectoryWalker(string targetDirectory)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                FileProcessor.CSVParser(fileName);

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                DirectoryWalker(subdirectory);
        }
    }
}
