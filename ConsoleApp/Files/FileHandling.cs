using System;
using System.IO;


namespace ConsoleApp.Files
{
    public class FileHandling
    {
        public void Run()
        {
            //Get Users Home Directory
            var path = GetUserHomePath();

            var programPath = Path.Combine(path, "DemoApp");
            
            //Check if folder exists
            if (!Directory.Exists(programPath))
            {
                //CreateDirectory creates all directories in path if they doesn't exist so can be run without checking first.
                Directory.CreateDirectory(programPath);
            }

            var filePath = Path.Combine(programPath, "File.txt");
            
            Console.WriteLine(filePath);
            
            ReadTextFileAndPrintToConsole(filePath);
            
            AppendLineToTextFile(filePath,Environment.NewLine + "Some new text...");

            ReadTextFileUsingFileStream(filePath);

            
            //Binary file

        }

        public string GetUserHomePath()
        {
            return
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile,
                    Environment.SpecialFolderOption.DoNotVerify);
        }


        public void ReadTextFileAndPrintToConsole(string filePath)
        {
            if (File.Exists(filePath))
            {
                var lines = File.ReadLines(filePath);
                foreach (var line in lines)
                {
                    Console.WriteLine(line);
                }
            }
        }

        public void AppendLineToTextFile(string filePath, string text)
        {
            File.AppendAllText(filePath,text);
        }
        
        
        private void ReadTextFileUsingFileStream(string filePath)
        {
            //http://zetcode.com/csharp/filestream/
            
            //var fileName = @"C:\Users\UserName\Documents\words.txt";

            
            //https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-statement
            
            using FileStream fs = File.OpenRead(filePath);
            using StreamReader sr = new StreamReader(fs);

            string line;

            while ((line = sr.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }
}