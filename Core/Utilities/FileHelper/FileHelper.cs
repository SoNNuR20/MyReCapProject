using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.FileHelper
{
	public partial class FileHelper
    {
        private static string _currentDirectory = Environment.CurrentDirectory + "\\wwwroot";
        private static string _folderName = "\\Images\\";

        public static IDataResult<string> Upload(IFormFile file)
        {

            var fileExists = CheckFileExists(file);
            if (fileExists.Message != null)
            {
                return new ErrorDataResult<string>(fileExists.Message);
            }
            var randomName = Guid.NewGuid().ToString();
            var type = Path.GetExtension(file.FileName).ToLower();

            var typeValidCheck = CheckFileTypeValid(type);
            if (typeValidCheck.Message != null)
            {
                return new ErrorDataResult<string>(typeValidCheck.Message);
            }

            CheckDirectoryExists(_currentDirectory + _folderName);
            CreateImageFile(file, _currentDirectory + _folderName + randomName + type);
            return new SuccessDataResult<string>(data: (_folderName + randomName + type).Replace("\\", "/"));
        }

        public static IDataResult<string> Update(IFormFile file, string imagePath)
        {
            var fileExists = CheckFileExists(file);
            if (fileExists.Message != null)
            {
                return new ErrorDataResult<string>(fileExists.Message);
            }
            var randomName = Guid.NewGuid().ToString();
            var type = Path.GetExtension(file.FileName).ToLower();

            var typeValidCheck = CheckFileTypeValid(type);
            if (typeValidCheck.Message != null)
            {
                return new ErrorDataResult<string>(typeValidCheck.Message);
            }
            CheckDirectoryExists(_currentDirectory + _folderName);
            DeleteOldImageFile((_currentDirectory + imagePath).Replace("/", "\\"));
            CreateImageFile(file, _currentDirectory + _folderName + randomName + type);
            return new SuccessDataResult<string>(data: (_folderName + randomName + type).Replace("\\", "/"));
        }

        public static IDataResult<string> Delete(string path)
        {
            DeleteOldImageFile((_currentDirectory + path).Replace("/", "\\"));
            return new SuccessDataResult<string>();
        }

        private static void DeleteOldImageFile(string path)
        {
            if (File.Exists(path.Replace("/", "\\")))
            {
                File.Delete(path.Replace("/", "\\"));
            }
        }

        private static void CreateImageFile(IFormFile file, string directory)
        {
            using (FileStream fs = File.Create(directory))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
        }

        private static void CheckDirectoryExists(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        private static IDataResult<string> CheckFileTypeValid(string type)
        {
            if (type != ".jpeg" && type != ".png" && type != ".jpg")
            {
                return new ErrorDataResult<string>("Wrong file type.");
            }

            return new SuccessDataResult<string>();
        }

        private static IDataResult<string> CheckFileExists(IFormFile file)
        {
            if (file != null)
            {
                return new SuccessDataResult<string>();
            }
            return new ErrorDataResult<string>("File doesn't exists.");

        }
    }
}
