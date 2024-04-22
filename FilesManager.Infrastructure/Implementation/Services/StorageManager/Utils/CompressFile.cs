using FilesManager.Domain.Enum.CompressionFormat;
using SharpCompress.Archives;
using SharpCompress.Common;
using SharpCompress.Writers;

namespace FilesManager.Infrastructure.Implementation.Services.StorageManager.Utils;
public static class CompressFile
{
    public static bool CompressFileHandler(Compression_Format_Enum compressionFormat, string sourceFilePath, string destinationFilePath, string password)
    {
        try
        {
            //conversion
            System.Text.Encoding encodedPassword = System.Text.Encoding.GetEncoding(password);

            // create
            using IWritableArchive archive = ArchiveFactory.Create((ArchiveType)compressionFormat);
            archive.AddAllFromDirectory(sourceFilePath, searchOption: SearchOption.AllDirectories);
            archive.AddAllFromDirectory(sourceFilePath, searchOption: SearchOption.AllDirectories);

            // compress
            WriterOptions options = new((CompressionType)compressionFormat) { ArchiveEncoding = new ArchiveEncoding { Password = encodedPassword } };
            using FileStream stream = File.OpenWrite(destinationFilePath);
            archive.SaveTo(stream, options);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine($"file Compressing Error => {e}");
            return false;
        }
    }
}
