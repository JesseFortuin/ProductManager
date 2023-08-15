using System.Buffers.Text;
using System.Security.Cryptography;
using System;

namespace ACMEData.Application
{
    public class FileService : IFileService
    {
        public string GetImageObject(string imagePath)
        {
            byte[] imageData = File.ReadAllBytes(imagePath);

            string stringObject = Convert.ToBase64String(imageData);

            return stringObject;
        }
    }
}
