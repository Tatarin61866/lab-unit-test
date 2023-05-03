using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnitTestEx;
using Assert = NUnit.Framework.Assert;

namespace UnitTestProject
{
    /// <summary>
    /// Summary description for FileStorageTest
    /// </summary>
    [TestClass] // исправил test на TesrMethod
    public class FileTest
    {

        public const string SIZE_EXCEPTION = "Wrong size";
        public const string NAME_EXCEPTION = "Wrong name";
        public const string SPACE_STRING = " ";
        public const string FILE_PATH_STRING = "@D:\\JDK-intellij-downloader-info.txt";
        public const string CONTENT_STRING = "Some text";
        public double lenght;

        /* ПРОВАЙДЕР */
        // сформировал лист из объекта
        static IEnumerable<object[]> FilesData => new List<object[]>
        {
            new object[] {new File(FILE_PATH_STRING, CONTENT_STRING), FILE_PATH_STRING, CONTENT_STRING},
            new object[] { new File(SPACE_STRING, SPACE_STRING), SPACE_STRING, SPACE_STRING}
        };

        /* Тестируем получение размера */
        [TestMethod, DynamicData(nameof(FilesData))] // поменял тип парамаетров с TestCaseSource на DynamicData
        public void GetSizeTest(File newFile, String name, String content)
        {
            lenght = content.Length / 2;
            Assert.AreEqual(newFile.GetSize(), lenght, SIZE_EXCEPTION);
        }

        /* Тестируем получение имени */ 
        [TestMethod, DynamicData(nameof(FilesData))] // поменял тип парамаетров с TestCaseSource на DynamicData
        public void GetFilenameTest(File newFile, String name, String content)
        {
            Assert.AreEqual(newFile.GetFilename(), name, NAME_EXCEPTION);
        }

    }
}
