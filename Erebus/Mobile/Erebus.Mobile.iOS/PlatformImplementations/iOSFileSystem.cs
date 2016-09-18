﻿using Erebus.Core;
using Erebus.Core.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Erebus.Mobile.iOS.PlatformImplementations
{
    public class iOSFileSystem : IFileSystem
    {
        private string ConvertPathRootToPersonal(string path)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(documentsPath, path);
        }

        public bool FileExists(string path)
        {
            GuardClauses.ArgumentIsNotNull(nameof(path), path);

            path = ConvertPathRootToPersonal(path);
            return File.Exists(path);
        }

        public bool DirectoryExists(string path)
        {
            GuardClauses.ArgumentIsNotNull(nameof(path), path);

            path = ConvertPathRootToPersonal(path);
            return Directory.Exists(path);
        }

        public byte[] ReadAllBytes(string path)
        {
            GuardClauses.ArgumentIsNotNull(nameof(path), path);

            path = ConvertPathRootToPersonal(path);
            return File.ReadAllBytes(path);
        }

        public void WriteAllBytes(string path, byte[] data)
        {
            GuardClauses.ArgumentIsNotNull(nameof(path), path);
            GuardClauses.ArgumentIsNotNull(nameof(data), data);

            path = ConvertPathRootToPersonal(path);
            File.WriteAllBytes(path, data);
        }

        public IEnumerable<string> GetDirectoryFiles(string path, string searchPattern)
        {
            GuardClauses.ArgumentIsNotNull(nameof(path), path);
            GuardClauses.ArgumentIsNotNull(nameof(searchPattern), searchPattern);

            path = ConvertPathRootToPersonal(path);
            return Directory.GetFiles(path, searchPattern).Select(filePath => Path.GetFileName(filePath));
        }

        public void CreateDirectory(string path)
        {
            GuardClauses.ArgumentIsNotNull(nameof(path), path);

            path = ConvertPathRootToPersonal(path);
            Directory.CreateDirectory(path);
        }

        public void DeleteFile(string path)
        {
            GuardClauses.ArgumentIsNotNull(nameof(path), path);

            path = ConvertPathRootToPersonal(path);
            File.Delete(path);
        }

        public void MoveFile(string sourcePath, string destinationPath)
        {
            GuardClauses.ArgumentIsNotNull(nameof(sourcePath), sourcePath);
            GuardClauses.ArgumentIsNotNull(nameof(destinationPath), destinationPath);


            sourcePath = ConvertPathRootToPersonal(sourcePath);
            destinationPath = ConvertPathRootToPersonal(destinationPath);

            File.Move(sourcePath, destinationPath);
        }
    }

}
