namespace ColdStorageTemperature_Console_JUL2026;

class Program
{

    
    static void Main(string[] args)
    {

        
        

        Console.WriteLine("Hello, World!");
        ReadTemperatureFile();
        
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
        string strColdStorageFilePathAndName = "C:\\Weather\\MONTH 2026-02-FEB.csv";

        

        using (StreamReader swSourceFile = File.OpenText(strColdStorageFilePathAndName))
        using (StreamWriter swDestinationFile = new StreamWriter("C:\\Weather\\NEW_VS2.txt", true))
        {
            string strHeadingLine ="";
            string strLine = "";
            int intCount = 0;

            strHeadingLine = swSourceFile.ReadLine();  // Read first line of file which the headings
            //string[] strHeadings = strHeadingLine.Split(','); 
            
            //swDestinationFile.WriteLine(strHeadingLine);


            string strHeadings;

            Console.WriteLine("Heading" + strHeadingLine);

            while ((strLine = swSourceFile.ReadLine()) != null)
            {
                
                //string[] strData = strLine.Split(',');

                 intRecordCount++;

                Console.WriteLine(strLine);
                
                if (intRecordCount == 1) 
                {
                    swDestinationFile.WriteLine(strHeadingLine);
                }
                else
                {
                    swDestinationFile.WriteLine(strLine);
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

}
