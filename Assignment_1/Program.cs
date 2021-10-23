using System.Configuration;
using System.IO;

namespace Assignment_1
{
    public class RecursiveCSVProcessor
    {
        public static int NoOfFiles = 0;
        public static int GoodRecords = 0;
        public static int BadRecords = 0;
        public static void Main(string[] args)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            using (StreamWriter writer = new StreamWriter(ConfigurationManager.AppSettings["outputpath"], append: true))
            {
                writer.WriteLine("First Name,Last Name,Street Number,Street,City,Province,Postal Code,Country,Phone Number,email Address,Date");
            }
            foreach (string path in args)
            {
                PathWalker.StartWalking(path);
            }
            watch.Stop();

            Logger.WriteLog("");
            Logger.WriteLog("");
            Logger.WriteLog($"Total number of Files Processed: {NoOfFiles}.", "Info");
            Logger.WriteLog($"Total number of valid rows: {GoodRecords}.", "Info");
            Logger.WriteLog($"Total number of skipped rows: {BadRecords}.", "Info");
            Logger.WriteLog($"Total execution time: {watch.ElapsedMilliseconds} ms.", "Info");
        }
    }
}
