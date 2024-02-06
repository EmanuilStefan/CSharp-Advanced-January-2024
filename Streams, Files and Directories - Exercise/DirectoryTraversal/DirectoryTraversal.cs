namespace DirectoryTraversal;

using System;
using System.IO;
using System.Linq;
using System.Text;

public class DirectoryTraversal
{
    static void Main()
    {
        string path = Console.ReadLine();
        string reportFileName = @"\report.txt";

        string reportContent = TraverseDirectory(path);
        Console.WriteLine(reportContent);

        WriteReportToDesktop(reportContent, reportFileName);
    }

    public static string TraverseDirectory(string inputFolderPath)
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(inputFolderPath);

        // Get all files in the directory (first level only)
        FileInfo[] files = directoryInfo.GetFiles("*.*", SearchOption.TopDirectoryOnly);

        // Group files by extension, order by count and then by name alphabetically
        var groupedFiles = files
            .GroupBy(file => file.Extension.ToLower())
            .OrderByDescending(group => group.Count())
            .ThenBy(group => group.Key);

        StringBuilder reportContent = new StringBuilder();

        foreach (var group in groupedFiles)
        {
            reportContent.AppendLine($"{group.Key}");

            // Order files under each extension by size
            var orderedFiles = group.OrderBy(file => file.Length);

            foreach (var file in orderedFiles)
            {
                reportContent.AppendLine($"--{file.Name} - {file.Length / 1024.0:f3}kb");
            }
        }

        return reportContent.ToString();
    }

    public static void WriteReportToDesktop(string textContent, string reportFileName)
    {
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string reportFilePath = desktopPath + reportFileName;

        File.WriteAllText(reportFilePath, textContent);

        Console.WriteLine($"Report saved on the desktop: {reportFilePath}");
    }
}
