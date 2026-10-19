namespace ColdStorageTemperature_Console_JUL2026;

class Program
{

    
    static void Main(string[] args)
    {

         ReadTemperatureFile();
        //ReadDocumentsFolder();
        
        // Dispose of the StreamWriter to release resources
        //swDestinationFile.Dispose();

        //TempStuff();
    }

    static void TempStuff()
    {
        Console.WriteLine($"Base Directory: {AppDomain.CurrentDomain.BaseDirectory}");
        Console.WriteLine($"Curent Directory: {Environment.CurrentDirectory}");
    }
    //static void ReadTemperatureFile()
    static void ReadTemperatureFile()
    {
        int intRecordCount =0;

        
        string baseDir = AppDomain.CurrentDomain.BaseDirectory;
        Console.WriteLine(baseDir);
        
        //string strFilePath = Path.Combine(baseDir, "NEW_ZeroHistory_2KLPG007_2026.txt");
        
                string strDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        
        //string strColdStorageFilePathAndName = "C:\\Weather\\MONTH 2026-02-FEB.csv";
        
               string strColdStorageFilePathAndName = strDocumentsPath + "\\MONTH 2026-02-FEB.csv";       
        Console.WriteLine($"\nStart of processing\n\nSource file name: {strColdStorageFilePathAndName}");
        //Console.ReadLine();

                if (!File.Exists(strColdStorageFilePathAndName))
                {
                    Console.WriteLine($"File not found: {strColdStorageFilePathAndName}");
                }

 
        

        using (StreamReader swSourceFile = File.OpenText(strColdStorageFilePathAndName))
        //using (StreamWriter swDestinationFile = new StreamWriter("C:\\Weather\\NEW_VS2.txt", true))
        {
            string strHeadingLine ="";
            string strLine = "";
            int intCount = 0;

            strHeadingLine = swSourceFile.ReadLine();  // Read first line of file which the headings
            //string[] strHeadings = strHeadingLine.Split(','); 
            
            //swDestinationFile.WriteLine(strHeadingLine);


            string strHeadings;

            Console.WriteLine($"\nHeading: {strHeadingLine}");

            while ((strLine = swSourceFile.ReadLine()) != null)
            {
                string[] fields = strLine.Split(',');
                int intTotalFieldsLength = fields.Length;
                intCount++;
                int intFieldCount = 0;
                
                Console.WriteLine($"\nRecord: {intCount} - {strLine}\n");

                foreach (string field in fields)
                {
                    intFieldCount++;
                    Console.WriteLine($"# {intFieldCount} Field: {field}");
                }

                WriteDatatoMonthFile(strLine);

                Console.WriteLine("\n End of record - Press ENTER to continue...");
                Console.ReadLine();

                 intRecordCount++;

                //Console.WriteLine($"{intFieldCount} {strLine}");

                
                
                if (intRecordCount == 1) 
                {
                    Console.WriteLine(strHeadingLine);
                    /* 2026-09-29 disabled write to new file
                    swDestinationFile.WriteLine(strHeadingLine);
                    */
                }
                else
                {
                    Console.WriteLine(strLine);
                    //Environment.Exit(0);
                    /* 2026-09-29 disabled write to new file
                    swDestinationFile.WriteLine(strLine);
                    */
                }
                
                
                //swDestinationFile.WriteLine(strLine);

                //WriteDestinationFile(strLine,strHeadingLine);
                

                
            }
            
            //swDestinationFile.Close();

        }
    }


    public void WriteDestinationFile(string strLine, string strHeadings)
    {

            
        //swDestinationFile.WriteLine(strLine);
        // Implementation for writing to destination file
    }

    
    static void WriteDatatoMonthFile(string strEntireRecord)
    {
        // Implementation for writing data to month file

        
        int intSlashCount = 0; // count the number of slashes in the DateTime string
        string strMonth = ""; // save Month digit(s) from DateTime string
        string strYear = ""; // save 4 digit Year from DateTime string
        int intMonth = 0;
        //string strFullFlleName = "";

        string[] fields = strEntireRecord.Split(',');


        string strDateTime=fields[0];
        string strTemperature=fields[1];
        string strAlarm=fields[2];
        string strComment="";


        // From strDateTime mm/dd/yyyy or (m/d/yyyy)
        // Parse  4 digit year 
        // and Month number 1-12 
        for (int i = 0; i < strDateTime.Length; i++)
        {
                        
            if (intSlashCount == 2)
            {
                strYear = strDateTime.Substring(i, 4);
                intMonth = int.Parse(strMonth);
                break;
            }

            if(intSlashCount== 1)
            {
                if (strDateTime.Substring(i,1) == "/")
                {
                    intSlashCount++;
                }
            }

            if (intSlashCount == 0)
            {
                if (strDateTime.Substring(i,1) == "/") 
                {
                    intSlashCount++;
                }
                else
                {
                    strMonth = strMonth + strDateTime.Substring(i,1);
                }
            }
        }

        string[] strMonthNames = ["JAN", "FEB","MAR","APR","MAY","JUN","JUL","AUG","SEP","OCT","NOV","DEC"];

        string strFullFlleName = $"C:\\Weather\\XNEW MONTH {strYear}-{intMonth:D2}-{strMonthNames[intMonth - 1]}.txt";
        string strLinetoWrite;

        if (File.Exists(strFullFlleName))
        {
            Console.WriteLine("File Exists - Write data");
            strLinetoWrite = "Hello, weather data written";
        }
        else
        {
            Console.WriteLine("FILE DOES NOT EXIST = Write first heading line");
            strLinetoWrite = "Time,Chan 1 - Deg F,Alm 1";
        }

        using (StreamWriter filewrite = new StreamWriter(strFullFlleName, true))
        {
             filewrite.WriteLine(strLinetoWrite);
        }


       // If Dir(strFullFlleName) = "" Then  ' Write headings to first line
/*
            Open strFullFlleName For Append As #2
            Print #2, strHeadingLine
            Close #2
        End If
*/
    }


    static void ReadDocumentsFolder()
    {
        // 1. Get the path to the Documents folder
        string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        Console.WriteLine($"Documents Path: {documentsPath}");

        // 2. Safely create a path to a specific file or folder inside Documents
        string filePath = Path.Combine(documentsPath, "MyFolder", "example.txt");
        Console.WriteLine($"Full File Path: {filePath}");
        Console.WriteLine("\nPress ENTER to exit...");

        Console.ReadLine();
    }

}
