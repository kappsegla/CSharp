using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;


namespace ConsoleApp.Files
{
    public class FileHandling
    {
        public void Run()
        {
            //Get Users Home Directory
            var path = GetUserHomePath();
            
            var programPath = Path.Combine(path, ".DemoApp2020");

            //Check if folder exists
            if (!Directory.Exists(programPath))
            {
                //CreateDirectory creates all directories in path if they doesn't exist so can be run without checking first.
                Directory.CreateDirectory(programPath);
            }
            
            var filePath = Path.Combine(programPath, "File.txt");
            
            Console.WriteLine(filePath);

            //ReadTextFileAndPrintToConsole(filePath);
            
            //AppendLineToTextFile(filePath, Environment.NewLine + "Some new text...");
            
            //ReadTextFileUsingFileStream(filePath);
            
            //var filePathBinary = Path.Combine(programPath, "File.dat");
            
            //WriteBinaryValueToFile(filePathBinary, 1234);
            //
            
            //DownloadAndPrintFileFromGitHub();
            
            //
            // var icoPath = Path.Combine(programPath, "image.bmp");
            //
            // LoadIcoFileAndPrintAsHex(icoPath);
            //
             var csvPath = Path.Combine(programPath, "data.csv");
             //LoadPersonsFromCSV(csvPath);

             LoadCSVFile(csvPath);
        }

        private void LoadPersonsFromCSV(string csvPath)
        {
            //File.AppendAllText(csvPath, "Kalle,10,Stockholm");
            
            // var persons = File.ReadLines(csvPath).Skip(1)
            //     .Select(s => s.Split(","))
            //     .Select(sa => new Person() {Name = sa[0], Age = Int32.Parse(sa[1]), City = sa[2]})
            //     .ToList();
            //
            // foreach (var person in persons)
            // {
            //     Console.WriteLine(person);
            // }

        }

        public static string GetUserHomePath()
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
            File.AppendAllText(filePath, text);
        }


        private void ReadTextFileUsingFileStream(string filePath)
        {
            //http://zetcode.com/csharp/filestream/

            //var fileName = @"C:\Users\UserName\Documents\words.txt";

            //https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-statement

            using FileStream fs = File.OpenRead(filePath);
            using StreamReader sr = new StreamReader(fs); //Can also use , to declare multiple variables with one using.
            
            string line;
                
            while ((line = sr.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }

        private async void DownloadAndPrintFileFromGitHub()
        {
            using var httpClient = new HttpClient();
            var url = "https://raw.githubusercontent.com/kappsegla/CSharp/master/ConsoleApp/Files/Data.txt";
            var gitFile = httpClient.GetStringAsync(url).Result;
            Console.WriteLine(gitFile);
        }

        //Binary file
        private void WriteBinaryValueToFile(string filePath, int value)
        {
            using BinaryWriter binWriter =
                new BinaryWriter(File.Open(filePath, FileMode.Create));

            // Write int   
            binWriter.Write(1234);
            binWriter.Write(0);
            binWriter.Write(true);
        }

        //Load binary file
        private void LoadIcoFileAndPrintAsHex(string fileName)
        {
            using var fs = new FileStream(fileName, FileMode.Open);

            int c;
            int i = 0;
            
            //Ignore headers and image info for now
            //Could use Seek to move
            //https://itnext.io/bits-to-bitmaps-a-simple-walkthrough-of-bmp-image-format-765dc6857393
            for (int j = 0; j < 54; j++)
                fs.ReadByte();

            //Prints each pixel row where each pixel has 3 bytes- 24 bits 16*16 pixels.
            while ((c = fs.ReadByte()) != -1)
            {
                Console.Write("{0:X2} ", c);
                i++;

                if (i % (16) == 0)
                    Console.WriteLine();
                fs.ReadByte();
                fs.ReadByte();
            }
        }

        private void LoadCSVFile(string csvFilePath)
        {
            var regex = new Regex("(?<=^|,)(\"(?:[^\"]|\"\")*\"|[^,]*)",
                RegexOptions.Singleline | RegexOptions.Compiled);

            var stuff = File.ReadLines(csvFilePath)
                .Skip(1) // For header
                .Select(s => regex.Matches(s))
                .Select(data => new
                {
                    Foo = data[0].Value,
                    Bar = data[1].Value,
                    Baz = data[2].Value
                });

            foreach (var f in stuff)
            {
                Console.WriteLine(f.Foo);
                Console.WriteLine(f.Bar);
                Console.WriteLine(f.Baz);
            }
        }
    }
}