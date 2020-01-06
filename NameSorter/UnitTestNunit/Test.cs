using NUnit.Framework;
using System;
using System.Collections.Generic;
using NameSorter;

namespace UnitTestNunit
{
    [TestFixture()]
    public class Test
    {
        List<string> testList = new List<string>();
        [Test()]
        public void ReadTest()
        {
            ReadWriteFile read = new ReadWriteFile();
            testList = read.ReadFileToList("unsorted.txt");
        }

        [Test()]
        public void WriteTest()
        {
            ReadWriteFile write = new ReadWriteFile();
            write.WriteListToFile("write.txt", testList);
        }

        [Test()]
        public void PrintTest()
        {
            PrintList p = new PrintList();
            p.Print(testList);
        }

        [Test()]
        public void Reverse()
        {
            ReverseWords rev = new ReverseWords();
            string[] s = "This is unit testing".Split(' ');
            string reversedStr = rev.ReverseWordInString(s);
            Assert.AreEqual("testing This is unit", reversedStr);
        }

        [Test()]
        public void SorterTest()
        {
            Sorter n = new Sorter("unittest.txt");
            n.SetResultFileName("unittestsorted.txt");
            n.SortName();

            ReadWriteFile read = new ReadWriteFile();
            List<string> correct = read.ReadFileToList("sortedtest.txt");
            List<string> test = read.ReadFileToList("unittestsorted.txt");
            Assert.AreEqual(correct, test);
        }
    }
}