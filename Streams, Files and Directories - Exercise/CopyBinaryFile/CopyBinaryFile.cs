namespace CopyBinaryFile
{
    using System;
    using System.IO;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
           using (FileStream source = 
                new FileStream(inputFilePath, FileMode.Open, FileAccess.Read))
            {
                using (FileStream destination = 
                    new FileStream(outputFilePath, FileMode.Create, FileAccess.Write))
                {
                    source.CopyTo(destination);
                }
            }
        }
    }
}
