namespace ZipAndExtract;


using System;
using System.IO;
using System.IO.Compression;

public class ZipAndExtract
{
    static void Main()
    {
        string inputFile = @"..\..\..\copyMe.png";
        string zipArchiveFile = @"..\..\..\archive.zip";
        string extractedFile = @"..\..\..\extracted.png";

        ZipFileToArchive(inputFile, zipArchiveFile);

        var fileNameOnly = Path.GetFileName(inputFile);
        ExtractFileFromArchive(zipArchiveFile, fileNameOnly, extractedFile);
    }

    public static void ZipFileToArchive(string inputFilePath, string zipArchiveFilePath)
    {
        try
        {
            using (FileStream originalFileStream
                = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read))
            {
                using (FileStream compressedFileStream = File.Create(zipArchiveFilePath))
                {
                    using (GZipStream zippedStream
                        = new GZipStream(compressedFileStream, CompressionMode.Compress))
                    {
                        originalFileStream.CopyTo(zippedStream);
                    }
                }
            }
            Console.WriteLine($"File Compressed successfully in {zipArchiveFilePath}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error compressing file: {ex.Message}");
        }
    }
    public static void ExtractFileFromArchive(string zipArchiveFilePath, string fileName, string outputFilePath)
    {
        try
        {
            using (FileStream compressedFile = new FileStream(zipArchiveFilePath, FileMode.Open, FileAccess.Read))
            {
                using (GZipStream decompressedFile = new GZipStream(compressedFile, CompressionMode.Decompress))
                {
                    using (FileStream decompressedFileStream = File.Create(outputFilePath))
                    {
                        decompressedFile.CopyTo(decompressedFileStream);
                    }
                }
            }

            Console.WriteLine($"File extracted successfully to {outputFilePath}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error extracting file: {ex.Message}");
        }
    }

}