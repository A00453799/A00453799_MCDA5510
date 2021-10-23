# MCDA5510 Assignment 1

## About The Assignment:

* This Code parses CSV files inside the directories and sub-directories of the given path by traversing through them.
* It requires an Input path as a runtime argument. The Input must be an absolute path.
* Add value for `<Logs Directory Path>` and `<Output Directory Path>` in [Assignment_1/App.config](https://github.com/A00453799/A00453799_MCDA5510/blob/main/Assignment_1/App.config) file.
* This code uses [CsvHelper](https://joshclose.github.io/CsvHelper/) library to parse CSV files and validate data.
* The Program writes Valid records to [Output/outpt.csv](https://github.com/A00453799/A00453799_MCDA5510/tree/main/Assignment_1/Output) file.
* The Program derives `Date` from the folder structure and writes it to the [Output/outpt.csv](https://github.com/A00453799/A00453799_MCDA5510/tree/main/Assignment_1/Output) file as the last Data Field.
* The Program logs the following things to [logs/log.txt](https://github.com/A00453799/A00453799_MCDA5510/tree/main/Assignment_1/logs) file.

	1. Exceptions
	2. Total execution time
	3. Total number of valid rows
	4. Total number of skipped rows
	5. Total number of Files Processed
