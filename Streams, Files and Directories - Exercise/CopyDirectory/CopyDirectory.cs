using System;
using System.IO;

namespace CopyDirectory;
public class CopyDirectory
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Enter input directory path:");
            string inputPath = Console.ReadLine();

            Console.WriteLine("Enter output directory path:");
            string outputPath = Console.ReadLine();

            CopyAllFiles(inputPath, outputPath);
            Console.WriteLine("Directory copied successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public static void CopyAllFiles(string inputPath, string outputPath)
    {
        if (inputPath == outputPath)
        {
            Console.WriteLine("Input and output directories cannot be the same.");
            return;
        }

        if (!Directory.Exists(inputPath))
        {
            throw new DirectoryNotFoundException($"Input directory not found: {inputPath}");
        }

        if (!Directory.Exists(outputPath))
        {
            Directory.CreateDirectory(outputPath);
        }

        string[] files = Directory.GetFiles(inputPath);
        foreach (string file in files)
        {
            try
            {
                string destFile = Path.Combine(outputPath, Path.GetFileName(file));
                File.Copy(file, destFile, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error copying file '{file}': {ex.Message}");
            }
        }

        string[] subdirectories = Directory.GetDirectories(inputPath);
        foreach (string subdir in subdirectories)
        {
            try
            {
                string destSubDir = Path.Combine(outputPath, Path.GetFileName(subdir));

                if (!Directory.Exists(destSubDir))
                {
                    Directory.CreateDirectory(destSubDir);
                }

                CopyAllFiles(subdir, destSubDir);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error copying subdirectory '{subdir}': {ex.Message}");
            }
        }
    }
}
