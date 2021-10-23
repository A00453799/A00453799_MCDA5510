using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace Assignment_1
{
    public class FileProcessor
    {
        public static void CSVParser(string path)
        {
            RecursiveCSVProcessor.NoOfFiles++;
            var rowCount = 0;
            var hasExceptionOccured = false;
            var dateValue = GetDateValue(path);

            using (var streamReader = new StreamReader(@path))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    using (StreamWriter writer = new StreamWriter(ConfigurationManager.AppSettings["outputpath"], append: true))
                    {
                        csvReader.Context.RegisterClassMap<CustomerInfoClassMap>();

                        while (csvReader.Read())
                        {
                            try
                            {
                                rowCount++;
                                var record = csvReader.GetRecord<CustomerInfo>();
                                RecursiveCSVProcessor.GoodRecords++;

                                writer.WriteLine($"\"{record.FirstName}\",\"{record.LastName}\",\"{record.StreetNumber}\",\"{record.Street}\",\"{record.City}\",\"{record.Province}\",\"{record.PostalCode}\",\"{record.Country}\",\"{record.PhoneNumber}\",\"{record.EmailAddress}\",\"{dateValue}\"");
                            }
                            catch (FieldValidationException ex)
                            {
                                hasExceptionOccured = true;
                                RecursiveCSVProcessor.BadRecords++;
                                Logger.WriteLog($"[Line Number - {rowCount}] : " +
                                                $"[Field - {ex.Context.Reader.HeaderRecord[ex.Context.Reader.CurrentIndex]}] : " +
                                                $"[File - {path}] : " +
                                                $"[Error Message - {ex.Message}]'", "Exception");
                            }
                            catch (CsvHelper.MissingFieldException ex)
                            {
                                hasExceptionOccured = true;
                                RecursiveCSVProcessor.BadRecords++;
                                Logger.WriteLog($"[Line Number - {rowCount}] : " +
                                                $"[Field - {ex.Context.Reader.HeaderRecord[ex.Context.Reader.CurrentIndex]}] : " +
                                                $"[File - {path}] : " +
                                                $"[Error Message - {ex.Message}]'", "Exception");
                            }
                            catch (CsvHelper.TypeConversion.TypeConverterException ex)
                            {
                                hasExceptionOccured = true;
                                RecursiveCSVProcessor.BadRecords++;
                                Logger.WriteLog($"[Line Number - {rowCount}] : " +
                                                $"[Field - {ex.Context.Reader.HeaderRecord[ex.Context.Reader.CurrentIndex]}] : " +
                                                $"[File - {path}] : " +
                                                $"[Error Message - {ex.Message}]'", "Exception");
                            }
                            catch (Exception ex)
                            {
                                hasExceptionOccured = true;
                                RecursiveCSVProcessor.BadRecords++;
                                Logger.WriteLog($"Unhandled Exceptin : [{ex}] at Line Number: {rowCount} in {path}'.", "Exception");
                            }
                        }
                        if (hasExceptionOccured == false)
                        {
                            Logger.WriteLog($"Processed the file '{path}' without exceptions.");
                        }
                    }
                }
            }
        }

        public static string GetDateValue(string path)
        {
            string basePath = Path.GetDirectoryName(path);
            string[] basePathList = basePath.Split(Path.DirectorySeparatorChar);
            int length = basePathList.Count();
            return $"{basePathList[length - 3]}/{basePathList[length - 2]}/{basePathList[length - 1]}";
        }
    }
}
