using System;
using System.IO;
using System.Linq;

namespace KopierJochen
{
    class Program
    {
        static void Main(string[] args)
        {
            const string referenceDirectory = @"***";
            const string notCompleteDirectory = @"***";
            const string alternateDirectory = @"***";

            var referenceFiles = Directory.EnumerateFiles(referenceDirectory, "*.*").ToDictionary(key => key.Split('\\').Last(), value => value);
            var notCompleteFiles = Directory.EnumerateFiles(notCompleteDirectory, "*.*").ToDictionary(key => key.Split('\\').Last(), value => value);

            foreach (var aFile in referenceFiles.Where(_ => !notCompleteFiles.ContainsKey(_.Key)))
            {
                Console.WriteLine(aFile.Key);
                File.Copy(aFile.Value, alternateDirectory + Path.DirectorySeparatorChar + aFile.Key);
            }
            Console.WriteLine("done");
            Console.ReadLine();
        }
    }
}
